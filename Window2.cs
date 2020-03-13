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
        ConnectionWIthDataBase connect = new ConnectionWIthDataBase();
        public Form2()
        {
            InitializeComponent();
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

            textBox1.Text = connect.GetChoosenDocumentInfo();
            /*foreach(ConnectionWIthDataBase.EmployeeNameAndBirthDay person in people)
            {
                 string s = person.name + ", " + person.birthday;
                 textBox2.Text += s + Environment.NewLine + Environment.NewLine;
             }*/
            textBox2.Text += ("Отдел: " + ConnectionWIthDataBase.ChoosenDocument.Department + Environment.NewLine + "Минимальный уровень доступа: " 
                + ConnectionWIthDataBase.ChoosenDocument.SecurityLevel.ToString() + Environment.NewLine + "Требуется подписей: "
                + ConnectionWIthDataBase.ChoosenDocument.NumberOfSigned.ToString() + Environment.NewLine + "Подписали: " +
                ConnectionWIthDataBase.ChoosenDocument.EmployeesWhoSigned);

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

}
