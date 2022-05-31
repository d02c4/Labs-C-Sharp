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
    public partial class ActionStudent : Form
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
                textBoxNumberExam.Text = ((Student)(collection[ind])).NumberExam.ToString();
                textBoxNameUniver.Text = ((Student)(collection[ind])).NameUniver.ToString();
                textBoxFormStudy.Text = ((Student)(collection[ind])).FormStudy.ToString();
                textBoxGroupName.Text = ((Student)(collection[ind])).GroupName.ToString();
                textBoxCourse.Text = ((Student)(collection[ind])).Course.ToString();
                button1.Text = "Изменить";
            }
        }

        public ActionStudent(bool mode, ref NewMyCollection<Person> collection, int ind, Form1 form1)
        {
            this.form1 = form1;
            this.mode = mode;
            this.collection = collection;
            this.ind = ind;
            InitializeComponent();
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

            f = double.TryParse(textBoxNumberExam.Text, out tmp);
            if (!f)
                throw new Exception("Некорректное значение введнего количества экзаменов");

            if (textBoxNameUniver.Text == "")
                throw new Exception("Некорректное значение названия университета");

            if (textBoxFormStudy.Text == "")
                throw new Exception("Некорректное значение формы обучения");

            if (textBoxGroupName.Text == "")
                throw new Exception("Некорректное значение названия группы");

            f = double.TryParse(textBoxCourse.Text, out tmp);
            if (!f)
                throw new Exception("Некорректное значение номера курса");

        }


        private void ActionStudent_Load(object sender, EventArgs e)
        {
            ChangeMode();
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
                        ((Student)collection[ind]).NumberExam = (int)double.Parse(textBoxNumberExam.Text);
                        ((Student)collection[ind]).NameUniver = textBoxNameUniver.Text;
                        ((Student)collection[ind]).FormStudy = textBoxFormStudy.Text;
                        ((Student)collection[ind]).GroupName = textBoxGroupName.Text;
                        ((Student)collection[ind]).Course = (int)double.Parse(textBoxCourse.Text);
                        MessageBox.Show("Успешно!");
                        form1.Upd();
                    }
                }
                else
                {
                    Student student = new Student(textBoxName.Text, textBoxSurname.Text, (int)double.Parse(textBoxAge.Text), textBoxSex.Text, double.Parse(textBoxAVG.Text), textBoxNameUniver.Text, textBoxGroupName.Text, (int)double.Parse(textBoxCourse.Text), (int)double.Parse(textBoxNumberExam.Text), textBoxFormStudy.Text);
                    collection.Add(student);
                    form1.Upd();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
