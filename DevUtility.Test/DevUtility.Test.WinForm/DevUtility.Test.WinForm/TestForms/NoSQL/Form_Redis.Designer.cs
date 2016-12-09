namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    partial class Form_Redis
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
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label_Key = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_IsConnected = new System.Windows.Forms.Button();
            this.button_GetValue = new System.Windows.Forms.Button();
            this.button_SetValue = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_ExecuteLua = new System.Windows.Forms.Button();
            this.button_GetModelKey = new System.Windows.Forms.Button();
            this.button_GetValueFromDB1 = new System.Windows.Forms.Button();
            this.groupBox_String = new System.Windows.Forms.GroupBox();
            this.groupBox_Common = new System.Windows.Forms.GroupBox();
            this.label_DB = new System.Windows.Forms.Label();
            this.comboBox_DB = new System.Windows.Forms.ComboBox();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label_Pwd = new System.Windows.Forms.Label();
            this.textBox_Fields = new System.Windows.Forms.TextBox();
            this.label_Fields = new System.Windows.Forms.Label();
            this.groupBox_String.SuspendLayout();
            this.groupBox_Common.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(453, 34);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(150, 21);
            this.textBox_Key.TabIndex = 12;
            // 
            // label_Key
            // 
            this.label_Key.AutoSize = true;
            this.label_Key.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Key.Location = new System.Drawing.Point(408, 37);
            this.label_Key.Name = "label_Key";
            this.label_Key.Size = new System.Drawing.Size(39, 15);
            this.label_Key.TabIndex = 11;
            this.label_Key.Text = "Key:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(10, 200);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(820, 319);
            this.textBox_Message.TabIndex = 10;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(368, 7);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(119, 19);
            this.label_Title.TabIndex = 9;
            this.label_Title.Text = "Redis Test";
            // 
            // button_IsConnected
            // 
            this.button_IsConnected.Location = new System.Drawing.Point(5, 20);
            this.button_IsConnected.Name = "button_IsConnected";
            this.button_IsConnected.Size = new System.Drawing.Size(100, 23);
            this.button_IsConnected.TabIndex = 13;
            this.button_IsConnected.Text = "Is Connected";
            this.button_IsConnected.UseVisualStyleBackColor = true;
            this.button_IsConnected.Click += new System.EventHandler(this.button_IsConnected_Click);
            // 
            // button_GetValue
            // 
            this.button_GetValue.Location = new System.Drawing.Point(6, 20);
            this.button_GetValue.Name = "button_GetValue";
            this.button_GetValue.Size = new System.Drawing.Size(75, 23);
            this.button_GetValue.TabIndex = 14;
            this.button_GetValue.Text = "Get Value";
            this.button_GetValue.UseVisualStyleBackColor = true;
            this.button_GetValue.Click += new System.EventHandler(this.button_GetValue_Click);
            // 
            // button_SetValue
            // 
            this.button_SetValue.Location = new System.Drawing.Point(87, 20);
            this.button_SetValue.Name = "button_SetValue";
            this.button_SetValue.Size = new System.Drawing.Size(75, 23);
            this.button_SetValue.TabIndex = 15;
            this.button_SetValue.Text = "Set Value";
            this.button_SetValue.UseVisualStyleBackColor = true;
            this.button_SetValue.Click += new System.EventHandler(this.button_SetValue_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(111, 20);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(55, 23);
            this.button_Remove.TabIndex = 18;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_ExecuteLua
            // 
            this.button_ExecuteLua.Location = new System.Drawing.Point(275, 20);
            this.button_ExecuteLua.Name = "button_ExecuteLua";
            this.button_ExecuteLua.Size = new System.Drawing.Size(90, 23);
            this.button_ExecuteLua.TabIndex = 19;
            this.button_ExecuteLua.Text = "Execute Lua";
            this.button_ExecuteLua.UseVisualStyleBackColor = true;
            this.button_ExecuteLua.Click += new System.EventHandler(this.button_ExecuteLua_Click);
            // 
            // button_GetModelKey
            // 
            this.button_GetModelKey.Location = new System.Drawing.Point(172, 20);
            this.button_GetModelKey.Name = "button_GetModelKey";
            this.button_GetModelKey.Size = new System.Drawing.Size(97, 23);
            this.button_GetModelKey.TabIndex = 20;
            this.button_GetModelKey.Text = "Get Model Key";
            this.button_GetModelKey.UseVisualStyleBackColor = true;
            this.button_GetModelKey.Click += new System.EventHandler(this.button_GetModelKey_Click);
            // 
            // button_GetValueFromDB1
            // 
            this.button_GetValueFromDB1.Location = new System.Drawing.Point(168, 20);
            this.button_GetValueFromDB1.Name = "button_GetValueFromDB1";
            this.button_GetValueFromDB1.Size = new System.Drawing.Size(124, 23);
            this.button_GetValueFromDB1.TabIndex = 25;
            this.button_GetValueFromDB1.Text = "Get Value From DB1";
            this.button_GetValueFromDB1.UseVisualStyleBackColor = true;
            this.button_GetValueFromDB1.Click += new System.EventHandler(this.button_GetValueFromDB1_Click);
            // 
            // groupBox_String
            // 
            this.groupBox_String.Controls.Add(this.button_GetValue);
            this.groupBox_String.Controls.Add(this.button_SetValue);
            this.groupBox_String.Controls.Add(this.button_GetValueFromDB1);
            this.groupBox_String.Location = new System.Drawing.Point(10, 134);
            this.groupBox_String.Name = "groupBox_String";
            this.groupBox_String.Size = new System.Drawing.Size(820, 60);
            this.groupBox_String.TabIndex = 26;
            this.groupBox_String.TabStop = false;
            this.groupBox_String.Text = "String";
            // 
            // groupBox_Common
            // 
            this.groupBox_Common.Controls.Add(this.button_IsConnected);
            this.groupBox_Common.Controls.Add(this.button_Remove);
            this.groupBox_Common.Controls.Add(this.button_ExecuteLua);
            this.groupBox_Common.Controls.Add(this.button_GetModelKey);
            this.groupBox_Common.Location = new System.Drawing.Point(10, 68);
            this.groupBox_Common.Name = "groupBox_Common";
            this.groupBox_Common.Size = new System.Drawing.Size(820, 60);
            this.groupBox_Common.TabIndex = 27;
            this.groupBox_Common.TabStop = false;
            this.groupBox_Common.Text = "Common";
            // 
            // label_DB
            // 
            this.label_DB.AutoSize = true;
            this.label_DB.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DB.Location = new System.Drawing.Point(324, 37);
            this.label_DB.Name = "label_DB";
            this.label_DB.Size = new System.Drawing.Size(31, 15);
            this.label_DB.TabIndex = 29;
            this.label_DB.Text = "DB:";
            // 
            // comboBox_DB
            // 
            this.comboBox_DB.FormattingEnabled = true;
            this.comboBox_DB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox_DB.Location = new System.Drawing.Point(361, 35);
            this.comboBox_DB.Name = "comboBox_DB";
            this.comboBox_DB.Size = new System.Drawing.Size(40, 20);
            this.comboBox_DB.TabIndex = 30;
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(65, 34);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(100, 21);
            this.textBox_Host.TabIndex = 32;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Host.Location = new System.Drawing.Point(13, 37);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(47, 15);
            this.label_Host.TabIndex = 31;
            this.label_Host.Text = "Host:";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(215, 34);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(100, 21);
            this.textBox_Pwd.TabIndex = 34;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(172, 37);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 33;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Fields
            // 
            this.textBox_Fields.Location = new System.Drawing.Point(680, 34);
            this.textBox_Fields.Name = "textBox_Fields";
            this.textBox_Fields.Size = new System.Drawing.Size(150, 21);
            this.textBox_Fields.TabIndex = 36;
            // 
            // label_Fields
            // 
            this.label_Fields.AutoSize = true;
            this.label_Fields.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Fields.Location = new System.Drawing.Point(611, 37);
            this.label_Fields.Name = "label_Fields";
            this.label_Fields.Size = new System.Drawing.Size(63, 15);
            this.label_Fields.TabIndex = 35;
            this.label_Fields.Text = "Fields:";
            // 
            // Form_Redis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 531);
            this.Controls.Add(this.textBox_Fields);
            this.Controls.Add(this.label_Fields);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.label_Pwd);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.comboBox_DB);
            this.Controls.Add(this.label_DB);
            this.Controls.Add(this.groupBox_Common);
            this.Controls.Add(this.groupBox_String);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.label_Key);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Redis";
            this.Text = "Form_Redis";
            this.groupBox_String.ResumeLayout(false);
            this.groupBox_Common.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label_Key;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_IsConnected;
        private System.Windows.Forms.Button button_GetValue;
        private System.Windows.Forms.Button button_SetValue;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_ExecuteLua;
        private System.Windows.Forms.Button button_GetModelKey;
        private System.Windows.Forms.Button button_GetValueFromDB1;
        private System.Windows.Forms.GroupBox groupBox_String;
        private System.Windows.Forms.GroupBox groupBox_Common;
        private System.Windows.Forms.Label label_DB;
        private System.Windows.Forms.ComboBox comboBox_DB;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label_Pwd;
        private System.Windows.Forms.TextBox textBox_Fields;
        private System.Windows.Forms.Label label_Fields;
    }
}