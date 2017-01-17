﻿namespace DevUtility.Test.WinForm.TestForms.Base
{
    partial class Form_Reflection
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
            this.button_AssemblyLoadFile = new System.Windows.Forms.Button();
            this.button_AssemblyLoad = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.button_LockerHelper = new System.Windows.Forms.Button();
            this.groupBox_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 141);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 42;
            // 
            // groupBox_Functions
            // 
            this.groupBox_Functions.Controls.Add(this.button_LockerHelper);
            this.groupBox_Functions.Controls.Add(this.button_AssemblyLoadFile);
            this.groupBox_Functions.Controls.Add(this.button_AssemblyLoad);
            this.groupBox_Functions.Location = new System.Drawing.Point(12, 76);
            this.groupBox_Functions.Name = "groupBox_Functions";
            this.groupBox_Functions.Size = new System.Drawing.Size(760, 59);
            this.groupBox_Functions.TabIndex = 41;
            this.groupBox_Functions.TabStop = false;
            this.groupBox_Functions.Text = "Funtions";
            // 
            // button_AssemblyLoadFile
            // 
            this.button_AssemblyLoadFile.Location = new System.Drawing.Point(112, 20);
            this.button_AssemblyLoadFile.Name = "button_AssemblyLoadFile";
            this.button_AssemblyLoadFile.Size = new System.Drawing.Size(125, 23);
            this.button_AssemblyLoadFile.TabIndex = 1;
            this.button_AssemblyLoadFile.Text = "Assembly Load File";
            this.button_AssemblyLoadFile.UseVisualStyleBackColor = true;
            this.button_AssemblyLoadFile.Click += new System.EventHandler(this.button_AssemblyLoadFile_Click);
            // 
            // button_AssemblyLoad
            // 
            this.button_AssemblyLoad.Location = new System.Drawing.Point(7, 21);
            this.button_AssemblyLoad.Name = "button_AssemblyLoad";
            this.button_AssemblyLoad.Size = new System.Drawing.Size(99, 23);
            this.button_AssemblyLoad.TabIndex = 0;
            this.button_AssemblyLoad.Text = "Assembly Load";
            this.button_AssemblyLoad.UseVisualStyleBackColor = true;
            this.button_AssemblyLoad.Click += new System.EventHandler(this.button_AssemblyLoad_Click);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(339, 10);
            this.label_Title.Margin = new System.Windows.Forms.Padding(0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(119, 19);
            this.label_Title.TabIndex = 34;
            this.label_Title.Text = "Reflection";
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(124, 40);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(302, 21);
            this.textBox_inputValue.TabIndex = 44;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(15, 43);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 43;
            this.label_inputValue.Text = "Input Value:";
            // 
            // button_LockerHelper
            // 
            this.button_LockerHelper.Location = new System.Drawing.Point(243, 20);
            this.button_LockerHelper.Name = "button_LockerHelper";
            this.button_LockerHelper.Size = new System.Drawing.Size(101, 23);
            this.button_LockerHelper.TabIndex = 2;
            this.button_LockerHelper.Text = "Locker Helper";
            this.button_LockerHelper.UseVisualStyleBackColor = true;
            this.button_LockerHelper.Click += new System.EventHandler(this.button_LockerHelper_Click);
            // 
            // Form_Reflection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_Functions);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Reflection";
            this.Text = "Form_Reflection";
            this.groupBox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_Functions;
        private System.Windows.Forms.Button button_AssemblyLoad;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Button button_AssemblyLoadFile;
        private System.Windows.Forms.Button button_LockerHelper;
    }
}