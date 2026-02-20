namespace Hosok
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboBoxKasztok = new ComboBox();
            label1 = new Label();
            textBoxNev = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxSzarmazas = new TextBox();
            label4 = new Label();
            textBoxSzint = new TextBox();
            buttonAdd = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 253);
            dataGridView1.TabIndex = 0;
            // 
            // comboBoxKasztok
            // 
            comboBoxKasztok.FormattingEnabled = true;
            comboBoxKasztok.Location = new Point(316, 430);
            comboBoxKasztok.Name = "comboBoxKasztok";
            comboBoxKasztok.Size = new Size(155, 23);
            comboBoxKasztok.TabIndex = 1;
            comboBoxKasztok.SelectedIndexChanged += comboBoxKasztok_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 412);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "Kaszt";
            // 
            // textBoxNev
            // 
            textBoxNev.Location = new Point(316, 297);
            textBoxNev.Name = "textBoxNev";
            textBoxNev.Size = new Size(155, 23);
            textBoxNev.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(381, 279);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 6;
            label2.Text = "Név";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(363, 323);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 8;
            label3.Text = "Származás";
            // 
            // textBoxSzarmazas
            // 
            textBoxSzarmazas.Location = new Point(316, 341);
            textBoxSzarmazas.Name = "textBoxSzarmazas";
            textBoxSzarmazas.Size = new Size(155, 23);
            textBoxSzarmazas.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 368);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 10;
            label4.Text = "Szint";
            // 
            // textBoxSzint
            // 
            textBoxSzint.Location = new Point(316, 385);
            textBoxSzint.Name = "textBoxSzint";
            textBoxSzint.Size = new Size(155, 23);
            textBoxSzint.TabIndex = 9;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(316, 459);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(155, 35);
            buttonAdd.TabIndex = 12;
            buttonAdd.Text = "Hozzáadás";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // button1
            // 
            button1.Location = new Point(676, 271);
            button1.Name = "button1";
            button1.Size = new Size(112, 23);
            button1.TabIndex = 13;
            button1.Text = "Hős törlése";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 506);
            Controls.Add(button1);
            Controls.Add(buttonAdd);
            Controls.Add(label4);
            Controls.Add(textBoxSzint);
            Controls.Add(label3);
            Controls.Add(textBoxSzarmazas);
            Controls.Add(label2);
            Controls.Add(textBoxNev);
            Controls.Add(label1);
            Controls.Add(comboBoxKasztok);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxKasztok;
        private Label label1;
        private TextBox textBoxNev;
        private Label label2;
        private Label label3;
        private TextBox textBoxSzarmazas;
        private Label label4;
        private TextBox textBoxSzint;
        private Button buttonAdd;
        private Button button1;
    }
}
