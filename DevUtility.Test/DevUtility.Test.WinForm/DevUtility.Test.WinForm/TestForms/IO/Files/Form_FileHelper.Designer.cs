namespace DevUtility.Test.WinForm.TestForms.IO.Files
{
    partial class Form_FileHelper
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
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_GetChecksumSHA1 = new System.Windows.Forms.Button();
            this.button_GetExtension = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 132);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 17;
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(121, 42);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(302, 21);
            this.textBox_inputValue.TabIndex = 16;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(12, 45);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 15;
            this.label_inputValue.Text = "Input Value:";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(323, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(130, 19);
            this.label_Title.TabIndex = 14;
            this.label_Title.Text = "File Helper";
            // 
            // button_GetChecksumSHA1
            // 
            this.button_GetChecksumSHA1.Location = new System.Drawing.Point(12, 80);
            this.button_GetChecksumSHA1.Name = "button_GetChecksumSHA1";
            this.button_GetChecksumSHA1.Size = new System.Drawing.Size(127, 23);
            this.button_GetChecksumSHA1.TabIndex = 18;
            this.button_GetChecksumSHA1.Text = "Get Checksum SHA1";
            this.button_GetChecksumSHA1.UseVisualStyleBackColor = true;
            this.button_GetChecksumSHA1.Click += new System.EventHandler(this.button_GetChecksumSHA1_Click);
            // 
            // button_GetExtension
            // 
            this.button_GetExtension.Location = new System.Drawing.Point(145, 80);
            this.button_GetExtension.Name = "button_GetExtension";
            this.button_GetExtension.Size = new System.Drawing.Size(95, 23);
            this.button_GetExtension.TabIndex = 19;
            this.button_GetExtension.Text = "Get Extension";
            this.button_GetExtension.UseVisualStyleBackColor = true;
            this.button_GetExtension.Click += new System.EventHandler(this.button_GetExtension_Click);
            // 
            // Form_FileHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button_GetExtension);
            this.Controls.Add(this.button_GetChecksumSHA1);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_FileHelper";
            this.Text = "Form_FileHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FileHelper_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_GetChecksumSHA1;
        private System.Windows.Forms.Button button_GetExtension;
    }
}