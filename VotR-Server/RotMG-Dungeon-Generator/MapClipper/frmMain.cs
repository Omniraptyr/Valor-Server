/*
    Copyright (C) 2015 creepylava

    This file is part of RotMG Dungeon Generator.

    RotMG Dungeon Generator is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DungeonGenerator.Dungeon;
using RotMG.Common.Rasterizer;

namespace MapClipper {
	public partial class frmMain : Form {
		class CommandIntercepter : NativeWindow {
			readonly frmMain main;
			readonly TextBox txt;

			public CommandIntercepter(frmMain main, TextBox txt) {
				this.main = main;
				this.txt = txt;
				txt.HandleCreated += (sender, e) => AssignHandle(txt.Handle);
				txt.HandleDestroyed += (sender, e) => ReleaseHandle();
			}

			protected override void WndProc(ref Message m) {
				switch (m.Msg) {
					case 0x302:
						var text = Clipboard.GetText();
						if (string.IsNullOrEmpty(text))
							break;

						var cmds = text.Split('\r', '\n');
						for (int i = 0; i < cmds.Length - 1; i++)
							main.RunCmd(cmds[i].Trim());

						txt.Text = cmds[cmds.Length - 1];

						return;
				}
				base.WndProc(ref m);
			}
		}

		CommandIntercepter intercepter;

		public frmMain() {
			InitializeComponent();
			intercepter = new CommandIntercepter(this, txtCmd);
		}

		DungeonTile[,] map;
		Rect selection;

		readonly DungeonTile[][,] clip = new DungeonTile[100][,];

		static readonly DungeonTile space = new DungeonTile {
			TileType = new TileType(0x00fe, "Space")
		};

		void Render(Rect bounds) {
			var bmp = new Bitmap(bounds.MaxX - bounds.X, bounds.MaxY - bounds.Y);

			for (int x = bounds.X; x < bounds.MaxX; x++)
				for (int y = bounds.Y; y < bounds.MaxY; y++) {
					var type = map[x, y].TileType;
					if (type.Id != 0xfe && type.Name != null) {
						var color = type.Name.GetHashCode() & 0x00ffffff | (0xff << 24);
						bmp.SetPixel(x - bounds.X, y - bounds.Y, Color.FromArgb(color));
					}
				}

			var original = box.Image;
			box.Image = bmp;
			if (original != null)
				original.Dispose();
		}

		void AppendLine(string txt) {
			txtHist.AppendText(txt + Environment.NewLine);
		}

		void box_Click(object sender, EventArgs e) {
			if (box.Image != null)
				Clipboard.SetImage(box.Image);
		}

		void txtCmd_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter)
				return;

			var cmd = txtCmd.Text;
			RunCmd(cmd);
		}

		void RunCmd(string cmd) {
			if (string.IsNullOrEmpty(cmd))
				return;

			AppendLine("> " + cmd);
			txtCmd.Clear();

			try {
				ProcessCmd(cmd);
			}
			catch {
				AppendLine("Error occured while executing the command.");
			}
		}

		void ProcessCmd(string cmd) {
			var index = cmd.IndexOf(' ');
			var cmdName = cmd.Substring(0, index).ToUpperInvariant();
			var args = cmd.Substring(index + 1);

			switch (cmdName) {
				case "NEW": {
					var size = args.Split(' ');
					int w = int.Parse(size[0]);
					int h = int.Parse(size[1]);
					map = new DungeonTile[w, h];
					for (int x = 0; x < w; x++)
						for (int y = 0; y < h; y++)
							map[x, y] = space;
					AppendLine("New map " + w + "x" + h + " created.");
					break;
				}

				case "RESIZE": {
					var size = args.Split(' ');
					int w = int.Parse(size[0]);
					int h = int.Parse(size[1]);
					int _w = map.GetUpperBound(0) + 1, _h = map.GetUpperBound(1) + 1;
					var newMap = new DungeonTile[w, h];
					for (int x = 0; x < w; x++)
						for (int y = 0; y < h; y++) {
							if (x < _w && y < _h)
								newMap[x, y] = map[x, y];
							else
								newMap[x, y] = space;
						}
					map = newMap;
					AppendLine("Resized to " + w + "x" + h + ".");
					break;
				}

				case "LOAD":
					LoadMap(args);
					break;

				case "SAVE":
					SaveMap(args);
					break;

				case "REGION":
					CmdRegion(args);
					break;

				case "CLIP":
					CmdClip(args);
					break;
			}
		}

		void LoadMap(string file) {
			map = JsonMap.Load(File.ReadAllText(file));
			selection = Rect.Empty;
			AppendLine("Map loaded.");
		}

		void SaveMap(string file) {
			File.WriteAllText(file, JsonMap.Save(map));
			AppendLine("Map saved.");
		}

		void CmdRegion(string args) {
			var index = args.IndexOf(' ');
			string subCmd, arg;
			if (index == -1) {
				subCmd = args.ToUpperInvariant();
				arg = "";
			}
			else {
				subCmd = args.Substring(0, index).ToUpperInvariant();
				arg = args.Substring(index + 1);
			}

			switch (subCmd) {
				case "ALL":
					selection = new Rect(0, 0, map.GetUpperBound(0) + 1, map.GetUpperBound(1) + 1);
					AppendLine("Selected " + selection + ".");
					break;

				case "SELECT": {
					var bounds = arg.Split(' ');
					int x = int.Parse(bounds[0]);
					int y = int.Parse(bounds[1]);
					int w = int.Parse(bounds[2]);
					int h = int.Parse(bounds[3]);
					selection = new Rect(x, y, x + w, y + h);
					AppendLine("Selected " + selection + ".");
				}
					break;

				case "DISPLAY":
					Render(selection);
					AppendLine("Displaying " + selection + ".");
					break;

				case "CLEAR": {
					for (int x = selection.X; x < selection.MaxX; x++)
						for (int y = selection.Y; y < selection.MaxY; y++) {
							map[x, y] = space;
						}
					AppendLine("Cleared " + selection + ".");
				}
					break;
			}
		}

		void CmdClip(string args) {
			var index = args.IndexOf(' ');
			string subCmd, arg;
			if (index == -1) {
				subCmd = args.ToUpperInvariant();
				arg = "";
			}
			else {
				subCmd = args.Substring(0, index).ToUpperInvariant();
				arg = args.Substring(index + 1);
			}

			switch (subCmd) {
				case "COPY": {
					int num = int.Parse(arg);
					clip[num] = new DungeonTile[selection.MaxX - selection.X, selection.MaxY - selection.Y];
					for (int x = selection.X; x < selection.MaxX; x++)
						for (int y = selection.Y; y < selection.MaxY; y++) {
							clip[num][x - selection.X, y - selection.Y] = map[x, y];
						}
					AppendLine("Copied " + selection + " at " + num + ".");
				}
					break;

				case "PASTE": {
					var pasteArgs = arg.Split(' ');
					int num = int.Parse(pasteArgs[0]);
					int tx = int.Parse(pasteArgs[1]);
					int ty = int.Parse(pasteArgs[2]);

					var w = clip[num].GetUpperBound(0) + 1;
					var h = clip[num].GetUpperBound(1) + 1;
					for (int x = 0; x < w; x++)
						for (int y = 0; y < h; y++) {
							map[x + tx, y + ty] = clip[num][x, y];
						}
					AppendLine("Pasted " + num + " at (" + tx + ", " + ty + ").");
				}
					break;
			}
		}
	}
}