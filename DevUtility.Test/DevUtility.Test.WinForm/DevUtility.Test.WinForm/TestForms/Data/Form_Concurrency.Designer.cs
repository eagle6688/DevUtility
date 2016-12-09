namespace DevUtility.Test.WinForm.TestForms.Data
{
    partial class Form_Concurrency
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
            this.label_Title = new System.Windows.Forms.Label();
            this.button_InsertData = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.button_InsertDuplicateData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(314, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(130, 19);
            this.label_Title.TabIndex = 5;
            this.label_Title.Text = "Concurrency";
            // 
            // button_InsertData
            // 
            this.button_InsertData.Location = new System.Drawing.Point(12, 88);
            this.button_InsertData.Name = "button_InsertData";
            this.button_InsertData.Size = new System.Drawing.Size(90, 23);
            this.button_InsertData.TabIndex = 12;
            this.button_InsertData.Text = "Insert Data";
            this.button_InsertData.UseVisualStyleBackColor = true;
            this.button_InsertData.Click += new System.EventHandler(this.button_InsertData_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 131);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 13;
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(123, 53);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(235, 21);
            this.textBox_inputValue.TabIndex = 15;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(13, 55);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 14;
            this.label_inputValue.Text = "Input Value:";
            // 
            // button_InsertDuplicateData
            // 
            this.button_InsertDuplicateData.Location = new System.Drawing.Point(108, 88);
            this.button_InsertDuplicateData.Name = "button_InsertDuplicateData";
            this.button_InsertDuplicateData.Size = new System.Drawing.Size(156, 23);
            this.button_InsertDuplicateData.TabIndex = 16;
            this.button_InsertDuplicateData.Text = "Insert Duplicate Data";
            this.button_InsertDuplicateData.UseVisualStyleBackColor = true;
            this.button_InsertDuplicateData.Click += new System.EventHandler(this.button_InsertDuplicateData_Click);
            // 
            // Form_Concurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button_InsertDuplicateData);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.button_InsertData);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Concurrency";
            this.Text = "Form_Concurrency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Concurrency_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_InsertData;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Button button_InsertDuplicateData;
    }
}