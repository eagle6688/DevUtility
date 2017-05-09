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
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.label_Input = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.groupBox_FTPHelper = new System.Windows.Forms.GroupBox();
            this.button_Download = new System.Windows.Forms.Button();
            this.button_Exists = new System.Windows.Forms.Button();
            this.button_ListDirectory = new System.Windows.Forms.Button();
            this.button_ListDirectoryDetails = new System.Windows.Forms.Button();
            this.button_Upload = new System.Windows.Forms.Button();
            this.button_GetFileInfo = new System.Windows.Forms.Button();
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
            this.textBox_User.Location = new System.Drawing.Point(367, 44);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(129, 21);
            this.textBox_User.TabIndex = 26;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_User.Location = new System.Drawing.Point(314, 47);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(47, 15);
            this.label_User.TabIndex = 25;
            this.label_User.Text = "User:";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(558, 44);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(129, 21);
            this.textBox_Pwd.TabIndex = 24;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(505, 47);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 23;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Input
            // 
            this.textBox_Input.Location = new System.Drawing.Point(72, 44);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(235, 21);
            this.textBox_Input.TabIndex = 22;
            // 
            // label_Input
            // 
            this.label_Input.AutoSize = true;
            this.label_Input.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Input.Location = new System.Drawing.Point(14, 47);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(55, 15);
            this.label_Input.TabIndex = 21;
            this.label_Input.Text = "Input:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 140);
            this.textBox_Message.MaxLength = 0;
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 33;
            // 
            // groupBox_FTPHelper
            // 
            this.groupBox_FTPHelper.Controls.Add(this.button_GetFileInfo);
            this.groupBox_FTPHelper.Controls.Add(this.button_Download);
            this.groupBox_FTPHelper.Controls.Add(this.button_Exists);
            this.groupBox_FTPHelper.Controls.Add(this.button_ListDirectory);
            this.groupBox_FTPHelper.Controls.Add(this.button_ListDirectoryDetails);
            this.groupBox_FTPHelper.Controls.Add(this.button_Upload);
            this.groupBox_FTPHelper.Location = new System.Drawing.Point(12, 75);
            this.groupBox_FTPHelper.Name = "groupBox_FTPHelper";
            this.groupBox_FTPHelper.Size = new System.Drawing.Size(760, 59);
            this.groupBox_FTPHelper.TabIndex = 32;
            this.groupBox_FTPHelper.TabStop = false;
            this.groupBox_FTPHelper.Text = "FTP Helper";
            // 
            // button_Download
            // 
            this.button_Download.Location = new System.Drawing.Point(430, 21);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(69, 23);
            this.button_Download.TabIndex = 4;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // button_Exists
            // 
            this.button_Exists.Location = new System.Drawing.Point(355, 21);
            this.button_Exists.Name = "button_Exists";
            this.button_Exists.Size = new System.Drawing.Size(69, 23);
            this.button_Exists.TabIndex = 3;
            this.button_Exists.Text = "Exists";
            this.button_Exists.UseVisualStyleBackColor = true;
            this.button_Exists.Click += new System.EventHandler(this.button_Exists_Click);
            // 
            // button_ListDirectory
            // 
            this.button_ListDirectory.Location = new System.Drawing.Point(245, 21);
            this.button_ListDirectory.Name = "button_ListDirectory";
            this.button_ListDirectory.Size = new System.Drawing.Size(104, 23);
            this.button_ListDirectory.TabIndex = 2;
            this.button_ListDirectory.Text = "List Directory";
            this.button_ListDirectory.UseVisualStyleBackColor = true;
            this.button_ListDirectory.Click += new System.EventHandler(this.button_ListDirectory_Click);
            // 
            // button_ListDirectoryDetails
            // 
            this.button_ListDirectoryDetails.Location = new System.Drawing.Point(84, 21);
            this.button_ListDirectoryDetails.Name = "button_ListDirectoryDetails";
            this.button_ListDirectoryDetails.Size = new System.Drawing.Size(155, 23);
            this.button_ListDirectoryDetails.TabIndex = 1;
            this.button_ListDirectoryDetails.Text = "List Directory Details";
            this.button_ListDirectoryDetails.UseVisualStyleBackColor = true;
            this.button_ListDirectoryDetails.Click += new System.EventHandler(this.button_ListDirectoryDetails_Click);
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
            // button_GetFileInfo
            // 
            this.button_GetFileInfo.Location = new System.Drawing.Point(505, 21);
            this.button_GetFileInfo.Name = "button_GetFileInfo";
            this.button_GetFileInfo.Size = new System.Drawing.Size(96, 23);
            this.button_GetFileInfo.TabIndex = 5;
            this.button_GetFileInfo.Text = "Get File Info";
            this.button_GetFileInfo.UseVisualStyleBackColor = true;
            this.button_GetFileInfo.Click += new System.EventHandler(this.button_GetFileInfo_Click);
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
            this.Controls.Add(this.textBox_Input);
            this.Controls.Add(this.label_Input);
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
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_FTPHelper;
        private System.Windows.Forms.Button button_Upload;
        private System.Windows.Forms.Button button_ListDirectoryDetails;
        private System.Windows.Forms.Button button_ListDirectory;
        private System.Windows.Forms.Button button_Exists;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.Button button_GetFileInfo;
    }
}