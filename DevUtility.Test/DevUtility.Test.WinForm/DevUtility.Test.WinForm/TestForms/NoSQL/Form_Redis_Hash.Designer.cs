namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    partial class Form_Redis_Hash
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
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label_Pwd = new System.Windows.Forms.Label();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label_Key = new System.Windows.Forms.Label();
            this.textBox_Field = new System.Windows.Forms.TextBox();
            this.label_Field = new System.Windows.Forms.Label();
            this.groupBox_HashHelper = new System.Windows.Forms.GroupBox();
            this.button_GetValueByKeyAndField = new System.Windows.Forms.Button();
            this.button_GetAllByKey = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.groupBox_HashHelper.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(333, 5);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(119, 19);
            this.label_Title.TabIndex = 11;
            this.label_Title.Text = "Redis Test";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(251, 37);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(129, 21);
            this.textBox_Pwd.TabIndex = 18;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(198, 40);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 17;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(69, 37);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(120, 21);
            this.textBox_Host.TabIndex = 16;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Host.Location = new System.Drawing.Point(16, 40);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(47, 15);
            this.label_Host.TabIndex = 15;
            this.label_Host.Text = "Host:";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(444, 37);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(129, 21);
            this.textBox_Key.TabIndex = 20;
            // 
            // label_Key
            // 
            this.label_Key.AutoSize = true;
            this.label_Key.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Key.Location = new System.Drawing.Point(391, 40);
            this.label_Key.Name = "label_Key";
            this.label_Key.Size = new System.Drawing.Size(39, 15);
            this.label_Key.TabIndex = 19;
            this.label_Key.Text = "Key:";
            // 
            // textBox_Field
            // 
            this.textBox_Field.Location = new System.Drawing.Point(638, 37);
            this.textBox_Field.Name = "textBox_Field";
            this.textBox_Field.Size = new System.Drawing.Size(129, 21);
            this.textBox_Field.TabIndex = 22;
            // 
            // label_Field
            // 
            this.label_Field.AutoSize = true;
            this.label_Field.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Field.Location = new System.Drawing.Point(579, 40);
            this.label_Field.Name = "label_Field";
            this.label_Field.Size = new System.Drawing.Size(55, 15);
            this.label_Field.TabIndex = 21;
            this.label_Field.Text = "Field:";
            // 
            // groupBox_HashHelper
            // 
            this.groupBox_HashHelper.Controls.Add(this.button_GetValueByKeyAndField);
            this.groupBox_HashHelper.Controls.Add(this.button_GetAllByKey);
            this.groupBox_HashHelper.Location = new System.Drawing.Point(12, 72);
            this.groupBox_HashHelper.Name = "groupBox_HashHelper";
            this.groupBox_HashHelper.Size = new System.Drawing.Size(760, 59);
            this.groupBox_HashHelper.TabIndex = 30;
            this.groupBox_HashHelper.TabStop = false;
            this.groupBox_HashHelper.Text = "Hash Helper";
            // 
            // button_GetValueByKeyAndField
            // 
            this.button_GetValueByKeyAndField.Location = new System.Drawing.Point(118, 20);
            this.button_GetValueByKeyAndField.Name = "button_GetValueByKeyAndField";
            this.button_GetValueByKeyAndField.Size = new System.Drawing.Size(178, 23);
            this.button_GetValueByKeyAndField.TabIndex = 1;
            this.button_GetValueByKeyAndField.Text = "Get Value by Key and Field";
            this.button_GetValueByKeyAndField.UseVisualStyleBackColor = true;
            this.button_GetValueByKeyAndField.Click += new System.EventHandler(this.button_GetValueByKeyAndField_Click);
            // 
            // button_GetAllByKey
            // 
            this.button_GetAllByKey.Location = new System.Drawing.Point(7, 21);
            this.button_GetAllByKey.Name = "button_GetAllByKey";
            this.button_GetAllByKey.Size = new System.Drawing.Size(105, 23);
            this.button_GetAllByKey.TabIndex = 0;
            this.button_GetAllByKey.Text = "Get All By Key";
            this.button_GetAllByKey.UseVisualStyleBackColor = true;
            this.button_GetAllByKey.Click += new System.EventHandler(this.button_GetAllByKey_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 137);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 31;
            // 
            // Form_Redis_Hash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_HashHelper);
            this.Controls.Add(this.textBox_Field);
            this.Controls.Add(this.label_Field);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.label_Key);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.label_Pwd);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Redis_Hash";
            this.Text = "Form_Redis_Hash";
            this.groupBox_HashHelper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label_Pwd;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label_Key;
        private System.Windows.Forms.TextBox textBox_Field;
        private System.Windows.Forms.Label label_Field;
        private System.Windows.Forms.GroupBox groupBox_HashHelper;
        private System.Windows.Forms.Button button_GetAllByKey;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_GetValueByKeyAndField;
    }
}