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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DungeonGenerator.Dungeon;
using DungeonGenerator.Templates;

namespace DungeonGenerator {
	public partial class frmMain : Form {
		public frmMain() {
			InitializeComponent();
		}

		class Template {
			public string Name { get; set; }
			public DungeonTemplate Item { get; set; }
		}

		readonly Random rand = new Random();
		readonly List<Button> btns = new List<Button>();
		int seed;
		Generator gen;
		Rasterizer ras;
		DungeonTemplate active;

		void frmMain_Load(object sender, EventArgs e) {
			foreach (var value in Enum.GetValues(typeof(GenerationStep))) {
				if ((GenerationStep)value == GenerationStep.Finish)
					continue;
				var btn = new Button { Text = value.ToString(), Tag = value, AutoSize = true };
				btn.Click += Step_Click;
				stepsPane.Controls.Add(btn);
				btns.Add(btn);
			}
			foreach (var value in Enum.GetValues(typeof(RasterizationStep))) {
				if ((RasterizationStep)value == RasterizationStep.Finish)
					continue;
				var btn = new Button { Text = value.ToString(), Tag = value, AutoSize = true };
				btn.Click += Step_Click;
				stepsPane.Controls.Add(btn);
				btns.Add(btn);
			}
			foreach (var type in typeof(Generator).Assembly.GetTypes()) {
				if (!type.IsSubclassOf(typeof(DungeonTemplate)))
					continue;
				var name = type.Namespace.Substring(type.Namespace.LastIndexOf('.') + 1);
				comTemplates.Items.Add(new Template {
					Name = name,
					Item = (DungeonTemplate)Activator.CreateInstance(type)
				});
			}
			comTemplates.SelectedIndex = 0;
			stepsPane.Enabled = false;
		}

		void Step_Click(object sender, EventArgs e) {
			if (((Button)sender).Tag is GenerationStep) {
				var step = (GenerationStep)((Button)sender).Tag;
				gen.Generate(step + 1);
			}
			else {
				gen.Generate();
				if (ras == null)
					ras = new Rasterizer(seed, gen.ExportGraph());

				var step = (RasterizationStep)((Button)sender).Tag;
				ras.Rasterize(step + 1);
			}

			Render();
			foreach (var btn in btns) {
				if (btn.Tag is GenerationStep)
					btn.Enabled = (GenerationStep)btn.Tag >= gen.Step;
				else
					btn.Enabled = ras == null || (RasterizationStep)btn.Tag >= ras.Step;
			}
		}

		const int ScaleFactor = 4;

		void Render() {
			if (gen.GetRooms() == null)
				return;
			if (cbBorder.Checked) {
				RenderBorder();
				return;
			}
			if (ras != null) {
				RenderRaster();
				return;
			}

			var rms = gen.GetRooms().ToList();
			int dx = int.MaxValue, dy = int.MaxValue;
			int mx = int.MinValue, my = int.MinValue;
			foreach (var rm in rms) {
				var bounds = rm.Bounds;

				if (bounds.X < dx)
					dx = bounds.X;
				if (bounds.Y < dy)
					dy = bounds.Y;

				if (bounds.MaxX > mx)
					mx = bounds.MaxX;
				if (bounds.MaxY > my)
					my = bounds.MaxY;
			}


			var bmp = new Bitmap((mx - dx + 4) * ScaleFactor, (my - dy + 4) * ScaleFactor);
			using (var g = Graphics.FromImage(bmp)) {
				g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				foreach (var rm in rms) {
					var brush = Brushes.Black;
					if (rm.Type == RoomType.Start)
						brush = Brushes.Red;
					else if (rm.Type == RoomType.Target)
						brush = Brushes.Green;
					else if (rm.Type == RoomType.Special)
						brush = Brushes.Blue;

					var x = (rm.Pos.X - dx) * ScaleFactor + 2 * ScaleFactor;
					var y = (rm.Pos.Y - dy) * ScaleFactor + 2 * ScaleFactor;
					g.FillRectangle(brush, x, y, rm.Width * ScaleFactor, rm.Height * ScaleFactor);
					g.DrawString(rm.Depth.ToString(), Font, Brushes.White, x, y);
				}
			}

			var original = box.Image;
			box.Image = bmp;
			if (original != null)
				original.Dispose();
		}

