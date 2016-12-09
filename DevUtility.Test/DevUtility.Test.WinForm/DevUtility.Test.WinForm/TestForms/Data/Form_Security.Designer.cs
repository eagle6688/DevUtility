namespace DevUtility.Test.WinForm.TestForms.Data
{
    partial class Form_Security
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
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_AESHelper_Encrypt = new System.Windows.Forms.Button();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.button_AESHelper_Decrypt = new System.Windows.Forms.Button();
            this.button_MD5Encrypt = new System.Windows.Forms.Button();
            this.button_SHA1Encrypt = new System.Windows.Forms.Button();
            this.button_SHA256Encrypt = new System.Windows.Forms.Button();
            this.button_FileSHA1Encrypt = new System.Windows.Forms.Button();
            this.button_FileMD5Encrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(299, 20);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(152, 19);
            this.label_Title.TabIndex = 3;
            this.label_Title.Text = "Security Test";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 152);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 4;
            // 
            // button_AESHelper_Encrypt
            // 
            this.button_AESHelper_Encrypt.Location = new System.Drawing.Point(12, 88);
            this.button_AESHelper_Encrypt.Name = "button_AESHelper_Encrypt";
            this.button_AESHelper_Encrypt.Size = new System.Drawing.Size(120, 23);
            this.button_AESHelper_Encrypt.TabIndex = 5;
            this.button_AESHelper_Encrypt.Text = "AESHelper_Encrypt";
            this.button_AESHelper_Encrypt.UseVisualStyleBackColor = true;
            this.button_AESHelper_Encrypt.Click += new System.EventHandler(this.button_AESHelper_Encrypt_Click);
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(13, 55);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 6;
            this.label_inputValue.Text = "Input Value:";
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(123, 53);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(235, 21);
            this.textBox_inputValue.TabIndex = 7;
            // 
            // button_AESHelper_Decrypt
            // 
            this.button_AESHelper_Decrypt.Location = new System.Drawing.Point(139, 88);
            this.button_AESHelper_Decrypt.Name = "button_AESHelper_Decrypt";
            this.button_AESHelper_Decrypt.Size = new System.Drawing.Size(120, 23);
            this.button_AESHelper_Decrypt.TabIndex = 8;
            this.button_AESHelper_Decrypt.Text = "AESHelper_Decrypt";
            this.button_AESHelper_Decrypt.UseVisualStyleBackColor = true;
            this.button_AESHelper_Decrypt.Click += new System.EventHandler(this.button_AESHelper_Decrypt_Click);
            // 
            // button_MD5Encrypt
            // 
            this.button_MD5Encrypt.Location = new System.Drawing.Point(266, 88);
            this.button_MD5Encrypt.Name = "button_MD5Encrypt";
            this.button_MD5Encrypt.Size = new System.Drawing.Size(75, 23);
            this.button_MD5Encrypt.TabIndex = 9;
            this.button_MD5Encrypt.Text = "MD5Encrypt";
            this.button_MD5Encrypt.UseVisualStyleBackColor = true;
            this.button_MD5Encrypt.Click += new System.EventHandler(this.button_MD5Encrypt_Click);
            // 
            // button_SHA1Encrypt
            // 
            this.button_SHA1Encrypt.Location = new System.Drawing.Point(348, 88);
            this.button_SHA1Encrypt.Name = "button_SHA1Encrypt";
            this.button_SHA1Encrypt.Size = new System.Drawing.Size(85, 23);
            this.button_SHA1Encrypt.TabIndex = 10;
            this.button_SHA1Encrypt.Text = "SHA1Encrypt";
            this.button_SHA1Encrypt.UseVisualStyleBackColor = true;
            this.button_SHA1Encrypt.Click += new System.EventHandler(this.button_SHA1Encrypt_Click);
            // 
            // button_SHA256Encrypt
            // 
            this.button_SHA256Encrypt.Location = new System.Drawing.Point(439, 88);
            this.button_SHA256Encrypt.Name = "button_SHA256Encrypt";
            this.button_SHA256Encrypt.Size = new System.Drawing.Size(96, 23);
            this.button_SHA256Encrypt.TabIndex = 11;
            this.button_SHA256Encrypt.Text = "SHA256Encrypt";
            this.button_SHA256Encrypt.UseVisualStyleBackColor = true;
            this.button_SHA256Encrypt.Click += new System.EventHandler(this.button_SHA256Encrypt_Click);
            // 
            // button_FileSHA1Encrypt
            // 
            this.button_FileSHA1Encrypt.Location = new System.Drawing.Point(147, 117);
            this.button_FileSHA1Encrypt.Name = "button_FileSHA1Encrypt";
            this.button_FileSHA1Encrypt.Size = new System.Drawing.Size(129, 23);
            this.button_FileSHA1Encrypt.TabIndex = 12;
            this.button_FileSHA1Encrypt.Text = "File SHA1 Encrypt";
            this.button_FileSHA1Encrypt.UseVisualStyleBackColor = true;
            this.button_FileSHA1Encrypt.Click += new System.EventHandler(this.button_FileSHA1Encrypt_Click);
            // 
            // button_FileMD5Encrypt
            // 
            this.button_FileMD5Encrypt.Location = new System.Drawing.Point(12, 117);
            this.button_FileMD5Encrypt.Name = "button_FileMD5Encrypt";
            this.button_FileMD5Encrypt.Size = new System.Drawing.Size(129, 23);
            this.button_FileMD5Encrypt.TabIndex = 13;
            this.button_FileMD5Encrypt.Text = "File MD5 Encrypt";
            this.button_FileMD5Encrypt.UseVisualStyleBackColor = true;
            this.button_FileMD5Encrypt.Click += new System.EventHandler(this.button_FileMD5Encrypt_Click);
            // 
            // Form_Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.button_FileMD5Encrypt);
            this.Controls.Add(this.button_FileSHA1Encrypt);
            this.Controls.Add(this.button_SHA256Encrypt);
            this.Controls.Add(this.button_SHA1Encrypt);
            this.Controls.Add(this.button_MD5Encrypt);
            this.Controls.Add(this.button_AESHelper_Decrypt);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.button_AESHelper_Encrypt);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Security";
            this.Text = "Form_Security";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Security_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_AESHelper_Encrypt;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Button button_AESHelper_Decrypt;
        private System.Windows.Forms.Button button_MD5Encrypt;
        private System.Windows.Forms.Button button_SHA1Encrypt;
        private System.Windows.Forms.Button button_SHA256Encrypt;
        private System.Windows.Forms.Button button_FileSHA1Encrypt;
        private System.Windows.Forms.Button button_FileMD5Encrypt;
    }
}