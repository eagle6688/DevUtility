namespace DevUtility.Test.WinForm.TestForms.Net
{
    partial class Form_FTP
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
            this.label_FTPTest = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label_Pwd = new System.Windows.Forms.Label();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.groupBox_FTPHelper = new System.Windows.Forms.GroupBox();
            this.button_Upload = new System.Windows.Forms.Button();
            this.groupBox_FTPHelper.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_FTPTest
            // 
            this.label_FTPTest.AutoSize = true;
            this.label_FTPTest.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FTPTest.Location = new System.Drawing.Point(339, 9);
            this.label_FTPTest.Margin = new System.Windows.Forms.Padding(0);
            this.label_FTPTest.Name = "label_FTPTest";
            this.label_FTPTest.Size = new System.Drawing.Size(97, 19);
            this.label_FTPTest.TabIndex = 13;
            this.label_FTPTest.Text = "FTP Test";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(250, 44);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(129, 21);
            this.textBox_User.TabIndex = 26;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_User.Location = new System.Drawing.Point(197, 47);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(47, 15);
            this.label_User.TabIndex = 25;
            this.label_User.Text = "User:";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(441, 44);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(129, 21);
            this.textBox_Pwd.TabIndex = 24;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(388, 47);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 23;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(67, 44);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(120, 21);
            this.textBox_Host.TabIndex = 22;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Host.Location = new System.Drawing.Point(14, 47);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(47, 15);
            this.label_Host.TabIndex = 21;
            this.label_Host.Text = "Host:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 140);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 33;
            // 
            // groupBox_FTPHelper
            // 
            this.groupBox_FTPHelper.Controls.Add(this.button_Upload);
            this.groupBox_FTPHelper.Location = new System.Drawing.Point(12, 75);
            this.groupBox_FTPHelper.Name = "groupBox_FTPHelper";
            this.groupBox_FTPHelper.Size = new System.Drawing.Size(760, 59);
            this.groupBox_FTPHelper.TabIndex = 32;
            this.groupBox_FTPHelper.TabStop = false;
            this.groupBox_FTPHelper.Text = "FTP Helper";
            // 
            // button_Upload
            // 
            this.button_Upload.Location = new System.Drawing.Point(7, 21);
            this.button_Upload.Name = "button_Upload";
            this.button_Upload.Size = new System.Drawing.Size(71, 23);
            this.button_Upload.TabIndex = 0;
            this.button_Upload.Text = "Upload";
            this.button_Upload.UseVisualStyleBackColor = true;
            this.button_Upload.Click += new System.EventHandler(this.button_Upload_Click);
            // 
            // Form_FTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_FTPHelper);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.label_Pwd);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.label_FTPTest);
            this.Name = "Form_FTP";
            this.Text = "Form_FTP";
            this.groupBox_FTPHelper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_FTPTest;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label_Pwd;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_FTPHelper;
        private System.Windows.Forms.Button button_Upload;
    }
}