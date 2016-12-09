namespace DevUtility.Test.WinForm.TestForms.Net
{
    partial class Form_Net
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
            this.button_HttpHelper_Using = new System.Windows.Forms.Button();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.button_HttpHelper_Post = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(330, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(97, 19);
            this.label_Title.TabIndex = 4;
            this.label_Title.Text = "Net Test";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 131);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 5;
            // 
            // button_HttpHelper_Using
            // 
            this.button_HttpHelper_Using.Location = new System.Drawing.Point(12, 91);
            this.button_HttpHelper_Using.Name = "button_HttpHelper_Using";
            this.button_HttpHelper_Using.Size = new System.Drawing.Size(127, 23);
            this.button_HttpHelper_Using.TabIndex = 6;
            this.button_HttpHelper_Using.Text = "HttpHelper_Using";
            this.button_HttpHelper_Using.UseVisualStyleBackColor = true;
            this.button_HttpHelper_Using.Click += new System.EventHandler(this.button_HttpHelper_Using_Click);
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(12, 52);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 7;
            this.label_inputValue.Text = "Input Value:";
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(121, 49);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(235, 21);
            this.textBox_inputValue.TabIndex = 8;
            // 
            // button_HttpHelper_Post
            // 
            this.button_HttpHelper_Post.Location = new System.Drawing.Point(146, 91);
            this.button_HttpHelper_Post.Name = "button_HttpHelper_Post";
            this.button_HttpHelper_Post.Size = new System.Drawing.Size(109, 23);
            this.button_HttpHelper_Post.TabIndex = 9;
            this.button_HttpHelper_Post.Text = "HttpHelper_Post";
            this.button_HttpHelper_Post.UseVisualStyleBackColor = true;
            this.button_HttpHelper_Post.Click += new System.EventHandler(this.button_HttpHelper_Post_Click);
            // 
            // Form_Net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.button_HttpHelper_Post);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.button_HttpHelper_Using);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Net";
            this.Text = "Form_Net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_HttpHelper_Using;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Button button_HttpHelper_Post;
    }
}