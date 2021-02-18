using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame
{
	class CaroChess
	{
		#region Model Properties
		public static Pen pen;
		public static Pen penO;
		public static Pen penX;
		private BoardBox[,] _ChessArrayBox;
		private Board _Board;
		private int _Turn;
		private int _Mode;
		private bool _Ready;
		private Stack<BoardBox> stack_GetLocated;
		private Stack<BoardBox> stack_Undo;
		public Label lbl = new Label();
		private int _END = -1;

		public int O;
		public int X;
		public int P1;
		public int P2;
		public int C;
		public int P;
		public int m, n;
		#endregion

		#region Create CaroChess,Mode,Turn,ArrayChess
		public int Mode
		{
			get { return _Mode; }
		}

		public int Turn
		{
			get { return _Turn; }
		}

		public bool Ready
		{
			get { return _Ready; }
		}

		public CaroChess()
		{
			pen = new Pen(Color.Green);
			penO = new Pen(Color.Red, 2f);
			penX = new Pen(Color.Blue, 2f);
			_Board = new Board(20, 20);
			_Turn = 1;
			_ChessArrayBox = new BoardBox[_Board.NumberofRow, _Board.NumberofCell];
			stack_GetLocated = new Stack<BoardBox>();
			stack_Undo = new Stack<BoardBox>();
			O = 0;
			X = 0;
			P1 = 0;
			P2 = 0;
			C = 0;
			P = 0;
			m = n = 0;
		}

		public void CreateArrayChess()
		{
			for (int i = 0; i < _Board.NumberofRow; i++)
			{
				for (int j = 0; j < _Board.NumberofCell; j++)
				{
					_ChessArrayBox[i, j] = new BoardBox(i, j, new Point(j * BoardBox._width, i * BoardBox._height), 0);
				}
			}
		}
		#endregion

		#region DrawBoard,PlayChess,DrawAgainChess
		public void DrawBoard(Graphics g)
		{
			_Board.DrawBoard(g);
		}
		public bool PlayChess(int MouseX, int MouseY, Graphics g)
		{
			if (MouseX % BoardBox._width == 0 || MouseY % BoardBox._height == 0)
			{
				return false;
			}


			int Cell = MouseX / BoardBox._width;
			int Row = MouseY / BoardBox._height;

			if (_ChessArrayBox[Row, Cell].Own != 0)
			{
				return false;
			}

			m = Row;
			n = Cell;

			switch (_Turn)
			{
				case 1:
					_ChessArrayBox[Row, Cell].Own = 1;
					_Board.DrawChessO(g, _ChessArrayBox[Row, Cell].Location);
					_Turn = 2;
					O++;
					break;
				case 2:
					_ChessArrayBox[Row, Cell].Own = 2;
					_Board.DrawChessX(g, _ChessArrayBox[Row, Cell].Location);
					_Turn = 1;
					X++;
					break;
				default:
					MessageBox.Show("Có lỗi xảy ra");
					break;
			}


			BoardBox _BoardBox = new BoardBox(_ChessArrayBox[Row, Cell].Row, _ChessArrayBox[Row, Cell].Cell, _ChessArrayBox[Row, Cell].Location, _ChessArrayBox[Row, Cell].Own);
			stack_Undo = new Stack<BoardBox>();
			stack_GetLocated.Push(_BoardBox);

			return true;
		}

		public void DrawNewChess(Graphics g)
		{
			foreach (BoardBox boardbox in stack_GetLocated)
			{
				if (boardbox.Own == 1)
				{
					_Board.DrawChessO(g, boardbox.Location);
				}
				else if (boardbox.Own == 2)
				{
					_Board.DrawChessX(g, boardbox.Location);
				}
			}
		}

		#endregion

		#region Start PvP,PvC
		public void StartPlayervsPlayer(Graphics g)
		{
			_Ready = true;
			stack_GetLocated = new Stack<BoardBox>();
			stack_Undo = new Stack<BoardBox>();
			_Turn = 1;
			_Mode = 1;
			O = X = P = C = 0;
			CreateArrayChess();
			DrawBoard(g);
		}

		public void StartPlayervsCom(Graphics g)
		{
			_Ready = true;
			stack_GetLocated = new Stack<BoardBox>();
			stack_Undo = new Stack<BoardBox>();
			_Turn = 1;
			_Mode = 2;
			O = X = P1 = P2 = 0;
			CreateArrayChess();
			DrawBoard(g);
			RunAICom(g);
		}
		#endregion

		#region Undo Redo
		public void Undo(Graphics g, Color clr)
		{
			if (stack_GetLocated.Count != 0 && _Ready == true)
			{
				BoardBox _BoardBox = stack_GetLocated.Pop();
				stack_Undo.Push(new BoardBox(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Location, _BoardBox.Own));
				if (_BoardBox.Own == 1)
				{
					_Board.DeleteChessO(g, _BoardBox.Location, clr);
					_Turn = 1;
					_ChessArrayBox[_BoardBox.Row, _BoardBox.Cell].Own = 0;
				}
				else if(_BoardBox.Own == 2)
				{
					_Board.DeleteChessX(g, _BoardBox.Location, clr);
					_Turn = 2;
					_ChessArrayBox[_BoardBox.Row, _BoardBox.Cell].Own = 0;
				}
			}
		}

		public void Redo(Graphics g)
		{
			if (stack_Undo.Count != 0)
			{
				BoardBox _BoardBox = stack_Undo.Pop();
				stack_GetLocated.Push(new BoardBox(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Location, _BoardBox.Own));
				if (_BoardBox.Own == 1)
				{
					_Board.DrawChessO(g, _BoardBox.Location);
					_Turn = 2;
					lbl.Text = "Đến lượt X đi.";
					_ChessArrayBox[_BoardBox.Row, _BoardBox.Cell].Own = 1;
				}
				else if (_BoardBox.Own == 2)
				{
					_Board.DrawChessX(g, _BoardBox.Location);
					_Turn = 1;
					lbl.Text = "Đến lượt O đi.";
					_ChessArrayBox[_BoardBox.Row, _BoardBox.Cell].Own = 2;
				}
			}
		}
		#endregion

		#region CheckEndGame
		public void EndGame()
		{
			switch (_END)
			{
				case 0:
					MessageBox.Show("Hòa cờ!");
					break;
				case 1:
					MessageBox.Show("Người chơi 1 thắng!");
					P1++;
					break;
				case 2:
					MessageBox.Show("Người chơi 2 thắng!");
					P2++;
					break;
				case 3:
					MessageBox.Show("Máy thắng!");
					C++;
					break;
				case 4:
					MessageBox.Show("Bạn thắng!");
					P++;
					break;
			}
			_Ready = false;
		}
		public bool CheckWin()
		{
			if (stack_GetLocated.Count == _Board.NumberofRow * _Board.NumberofCell)
			{
				_END = 0;
				return true;
			}
			foreach (BoardBox _BoardBox in stack_GetLocated)
			{
				if (CheckCell(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Own) || CheckRow(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Own)||CheckSidelongLR(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Own) ||CheckSidelongRL(_BoardBox.Row, _BoardBox.Cell, _BoardBox.Own))
				{
					if (_Mode == 1)
					{
						_END = _BoardBox.Own == 1 ? 1 : 2;
						return true;
					}
					else if (_Mode == 2)
					{
						_END = _BoardBox.Own == 1 ? 3 : 4;
						return true;
					}
				}
			}
			return false;
		}

		private bool CheckCell(int currentRow, int currentCell, int currentOwn)
		{
			if (currentRow > _Board.NumberofRow - 5)
			{
				return false;
			}
			int Count;

			for (Count = 1; Count < 5; Count++)
			{
				if (_ChessArrayBox[currentRow + Count, currentCell].Own != currentOwn)
				{
					return false;
				}
			}

			//if (currentRow == 0 || currentRow + Count == _Board.NumberofRow)
			//{
			//    return true;
			//}

			//if (_ChessArrayBox[currentRow -1, currentCell].Own == 0 || _ChessArrayBox[currentRow + Count, currentCell].Own == 0)
			//{
			//    return true;
			//}

			return true;
		}

		private bool CheckRow(int currentRow, int currentCell, int currentOwn)
		{
			if (currentCell > _Board.NumberofCell - 5)
			{
				return false;
			}
			int Count;

			for (Count = 1; Count < 5; Count++)
			{
				if (_ChessArrayBox[currentRow, currentCell + Count].Own != currentOwn)
				{
					return false;
				}
			}

			//if (currentCell == 0 || currentCell + Count == _Board.NumberofCell)
			//{
			//    return true;
			//}

			//if (_ChessArrayBox[currentRow, currentCell -1].Own == 0 || _ChessArrayBox[currentRow, currentCell + Count].Own == 0)
			//{
			//    return true;
			//}

			return true;
		}

		private bool CheckSidelongRL(int currentRow, int currentCell, int currentOwn)
		{
			if (currentRow < 4 || currentCell > _Board.NumberofCell - 5)
			{
				return false;
			}
			int Count;

			for (Count = 1; Count < 5; Count++)
			{
				if (_ChessArrayBox[currentRow - Count, currentCell + Count].Own != currentOwn)
				{
					return false;
				}
			}

			//if (currentRow == 0 || currentRow + Count == _Board.NumberofRow || currentCell == 0 || currentCell + Count == _Board.NumberofCell)
			//{
			//    return true;
			//}

			//if (_ChessArrayBox[currentRow - 1, currentCell - 1].Own == 0 || _ChessArrayBox[currentRow + Count, currentCell + Count].Own == 0)
			//{
			//    return true;
			//}

			return true;
		}

		private bool CheckSidelongLR(int currentRow, int currentCell, int currentOwn)
		{
			if (currentRow > _Board.NumberofRow - 5 || currentCell > _Board.NumberofCell - 5)
			{
				return false;
			}
			int Count;

			for (Count = 1; Count < 5; Count++)
			{
				if (_ChessArrayBox[currentRow + Count, currentCell + Count].Own != currentOwn)
				{
					return false;
				}
			}

			//if (currentRow == 4 || currentRow == _Board.NumberofRow - 1 || currentCell == 0 || currentCell + Count == _Board.NumberofCell)
			//{
			//    return true;
			//}

			//if (_ChessArrayBox[currentRow + 1, currentCell - 1].Own == 0 || _ChessArrayBox[currentRow - Count, currentCell + Count].Own == 0)
			//{
			//    return true;
			//}

			return true;
		}
		#endregion

		#region AI Works
		private long[] ArrayAttackLocate = new long[6] { 0, 64, 4096, 262144, 16777216, 1073741824 };
		private long[] ArrayDefenceLocate = new long[6] { 0, 64, 4096, 262144, 16777216, 1073741824 };

		public void RunAICom(Graphics g)
		{
			if (stack_GetLocated.Count == 0)
			{
				Random rd = new Random();
				int value = rd.Next(2, 5);
				int value2 = rd.Next(2, 5);
				PlayChess(_Board.NumberofRow / value * BoardBox._height + 1, _Board.NumberofCell/ value2 * BoardBox._width + 1, g);
			}
			else
			{
				BoardBox _BoardBox = FindLocate();
				PlayChess(_BoardBox.Location.X +1, _BoardBox.Location.Y + 1, g);
			}
		   
		}

		private BoardBox FindLocate()
		{
			BoardBox RightResult = new BoardBox();
			long MaxLocate = 0;
			for (int i = 0; i < _Board.NumberofRow; i++)
			{
				for (int j = 0; j < _Board.NumberofCell; j++)
				{
					if (_ChessArrayBox[i,j].Own==0)
					{
						long AttackLocate = AT_CheckCell(i,j) + AT_CheckRow(i, j) + AT_CheckSidelongLR(i, j) + AT_CheckSidelongRL(i, j);
						long DefenceLocate = DF_CheckCell(i, j) + DF_CheckRow(i, j) + DF_CheckSidelongLR(i, j) + DF_CheckSidelongRL(i, j);
						long TempLocate = AttackLocate > DefenceLocate ? AttackLocate : DefenceLocate;
						long _TotalLocate = (AttackLocate + DefenceLocate) > TempLocate ? (AttackLocate + DefenceLocate) : TempLocate;
						if (MaxLocate < _TotalLocate)
						{
							MaxLocate = _TotalLocate;
							RightResult = new BoardBox(_ChessArrayBox[i, j].Row, _ChessArrayBox[i, j].Cell, _ChessArrayBox[i, j].Location, _ChessArrayBox[i, j].Own);
						}
					}
				}
			}

			return RightResult;
		}

		#region Attack

		private long AT_CheckCell(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			if (crRow + 1 < _Board.NumberofRow && _ChessArrayBox[crRow + 1, crColumn].Own == 0)
			{

			}
			if (crRow > 0 && _ChessArrayBox[crRow - 1, crColumn].Own == 0)
			{

			}
			//
			Random rd1 = new Random();
			int v1 = rd1.Next(1, 3);
			for (int dem = v1; dem < 5 && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow + dem2 < _Board.NumberofRow; dem2++)
						if (_ChessArrayBox[crRow + dem2, crColumn].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow + dem2, crColumn].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crRow - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			if (_SoQD == 2)
				return 0;


			if (_SoQD == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT];
			////////////////////////////////
			if (_SoQD2 == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT2] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT2];
			///////////////////////
			if (_SoQT >= _SoQT2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			///////////////////////
			if (_SoQT == 4)
				_Diem_Tong *= 2;
			/////////////////////
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			////////////////////////
			if (_SoQT2 == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD2] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD2];
			return _Diem_Tong;
		}
		private long AT_CheckRow(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			if (crColumn + 1 < _Board.NumberofCell && _ChessArrayBox[crRow, crColumn + 1].Own == 0)
			{

			}
			if (crColumn > 0 && _ChessArrayBox[crRow, crColumn - 1].Own == 0)
			{

			}
			//
			Random rd2 = new Random();
			int v2 = rd2.Next(1, 3);
			for (int dem = v2; dem < 5 && crColumn + dem < _Board.NumberofCell; dem++)
			{
				if (_ChessArrayBox[crRow, crColumn + dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow, crColumn + dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn + dem2 < _Board.NumberofCell; dem2++)
						if (_ChessArrayBox[crRow, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow, crColumn - dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow, crColumn - dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			if (_SoQD == 2)
				return 0;
			if (_SoQD == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT];
			if (_SoQD2 == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT2] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT2];
			if (_SoQT >= _SoQT2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQT == 4)
				_Diem_Tong *= 2;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			if (_SoQT2 == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD2] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD2];
			return _Diem_Tong;
		}
		private long AT_CheckSidelongLR(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			if (crRow + 1 < _Board.NumberofRow && crColumn + 1 < _Board.NumberofCell && _ChessArrayBox[crRow + 1, crColumn + 1].Own == 0)
			{

			}
			if (crRow > 0 && crColumn > 0 && _ChessArrayBox[crRow - 1, crColumn - 1].Own == 0)
			{

			}
			//
			Random rd3 = new Random();
			int v3 = rd3.Next(1, 2);
			for (int dem = v3; dem < 5 && crColumn + dem < _Board.NumberofCell && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn + dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn + dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn + dem2 < _Board.NumberofCell && crRow + dem2 < _Board.NumberofRow; dem2++)
						if (_ChessArrayBox[crRow + dem2, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow + dem2, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0 && crRow - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn - dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn - dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 0 && crRow - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			if (_SoQD == 2)
				return 0;
			if (_SoQD == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT];
			if (_SoQD2 == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT2] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT2];
			if (_SoQT >= _SoQT2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;

			if (_SoQT == 4)
				_Diem_Tong *= 2;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			if (_SoQT2 == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD2] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD2];
			return _Diem_Tong;
		}
		private long AT_CheckSidelongRL(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			if (crRow > 0 && crColumn + 1 < _Board.NumberofCell && _ChessArrayBox[crRow - 1, crColumn + 1].Own == 0)
			{

			}
			if (crRow + 1 < _Board.NumberofRow && crColumn > 0 && _ChessArrayBox[crRow + 1, crColumn - 1].Own == 0)
			{

			}
			//
			Random rd4 = new Random();
			int v4 = rd4.Next(1, 2);
			for (int dem = v4; dem < 5 && crColumn + dem < _Board.NumberofCell && crRow - dem > 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn + dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn + dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn + dem2 < _Board.NumberofCell && crRow - dem2 > 0; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0 && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn - dem].Own == 1)
				{
					_SoQT++;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn - dem].Own == 2)
				{
					_SoQD++;
					break;
				}
				else // Own = 0
				{
					for (int dem2 = 1; dem2 < 6 && crColumn - dem2 >= 0 && crRow + dem2 < _Board.NumberofRow; dem2++)
						if (_ChessArrayBox[crRow + dem2, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
						}
						else if (_ChessArrayBox[crRow + dem2, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
							break;
						}
						else
							break;
					break;
				}
			}
			if (_SoQD == 2)
				return 0;
			if (_SoQD == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT];
			if (_SoQD2 == 0)
				_Diem_Tong += ArrayAttackLocate[_SoQT2] * 2;
			else
				_Diem_Tong += ArrayAttackLocate[_SoQT2];
			if (_SoQT >= _SoQT2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQT == 4)
				_Diem_Tong *= 2;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			if (_SoQT2 == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD2] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD2];
			return _Diem_Tong;
		}

		#endregion

		#region Defence

		private long DF_CheckCell(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			for (int dem = 1; dem < 5 && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow + dem2 < _Board.NumberofRow; dem2++)
						if (_ChessArrayBox[crRow + dem, crColumn].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow + dem, crColumn].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crRow - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			if (_SoQT == 2)
				return 0;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			/* 
			if (_SoQT2 == 0)
				_Diem_Tong += _MD_PT[_SoQD2] * 2;
			else
				_Diem_Tong += _MD_PT[_SoQD2];
			*/
			if (_SoQD >= _SoQD2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQD == 4)
				_Diem_Tong *= 2;
			return _Diem_Tong;
		}
		private long DF_CheckRow(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			for (int dem = 1; dem < 5 && crColumn + dem < _Board.NumberofCell; dem++)
			{
				if (_ChessArrayBox[crRow, crColumn + dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow, crColumn + dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn + dem2 < _Board.NumberofCell; dem2++)
						if (_ChessArrayBox[crRow, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow, crColumn - dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow, crColumn - dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
						}
						else break;
					break;
				}
			}
			if (_SoQT == 2)
				return 0;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			/* 
			if (_SoQT2 == 0)
				_Diem_Tong += _MD_PT[_SoQD2] * 2;
			else
				_Diem_Tong += _MD_PT[_SoQD2];
			*/
			if (_SoQD >= _SoQD2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQD == 4)
				_Diem_Tong *= 2;
			return _Diem_Tong;
		}
		private long DF_CheckSidelongLR(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			for (int dem = 1; dem < 5 && crColumn + dem < _Board.NumberofCell && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn + dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn + dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow + dem2 < _Board.NumberofRow && crColumn + dem2 < _Board.NumberofCell; dem2++)
						if (_ChessArrayBox[crRow + dem2, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow + dem2, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0 && crRow - dem >= 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn - dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn - dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 0 && crRow - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			if (_SoQT == 2)
				return 0;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			/* 
			if (_SoQT2 == 0)
				_Diem_Tong += _MD_PT[_SoQD2] * 2;
			else
				_Diem_Tong += _MD_PT[_SoQD2];
			*/
			if (_SoQD >= _SoQD2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQD == 4)
				_Diem_Tong *= 2;
			return _Diem_Tong;
		}
		private long DF_CheckSidelongRL(int crRow, int crColumn)
		{
			long _Diem_Tong = 0;
			int _SoQT = 0;
			int _SoQD = 0;
			int _SoQT2 = 0;
			int _SoQD2 = 0;
			for (int dem = 1; dem < 5 && crColumn + dem < _Board.NumberofCell && crRow - dem > 0; dem++)
			{
				if (_ChessArrayBox[crRow - dem, crColumn + dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow - dem, crColumn + dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 0 && crColumn + dem2 < _Board.NumberofCell; dem2++)
						if (_ChessArrayBox[crRow - dem2, crColumn + dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow - dem2, crColumn + dem2].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			for (int dem = 1; dem < 5 && crColumn - dem >= 0 && crRow + dem < _Board.NumberofRow; dem++)
			{
				if (_ChessArrayBox[crRow + dem, crColumn - dem].Own == 1)
				{
					_SoQT++;
					break;
				}
				else if (_ChessArrayBox[crRow + dem, crColumn - dem].Own == 2)
				{
					_SoQD++;
				}
				else // Own = 0
				{
					for (int dem2 = 2; dem2 < 6 && crRow + dem2 < _Board.NumberofRow && crColumn - dem2 >= 0; dem2++)
						if (_ChessArrayBox[crRow + dem2, crColumn - dem2].Own == 1)
						{
							_SoQT2++;
							break;
						}
						else if (_ChessArrayBox[crRow + dem2, crColumn - dem2].Own == 2)
						{
							_SoQD2++;
						}
						else
							break;
					break;
				}
			}
			if (_SoQT == 2)
				return 0;
			if (_SoQT == 0)
				_Diem_Tong += ArrayDefenceLocate[_SoQD] * 2;
			else
				_Diem_Tong += ArrayDefenceLocate[_SoQD];
			/* 
			if (_SoQT2 == 0)
				_Diem_Tong += _MD_PT[_SoQD2] * 2;
			else
				_Diem_Tong += _MD_PT[_SoQD2];
			*/
			if (_SoQD >= _SoQD2)
				_Diem_Tong -= 1;
			else
				_Diem_Tong -= 2;
			if (_SoQD == 4)
				_Diem_Tong *= 2;
			return _Diem_Tong;
		}

		#endregion

		#endregion
	}
}
