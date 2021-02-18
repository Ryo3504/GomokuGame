using System.Drawing;

namespace CaroGame
{
	class BoardBox
	{
		#region Board Box
		// Create Board Model Properties
		public const int _width = 25;
		public const int _height = 25;

		private int _Row;// Dòng
		private int _Cell;// Cột

		private Point _Location;

		private int _Own;

		public int Row
		{
			get{ return _Row; }

			set{ _Row = value; }
		}

		public int Cell
		{
			get{ return _Cell; }

			set{ _Cell = value; }
		}

		public Point Location
		{
			get{ return _Location; }

			set{ _Location = value; }
		}

		public int Own
		{
			get{ return _Own; }

			set{ _Own = value; }
		}

		public BoardBox()
		{

		}

		public BoardBox(int row, int cell, Point location, int own)
		{
			_Row = row;
			_Cell = cell;
			_Location = location;
			_Own = own;
		}
		#endregion
	}
}
