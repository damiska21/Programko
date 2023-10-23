using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace list_box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            string item = (string)listBox2.SelectedItem;
            if (item == null) { return; }
            listBox2.Items.Remove(item);
            listBox1.Items.Add(item);
            label1.Text = "Počet: " + listBox1.Items.Count;
            label2.Text = "Počet: " + listBox2.Items.Count;
            listBox1.SelectedIndex = listBox1.Items.Count -1;
        }

        private void button1_Click(object sender, EventArgs e)//nahoru levého
        {
            if (listBox1.SelectedIndex != 0)
            {
                int index = listBox1.SelectedIndex;
                string item = (string)listBox1.SelectedItem;
                if (item == null) { return; }
                listBox1.Items.Remove(item);
                listBox1.Items.Insert(index -1, item);
                listBox1.SelectedIndex = index-1;
                button2.Enabled = true;
                if (index -1 == 0)
                {
                    button1.Enabled = false;
                }
            }
            else { button1.Enabled = false; }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
            {
                button1.Enabled = true;
            }
            if (listBox1.SelectedIndex != listBox1.Items.Count-1)
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) // první dolů
        {
            if (listBox1.SelectedIndex != listBox1.Items.Count-1)
            {
                int index = listBox1.SelectedIndex;
                string item = (string)listBox1.SelectedItem;
                if (item == null) {return;}
                listBox1.Items.Remove(item);
                listBox1.Items.Insert(index +1, item);
                listBox1.SelectedIndex = index+1;
                button1.Enabled=true;
                if (index+1 == listBox1.Items.Count-1)
                {
                    button2.Enabled = false;
                }
            }else { button2.Enabled = false; }
            
        }

        private void button3_Click(object sender, EventArgs e) //2 nahorů
        {
            if (listBox2.SelectedIndex != 0)
            {
                int index = listBox2.SelectedIndex;
                string item = (string)listBox2.SelectedItem;
                if (item == null) { return; }
                listBox2.Items.Remove(item);
                listBox2.Items.Insert(index - 1, item);
                listBox2.SelectedIndex = index - 1;
                if (index - 1 == 0)
                {
                    button3.Enabled = false;
                }
            }
            else { button3.Enabled = false; }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != listBox2.Items.Count-1)
            {
                int index = listBox2.SelectedIndex;
                string item = (string)listBox2.SelectedItem;
                if (item == null) { return; }
                listBox2.Items.Remove(item);
                listBox2.Items.Insert(index + 1, item);
                listBox2.SelectedIndex = index + 1;

                if (index + 1 == listBox2.Items.Count - 1)
                {
                    button4.Enabled = false;
                }
            }
            else { button4.Enabled = false; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string item = (string)listBox1.SelectedItem;
            if (item == null) { return; }
            listBox1.Items.Remove(item);
            listBox2.Items.Add(item);
            label1.Text = "Počet: " + listBox1.Items.Count;
            label2.Text = "Počet: " + listBox2.Items.Count;
            listBox2.SelectedIndex = listBox2.Items.Count - 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
            label1.Text = "Počet: " + listBox1.Items.Count;
            label2.Text = "Počet: " + listBox2.Items.Count;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
            label1.Text = "Počet: " + listBox1.Items.Count;
            label2.Text = "Počet: " + listBox2.Items.Count;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            label1.Text = "Počet: " + listBox1.Items.Count;
            label2.Text = "Počet: " + listBox2.Items.Count;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != 0)
            {
                button3.Enabled = true;
            }
            if (listBox2.SelectedIndex != listBox1.Items.Count - 1)
            {
                button4.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
