﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form
    {
        buff obj1 = new buff();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.FormClosing += Window1_Closing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> people = new List<string>() { "Договор о покупке по форме ТОРГ-12", "Договор о приеме сотрудника на работу (Т-1)", "Договор аренды помещения", "Годовой бухгалтерский отчет (2019)" };
            foreach (string i in people)
            {
                comboBox1.Items.Add(i);
            }
        }

     
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string x = comboBox1.SelectedItem.ToString(); //имя выбранного документа
            obj1.buffer = x;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = obj1.buffer;
            //на этой строке нужно передать result в твою функцию
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
        }
        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }
        
        }
   
}