		void RenderBorder() {
			var rms = gen.GetRooms().ToList();
			int dx = int.MaxValue, dy = int.MaxValue;
			int mx = int.MinValue, my = int.MinValue;
			foreach (var rm in rms) {
				var bounds = rm.Bounds;

				if (bounds.X < dx)
					dx = bounds.X;
				if (bounds.Y < dy)
					dy = bounds.Y;

				if (bounds.MaxX > mx)
					mx = bounds.MaxX;
				if (bounds.MaxY > my)
					my = bounds.MaxY;
			}

			var pen = new Pen(Color.Black, ScaleFactor / 2);
			var bmp = new Bitmap((mx - dx + 4) * ScaleFactor, (my - dy + 4) * ScaleFactor);
			using (var g = Graphics.FromImage(bmp)) {
				g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				foreach (var rm in rms) {
					var rmPen = pen;
					if (rm.Type == RoomType.Start)
						rmPen = new Pen(Color.Red, ScaleFactor / 2);
					else if (rm.Type == RoomType.Target)
						rmPen = new Pen(Color.Green, ScaleFactor / 2);
					else if (rm.Type == RoomType.Special)
						rmPen = new Pen(Color.Blue, ScaleFactor / 2);

					var x = (rm.Pos.X - dx) * ScaleFactor + 2 * ScaleFactor;
					var y = (rm.Pos.Y - dy) * ScaleFactor + 2 * ScaleFactor;
					g.DrawRectangle(rmPen, x, y, rm.Width * ScaleFactor, rm.Height * ScaleFactor);
					g.DrawString(rm.Depth.ToString(), Font, Brushes.Black, x, y);

					if (rmPen != pen)
						rmPen.Dispose();
				}
			}

			pen.Dispose();

			var original = box.Image;
			box.Image = bmp;
			if (original != null)
				original.Dispose();
		}

		void RenderRaster() {
			var map = ras.ExportMap();
			int w = map.GetUpperBound(0) + 1, h = map.GetUpperBound(1) + 1;
			var bmp = new Bitmap(w * ScaleFactor, h * ScaleFactor);

			for (int x = 0; x < w; x++)
				for (int y = 0; y < h; y++) {
					var type = map[x, y].TileType;
					if (type.Id != 0xfe &&
					    type.Name != null) {
						for (int dx = 0; dx < ScaleFactor; dx++)
							for (int dy = 0; dy < ScaleFactor; dy++) {
								bmp.SetPixel(x * ScaleFactor + dx, y * ScaleFactor + dy,
									Color.FromArgb(type.Name.GetHashCode() & 0x00ffffff | (0xff << 24)));
							}
					}
				}

			var original = box.Image;
			box.Image = bmp;
			if (original != null)
				original.Dispose();
		}

		void btnNew_Click(object sender, EventArgs e) {
			btnNewStep_Click(sender, e);
			Step_Click(btns.Last(), e);
		}

		void btnNewStep_Click(object sender, EventArgs e) {
			seed = rand.Next();
			gen = new Generator(seed, active);
			ras = null;
			Text = ProductName + " [Seed: " + seed + "]";

			stepsPane.Enabled = true;
			foreach (var btn in btns)
				btn.Enabled = true;

			var original = box.Image;
			box.Image = null;
			if (original != null)
				original.Dispose();
		}

		void cbBorder_CheckedChanged(object sender, EventArgs e) {
			if (stepsPane.Enabled)
				Render();
		}

		void box_DoubleClick(object sender, EventArgs e) {
			if (box.Image != null)
				Clipboard.SetImage(box.Image);
		}


		void box_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Right ||
			    ras == null)
				return;

			var map = ras.ExportMap();
			var json = JsonMap.Save(map);

			var sfd = new SaveFileDialog();
			sfd.Filter = "Json Map (*.jm)|*.jm|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
				File.WriteAllText(sfd.FileName, json);
		}

		void comTemplates_SelectedIndexChanged(object sender, EventArgs e) {
			if (comTemplates.SelectedItem != null)
				active = ((Template)comTemplates.SelectedItem).Item;
		}
	}
}