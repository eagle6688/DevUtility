namespace DevUtility.Test.WinForm.TestForms.Research
{
    partial class Form_Research
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
            this.groupBox_ButtonsArea = new System.Windows.Forms.GroupBox();
            this.button_ADLogin = new System.Windows.Forms.Button();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_UnicodeTest = new System.Windows.Forms.Label();
            this.button_StaticProperty = new System.Windows.Forms.Button();
            this.groupBox_ButtonsArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 142);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 47;
            // 
            // groupBox_ButtonsArea
            // 
            this.groupBox_ButtonsArea.Controls.Add(this.button_StaticProperty);
            this.groupBox_ButtonsArea.Controls.Add(this.button_ADLogin);
            this.groupBox_ButtonsArea.Location = new System.Drawing.Point(12, 77);
            this.groupBox_ButtonsArea.Name = "groupBox_ButtonsArea";
            this.groupBox_ButtonsArea.Size = new System.Drawing.Size(760, 59);
            this.groupBox_ButtonsArea.TabIndex = 46;
            this.groupBox_ButtonsArea.TabStop = false;
            this.groupBox_ButtonsArea.Text = "Buttons Area";
            // 
            // button_ADLogin
            // 
            this.button_ADLogin.Location = new System.Drawing.Point(7, 21);
            this.button_ADLogin.Name = "button_ADLogin";
            this.button_ADLogin.Size = new System.Drawing.Size(73, 23);
            this.button_ADLogin.TabIndex = 0;
            this.button_ADLogin.Text = "AD Login";
            this.button_ADLogin.UseVisualStyleBackColor = true;
            this.button_ADLogin.Click += new System.EventHandler(this.button_ADLogin_Click);
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(72, 46);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(300, 21);
            this.textBox_Value.TabIndex = 45;
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Value.Location = new System.Drawing.Point(14, 49);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(55, 15);
            this.label_Value.TabIndex = 44;
            this.label_Value.Text = "Value:";
            // 
            // label_UnicodeTest
            // 
            this.label_UnicodeTest.AutoSize = true;
            this.label_UnicodeTest.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_UnicodeTest.Location = new System.Drawing.Point(338, 9);
            this.label_UnicodeTest.Margin = new System.Windows.Forms.Padding(0);
            this.label_UnicodeTest.Name = "label_UnicodeTest";
            this.label_UnicodeTest.Size = new System.Drawing.Size(97, 19);
            this.label_UnicodeTest.TabIndex = 43;
            this.label_UnicodeTest.Text = "Research";
            // 
            // button_StaticProperty
            // 
            this.button_StaticProperty.Location = new System.Drawing.Point(86, 20);
            this.button_StaticProperty.Name = "button_StaticProperty";
            this.button_StaticProperty.Size = new System.Drawing.Size(116, 23);
            this.button_StaticProperty.TabIndex = 1;
            this.button_StaticProperty.Text = "Static Property";
            this.button_StaticProperty.UseVisualStyleBackColor = true;
            this.button_StaticProperty.Click += new System.EventHandler(this.button_StaticProperty_Click);
            // 
            // Form_Research
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_ButtonsArea);
            this.Controls.Add(this.textBox_Value);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.label_UnicodeTest);
            this.Name = "Form_Research";
            this.Text = "Form_Research";
            this.groupBox_ButtonsArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_ButtonsArea;
        private System.Windows.Forms.Button button_ADLogin;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_UnicodeTest;
        private System.Windows.Forms.Button button_StaticProperty;
    }
}