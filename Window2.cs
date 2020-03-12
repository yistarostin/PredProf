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
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            List<string> people = new List<string>() { "Шилов Владлен Львович 25.05.1989 - подписал", "Гребневский Станислав Станиславович 07.09.1960 - подписал", "Белов Радислав Иванович 02.11.1958 - не подписал" };
            names.AddRange(people.ToArray());
            textBox2.AutoCompleteCustomSource = names;
            textBox2.AutoCompleteMode = AutoCompleteMode.None;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;
            this.FormClosing += Window2_Closing;
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
            textBox1.Text = vasia.NameOfDocument();
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Window2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            string s = "Годовой бухгалтерский отчет (2019)";
            return s;
       }
       
    }

}
