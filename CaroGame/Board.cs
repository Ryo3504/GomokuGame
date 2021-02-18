using System.Drawing;

namespace CaroGame
{
	class Board
	{
		#region Model Properties
		/// <summary>
		/// Create Model
		/// </summary>
		private int _NumberOfRow;
		private int _NumberOfCell;
		public static Pen penXO;
		public static Pen penXX;
		//public Bitmap bmpWebMachine = new Bitmap("..//..//bmpWebMachine.bmp");
		public int NumberofRow
		{
			get { return _NumberOfRow; }
		}

		public int NumberofCell
		{
			get { return _NumberOfCell; }
		}
		#endregion

		/// <summary>
		/// Create Board
		/// </summary>
		public Board()
		{
			_NumberOfRow = 0;//số dòng
			_NumberOfCell = 0;//số cột
		}

		public Board(int numberofrow, int numberofcell)
		{
			_NumberOfRow = numberofrow;
			_NumberOfCell = numberofcell;
		}
		#region Draw Game Object
		/// <summary>
		/// Draw Board
		/// </summary>
		/// <param name="g">Graphics</param>
		public void DrawBoard(Graphics g)
		{
			for (int i = 0; i <= _NumberOfCell; i++)
			{
				g.DrawLine(CaroChess.pen, i * BoardBox._width, 0, i * BoardBox._width, _NumberOfRow * BoardBox._height);
			}
			for (int j = 0; j <= _NumberOfRow; j++)
			{
				g.DrawLine(CaroChess.pen, 0, j * BoardBox._height, _NumberOfCell * BoardBox._width, j * BoardBox._height);
			}
		}

		/// <summary>
		/// Draw Chess O
		/// </summary>
		/// <param name="g">Graphics</param>
		/// <param name="point">Point</param>
		public void DrawChessO(Graphics g, Point point)
		{
			g.DrawEllipse(CaroChess.penO, point.X + 5, point.Y + 5, BoardBox._width - 10, BoardBox._height - 10);
		}

		/// <summary>
		/// Draw Chess X
		/// </summary>
		/// <param name="g">Graphics</param>
		/// <param name="point">Point</param>
		public void DrawChessX(Graphics g, Point point)
		{
			g.DrawLine(CaroChess.penX, point.X + 5, point.Y + 5, point.X + 20, point.Y + 20);
			g.DrawLine(CaroChess.penX, point.X + 20, point.Y + 5, point.X + 5, point.Y + 20); 
		}
		#endregion

		#region Game Action
		/// <summary>
		/// Delete Chess O For Undo/Redo
		/// </summary>
		/// <param name="g"></param>
		/// <param name="point"></param>
		/// <param name="clr"></param>
		public void DeleteChessO(Graphics g, Point point, Color clr)
		{
			penXO = new Pen(clr, 2f);
			g.DrawEllipse(penXO, point.X + 5, point.Y + 5, BoardBox._width - 10, BoardBox._height - 10);
		}

		/// <summary>
		/// Delete Chess X For Undo/Redo
		/// </summary>
		/// <param name="g"></param>
		/// <param name="point"></param>
		/// <param name="clr"></param>
		public void DeleteChessX(Graphics g, Point point, Color clr)
		{
			penXX = new Pen(clr, 2f);
			g.DrawLine(penXX, point.X + 5, point.Y + 5, point.X + 20, point.Y + 20);
			g.DrawLine(penXX, point.X + 20, point.Y + 5, point.X + 5, point.Y + 20);
		}
		#endregion
	}
}
