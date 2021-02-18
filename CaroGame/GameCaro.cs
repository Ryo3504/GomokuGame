using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame
{
	public partial class GameCaro : Form
	{
		#region Constructor
		/// <summary>
		/// Call Model
		/// </summary>
		private CaroChess _CaroChess;
		private Graphics _Graphics;
		int x = 0, y = 0, a = 1;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public GameCaro()
		{
			InitializeComponent();
			_CaroChess = new CaroChess();
			_CaroChess.CreateArrayChess();
			_Graphics = BoardPanel.CreateGraphics();
		}

		/// <summary>
		/// Constructor Loading Information
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">EventArgs</param>
		private void GameCaro_Load(object sender, EventArgs e)
		{
			StringLabel.Text = ("Chào mừng bạn đã đến với game\ncờ caro!") + Environment.NewLine + ("- Luật chơi:Bên nào đi 5 con trên \nmột hàng trước là chiến thắng!") + Environment.NewLine + ("- O đi trước,X đi sau") + Environment.NewLine + ("♠Game made by Lý Công Danh♣") + Environment.NewLine + ("-----------Lớp 14DTH09-----------");
			StringTimer.Enabled = true;
		}

		/// <summary>
		/// Spring Timer Work
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StringTimer_Tick(object sender, EventArgs e)
		{
			//Only up
			//StringLabel.Location= new Point(StringLabel.Location.X,StringLabel.Location.Y -1);
			//if(StringLabel.Y+StringLabel.Height<=0)
			//{ 
			//  StringLabel.Location = new Point(StringLabel.Location.X,StringPanel.Height)
			//}
			//Only Down
			//StringLabel.Location = new Point(StringLabel.Location.X, StringLabel.Location.Y + 1);
			//if (StringLabel.Location.Y + StringLabel.Height > 300)
			//{
			//    StringLabel.Location = new Point(0, 0);
			//}
			//Two Way
			try
			{
				y += a;
				StringLabel.Location = new Point(x, y);
				if (y >= 62)
				{
					a = -1;
				}
				if (y <= 0)
				{
					a = 1;
				}
			}
			catch (Exception)
			{ }
		}

		/// <summary>
		/// Drawing Board
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">PaintEventArgs</param>
		private void BoardPanel_Paint(object sender, PaintEventArgs e)
		{
			_CaroChess.DrawBoard(_Graphics);
			_CaroChess.DrawNewChess(_Graphics);
		}
		#endregion

		#region Undo, Redo Action
		/// <summary>
		/// Undo Action
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">EventArgs</param>
		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_CaroChess.Mode == 1)
			{
				_CaroChess.Undo(_Graphics, BoardPanel.BackColor);
				if (_CaroChess.Turn == 1)
					_CaroChess.O--;
				else
					_CaroChess.X--;
			}
			else
			{
				_CaroChess.Undo(_Graphics, BoardPanel.BackColor);
				_CaroChess.Undo(_Graphics, BoardPanel.BackColor);
				_CaroChess.O--;
				_CaroChess.X--;
			}
		}

		/// <summary>
		/// Undo Action
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">EventArgs</param>
		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_CaroChess.Mode == 1)
			{
				_CaroChess.Redo(_Graphics);
			}
			else
			{
				_CaroChess.Redo(_Graphics);
				_CaroChess.Redo(_Graphics);
			}
		}
		#endregion

		#region Button Event
		/// <summary>
		/// Create New Game: Player vs Com
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayerXComButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to play a new game (PvC)?","Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_Graphics.Clear(BoardPanel.BackColor);
				_CaroChess.StartPlayervsCom(_Graphics);
			}
		}

		/// <summary>
		/// Create New Game: Player vs Player
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayerXPlayerButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to play a new game (PvP)?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_Graphics.Clear(BoardPanel.BackColor);
				_CaroChess.StartPlayervsPlayer(_Graphics);
			}
		}

		/// <summary>
		/// Exit Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to Exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}
		#endregion

		# region Tool Strip Menu Event
		/// <summary>
		/// Tool Strip Menu Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void playerXComToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to play a new game (PvC)?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_Graphics.Clear(BoardPanel.BackColor);
				_CaroChess.StartPlayervsCom(_Graphics);
			}
		}

		/// <summary>
		/// Tool Strip Menu Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void playerXPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to play a new game (PvP)?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_Graphics.Clear(BoardPanel.BackColor);
				_CaroChess.StartPlayervsPlayer(_Graphics);
			}
		}

		/// <summary>
		/// Tool Strip Menu Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void optionPvCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new OptionPvC().ShowDialog();
		}
		#endregion

		#region Mouse Click Event Action
		/// <summary>
		/// Mouse Event => For First Player Create
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BoardPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (!_CaroChess.Ready)
			{
				return;
			}
			if (_CaroChess.PlayChess(e.X, e.Y, _Graphics))
			{
				if (_CaroChess.CheckWin())
				{
					_CaroChess.EndGame();
				}
				else
				{
					if (_CaroChess.Mode == 2)
					{
						_CaroChess.RunAICom(_Graphics);
						if (_CaroChess.CheckWin())
						{
							_CaroChess.EndGame();
						}
					}
				}
			}
		}
		#endregion
	}
}
