using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        // ??? ????? ???????? ???????? ??????????
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // 1. ??? ????? ??? ???? ?????? ??????? ????? (0-9 ????? .)
        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || isOperationPerformed)
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            // ??? ????????? ??????? ?????????
            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
        }

        // 2. ???????? ??????????? (+, -, *, /)
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0 && !isOperationPerformed)
            {
                buttonEquals_Click(sender, e);
                operationPerformed = button.Text;
                label1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox1.Text);
                label1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        // 3. ?????? (=) ????????
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(textBox1.Text) != 0)
                    {
                        textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("??? ?????? ????????!");
                    }
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox1.Text);
            label1.Text = "";
            isOperationPerformed = true;
        }

        // 4. C (??? ????? ????????)
        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            label1.Text = "";
        }

        // 5. CE (???? ????? ??? ????? ????????)
        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // 6. Backspace (??? ??????? ??????)
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "" || textBox1.Text == "-")
            {
                textBox1.Text = "0";
            }
        }

        // 7. ?????? (sqrt) ????? ???? (%) ?????????
        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            double val = Double.Parse(textBox1.Text);
            textBox1.Text = Math.Sqrt(val).ToString();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            double val = Double.Parse(textBox1.Text);
            textBox1.Text = (resultValue * (val / 100)).ToString();
        }

        // ??????????? ?????????? ?????? ?????? ????????
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button21_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
    }
}