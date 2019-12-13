using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project8.cs
{

    public partial class Form1 : Form
    {
        private PictureBox[,] _grid = new PictureBox[6, 7];
        private Button[] colbuttons;
        private Board bd;
        /// <summary>
        /// This class represents the GUI.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            bd = new Board();
            colbuttons = new Button[7];
            colbuttons[0] = button1;
            colbuttons[1] = button2;
            colbuttons[2] = button3;
            colbuttons[3] = button4;
            colbuttons[4] = button5;
            colbuttons[5] = button6;
            colbuttons[6] = button7;

            int yPos = 58;
            for (int i = 0; i < 6; i++)
            {
                int xPos = 13;
                for (int j = 0; j < 7; j++)
                {
                    _grid[i, j] = new PictureBox();
                    _grid[i, j].Size = new Size(68, 68);
                    _grid[i, j].Location = new Point(xPos, yPos);
                    _grid[i, j].BorderStyle = BorderStyle.FixedSingle;

                    Controls.Add(_grid[i, j]);

                    xPos += 74;
                }

                yPos += 73;
            }
        }
        /// <summary>
        /// This method allows for the player to select the column in which they want to place their move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickColumn(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int col = -1;
            for (int i =0; i<colbuttons.Length; i++)
            {
               if ( colbuttons[i] == clicked)
                {
                    col = i;
                    break;
                }
            }

            if (bd.Move(col))
            {
                int row = bd.getRow(col);
                if (bd.Turn == PieceColor.black)
                {
                    _grid[row + 1, col].Image = Properties.Resources.blackCircle;
                }
                else
                {
                    _grid[row +1, col].Image = Properties.Resources.redCircle;
                }
                if (bd.IsWinner(bd.Turn))
                {
                    MessageBox.Show(bd.Turn + "'s Wins.");
                    for(int i =0; i<7; i++)
                    {
                        colbuttons[i].Enabled = false;
                    }
                }
                else if (bd.CheckTie())
                {
                    MessageBox.Show("Tie game.");
                    for (int i = 0; i < 7; i++)
                    {
                        colbuttons[i].Enabled = false;
                    }
                }
                else
                {
                    for (int i =0; i < 6; i++)
                    {
                        PieceColor color = bd.GetColor(i, col);
                        if (color == PieceColor.red)
                        {
                            _grid[i, col].Image = Properties.Resources.redCircle;
                           
                        }
                        else if ( color == PieceColor.black)
                        {
                            _grid[i, col].Image = Properties.Resources.blackCircle;
                        }
                        else
                        {
                            _grid[i, col].Image = null;
                        }
                    }
                    bd.SwitchTurns();
                    label1.Text = (bd.Turn + "'s Turn");

                }
            }

        }
        /// <summary>
        /// This method allows for the user to clear the board and begin a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            for(int i = 0; i < 6; i++)
            {
                for (int j =0; j<7; j++)
                {
                    _grid[i, j].Image = null;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;

                }
            }
            bd = new Board();
            }
                    
        }
    }

