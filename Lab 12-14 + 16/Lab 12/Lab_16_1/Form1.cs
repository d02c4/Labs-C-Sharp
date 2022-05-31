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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab_16_1
{
    public partial class Form1 : Form
    {

        public NewMyCollection<Person> collection = new NewMyCollection<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
        }

        void PrintData()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < collection.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = collection[i].GetType().Name;
                dataGridView1.Rows[i].Cells[2].Value = collection[i].ToString();
            }
        }


        void AddToCollection(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var tmp = RandomClass.GetRadomClass();
                collection.Add(tmp);
            }
        }


        /// <summary>
        /// Генерация случайных элементов в коллекцию
        /// </summary>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int number = 0;
            string str = textBoxGenerate.Text;
            bool f = Int32.TryParse(str, out number);
            if (f)
            {
                if (number < 0)
                {
                    MessageBox.Show("Укажите число больше 0");
                    textBoxGenerate.Text = "";
                }
                else
                {
                    AddToCollection(number);
                    Upd();
                }
            }
            else
            {
                MessageBox.Show("Указан неверный тип данных!");
                textBoxGenerate.Text = "";
            }
        }

        public void Upd()
        {
            dataGridView1.Rows.Clear();
            PrintData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?\nЭто может привести к потере данных!", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                var tmp = collection[id];
                collection.Remove(tmp);
            }
            Upd();
        }


        void CheckSelect()
        {
            int ind = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            if (collection[ind].GetType().Name == "Person")
            {
                ActionPerson actionPerson = new ActionPerson(false, ref collection, ind, this);
                actionPerson.Show();
            }
            else if (collection[ind].GetType().Name == "Student")
            {
                ActionStudent actionStudent = new ActionStudent(false, ref collection, ind, this);
                actionStudent.Show();
            }
            else if (collection[ind].GetType().Name == "Schoolboy")
            {
                ActionSchoolboy actionSchoolboy = new ActionSchoolboy(false, ref collection, ind, this);
                actionSchoolboy.Show();
            }

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButtonPerson_CheckedChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonPerson.Checked)
            {
                ActionPerson actionPerson = new ActionPerson(true, ref collection, 0, this);
                actionPerson.Show();
            }
            else if (radioButtonSchoolboy.Checked)
            {
                ActionSchoolboy actionSchoolboy = new ActionSchoolboy(true, ref collection, 0, this);
                actionSchoolboy.Show();
            }
            else if (radioButtonStudent.Checked)
            {
                ActionStudent actionStudent = new ActionStudent(true, ref collection, 0, this);
                actionStudent.Show();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            collection.Clear();
            Upd();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (radioButtonBinary.Checked)
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "(*.bin)|*.bin";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    BinaryFormatter ser = new BinaryFormatter();
                    FileStream file = new FileStream(path, FileMode.Create);
                    ser.Serialize(file, collection.ToList());
                    file.Close();
                }
            }
            if (radioButtonJSON.Checked)
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "(*.json)|*.json";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    FileStream file = new FileStream(path, FileMode.Create);
                    var ser = new DataContractJsonSerializer(typeof(List<Person>));
                    ser.WriteObject(file, collection.ToList());
                    file.Close();
                }
            }
            if (radioButtonXML.Checked)
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "(*.xml)|*.xml";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    FileStream file = new FileStream(path, FileMode.Create);
                    XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                    ser.Serialize(file, collection.ToList());
                    file.Close();
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (radioButtonBinary.Checked)
            {
                OpenFileDialog d = new();
                d.Filter = "(*.bin)|*.bin";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    BinaryFormatter ser = new();
                    FileStream file = new(path, FileMode.Open, FileAccess.Read);
                    collection.Clear();
                    try
                    {
                        List<Person> tmpList = (List<Person>)ser.Deserialize(file);
                        collection = new(tmpList);
                        Upd();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Произошла ошибка чтения\n" + err.Message);
                    }
                    file.Close();
                }
            }
            if (radioButtonJSON.Checked)
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "(*.json)|*.json";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                    collection.Clear();
                    try
                    {
                        var ser = new DataContractJsonSerializer(typeof(List<Person>));
                        var tmpList = (List<Person>)ser.ReadObject(file);
                        collection = new NewMyCollection<Person>(tmpList);
                        Upd();
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show("Произошла ошибка чтения\n" + err.Message);
                    }
                    file.Close();
                }
            }
            if (radioButtonXML.Checked)
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "(*.xml)|*.xml";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var path = d.FileName;
                    XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                    collection.Clear();
                    try
                    {
                        var tmpList = (List<Person>)ser.Deserialize(file);
                        foreach (var el in tmpList)
                            collection.Add(el);
                        Upd();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Произошла ошибка чтения\n" + err.Message);
                    }
                    file.Close();
                }
            }
        }
    }
}