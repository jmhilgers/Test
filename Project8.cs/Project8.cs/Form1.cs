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
        public Form1()
        {
            InitializeComponent();

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

                    //don't put this here - but this is how you would add a piece
                    /*if (j % 2 == 0)
                    {
                        _grid[i, j].Image = Properties.Resources.blackCircle;
                    }
                    else
                    {
                        _grid[i, j].Image = Properties.Resources.redCircle;
                    }*/

                    this.Controls.Add(_grid[i, j]);

                    xPos += 74;
                }

                yPos += 73;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
