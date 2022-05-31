using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;

namespace Lab_16_1
{
    public partial class ActionSchoolboy : Form
    {
        bool mode = false;
        NewMyCollection<Person> collection = new NewMyCollection<Person>();
        int ind = 0;
        Form1 form1;

        void ChangeMode()
        {
            if (mode)
            {
                button1.Text = "Добавить";
            }
            else
            {
                textBoxSurname.Text = collection[ind].Surname;
                textBoxName.Text = collection[ind].Name;
                textBoxSex.Text = collection[ind].Sex;
                textBoxAVG.Text = collection[ind].AVGRating.ToString();
                textBoxAge.Text = collection[ind].Age.ToString();
                textBoxNameSchool.Text = ((Schoolboy)collection[ind]).SchoolName.ToString();
                textBoxNumberClass.Text = ((Schoolboy)collection[ind]).NumberClass.ToString();

                button1.Text = "Изменить";
            }
        }


        public ActionSchoolboy(bool mode, ref NewMyCollection<Person> collection, int ind, Form1 form1)
        {
            this.form1 = form1;
            this.mode = mode;
            this.collection = collection;
            this.ind = ind;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CheckInput();
                if (!mode)
                {
                    if (MessageBox.Show("Вы уверены?", "Изменить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        collection[ind].Name = textBoxName.Text;
                        collection[ind].Sex = textBoxSex.Text;
                        collection[ind].Surname = textBoxSurname.Text;
                        collection[ind].Age = (int)double.Parse(textBoxAge.Text);
                        collection[ind].AVGRating = double.Parse(textBoxAVG.Text);
                        ((Schoolboy)collection[ind]).SchoolName = textBoxNameSchool.Text;
                        ((Schoolboy)collection[ind]).NumberClass = (int)double.Parse(textBoxNumberClass.Text);
                        MessageBox.Show("Успешно!");
                        form1.Upd();
                    }
                }
                else
                {
                    Schoolboy schoolboy = new Schoolboy(textBoxName.Text, textBoxSurname.Text, (int)double.Parse(textBoxAge.Text), textBoxSex.Text, double.Parse(textBoxAVG.Text), textBoxNameSchool.Text, (int)double.Parse(textBoxNumberClass.Text));
                    collection.Add(schoolboy);
                    form1.Upd();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActionSchoolboy_Load(object sender, EventArgs e)
        {
            ChangeMode();
        }


        void CheckInput()
        {
            if (textBoxName.Text == "")
                throw new Exception("Некорректное значение имени");
            if (textBoxSurname.Text == "")
                throw new Exception("Некорректное значение фамилии");
            Person person = new Person();
            person.Sex = textBoxSex.Text;
            if (!(person.CheckMens(person) || person.CheckWomens(person)))
                throw new Exception("Некорректное значение пола");
            double tmp = 0;
            bool f = false;
            f = double.TryParse(textBoxAVG.Text, out tmp);
            if (!f)
                throw new Exception("Некорректное значение введнего рейтинга");

            f = double.TryParse(textBoxAge.Text, out tmp);
            if (!f)
                throw new Exception("Некорректное значение введнего возраста");

            if (textBoxNameSchool.Text == "")
                throw new Exception("Некорректное значение название школы");

            f = double.TryParse(textBoxNumberClass.Text, out tmp);
            if (!f)
                throw new Exception("Некорректное значение номера класса");



        }

    }
}
