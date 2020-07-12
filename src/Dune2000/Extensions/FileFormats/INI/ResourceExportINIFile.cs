using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Pal;
using Dune2000.Structs.R16;
using Dune2000.Util;
using Dune2000.Util.Palette;
using Primrose.FileFormat.INI;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using Primrose.Primitives.ValueTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Dune2000.Extensions.FileFormats.INI
{
  public class ResourceExportINIFile : INIFile
  {
    // Internal file format for importing and exporting resources
    [INIValue(Section = "General", Required = true)]
    public int EntryCount;

    [INISubSectionRegistry(Section = "Entries", SubsectionPrefix = "Entry_", Required = true)]
    public Registry<string, ResourceExportEntry> Entries = new Registry<string, ResourceExportEntry>();

    public void Export(ref IPalette basePalette, List<ResourceElement> elementList, string rootDir, string imagePathFormat, string palettePathFormat, IProgress<int> progress = null)
    {
      ResourceElement[] safeList = elementList.ToArray();
      for (int i = 0; i < safeList.Length; i++)
      {
        Export(ref basePalette, i, safeList[i], rootDir, imagePathFormat.F(i), palettePathFormat.F(i), progress);
      }
    }

    public void Export(ref IPalette basePalette, int key, ResourceElement element, string rootDir, string imagePath, string palettePath, IProgress<int> progress = null)
    {
      if (element.PaletteType == PaletteType.EMPTY_ENTRY) { return; }

      ResourceExportEntry expentry = new ResourceExportEntry();

      expentry.FrameSize = element.FrameSize;
      expentry.ImageOffset = element.ImageOffset;
      expentry.Alignment = element.Alignment;
      expentry.ImageHandle = element.ImageHandle;
      expentry.PaletteHandle = element.PaletteHandle;
      expentry.UsePalette = element.BitsPerPixel == 8;
      if (expentry.UsePalette)
      {
        expentry.UseOwnPalette = element.PaletteHandle != 0;
      }
      else
      {
        expentry.UseOwnPalette = null;
      }

      HousePaletteFile dummy = new HousePaletteFile();
      // modify palette to remove unique colors.
      IPalette opal = element.Palette;
      IPalette modpal = new Palette_15Bit();
      element.Palette.CopyTo(ref modpal);
      PaletteUtil.MakeSpecialIndicesUnique(ref modpal, out _);
      element.Palette = (Palette_15Bit)modpal;


      Bitmap image = element.GetBitmap(ref basePalette, ref dummy, false, false, -1);

      if (!Path.IsPathRooted(imagePath)) { imagePath = Path.Combine(rootDir, imagePath); }
      Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
      image.Save(imagePath);
      expentry.ImagePath = WinAPI.GetRelativePath(rootDir + @"\", imagePath);

      if (expentry.UseOwnPalette ?? false)
      {
        PaletteFile palfile = new PaletteFile();
        IPalette pal = palfile.Palette;
        element.Palette.CopyTo(ref pal);
        palfile.Palette = (Palette_18Bit)pal;
        if (!Path.IsPathRooted(palettePath)) { palettePath = Path.Combine(rootDir, palettePath); }
        Directory.CreateDirectory(Path.GetDirectoryName(palettePath));
        palfile.WriteToFile(palettePath);
        expentry.PalettePath = WinAPI.GetRelativePath(rootDir + @"\", palettePath);
      }

      // restore the original palette
      element.Palette = (Palette_15Bit)opal;

      Entries.Put(key.ToString(), expentry);
      progress?.Report(key);
    }

    /// <summary>Imports, replacing existing data only if there is new data</summary>
    public void ImportMerge(List<ResourceElement> srcResourceList, ref IPalette basePalette, string rootDir, IProgress<int> progress = null)
    {
      // create seperate list
      List<ResourceElement> workingList = new List<ResourceElement>(EntryCount);
      for (int i = 0; i < EntryCount; i++)
      {
        workingList.Add((i < srcResourceList.Count) ? srcResourceList[i] : new ResourceElement());
      }
      Import(ref workingList, ref basePalette, rootDir, progress);
      srcResourceList.Clear();
      srcResourceList.AddRange(workingList);
    }

    /// <summary>Wipes the source resource list, and imports</summary>
    public void ImportReplace(List<ResourceElement> srcResourceList, ref IPalette basePalette, string rootDir, IProgress<int> progress = null)
    {
      // create seperate list
      List<ResourceElement> workingList = new List<ResourceElement>(EntryCount);
      for (int i = 0; i < EntryCount; i++)
      {
        workingList.Add(new ResourceElement());
      }
      Import(ref workingList, ref basePalette, rootDir, progress);
      srcResourceList.Clear();
      srcResourceList.AddRange(workingList);
    }

    private void Import(ref List<ResourceElement> workingList, ref IPalette basePalette, string rootDir, IProgress<int> progress = null)
    {
      foreach (string key in Entries.GetKeys())
      {
        if (!int.TryParse(key, out int ikey)) { continue; }

        ResourceExportEntry entry = Entries[key];
        if (ikey >= workingList.Count) { continue; }

        Bitmap image = new Bitmap(Path.Combine(rootDir, entry.ImagePath));
        IPalette pal = basePalette;
        if (entry.UseOwnPalette == true)
        {
          PaletteFile palfile = new PaletteFile();
          palfile.ReadFromFile(Path.Combine(rootDir, entry.PalettePath));
          palfile.Palette.CopyTo(ref pal);
          if (PaletteUtil.HasNonUniqueSpecialIndices(ref pal, out _))
          {

          }
        }

        if (entry.UsePalette)
        {
          workingList[ikey].ImportImageDataAs8Bit(image, pal, entry.UseOwnPalette == false, out int _);
        }
        else
        {
          workingList[ikey].ImportImageDataAs15Bit(image);
        }

        workingList[ikey].FrameSize = entry.FrameSize;
        workingList[ikey].ImageOffset = entry.ImageOffset;
        workingList[ikey].Alignment = entry.Alignment;
        workingList[ikey].ImageHandle = entry.ImageHandle;
        workingList[ikey].PaletteHandle = entry.PaletteHandle;

        IPalette p = workingList[ikey].Palette;
        if (PaletteUtil.HasNonUniqueSpecialIndices(ref p, out _))
        {

        }

        progress?.Report(ikey);
      }
    }
  }

  public struct ResourceExportEntry
  {
    [INIValue]
    public int2 FrameSize;

    [INIValue]
    public int2 ImageOffset;

    [INIValue]
    public byte Alignment;

    [INIValue]
    public int ImageHandle;

    [INIValue]
    public int PaletteHandle;

    [INIValue(NoWriteValue = null)]
    public string ImagePath;

    [INIValue]
    public bool UsePalette;

    [INIValue(NoWriteValue = null)]
    public bool? UseOwnPalette;

    [INIValue(NoWriteValue = null)]
    public string PalettePath;
  }
}
