namespace Lab_16_1
{
    partial class ActionPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxSex = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.textBoxAVG = new System.Windows.Forms.TextBox();
            this.labelAVG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(175, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(12, 83);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(175, 27);
            this.textBoxSurname.TabIndex = 1;
            // 
            // textBoxSex
            // 
            this.textBoxSex.Location = new System.Drawing.Point(207, 28);
            this.textBoxSex.Name = "textBoxSex";
            this.textBoxSex.Size = new System.Drawing.Size(175, 27);
            this.textBoxSex.TabIndex = 1;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(207, 80);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(175, 27);
            this.textBoxAge.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 5);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Имя";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(12, 60);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(73, 20);
            this.labelSurname.TabIndex = 2;
            this.labelSurname.Text = "Фамилия";
            // 
            // labelSex
            // 
            this.labelSex.AutoSize = true;
            this.labelSex.Location = new System.Drawing.Point(207, 5);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(37, 20);
            this.labelSex.TabIndex = 2;
            this.labelSex.Text = "Пол";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(207, 60);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(64, 20);
            this.labelAge.TabIndex = 2;
            this.labelAge.Text = "Возраст";
            // 
            // textBoxAVG
            // 
            this.textBoxAVG.Location = new System.Drawing.Point(12, 145);
            this.textBoxAVG.Name = "textBoxAVG";
            this.textBoxAVG.Size = new System.Drawing.Size(175, 27);
            this.textBoxAVG.TabIndex = 1;
            // 
            // labelAVG
            // 
            this.labelAVG.AutoSize = true;
            this.labelAVG.Location = new System.Drawing.Point(12, 122);
            this.labelAVG.Name = "labelAVG";
            this.labelAVG.Size = new System.Drawing.Size(122, 20);
            this.labelAVG.TabIndex = 2;
            this.labelAVG.Text = "Средняя оценка";
            // 
            // ActionPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 235);
            this.Controls.Add(this.labelAVG);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxAVG);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxSex);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.button1);
            this.Name = "ActionPerson";
            this.Text = "ActionPerson";
            this.Load += new System.EventHandler(this.ActionPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private TextBox textBoxSex;
        private TextBox textBoxAge;
        private Label labelName;
        private Label labelSurname;
        private Label labelSex;
        private Label labelAge;
        private TextBox textBoxAVG;
        private Label labelAVG;
    }
}