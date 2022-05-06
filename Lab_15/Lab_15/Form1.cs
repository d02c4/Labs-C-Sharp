
namespace Lab_15
{
    public partial class Form1 : Form
    {
        double x = 200;
        double y = 222;
        int sel = 0;
        bool direction = false;

        public Form1()
        {
            InitializeComponent();
        }

        void MoveButton()
        {

            // Action встроенный делегат который не принимает никаких параметров и ничего не возвращает
            button1.BeginInvoke(() =>
            {
                button1.Location = new Point((int)x, (int)y);
            });
        }

        void CheckDirection()
        {
            if (x >= panel1.Location.X + panel1.Width)
                direction = true;
            else if (x <= panel1.Location.X)
                direction = false;
        }

        int CheckX()
        {
            CheckDirection();
            if (direction)
                return -1;
            else
                return 1;
        }

        void StopMove()
        {
            y = panel1.Size.Height / 2;
        }

        void LineMove()
        {
            x += CheckX();
            y = panel1.Size.Height / 2;
        }

        void SinMove()
        {
            x += 0.1 * CheckX();
            y = panel1.Size.Height / 2 + 100 * Math.Sin(x);
        }

        void CosMove()
        {
            x += 0.1 * CheckX();
            y = panel1.Size.Height / 2 + 100 * Math.Cos(x);
        }

        private void Select(int i)
        {
            
            switch (i)
            {
                case 0:
                    StopMove();
                    break;
                case 1:
                    LineMove();
                    break;
                case 2:
                    SinMove();
                    break;
                case 3:
                    CosMove();
                    break;
            }
        }

        private void CheckComboBox()
        {
            if (comboBox1.Text == "не перемещаться")
            {
                sel = 0;
            }
            else if (comboBox1.Text == "по прямой")
            {
                sel = 1;
            }
            else if (comboBox1.Text == "sin(x)")
            {
                sel = 2;
            }
            else if (comboBox1.Text == "cos(x)")
            {
                sel = 3;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBox();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            y = panel1.Size.Height / 2;
            button1.Location = new Point(0, panel1.Size.Height / 2);
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    Select(sel);
                }
            });
            thread.Start();

            Thread thread2 = new Thread(() =>
            {
                while (true)
                {
                    MoveButton();
                    Thread.Sleep(10);
                }
            });
            thread2.Start();
        }
    }
}