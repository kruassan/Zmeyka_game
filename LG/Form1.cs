using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG
{
	public partial class Form1 : Form
	{
		Zmeyka zmeya;
		public Form1()
		{
			this.KeyPreview = true;
			InitializeComponent();
			zmeya = new Zmeyka(WorkField, countLabel);
			zmeya.Start(SpeedTrackBar.Value);
		}

		private void Go_top(object sender, EventArgs e)
		{	
			zmeya.direct = Zmeyka.Direction.TOP;
		}

		private void Go_right(object sender, EventArgs e)
		{
			zmeya.direct = Zmeyka.Direction.RIGHT;
		}

		private void Go_left(object sender, EventArgs e)
		{
			zmeya.direct = Zmeyka.Direction.LEFT;
		}

		private void Go_down(object sender, EventArgs e)
		{
			zmeya.direct = Zmeyka.Direction.BOT;
		}

		private void PauseButton_Click(object sender, EventArgs e)
		{
			zmeya.Pause();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			zmeya.Start(SpeedTrackBar.Value);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case (Keys.A):
					{
						Go_left(null, null);
						break;
					}
				case (Keys.S):
					{
						Go_down(null, null);
						break;
					}
				case (Keys.D):
					{
						Go_right(null, null);
						break;
					}
				case (Keys.W):
					{
						Go_top(null, null);
						break;
					}
				case (Keys.Escape):
					{
						zmeya.Pause();
						break;
					}
				case (Keys.Enter):
					{
						zmeya.Start(SpeedTrackBar.Value);
						break;
					}
			}
		}

		private void SpeedTrackBar_ValueChanged(object sender, EventArgs e)
		{
			zmeya.SetInterval(SpeedTrackBar.Value);
			SpeedTB.Text = SpeedTrackBar.Value.ToString();
		}

		private void SpeedTB_TextChanged(object sender, EventArgs e)
		{
			SpeedTrackBar.Value = int.Parse(SpeedTB.Text);
		}

		private void SpeedTrackBar_MouseDown(object sender, MouseEventArgs e)
		{
			zmeya.Pause(true);
		}

		private void SpeedTrackBar_MouseUp(object sender, MouseEventArgs e)
		{
			zmeya.Pause(false);
		}
	}

	public enum Cell { NONE = 0, ZMEYA, DROP }

	class Zmeyka
	{
		Timer workingTimer;

		List<Point> zmeyaCoordinate;

		PictureBox pb_handle;
		Label label_handle;

		int interval = -1;

		public enum Direction { LEFT, TOP, RIGHT, BOT }

		MatrixField workingMatrix;

		public Direction direct = Direction.RIGHT;

		public Zmeyka(PictureBox pb_handle, Label label_handle)
		{
			this.pb_handle = pb_handle;
			this.label_handle = label_handle;
		}

		private void ReInit()
		{
			label_handle.Text = "0 съедено";
			direct = Direction.RIGHT;
			if (workingTimer != null && workingTimer.Enabled)
				workingTimer.Stop();

			workingMatrix = new MatrixField(15, new Size(25, 25));

			zmeyaCoordinate = new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0) };
			foreach (var item in zmeyaCoordinate)
			{
				workingMatrix.SetCell(item.X, item.Y, Cell.ZMEYA);
			}

			workingTimer = new Timer();
			workingTimer.Interval = interval;
			workingTimer.Tick += (x, y) => { Tick(); };
		}

		public void Start(int interval)
		{
			this.interval = interval;
			ReInit();
			workingTimer.Interval = interval;
			workingTimer.Start();
		}

		public void Pause()
		{
			if(workingTimer.Enabled)
			{
				workingTimer.Stop();
			}
			else
			{
				workingTimer.Start();
			}
		}

		public void Pause(bool stopProj)
		{
			if (stopProj)
			{
				if (workingTimer.Enabled)
				{
					workingTimer.Stop();
				}
			}
			else
			{
				if (!workingTimer.Enabled)
				{
					workingTimer.Start();
				}
			}
		}

		public void SetInterval(int newInterval)
		{
			interval = newInterval;
			if (workingTimer != null)
			{
				workingTimer.Interval = newInterval;
			}
		}

		private void RandomDrop(int procentOfDrop)
		{
			int randResult = 0;

			Random rand = new Random(DateTime.Now.Millisecond);

			randResult = rand.Next(100);

			if (randResult > procentOfDrop)
				return;

			int nextPoint = rand.Next(24 * 24 - zmeyaCoordinate.Count);
			Point dropPoint = new Point(nextPoint / 24, nextPoint % 24);

			bool great = false;

			for(int x = dropPoint.X; x < 24; x++)
			{
				for (int y = dropPoint.Y; y < 24; y++)
				{
					if(workingMatrix.cells[x,y] == Cell.NONE)
					{
						workingMatrix.cells[x, y] = Cell.DROP;
						workingMatrix.SetCell(x, y, Cell.DROP);
						great = true;
						break;
					}
				}
				if (great)
					break;
			}
		}

		private void Tick()
		{
			switch(direct)
			{
				case (Direction.TOP):
					{
						if(zmeyaCoordinate.Last().Y - 1 < 0 || (workingMatrix.cells[zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y - 1] == Cell.ZMEYA))
						{
							workingTimer.Stop();
							MessageBox.Show("You loose :(");
							return;
						}
						else if(workingMatrix.cells[zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y - 1] == Cell.DROP)
						{
							zmeyaCoordinate.Add(new Point(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y - 1));
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
							label_handle.Text = (zmeyaCoordinate.Count) - 3 + " съедено";
						}
						else
						{
							workingMatrix.SetCell(zmeyaCoordinate[0].X, zmeyaCoordinate[0].Y, Cell.NONE);
							for (int x = 0; x < zmeyaCoordinate.Count - 1; x++)
							{
								zmeyaCoordinate[x] = zmeyaCoordinate[x + 1];
							}
							zmeyaCoordinate[zmeyaCoordinate.Count - 1] = new Point(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y - 1);
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
						}
						break;
					}
				case (Direction.RIGHT):
					{
						if (zmeyaCoordinate.Last().X + 1 > 24 || (workingMatrix.cells[zmeyaCoordinate.Last().X + 1, zmeyaCoordinate.Last().Y] == Cell.ZMEYA))
						{
							workingTimer.Stop();
							MessageBox.Show("You loose :(");
							return;
						}
						else if (workingMatrix.cells[zmeyaCoordinate.Last().X + 1, zmeyaCoordinate.Last().Y] == Cell.DROP)
						{
							zmeyaCoordinate.Add(new Point(zmeyaCoordinate.Last().X + 1, zmeyaCoordinate.Last().Y));
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
							label_handle.Text = (zmeyaCoordinate.Count) - 3 + " съедено";
						}
						else
						{
							workingMatrix.SetCell(zmeyaCoordinate[0].X, zmeyaCoordinate[0].Y, Cell.NONE);
							for (int x = 0; x < zmeyaCoordinate.Count - 1; x++)
							{
								zmeyaCoordinate[x] = zmeyaCoordinate[x + 1];
							}


							zmeyaCoordinate[zmeyaCoordinate.Count - 1] = new Point(zmeyaCoordinate.Last().X + 1, zmeyaCoordinate.Last().Y);
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
						}
						break;
					}
				case (Direction.BOT):
					{
						if ((zmeyaCoordinate.Last().Y + 1 > 24) || (workingMatrix.cells[zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y + 1] == Cell.ZMEYA))
						{
							workingTimer.Stop();
							MessageBox.Show("You loose :(");
							return;
						}
						else if (workingMatrix.cells[zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y + 1] == Cell.DROP)
						{
							zmeyaCoordinate.Add(new Point(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y + 1));
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
							label_handle.Text = (zmeyaCoordinate.Count) - 3 + " съедено";
						}
						else
						{
							workingMatrix.SetCell(zmeyaCoordinate[0].X, zmeyaCoordinate[0].Y, Cell.NONE);
							for (int x = 0; x < zmeyaCoordinate.Count - 1; x++)
							{
								zmeyaCoordinate[x] = zmeyaCoordinate[x + 1];
							}
							zmeyaCoordinate[zmeyaCoordinate.Count - 1] = new Point(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y + 1);
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
						}
						break;
					}
				case (Direction.LEFT):
					{
						if (zmeyaCoordinate.Last().X - 1 < 0 || (workingMatrix.cells[zmeyaCoordinate.Last().X - 1, zmeyaCoordinate.Last().Y] == Cell.ZMEYA))
						{
							workingTimer.Stop();
							MessageBox.Show("You loose :(");
							return;
						}
						else if (workingMatrix.cells[zmeyaCoordinate.Last().X - 1, zmeyaCoordinate.Last().Y] == Cell.DROP)
						{
							zmeyaCoordinate.Add(new Point(zmeyaCoordinate.Last().X - 1, zmeyaCoordinate.Last().Y));
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
							label_handle.Text = (zmeyaCoordinate.Count) - 3 + " съедено";
						}
						else
						{
							workingMatrix.SetCell(zmeyaCoordinate[0].X, zmeyaCoordinate[0].Y, Cell.NONE);
							for (int x = 0; x < zmeyaCoordinate.Count - 1; x++)
							{
								zmeyaCoordinate[x] = zmeyaCoordinate[x + 1];
							}

							zmeyaCoordinate[zmeyaCoordinate.Count - 1] = new Point(zmeyaCoordinate.Last().X - 1, zmeyaCoordinate.Last().Y);
							workingMatrix.SetCell(zmeyaCoordinate.Last().X, zmeyaCoordinate.Last().Y, Cell.ZMEYA);
						}
						break;
					}
			}
			RandomDrop(10);
			pb_handle.Image = workingMatrix.GetBitmap();
		}
	}

	public class MatrixField
	{
		public Cell[,] cells;

		Bitmap bitmap;
		Graphics graphics;

		int CellSize;

		public MatrixField(int cellSize, Size fieldSize)
		{
			cells = new Cell[fieldSize.Width, fieldSize.Height];
			CellSize = cellSize;
			
			bitmap = new Bitmap((cellSize * fieldSize.Width + 1 * (fieldSize.Width + 1)), (cellSize * fieldSize.Height + 1 * (fieldSize.Height + 1)));
			graphics = Graphics.FromImage(bitmap);

			//draw external fringes
			graphics.DrawLine(new Pen(Color.Gray), new Point(0, 0), new Point(0, bitmap.Height - 1));
			graphics.DrawLine(new Pen(Color.Gray), new Point(0, bitmap.Height - 1), new Point(bitmap.Width - 1, bitmap.Height - 1));
			graphics.DrawLine(new Pen(Color.Gray), new Point(bitmap.Width - 1, bitmap.Height), new Point(bitmap.Width - 1, 0));
			graphics.DrawLine(new Pen(Color.Gray), new Point(bitmap.Width - 1, 0), new Point(0, 0));

			//X fringes
			for(int x = 0; x < fieldSize.Width; x++)
			{
				var startX = 1 + 1 * (x) + (x + 1) * cellSize;
				graphics.DrawLine(new Pen(Color.Gray), new Point(startX, 0), new Point(startX, bitmap.Height));
			}

			//Y fringes
			for (int x = 0; x < fieldSize.Height; x++)
			{
				var startY = 1 + 1 * (x) + (x + 1) * cellSize;
				graphics.DrawLine(new Pen(Color.Gray), new Point(0, startY), new Point(bitmap.Width, startY));
			}
		}

		public Bitmap GetBitmap()
		{
			return bitmap;
		}

		//public void Click(int x_coord, int y_coord)
		//{

		//	//extern bitmap or on fringe
		//	if (x_coord >= bitmap.Width || y_coord >= bitmap.Height || x_coord == 1 || y_coord == 1)
		//		return;

		//	//raschet x
		//	if (x_coord % (CellSize + 1) == 0)
		//	{
		//		return;
		//	}

		//	int xpos = (x_coord / (CellSize + 1));

		//	//raschet y
		//	if (y_coord % (CellSize + 1) == 0)
		//	{
		//		return;
		//	}

		//	int ypos = (y_coord / (CellSize + 1));

		//	Redraw(xpos, ypos, brushColor);
		//}

		public void SetCell(int xpos, int ypos, Cell newCell)
		{
			cells[xpos, ypos] = newCell;
			Redraw(xpos, ypos, newCell);
		}

		private void Redraw(int xpos, int ypos, Cell newCell)
		{
			int xstart = 1 + 1 * (xpos) + (xpos) * CellSize;
			int ystart = 1 + 1 * (ypos) + (ypos) * CellSize;

			Color color = new Color();
			switch(newCell)
			{
				case (Cell.DROP):
					{
						color = Color.Gold;
						break;
					}
				case (Cell.NONE):
					{
						color = Color.White;
						break;
					}
				case (Cell.ZMEYA):
					{
						color = Color.Green;
						break;
					}
			}

			graphics.FillRectangle(new SolidBrush(color), new Rectangle(xstart, ystart, CellSize, CellSize));
		}
	}
}
