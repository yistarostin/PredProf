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
    public partial class Window3 : Form
    {
        string res;
        ConnectionWIthDataBase connect = new ConnectionWIthDataBase();
        buff obj1 = new buff();
        public Window3()
        {
            InitializeComponent();
            List<ConnectionWIthDataBase.EmployeeNameAndBirthDay> people = connect.GetAllEmployees();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            foreach(ConnectionWIthDataBase.EmployeeNameAndBirthDay person in people)
            {
                source.Add(person.name + ", " +person.birthday);
            }
            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.TextChanged += textBox1_TextChanged;
            this.FormClosing += Window3_Closing;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Escape_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void YES_Click(object sender, EventArgs e)
        {
            res = obj1.Name; //имя алкаша
            DialogResult result = MessageBox.Show(//открытие окна 4
                 "Вставьте флеш-накопитель, содержащий вашу подпись",
                 "Сообщение",
                 MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.OK) // открытие варианций окон 5
            {
                if (obj1.CheckFlesh() == 0)//окно 5.1
                {
                    DialogResult result2 = MessageBox.Show(
                    "Ваши права подтверждены, подпись успешно поставлена",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result2 == DialogResult.OK)
                    {
                        this.Hide();
                        Window3 newForm = new Window3();
                        newForm.Show();
                    }
                }
                if (obj1.CheckFlesh() == 1)//окно 5.2
                {
                    DialogResult result2 = MessageBox.Show(
                    "Ваши права не подтверждены",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result2 == DialogResult.OK)
                    {
                        this.Hide();
                        Window3 newForm = new Window3();
                        newForm.Show();
                    }
                }
                if (obj1.CheckFlesh() == -1)//окно 5.3
                {
                    DialogResult result2 = MessageBox.Show(
                    "Флеш-карта не прочитана",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result2 == DialogResult.OK)
                    {
                        this.Hide();
                        Window3 newForm = new Window3();
                        newForm.Show();
                    }
                }
                if (obj1.CheckFlesh() == -2)//окно 5.4
                {
                    DialogResult result2 = MessageBox.Show(
                    "Вы уже подписывали этот документ",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result2 == DialogResult.OK)
                    {
                        this.Hide();
                        Window3 newForm = new Window3();
                        newForm.Show();
                    }
                }
            }
            else
            {
                this.Hide();
                Window3 newForm = new Window3();
                newForm.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            obj1.Name = textBox1.Text;
        }
        private void Window3_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }
    }
    class buff
    {
        public int a;
        public int documentIndex;
        public string name;
        ConnectionWIthDataBase connect = new ConnectionWIthDataBase();
        public int x
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int buffer
        {
            get
            {
                return documentIndex;
            }
            set
            {
                documentIndex = value;
            }
        }
        public int CheckFlesh()//чекает флешку
        {
            string checkedflash = connect.IsIDValid(name);
            if (checkedflash == "Флеш-карта не прочитана")
            {
                return -1;
            }
            if (checkedflash == "Сотрудник подтвержден")
            {
                connect.SetSigned(name); // Дописать функцию, которая по строке "ФИО, ДР" возращается айди человека и передать в SetSigned айди
                return 0;
            }
            if (checkedflash == "Уже подписал")
            {
                return -2;
            }
            else
            {
                return 1;
            }
        }
    }
}
