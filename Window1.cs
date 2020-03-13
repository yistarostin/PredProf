using System;
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
        ConnectionWIthDataBase connect = new ConnectionWIthDataBase();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.FormClosing += Window1_Closing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ConnectionWIthDataBase.DocumentNameAndIsSigned> documents = new List<ConnectionWIthDataBase.DocumentNameAndIsSigned>();
            documents = connect.GetAllDocumentsNames();
            string s;
            string s2;
            foreach (ConnectionWIthDataBase.DocumentNameAndIsSigned i in documents)
            {
                if (i.isFullySigned == true)
                {
                    s2 = "подписан";
                }
                else
                {
                    s2 = "неподписан";
                }
                s = i.name + ", " + s2;
                comboBox1.Items.Add(s);
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
            
            int x = comboBox1.SelectedIndex; //имя выбранного документа. надо поменять на инлекс выбранного, который является праймари-ключом
            obj1.buffer = x;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.SetChoosenDocument(obj1.buffer);
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

