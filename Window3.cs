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
        buff obj1 = new buff();
        public Window3()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            List<string> people = new List<string>() { "Уругвай", "Эквадор" };
            foreach (string i in people)
            {
                comboBox1.Items.Add(i);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string x = comboBox1.SelectedItem.ToString(); //имя выбранного документа
        }

        private void Escape_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void YES_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "Вставьте флеш-накопитель, содержащий вашу подпись",
                 "Сообщение",
                 MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.OK)
            {
                if (obj1.CheckFlesh() == 1)
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
                if (obj1.CheckFlesh() == 1)
                {
                    DialogResult result2 = MessageBox.Show(
                    "Ваши права не подтверждены, идите нахуй",
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
                if (obj1.CheckFlesh() == -1)
                {
                    DialogResult result2 = MessageBox.Show(
                    "Флешка не вставлена",
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
                if (obj1.CheckFlesh() == -2)
                {
                    DialogResult result2 = MessageBox.Show(
                    "Ты уже подписывал этот документ!",
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
    }
    class buff
    {
        public int a;
        public string s;
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
        public string buffer
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }
        public int CheckFlesh()//чекает флешку
        {
            int a = 0;
            if (a == 1)
            {
                return 1;
            }
            if (a == 0)
            {
                return 0;
            }
            if (a==-2)
            {
                return -2;
            }
            else
            {
                return -1;
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
}
