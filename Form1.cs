﻿using System;
using System.Windows.Forms;

namespace AlifCalcv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string number = "";
        static double x = 0;
        static double y = 0;
        static char function = ' ';
        static bool resultClicked = false;
        static double memory = 0;

        private void Num_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            number += btn.Text;
            PanelTBox.Text = number;
        }

        private void BackspaceBtn_Click(object sender, EventArgs e)
        {
            char[] nums = number.ToCharArray();
            number = "";
            for (int i = 0; i < nums.Length - 1; i++)
            {
                number += nums[i];
            }
            PanelTBox.Text = number;
        }

        private void ClearElementBtn_Click(object sender, EventArgs e)
        {
            number = "";
            y = 0;
            PanelTBox.Text = "0";
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            number = "";
            y = 0;
            x = 0;
            PanelTBox.Text = "0";
        }

        private void Function_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (x == 0 && !resultClicked)
            {
                x = double.Parse(number);
                number = "";
            }
            else if (!resultClicked)
            {
                try
                {
                    y = double.Parse(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка");
                }
                number = "";
                technique();
            }
            function = char.Parse(btn.Text);
            resultClicked = false;
        }

        private void technique()
        {
            switch (function)
            {
                case '+':
                    {
                        x += y;
                    }
                    break;
                case '/':
                    {
                        x /= y;
                    }
                    break;
                case '*':
                    {
                        x *= y;
                    }
                    break;
                case '-':
                    {
                        x -= y;
                    }
                    break;
            }
            function = ' ';
            PanelTBox.Text = x.ToString();
        }

        private void ResultBtn_Click(object sender, EventArgs e)
        {
            resultClicked = true;
            if (function != ' ')
            {
                try
                {
                    y = double.Parse(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка");
                }
                number = "";
                technique();
            }
            else
            {
                y = 0;
                number = "";
                PanelTBox.Text = x.ToString();
            }
        }

        private void SqrtBtn_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                x = Math.Sqrt(double.Parse(number));
                PanelTBox.Text = x.ToString();
            }
            else
            {
                y = Math.Sqrt(double.Parse(number));
                PanelTBox.Text = y.ToString();
            }
            number = "";
        }

        private void OnOneBtn_Click(object sender, EventArgs e)
        {
                x = 1 / double.Parse(number);
                number = "";
                PanelTBox.Text = x.ToString();
        }

        private void ProcBtn_Click(object sender, EventArgs e)
        {
            y = x / 100 * double.Parse(number);
            number = "";
            PanelTBox.Text = y.ToString();
        }

        private void McBtn_Click(object sender, EventArgs e)
        {
            memory = 0;
            PanelTBox.Text = "Завершен!";
        }

        private void MsBtn_Click(object sender, EventArgs e)
        {
            PanelTBox.Text = memory.ToString();
            number = memory.ToString();
        }

        private void MpBtn_Click(object sender, EventArgs e)
        {
            PanelTBox.Text = "0";
            memory += double.Parse(number);
            number = "";
        }

        private void MmBtn_Click(object sender, EventArgs e)
        {
            PanelTBox.Text = "0";
            memory -= double.Parse(number);
            number = "";
        }

        private void PlusMinusBtn_Click(object sender, EventArgs e)
        {
            double q = double.Parse(number);
            if (q > 0)
            {
                char[] z = number.ToCharArray();
                number = "-";
                for (int i = 0; i < z.Length; i++)
                {
                    number += z[i];
                }
            }
            else if (q < 0)
            {
                char[] z = number.ToCharArray();
                number = "";
                for (int i = 1; i < z.Length; i++)
                {
                    number += z[i];
                }
            }
            PanelTBox.Text = number;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
