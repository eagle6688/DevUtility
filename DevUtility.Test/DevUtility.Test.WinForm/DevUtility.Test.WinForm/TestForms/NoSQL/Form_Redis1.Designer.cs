namespace DevUtility.Test.WinForm.TestForms.NoSQL
{
    partial class Form_Redis1
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
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label_Pwd = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.groupBox_ModelHelper = new System.Windows.Forms.GroupBox();
            this.button_SetAll = new System.Windows.Forms.Button();
            this.button_PerformanceTest = new System.Windows.Forms.Button();
            this.button_GetESPData = new System.Windows.Forms.Button();
            this.groupBox_ModelHelper.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(331, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(119, 19);
            this.label_Title.TabIndex = 10;
            this.label_Title.Text = "Redis Test";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(66, 40);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(235, 21);
            this.textBox_Host.TabIndex = 12;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Host.Location = new System.Drawing.Point(13, 43);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(47, 15);
            this.label_Host.TabIndex = 11;
            this.label_Host.Text = "Host:";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(363, 40);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.Size = new System.Drawing.Size(235, 21);
            this.textBox_Pwd.TabIndex = 14;
            // 
            // label_Pwd
            // 
            this.label_Pwd.AutoSize = true;
            this.label_Pwd.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Pwd.Location = new System.Drawing.Point(310, 43);
            this.label_Pwd.Name = "label_Pwd";
            this.label_Pwd.Size = new System.Drawing.Size(39, 15);
            this.label_Pwd.TabIndex = 13;
            this.label_Pwd.Text = "Pwd:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 142);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 15;
            // 
            // groupBox_ModelHelper
            // 
            this.groupBox_ModelHelper.Controls.Add(this.button_GetESPData);
            this.groupBox_ModelHelper.Controls.Add(this.button_SetAll);
            this.groupBox_ModelHelper.Controls.Add(this.button_PerformanceTest);
            this.groupBox_ModelHelper.Location = new System.Drawing.Point(12, 77);
            this.groupBox_ModelHelper.Name = "groupBox_ModelHelper";
            this.groupBox_ModelHelper.Size = new System.Drawing.Size(760, 59);
            this.groupBox_ModelHelper.TabIndex = 29;
            this.groupBox_ModelHelper.TabStop = false;
            this.groupBox_ModelHelper.Text = "Model Helper";
            // 
            // button_SetAll
            // 
            this.button_SetAll.Location = new System.Drawing.Point(127, 20);
            this.button_SetAll.Name = "button_SetAll";
            this.button_SetAll.Size = new System.Drawing.Size(75, 23);
            this.button_SetAll.TabIndex = 24;
            this.button_SetAll.Text = "Set all";
            this.button_SetAll.UseVisualStyleBackColor = true;
            this.button_SetAll.Click += new System.EventHandler(this.button_SetAll_Click);
            // 
            // button_PerformanceTest
            // 
            this.button_PerformanceTest.Location = new System.Drawing.Point(6, 20);
            this.button_PerformanceTest.Name = "button_PerformanceTest";
            this.button_PerformanceTest.Size = new System.Drawing.Size(115, 23);
            this.button_PerformanceTest.TabIndex = 23;
            this.button_PerformanceTest.Text = "Performance Test";
            this.button_PerformanceTest.UseVisualStyleBackColor = true;
            this.button_PerformanceTest.Click += new System.EventHandler(this.button_PerformanceTest_Click);
            // 
            // button_GetESPData
            // 
            this.button_GetESPData.Location = new System.Drawing.Point(208, 20);
            this.button_GetESPData.Name = "button_GetESPData";
            this.button_GetESPData.Size = new System.Drawing.Size(100, 23);
            this.button_GetESPData.TabIndex = 25;
            this.button_GetESPData.Text = "Get ESP Data";
            this.button_GetESPData.UseVisualStyleBackColor = true;
            this.button_GetESPData.Click += new System.EventHandler(this.button_GetESPData_Click);
            // 
            // Form_Redis1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.groupBox_ModelHelper);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.label_Pwd);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Redis1";
            this.Text = "Form_Redis1";
            this.groupBox_ModelHelper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label_Pwd;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_ModelHelper;
        private System.Windows.Forms.Button button_PerformanceTest;
        private System.Windows.Forms.Button button_SetAll;
        private System.Windows.Forms.Button button_GetESPData;
    }
}