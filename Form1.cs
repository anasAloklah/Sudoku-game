using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EasyGame easy;
        MediumGame medium;
        HardGame hard;
        public TextBox[,] getAraayText ()
        {
             TextBox[,] arrayText = new TextBox[,]
            {
                {x11,x12,x13,x14,x15,x16,x17,x18,x19,},
                {x21,x22,x23,x24,x25,x26,x27,x28,x29,},
                {x31,x32,x33,x34,x35,x36,x37,x38,x39,},
                {x41,x42,x43,x44,x45,x46,x47,x48,x49,},
                {x51,x52,x53,x54,x55,x56,x57,x58,x59,},
                {x61,x62,x63,x64,x65,x66,x67,x68,x69,},
                {x71,x72,x73,x74,x75,x76,x77,x78,x79,},
                {x81,x82,x83,x84,x85,x86,x87,x88,x89,},
                {x91,x92,x93,x94,x95,x96,x97,x98,x99,},
            };

             return arrayText;
        }

        public TextBox[,] iniTextBox()
        {
            TextBox[,] arrayText = getAraayText();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    arrayText[i, j].MaxLength = 1;
                    arrayText[i, j].ReadOnly = false;
                    arrayText[i, j].Text = "";
                }
            return arrayText;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            TextBox[,] arrayText = iniTextBox();
            string selcted="";
                 selcted = comboBox1.SelectedItem.ToString();
            if (selcted.Equals("Easy"))
            {
                easy = new EasyGame();
                showTable(easy);
            }
            else if (selcted.Equals("Medium"))
            {
                medium = new MediumGame();
                showTable(medium);
            }
            else if (selcted.Equals("Hard"))
            {
                hard = new HardGame();
                showTable(hard);
            }
            button2.Enabled = true;
            button3.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

           

            string selcted = "";
            selcted = comboBox1.SelectedItem.ToString();
            if (selcted.Equals("Easy"))
            {
                copy(easy);
                validation(easy);
            }
            else if (selcted.Equals("Medium"))
            {
                copy(easy);
                validation(medium);
            }
            else if (selcted.Equals("Hard"))
            {
                copy(easy);
                validation(hard);
            }
            

        }

         public void copy (game value)
        {
             int[,] su_in = new int[9, 9];
            TextBox[,] arrayText = getAraayText(); 
             for (int i = 0; i < 9; i++)
                 for (int j = 0; j < 9; j++)
                 {
                     //textBox1.Text=+ easy.su_in[i][j];
                     if (arrayText[i, j].Text.Equals(""))
                     {
                         //arrayText[i, j].Text = su_in[i, j].ToString();
                         value.su_in[i, j] = 0;

                     }
                     else
                     {
                         value.su_in[i, j] = int.Parse(arrayText[i, j].Text);
                     }
                 }
        }

        public void validation (game value)
        {
            bool valid= value.check();
            if (valid)
            {
                MessageBox.Show("you win");
            }
            else
            {
                MessageBox.Show("you lost");
            }
        }

        public void showTable(game value)
        {
            TextBox[,] arrayText = getAraayText();
            int[,] su_in = value.getArray();
            for (int i=0;i<9;i++)
                for ( int j=0;j<9;j++)
                {
                    //textBox1.Text=+ easy.su_in[i][j];
                    if (value.su_in[i, j] != 0)
                    {
                        arrayText[i, j].Text = su_in[i, j].ToString();
                        arrayText[i, j].ReadOnly = true;
                    }
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selcted = "";
            selcted = comboBox1.SelectedItem.ToString();
            if (selcted.Equals("Easy"))
            {
                solving(easy);
            }
            else if (selcted.Equals("Medium"))
            {
                solving(medium);
            }
            else if (selcted.Equals("Hard"))
            {
                solving(hard);
            }
        }

        public void solving (game value)
        {
            value.solve(0, 0);
            TextBox[,] arrayText = getAraayText();
            int[,] su_in = value.getArray();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    //textBox1.Text=+ easy.su_in[i][j];
                    if (value.su_in[i, j] != 0)
                    {
                        arrayText[i, j].Text = su_in[i, j].ToString();
                        arrayText[i, j].ReadOnly = true;
                    }
                }
        }
       
    }
}
