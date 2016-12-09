namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    partial class Form_Set
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
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label__Value = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label_Key = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label_Pwd = new System.Windows.Forms.Label();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.groupBox_HashHelper = new System.Windows.Forms.GroupBox();
            this.button_CheckValue = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_GetValues = new System.Windows.Forms.Button();
            this.groupBox_HashHelper.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(337, 6);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(119, 19);
            this.label_Title.TabIndex = 12;
            this.label_Title.Text = "Redis Test";
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(590, 33);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(180, 21);
            this.textBox_Value.TabIndex = 30;
            // 
            // label__Value
            // 
            this.label__Value.AutoSize = true;
            this.label__Value.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label__Value.Location = new System.Drawing.Point(529, 36);
            this.label__Value.Name = "label__Value";
            this.label__Value.Size = new System.Drawing.Size(55, 15);
            this.label__Value.TabIndex = 29;
            this.label__Value.Text = "Value:";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(362, 33);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(160, 21);
            this.textBox_Key.TabIndex = 28;
            // 
            // label_Key
            // 
            this.label_Key.AutoSize = true;
            this.label_Key.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Key.Location = new System.Drawing.Point(317, 36);
            this.label_Key.Name = "label_Key";
            this.label_Key.Size = new System.Drawing.Size(39, 15);
            this.label_Key.TabIndex = 27;
            this.label_Key.Text = "Key:";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(211, 33);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(100, 21);
            this.textBox_Pwd.TabIndex = 26;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(166, 36);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 25;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(60, 33);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(100, 21);
            this.textBox_Host.TabIndex = 24;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Host.Location = new System.Drawing.Point(13, 36);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(47, 15);
            this.label_Host.TabIndex = 23;
            this.label_Host.Text = "Host:";
            // 
            // groupBox_HashHelper
            // 
            this.groupBox_HashHelper.Controls.Add(this.button_GetValues);
            this.groupBox_HashHelper.Controls.Add(this.button_CheckValue);
            this.groupBox_HashHelper.Location = new System.Drawing.Point(10, 70);
            this.groupBox_HashHelper.Name = "groupBox_HashHelper";
            this.groupBox_HashHelper.Size = new System.Drawing.Size(760, 59);
            this.groupBox_HashHelper.TabIndex = 31;
            this.groupBox_HashHelper.TabStop = false;
            this.groupBox_HashHelper.Text = "Hash Helper";
            // 
            // button_CheckValue
            // 
            this.button_CheckValue.Location = new System.Drawing.Point(6, 20);
            this.button_CheckValue.Name = "button_CheckValue";
            this.button_CheckValue.Size = new System.Drawing.Size(93, 23);
            this.button_CheckValue.TabIndex = 0;
            this.button_CheckValue.Text = "Check Value";
            this.button_CheckValue.UseVisualStyleBackColor = true;
            this.button_CheckValue.Click += new System.EventHandler(this.button_CheckValue_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(10, 140);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 32;
            // 
            // button_GetValues
            // 
            this.button_GetValues.Location = new System.Drawing.Point(105, 20);
            this.button_GetValues.Name = "button_GetValues";
            this.button_GetValues.Size = new System.Drawing.Size(75, 23);
            this.button_GetValues.TabIndex = 33;
            this.button_GetValues.Text = "Get Values";
            this.button_GetValues.UseVisualStyleBackColor = true;
            this.button_GetValues.Click += new System.EventHandler(this.button_GetValues_Click);
            // 
            // Form_Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_HashHelper);
            this.Controls.Add(this.textBox_Value);
            this.Controls.Add(this.label__Value);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.label_Key);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.label_Pwd);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Set";
            this.Text = "Form_Set";
            this.groupBox_HashHelper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Label label__Value;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label_Key;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label_Pwd;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.GroupBox groupBox_HashHelper;
        private System.Windows.Forms.Button button_CheckValue;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_GetValues;
    }
}