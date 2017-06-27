namespace DevUtility.Test.WinForm.TestForms.Data
{
    partial class Form_LinqData
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
            this.groupBox_Functions = new System.Windows.Forms.GroupBox();
            this.button_NullInLinq = new System.Windows.Forms.Button();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_WhereReference = new System.Windows.Forms.Button();
            this.groupBox_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 142);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 57;
            // 
            // groupBox_Functions
            // 
            this.groupBox_Functions.Controls.Add(this.button_WhereReference);
            this.groupBox_Functions.Controls.Add(this.button_NullInLinq);
            this.groupBox_Functions.Location = new System.Drawing.Point(12, 77);
            this.groupBox_Functions.Name = "groupBox_Functions";
            this.groupBox_Functions.Size = new System.Drawing.Size(760, 59);
            this.groupBox_Functions.TabIndex = 56;
            this.groupBox_Functions.TabStop = false;
            this.groupBox_Functions.Text = "Funtions";
            // 
            // button_NullInLinq
            // 
            this.button_NullInLinq.Location = new System.Drawing.Point(7, 21);
            this.button_NullInLinq.Name = "button_NullInLinq";
            this.button_NullInLinq.Size = new System.Drawing.Size(89, 23);
            this.button_NullInLinq.TabIndex = 0;
            this.button_NullInLinq.Text = "Null In Linq";
            this.button_NullInLinq.UseVisualStyleBackColor = true;
            this.button_NullInLinq.Click += new System.EventHandler(this.button_NullInLinq_Click);
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(124, 41);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(302, 21);
            this.textBox_inputValue.TabIndex = 59;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(15, 44);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 58;
            this.label_inputValue.Text = "Input Value:";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(328, 9);
            this.label_Title.Margin = new System.Windows.Forms.Padding(0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(108, 19);
            this.label_Title.TabIndex = 55;
            this.label_Title.Text = "Linq Data";
            // 
            // button_WhereReference
            // 
            this.button_WhereReference.Location = new System.Drawing.Point(102, 21);
            this.button_WhereReference.Name = "button_WhereReference";
            this.button_WhereReference.Size = new System.Drawing.Size(109, 23);
            this.button_WhereReference.TabIndex = 1;
            this.button_WhereReference.Text = "Where Reference";
            this.button_WhereReference.UseVisualStyleBackColor = true;
            this.button_WhereReference.Click += new System.EventHandler(this.button_WhereReference_Click);
            // 
            // Form_LinqData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_Functions);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_LinqData";
            this.Text = "Form_LinqData";
            this.groupBox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_Functions;
        private System.Windows.Forms.Button button_NullInLinq;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_WhereReference;
    }
}