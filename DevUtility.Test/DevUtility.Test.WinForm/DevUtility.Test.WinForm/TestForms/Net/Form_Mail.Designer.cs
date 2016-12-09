namespace DevUtility.Test.WinForm.TestForms.Net
{
    partial class Form_Mail
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
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.label_ServerPort = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label_UserName = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_MailTitle = new System.Windows.Forms.TextBox();
            this.label_MailTitle = new System.Windows.Forms.Label();
            this.textBox_Sender = new System.Windows.Forms.TextBox();
            this.label_Sender = new System.Windows.Forms.Label();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(334, 11);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(108, 19);
            this.label_Title.TabIndex = 5;
            this.label_Title.Text = "Mail Test";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(86, 46);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(260, 21);
            this.textBox_Server.TabIndex = 10;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Server.Location = new System.Drawing.Point(17, 48);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(63, 15);
            this.label_Server.TabIndex = 9;
            this.label_Server.Text = "Server:";
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(127, 81);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(219, 21);
            this.textBox_ServerPort.TabIndex = 12;
            // 
            // label_ServerPort
            // 
            this.label_ServerPort.AutoSize = true;
            this.label_ServerPort.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ServerPort.Location = new System.Drawing.Point(17, 84);
            this.label_ServerPort.Name = "label_ServerPort";
            this.label_ServerPort.Size = new System.Drawing.Size(103, 15);
            this.label_ServerPort.TabIndex = 11;
            this.label_ServerPort.Text = "Server Port:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 312);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 148);
            this.textBox_Message.TabIndex = 13;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(436, 45);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(255, 21);
            this.textBox_UserName.TabIndex = 15;
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_UserName.Location = new System.Drawing.Point(352, 48);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(79, 15);
            this.label_UserName.TabIndex = 14;
            this.label_UserName.Text = "UserName:";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(436, 78);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(255, 21);
            this.textBox_Password.TabIndex = 17;
            this.textBox_Password.UseSystemPasswordChar = true;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Password.Location = new System.Drawing.Point(352, 83);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(79, 15);
            this.label_Password.TabIndex = 16;
            this.label_Password.Text = "Password:";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(697, 45);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 96);
            this.button_Send.TabIndex = 18;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_MailTitle
            // 
            this.textBox_MailTitle.Location = new System.Drawing.Point(127, 158);
            this.textBox_MailTitle.Name = "textBox_MailTitle";
            this.textBox_MailTitle.Size = new System.Drawing.Size(645, 21);
            this.textBox_MailTitle.TabIndex = 20;
            // 
            // label_MailTitle
            // 
            this.label_MailTitle.AutoSize = true;
            this.label_MailTitle.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MailTitle.Location = new System.Drawing.Point(17, 161);
            this.label_MailTitle.Name = "label_MailTitle";
            this.label_MailTitle.Size = new System.Drawing.Size(95, 15);
            this.label_MailTitle.TabIndex = 19;
            this.label_MailTitle.Text = "Mail Title:";
            // 
            // textBox_Sender
            // 
            this.textBox_Sender.Location = new System.Drawing.Point(86, 120);
            this.textBox_Sender.Name = "textBox_Sender";
            this.textBox_Sender.Size = new System.Drawing.Size(260, 21);
            this.textBox_Sender.TabIndex = 22;
            // 
            // label_Sender
            // 
            this.label_Sender.AutoSize = true;
            this.label_Sender.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Sender.Location = new System.Drawing.Point(17, 122);
            this.label_Sender.Name = "label_Sender";
            this.label_Sender.Size = new System.Drawing.Size(63, 15);
            this.label_Sender.TabIndex = 21;
            this.label_Sender.Text = "Sender:";
            // 
            // textBox_To
            // 
            this.textBox_To.Location = new System.Drawing.Point(436, 120);
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(255, 21);
            this.textBox_To.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(368, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // textBox_Body
            // 
            this.textBox_Body.Location = new System.Drawing.Point(12, 192);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Body.Size = new System.Drawing.Size(760, 103);
            this.textBox_Body.TabIndex = 25;
            // 
            // Form_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.textBox_Body);
            this.Controls.Add(this.textBox_To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Sender);
            this.Controls.Add(this.label_Sender);
            this.Controls.Add(this.textBox_MailTitle);
            this.Controls.Add(this.label_MailTitle);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.label_ServerPort);
            this.Controls.Add(this.textBox_Server);
            this.Controls.Add(this.label_Server);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Mail";
            this.Text = "Form_Mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Mail_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.Label label_ServerPort;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBox_MailTitle;
        private System.Windows.Forms.Label label_MailTitle;
        private System.Windows.Forms.TextBox textBox_Sender;
        private System.Windows.Forms.Label label_Sender;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Body;
    }
}