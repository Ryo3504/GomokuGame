using System;
using System.Windows.Forms;

namespace CaroGame
{
	public partial class OptionPvC : Form
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public OptionPvC()
		{
			InitializeComponent();
		}

		private void OptionPvC_Load(object sender, EventArgs e)
		{
		}
		#region Check Com Or Player
		/// <summary>
		/// Check Computer Player
		/// </summary>
		/// <returns>True/False</returns>
		public bool ComOrPlayer()
		{
			if (CGFRadioButton.Checked == true)
			{
				return true;
			}
			else if (PGFRadioButton.Checked == true)
			{
				CGFRadioButton.Checked = false;
				PGFRadioButton.Checked = true;
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region Button Event
		/// <summary>
		/// This is a Test For Ver 1.1, Maybe This Setting Not Working
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">EventArgs</param>
		private void AcceptButton_Click(object sender, EventArgs e)
		{
			if (ComOrPlayer())
			{
				if (MessageBox.Show("You want Computer go First?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Close();
				}
			}
			else
			{
				if (MessageBox.Show("You want Player go First?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Close();
				}
			}
		}

		/// <summary>
		/// This is a Test For Ver 1.1, Maybe Not Work
		/// </summary>
		/// <param name="sender">Object</param>
		/// <param name="e">EventArgs</param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You really want to exit this Option (default com will go first),don't you?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}
		#endregion
	}
}
