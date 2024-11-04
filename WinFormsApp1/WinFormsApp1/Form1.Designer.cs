namespace WinFormsApp1
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
            computersDataGridView = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            nameTextBox = new TextBox();
            modelTextBox = new TextBox();
            osTextBox = new TextBox();
            datePurchasedDateTimePicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)computersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // computersDataGridView
            // 
            computersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            computersDataGridView.Location = new Point(27, 56);
            computersDataGridView.Name = "computersDataGridView";
            computersDataGridView.Size = new Size(745, 359);
            computersDataGridView.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(411, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Удалить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(330, 27);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Добавить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(27, 27);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(85, 23);
            nameTextBox.TabIndex = 3;
            // 
            // modelTextBox
            // 
            modelTextBox.Location = new Point(118, 27);
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(100, 23);
            modelTextBox.TabIndex = 4;
            // 
            // osTextBox
            // 
            osTextBox.Location = new Point(224, 27);
            osTextBox.Name = "osTextBox";
            osTextBox.Size = new Size(100, 23);
            osTextBox.TabIndex = 5;
            // 
            // datePurchasedDateTimePicker
            // 
            datePurchasedDateTimePicker.Location = new Point(509, 27);
            datePurchasedDateTimePicker.Name = "datePurchasedDateTimePicker";
            datePurchasedDateTimePicker.Size = new Size(146, 23);
            datePurchasedDateTimePicker.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(datePurchasedDateTimePicker);
            Controls.Add(osTextBox);
            Controls.Add(modelTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(computersDataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)computersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView computersDataGridView;
        private Button button1;
        private Button button2;
        private TextBox nameTextBox;
        private TextBox modelTextBox;
        private TextBox osTextBox;
        private DateTimePicker datePurchasedDateTimePicker;
    }
}
