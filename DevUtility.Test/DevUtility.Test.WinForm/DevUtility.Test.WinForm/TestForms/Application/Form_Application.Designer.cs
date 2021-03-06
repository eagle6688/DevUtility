﻿namespace DevUtility.Test.WinForm.TestForms.Application
{
    partial class Form_Application
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
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.button_RunProgram = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_ExcuteCmd = new System.Windows.Forms.Button();
            this.button_ServiceStatus = new System.Windows.Forms.Button();
            this.button_GetAllServices = new System.Windows.Forms.Button();
            this.button_GetSection = new System.Windows.Forms.Button();
            this.groupBox_Functions = new System.Windows.Forms.GroupBox();
            this.button_GetEndpoint = new System.Windows.Forms.Button();
            this.groupBox_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(286, 7);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(185, 19);
            this.label_Title.TabIndex = 5;
            this.label_Title.Text = "Test Application";
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(119, 38);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(302, 21);
            this.textBox_inputValue.TabIndex = 11;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(10, 41);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 10;
            this.label_inputValue.Text = "Input Value:";
            // 
            // button_RunProgram
            // 
            this.button_RunProgram.Location = new System.Drawing.Point(6, 20);
            this.button_RunProgram.Name = "button_RunProgram";
            this.button_RunProgram.Size = new System.Drawing.Size(95, 23);
            this.button_RunProgram.TabIndex = 12;
            this.button_RunProgram.Text = "Run Program";
            this.button_RunProgram.UseVisualStyleBackColor = true;
            this.button_RunProgram.Click += new System.EventHandler(this.button_RunProgram_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(12, 131);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(760, 319);
            this.textBox_Message.TabIndex = 13;
            // 
            // button_ExcuteCmd
            // 
            this.button_ExcuteCmd.Location = new System.Drawing.Point(107, 20);
            this.button_ExcuteCmd.Name = "button_ExcuteCmd";
            this.button_ExcuteCmd.Size = new System.Drawing.Size(83, 23);
            this.button_ExcuteCmd.TabIndex = 14;
            this.button_ExcuteCmd.Text = "Excute Cmd";
            this.button_ExcuteCmd.UseVisualStyleBackColor = true;
            this.button_ExcuteCmd.Click += new System.EventHandler(this.button_ExcuteCmd_Click);
            // 
            // button_ServiceStatus
            // 
            this.button_ServiceStatus.Location = new System.Drawing.Point(196, 20);
            this.button_ServiceStatus.Name = "button_ServiceStatus";
            this.button_ServiceStatus.Size = new System.Drawing.Size(114, 23);
            this.button_ServiceStatus.TabIndex = 15;
            this.button_ServiceStatus.Text = "Service Status";
            this.button_ServiceStatus.UseVisualStyleBackColor = true;
            this.button_ServiceStatus.Click += new System.EventHandler(this.button_ServiceStatus_Click);
            // 
            // button_GetAllServices
            // 
            this.button_GetAllServices.Location = new System.Drawing.Point(316, 20);
            this.button_GetAllServices.Name = "button_GetAllServices";
            this.button_GetAllServices.Size = new System.Drawing.Size(119, 23);
            this.button_GetAllServices.TabIndex = 16;
            this.button_GetAllServices.Text = "Get All Services";
            this.button_GetAllServices.UseVisualStyleBackColor = true;
            this.button_GetAllServices.Click += new System.EventHandler(this.button_GetAllServices_Click);
            // 
            // button_GetSection
            // 
            this.button_GetSection.Location = new System.Drawing.Point(441, 20);
            this.button_GetSection.Name = "button_GetSection";
            this.button_GetSection.Size = new System.Drawing.Size(95, 23);
            this.button_GetSection.TabIndex = 17;
            this.button_GetSection.Text = "Get Section";
            this.button_GetSection.UseVisualStyleBackColor = true;
            this.button_GetSection.Click += new System.EventHandler(this.button_GetSection_Click);
            // 
            // groupBox_Functions
            // 
            this.groupBox_Functions.Controls.Add(this.button_GetEndpoint);
            this.groupBox_Functions.Controls.Add(this.button_RunProgram);
            this.groupBox_Functions.Controls.Add(this.button_GetSection);
            this.groupBox_Functions.Controls.Add(this.button_ExcuteCmd);
            this.groupBox_Functions.Controls.Add(this.button_GetAllServices);
            this.groupBox_Functions.Controls.Add(this.button_ServiceStatus);
            this.groupBox_Functions.Location = new System.Drawing.Point(12, 65);
            this.groupBox_Functions.Name = "groupBox_Functions";
            this.groupBox_Functions.Size = new System.Drawing.Size(760, 59);
            this.groupBox_Functions.TabIndex = 62;
            this.groupBox_Functions.TabStop = false;
            this.groupBox_Functions.Text = "Funtions";
            // 
            // button_GetEndpoint
            // 
            this.button_GetEndpoint.Location = new System.Drawing.Point(542, 20);
            this.button_GetEndpoint.Name = "button_GetEndpoint";
            this.button_GetEndpoint.Size = new System.Drawing.Size(95, 23);
            this.button_GetEndpoint.TabIndex = 18;
            this.button_GetEndpoint.Text = "Get Endpoint";
            this.button_GetEndpoint.UseVisualStyleBackColor = true;
            this.button_GetEndpoint.Click += new System.EventHandler(this.button_GetEndpoint_Click);
            // 
            // Form_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBox_Functions);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Application";
            this.Text = "Form_Application";
            this.groupBox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Button button_RunProgram;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_ExcuteCmd;
        private System.Windows.Forms.Button button_ServiceStatus;
        private System.Windows.Forms.Button button_GetAllServices;
        private System.Windows.Forms.Button button_GetSection;
        private System.Windows.Forms.GroupBox groupBox_Functions;
        private System.Windows.Forms.Button button_GetEndpoint;
    }
}