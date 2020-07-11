using Dune2000.Editor.UI.Editors.Bin.Colours;
using Dune2000.Editor.UI.Editors.Bin.Palette;
using Dune2000.Editor.UI.Editors.Bin.Templates;
using Dune2000.Editor.UI.Editors.Resources;
using Dune2000.Editor.UI.Editors.Uib.Campaign;
using Dune2000.Editor.UI.Editors.Uib.Colours;
using Dune2000.Editor.UI.Editors.Uib.Menus;
using Dune2000.Editor.UI.Editors.Uib.Text;
using Primrose.Primitives.Factories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors
{
  public partial class ucEditorSelector : UserControl
  {
    public ucEditorSelector()
    {
      InitializeComponent();
      AssociateEditors();
    }

    private readonly Registry<ToolStripButton, IEditorControl> _editors = new Registry<ToolStripButton, IEditorControl>();
    private ToolStripButton _current;

    public UpdateDelegate<IEditorControl> EditorChanged;

    public bool Closing(ucEditorController controller, UpdateDelegate<IEditorControl> switchFunc)
    {
      foreach (ToolStripButton tsb in _editors.GetKeys())
      {
        IEditorControl editor = _editors[tsb];
        if (editor != null)
        {
          if (editor.Dirty)
          {
            controller.SetEditor(editor);
            switchFunc?.Invoke(editor);
            if (!controller.Unload())
            {
              return false;
            }
          }
        }
      }
      return true;
    }

    private void AssociateEditors()
    {
      // UIB
      _editors.Add(tsbTextUib, new ucTextUibEditor());
      _editors.Add(tsbColoursUib, new ucColourUibEditor());
      _editors.Add(tsbMenuUib, new ucMenusUibEditor());
      _editors.Add(tsbCampaignUib, new ucCampaignUibEditor());

      // Resource
      _editors.Add(tsbR8R16, new ucResourceEditor());

      // Bin
      //_editors.Add(tsbTemplatesBin, new ucTemplatesBinEditor()); // under development
      _editors.Add(tsbPaletteBin, new ucPaletteBinEditor());
      _editors.Add(tsbColoursBin, new ucColoursBinEditor());

      foreach (ToolStripButton tsb in _editors.GetKeys())
      {
        tsb.Enabled = true;
      }
    }

    public void UpdateEditor(IEditorControl editor)
    {
      foreach (ToolStripButton tsb in _editors.GetKeys())
      {
        if (_editors[tsb] == editor)
        {
          UpdateEditor(tsb, editor);
          break;
        }
      }
    }

    private void UpdateEditor(ToolStripButton tsb, IEditorControl editor)
    {
      if (_current != null)
      {
        //_current.BackColor = SystemColors.Control;
        if (_editors[_current] != null)
        {
          _current.BackColor = ucEditorController.GetFileTitleColor(_editors[_current]);
        }
        else
        {
          _current.BackColor = SystemColors.Control;
        }
      }

      tsb.BackColor = SystemColors.ActiveCaption;
      _current = tsb;
    }

    private void Select(object sender, EventArgs e)
    {
      if (sender is ToolStripButton tsb)
      {
        IEditorControl editor = _editors[tsb];
        if (tsb != null && tsb != _current)
        {
          UpdateEditor(editor);
          EditorChanged?.Invoke(editor);
        }
      }
    }
  }
}
