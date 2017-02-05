namespace DevUtility.Test.WinForm.TestForms.MultiThreads
{
    partial class Form_MultiThreads1
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
            this.groupBox_Functions = new System.Windows.Forms.GroupBox();
            this.button_AsyncAndAwait = new System.Windows.Forms.Button();
            this.button_BeginInvoke = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_Locker = new System.Windows.Forms.Button();
            this.groupBox_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(310, 9);
            this.label_Title.Margin = new System.Windows.Forms.Padding(0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(152, 19);
            this.label_Title.TabIndex = 12;
            this.label_Title.Text = "Multi Threads";
            // 
            // groupBox_Functions
            // 
            this.groupBox_Functions.Controls.Add(this.button_Locker);
            this.groupBox_Functions.Controls.Add(this.button_AsyncAndAwait);
            this.groupBox_Functions.Controls.Add(this.button_BeginInvoke);
            this.groupBox_Functions.Location = new System.Drawing.Point(12, 34);
            this.groupBox_Functions.Name = "groupBox_Functions";
            this.groupBox_Functions.Size = new System.Drawing.Size(760, 100);
            this.groupBox_Functions.TabIndex = 31;
            this.groupBox_Functions.TabStop = false;
            this.groupBox_Functions.Text = "Functions";
            // 
            // button_AsyncAndAwait
            // 
            this.button_AsyncAndAwait.Location = new System.Drawing.Point(103, 21);
            this.button_AsyncAndAwait.Name = "button_AsyncAndAwait";
            this.button_AsyncAndAwait.Size = new System.Drawing.Size(117, 23);
            this.button_AsyncAndAwait.TabIndex = 1;
            this.button_AsyncAndAwait.Text = "Async And Await";
            this.button_AsyncAndAwait.UseVisualStyleBackColor = true;
            this.button_AsyncAndAwait.Click += new System.EventHandler(this.button_AsyncAndAwait_Click);
            // 
            // button_BeginInvoke
            // 
            this.button_BeginInvoke.Location = new System.Drawing.Point(7, 21);
            this.button_BeginInvoke.Name = "button_BeginInvoke";
            this.button_BeginInvoke.Size = new System.Drawing.Size(90, 23);
            this.button_BeginInvoke.TabIndex = 0;
            this.button_BeginInvoke.Text = "BeginInvoke";
            this.button_BeginInvoke.UseVisualStyleBackColor = true;
            this.button_BeginInvoke.Click += new System.EventHandler(this.button_BeginInvoke_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 140);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 32;
            // 
            // button_Locker
            // 
            this.button_Locker.Location = new System.Drawing.Point(226, 21);
            this.button_Locker.Name = "button_Locker";
            this.button_Locker.Size = new System.Drawing.Size(55, 23);
            this.button_Locker.TabIndex = 2;
            this.button_Locker.Text = "Locker";
            this.button_Locker.UseVisualStyleBackColor = true;
            this.button_Locker.Click += new System.EventHandler(this.button_Locker_Click);
            // 
            // Form_MultiThreads1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_Functions);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_MultiThreads1";
            this.Text = "Form_MultiThreads1";
            this.groupBox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.GroupBox groupBox_Functions;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_BeginInvoke;
        private System.Windows.Forms.Button button_AsyncAndAwait;
        private System.Windows.Forms.Button button_Locker;
    }
}