using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace mobilya
{
    public partial class Form1 : Form
    {
        int lang = 1;
        bool caps = true;
        Button[] buttons, T9_but;
        string file;
        public Form1()
        {
            InitializeComponent();
            T9_but = new Button[] { button35, button36, button37 };
            file = File.ReadAllText("text.txt");
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11,
            button12, button13, button14, button15, button16, button17,  button18, button19, button20, button21, button22, button23, button24,
            button25, button26, button29, button31, button32, button33, button34, button35, button36, button37, button38, button39};
            Text = Convert.ToInt32('A').ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button29 == button)
                richTextBox1.Text += " ";
            else if (button32 == button)
                richTextBox1.Text += "\n";
            else
            {
                richTextBox1.Text += button.Text;
                if (caps == true)
                    foreach (Button x in buttons)
                    {
                        if (x == button29 || x == button31 || x == button32 || x == button33)
                            continue;
                        x.Text = Convert.ToChar(Convert.ToInt32(x.Text[0]) + 32).ToString();
                    }
            }
            caps = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!caps)
            {
                caps = true;
                foreach (Button x in buttons)
                {
                    if (x == button29 || x == button31 || x == button32 || x == button33)
                        continue;
                    x.Text = Convert.ToChar(Convert.ToInt32(x.Text[0]) - 32).ToString();
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
                return;
            else
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
                if (richTextBox1.Text.Length == 0)
                    button27_Click(sender, e);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = file.Split('\n');
            Text = words[0];
            string[] buf = richTextBox1.Text.Split(' ');
            List<string> t9 = new List<string> { };
            foreach (string word in words)
                if (word.Contains(buf[buf.Length - 1]) && word != buf[buf.Length - 1])
                    t9.Add(word);
            button35.Text = "";
            button36.Text = "";
            button37.Text = "";
            for (int i = 0; i < t9.Count; i++)
                T9_but[i].Text = t9[i];
            if (button35.Text == "" && button36.Text == "" && button37.Text == "")
                button36.Text = buf[buf.Length - 1];
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (lang == 1)
            {
                foreach (Button x in buttons)
                {
                    if (x == button29 || x == button31 || x == button32 || x == button33)
                        continue;
                    x.Text = Convert.ToChar(Convert.ToInt32(x.Text[0]) + 975).ToString();
                }
                lang = 0;
            }
            else
            {
                foreach (Button x in buttons)
                {
                    if (x == button29 || x == button31 || x == button32 || x == button33)
                        continue;
                    x.Text = Convert.ToChar(Convert.ToInt32(x.Text[0]) - 975).ToString();
                }
                lang = 1;
            }
        }

        private void T9_word(object sender, EventArgs e)
        {
            string[] buf = richTextBox1.Text.Split(' ');
            if (button36.Text == buf[buf.Length - 1] && !file.Contains(buf[buf.Length - 1]))
            {
                File.AppendAllText("text.txt", '\n' + buf[buf.Length - 1]);
                return;
            }
            Button button = (Button)sender;
            buf[buf.Length - 1] = button.Text;
            richTextBox1.Text = "";
            foreach (string x in buf)
                richTextBox1.Text += x + " ";
        }
    }
}
