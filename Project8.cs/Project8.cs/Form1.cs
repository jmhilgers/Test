﻿using System;
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
                if(bd.IsWinner(bd.Turn))
                {
                    MessageBox.Show(bd.Turn + "'s Wins.");
                }
                else if (bd.CheckTie())
                {
                    MessageBox.Show("Tie game.");
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

        private void NewGame(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            for(int i = 0; i < 6; i++)
            {
                for (int j =0; j<7; j++)
                {
                    _grid[i, j].Image = null;
                }
            }
            
            }
                    
        }
    }

