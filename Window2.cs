using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlServerCe;

namespace Ex1
{
    public partial class Form2 : Form
    {
        Employer vasia = new Employer();
        public Form2()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            List<string> people = new List<string>() { "Уругвай", "Эквадор" };
            foreach (string i in people)
            {
                names.Add(i);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Employer> people = new List<Employer>();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = vasia.NameOfDocument();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Escape_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void YES_Click(object sender, EventArgs e)
        {
            this.Hide();
            Window3 newForm = new Window3();
            newForm.Show();
        }
    }
    public partial class Employer
    {
       public string FIO; 
       public string DB;
       public string Depart;
       public string Position;
       public int admiss;
       public int id;
        public int score;
       
       public string NameOfDocument()//возвращает значение документа, который нужно подписать
       {
            string s = "document";
            return s;
       }
       
    }

}
