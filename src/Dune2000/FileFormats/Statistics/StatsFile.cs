using Dune2000.Enums;
using Dune2000.Util;
using Dune2000.Structs.Statistics;
using Primrose.Primitives.Factories;
using System.IO;
using System.Text;
using Primrose.FileFormats.Common;
using System;

namespace Dune2000.FileFormats.Statistics
{
	public struct StatsFile : IFile
	{
    public Stats Stats;

    public void ReadFromFile(string filePath) 
    {
      Stats = new Stats();
			ReadStatsDump(filePath);
    }

		private void ReadStatsDump(string filePath)
		{
			using (FileStream fs = new FileStream(filePath, FileMode.Open))
			{
				using (BinaryReader reader = new EndiannessAwareBinaryReader(fs, EndiannessAwareBinaryReader.Endianness.Big))
				{
					fs.Position = 4L;
					while (fs.Position + 4L < fs.Length)
					{
						string token = Encoding.Default.GetString(reader.ReadBytes(4));
						ushort datatype = reader.ReadUInt16();
						ushort datalen = reader.ReadUInt16();
						switch (datatype)
            {
							case 0x02:     // datatype 0x02 = probably boolean
								{
									if (datalen != 1)
									{
										// ????
									}
									bool bdata = reader.ReadByte() != 0;
									InterpretBoolean(token, bdata);
									datalen--;
									break;
								}

							case 0x05:     
							case 0x06:     // datatype 0x05 and 0x06 = 32-bit integer (could be unsigned or signed)
								{
									if (datalen != 4)
									{
										// ????
									}
									int idata = reader.ReadInt32();
									InterpretInteger(token, idata);
									datalen -= 4;
									break;
								}

							case 0x07:     // datatype 0x07 = C-style string (null terminated)
								{
									string sdata = new string(reader.ReadChars(datalen)).Trim('\0');
									InterpretString(token, sdata);
									datalen = 0;
									break;
								}

							case 0x14:    // datatype 0x14 = integer array (could be unsigned or signed)
								{
									int[] adata = new int[datalen / 4];
									for (int i = 0; i < adata.Length; i++)
										adata[i] = reader.ReadInt32();
									InterpretIntegerArray(token, adata);
									break;
								}

							default:    // unsure: discard this
                {
									break;
                }
						}

						if (datalen > 0)
							reader.ReadBytes(datalen);

						while (fs.Position % 4L != 0L)
						{
							fs.Position++;
						}
					}
				}
			}
		}

		private void InterpretBoolean(string token, bool data)
		{
			switch (token)
			{
				case "SDFX":
					{
						Stats.SuddenDisconnect = data;
						break;
					}

				case "TRNY":
					{
						Stats.TournamentGame = data;
						break;
					}
			}
		}

		private void InterpretInteger(string token, int data)
		{
			switch (token)
			{
				case "TIME":
					{
						Stats.Time = data;
						break;
					}

				case "AIPL":
					{
						Stats.AIPlayerCount = data;
						break;
					}

				case "GMID":
					{
						Stats.GameId = data;
						break;
					}

				case "TICK":
					{
						Stats.GameTicks = data;
						break;
					}

				case "UNIT":
					{
						Stats.UnitCount = data;
						break;
					}

				case "CRD0":
				case "CRD1":
				case "CRD2":
				case "CRD3":
				case "CRD4":
				case "CRD5":
				case "CRD6":
				case "CRD7":
					{
						House house = (House)byte.Parse(token[token.Length - 1].ToString());
						Stats.Houses[house].Credits = data;
						break;
					}
			}
		}

		private void InterpretString(string token, string data)
		{
			switch (token)
			{
				case "ACCN":
          {
						Stats.PlayerAccountName = data;
						break;
					}

				case "SCR0":
				case "SCR1":
				case "SCR2":
				case "SCR3":
				case "SCR4":
				case "SCR5":
				case "SCR6":
				case "SCR7":
					{
						string[] scr_data = data.Split('/');
						House house = (House)byte.Parse(token[token.Length - 1].ToString());
						Stats.Houses[house].FinishingPlace = int.Parse(scr_data[0]) + 1;
						Stats.Houses[house].BuildingsOwned = int.Parse(scr_data[1]);
						Stats.Houses[house].BuildingsLost = int.Parse(scr_data[2]);
						Stats.Houses[house].BuildingsDestroyed = int.Parse(scr_data[3]);
						Stats.Houses[house].UnitsOwned = int.Parse(scr_data[4]);
						Stats.Houses[house].UnitsLost = int.Parse(scr_data[5]);
						Stats.Houses[house].UnitsKilled = int.Parse(scr_data[6]);
						Stats.Houses[house].SpiceHarvested = int.Parse(scr_data[7]);
						break;
					}

				case "GEND":
					{
						Stats.EndStatus = data;
						break;
					}

				case "GMAP":
					{
						Stats.MapName = data;
						break;
					}

				case "GSET": // e.g.: Worms 3 Crates 0 Credits 7000 Techlevel 7
					{
						string[] gset_data = data.Split(' ');
						Stats.Worms = int.Parse(gset_data[1]);
						Stats.Crates = int.Parse(gset_data[3]) > 0;
						Stats.StartingCredits = int.Parse(gset_data[5]);
						Stats.TechLevel = int.Parse(gset_data[7]);
						break;
					}

				case "PL_0":
				case "PL_1":
				case "PL_2":
				case "PL_3":
				case "PL_4":
				case "PL_5":
				case "PL_6":
				case "PL_7":
					{
						Stats.PlayerCount++;
						string[] pl_data = data.Split('/');
						House house = (House)byte.Parse(token[token.Length - 1].ToString());
						Stats.Houses[house].Name = pl_data[0];
						Stats.Houses[house].Side = pl_data[1];
						Stats.Houses[house].ColorIndex = int.Parse(pl_data[2]);
						Stats.Houses[house].Handicap = int.Parse(pl_data[3]) + 1;
						break;
					}
			}
		}

		private void InterpretIntegerArray(string token, int[] data)
		{
			switch (token)
			{ 
				case "UNB0":
				case "UNB1":
				case "UNB2":
				case "UNB3":
				case "UNB4":
				case "UNB5":
				case "UNB6":
				case "UNB7":
					{
						House house = (House)byte.Parse(token[token.Length - 1].ToString());
						Registry<Unit, int> ureg = new Registry<Unit, int>();
						for(int n = 0; n < data.Length; n++)
            {
							ureg.Put((Unit)n, data[n]);
            }
						Stats.Houses[house].UnitsTable = ureg;
						break;
					}

				case "BLB0":
				case "BLB1":
				case "BLB2":
				case "BLB3":
				case "BLB4":
				case "BLB5":
				case "BLB6":
				case "BLB7":
					{
						House house = (House)byte.Parse(token[token.Length - 1].ToString());
						Registry<Building, int> breg = new Registry<Building, int>();
						for (int n = 0; n < data.Length; n++)
						{
							breg.Put((Building)n, data[n]);
						}
						Stats.Houses[house].BuildingsTable = breg;
						break;
					}
			}
		}

		public void WriteToFile(string destinationPath)
		{
			throw new NotImplementedException();
		}
	}
}
