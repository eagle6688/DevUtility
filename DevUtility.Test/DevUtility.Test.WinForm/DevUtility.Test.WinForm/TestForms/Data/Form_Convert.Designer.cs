namespace DevUtility.Test.WinForm.TestForms.Data
{
    partial class Form_Convert
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
            this.button_ListToArray = new System.Windows.Forms.Button();
            this.button_Count0ToList = new System.Windows.Forms.Button();
            this.button_ToDateTime = new System.Windows.Forms.Button();
            this.textBox_inputValue = new System.Windows.Forms.TextBox();
            this.label_inputValue = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
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
            this.textBox_Message.TabIndex = 52;
            // 
            // groupBox_Functions
            // 
            this.groupBox_Functions.Controls.Add(this.button_ListToArray);
            this.groupBox_Functions.Controls.Add(this.button_Count0ToList);
            this.groupBox_Functions.Controls.Add(this.button_ToDateTime);
            this.groupBox_Functions.Location = new System.Drawing.Point(12, 77);
            this.groupBox_Functions.Name = "groupBox_Functions";
            this.groupBox_Functions.Size = new System.Drawing.Size(760, 59);
            this.groupBox_Functions.TabIndex = 51;
            this.groupBox_Functions.TabStop = false;
            this.groupBox_Functions.Text = "Funtions";
            // 
            // button_ListToArray
            // 
            this.button_ListToArray.Location = new System.Drawing.Point(223, 21);
            this.button_ListToArray.Name = "button_ListToArray";
            this.button_ListToArray.Size = new System.Drawing.Size(100, 23);
            this.button_ListToArray.TabIndex = 2;
            this.button_ListToArray.Text = "List To Array";
            this.button_ListToArray.UseVisualStyleBackColor = true;
            this.button_ListToArray.Click += new System.EventHandler(this.button_ListToArray_Click);
            // 
            // button_Count0ToList
            // 
            this.button_Count0ToList.Location = new System.Drawing.Point(102, 21);
            this.button_Count0ToList.Name = "button_Count0ToList";
            this.button_Count0ToList.Size = new System.Drawing.Size(115, 23);
            this.button_Count0ToList.TabIndex = 1;
            this.button_Count0ToList.Text = "Count 0 To List";
            this.button_Count0ToList.UseVisualStyleBackColor = true;
            this.button_Count0ToList.Click += new System.EventHandler(this.button_Count0ToList_Click);
            // 
            // button_ToDateTime
            // 
            this.button_ToDateTime.Location = new System.Drawing.Point(7, 21);
            this.button_ToDateTime.Name = "button_ToDateTime";
            this.button_ToDateTime.Size = new System.Drawing.Size(89, 23);
            this.button_ToDateTime.TabIndex = 0;
            this.button_ToDateTime.Text = "To DateTime";
            this.button_ToDateTime.UseVisualStyleBackColor = true;
            this.button_ToDateTime.Click += new System.EventHandler(this.button_ToDateTime_Click);
            // 
            // textBox_inputValue
            // 
            this.textBox_inputValue.Location = new System.Drawing.Point(124, 41);
            this.textBox_inputValue.Name = "textBox_inputValue";
            this.textBox_inputValue.Size = new System.Drawing.Size(302, 21);
            this.textBox_inputValue.TabIndex = 54;
            // 
            // label_inputValue
            // 
            this.label_inputValue.AutoSize = true;
            this.label_inputValue.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_inputValue.Location = new System.Drawing.Point(15, 44);
            this.label_inputValue.Name = "label_inputValue";
            this.label_inputValue.Size = new System.Drawing.Size(103, 15);
            this.label_inputValue.TabIndex = 53;
            this.label_inputValue.Text = "Input Value:";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(340, 9);
            this.label_Title.Margin = new System.Windows.Forms.Padding(0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(86, 19);
            this.label_Title.TabIndex = 50;
            this.label_Title.Text = "Convert";
            // 
            // Form_Convert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.groupBox_Functions);
            this.Controls.Add(this.textBox_inputValue);
            this.Controls.Add(this.label_inputValue);
            this.Controls.Add(this.label_Title);
            this.Name = "Form_Convert";
            this.Text = "Form_Convert";
            this.groupBox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.GroupBox groupBox_Functions;
        private System.Windows.Forms.Button button_ToDateTime;
        private System.Windows.Forms.TextBox textBox_inputValue;
        private System.Windows.Forms.Label label_inputValue;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_Count0ToList;
        private System.Windows.Forms.Button button_ListToArray;
    }
}