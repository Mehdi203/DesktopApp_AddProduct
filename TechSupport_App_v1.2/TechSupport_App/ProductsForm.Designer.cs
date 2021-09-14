
namespace TechSupport_App
{
    partial class ProductsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Mod = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.textBox_Date = new System.Windows.Forms.TextBox();
            this.comboBox_Code = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.DarkGreen;
            this.button_Add.Location = new System.Drawing.Point(64, 346);
            this.button_Add.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(96, 32);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Mod
            // 
            this.button_Mod.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_Mod.Location = new System.Drawing.Point(189, 346);
            this.button_Mod.Margin = new System.Windows.Forms.Padding(4);
            this.button_Mod.Name = "button_Mod";
            this.button_Mod.Size = new System.Drawing.Size(96, 32);
            this.button_Mod.TabIndex = 2;
            this.button_Mod.Text = "Modify";
            this.button_Mod.UseVisualStyleBackColor = false;
            this.button_Mod.Click += new System.EventHandler(this.button_Mod_Click);
            // 
            // button_Del
            // 
            this.button_Del.BackColor = System.Drawing.Color.Crimson;
            this.button_Del.Location = new System.Drawing.Point(317, 346);
            this.button_Del.Margin = new System.Windows.Forms.Padding(4);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(96, 32);
            this.button_Del.TabIndex = 3;
            this.button_Del.Text = "Delete";
            this.button_Del.UseVisualStyleBackColor = false;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.Gold;
            this.button_Exit.Location = new System.Drawing.Point(448, 346);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(96, 32);
            this.button_Exit.TabIndex = 4;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Release Date";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(189, 118);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.ReadOnly = true;
            this.textBox_Name.Size = new System.Drawing.Size(264, 29);
            this.textBox_Name.TabIndex = 10;
            this.textBox_Name.Tag = "Name";
            // 
            // textBox_Version
            // 
            this.textBox_Version.Location = new System.Drawing.Point(189, 189);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.ReadOnly = true;
            this.textBox_Version.Size = new System.Drawing.Size(100, 29);
            this.textBox_Version.TabIndex = 11;
            this.textBox_Version.Tag = "Version";
            // 
            // textBox_Date
            // 
            this.textBox_Date.Location = new System.Drawing.Point(189, 252);
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.ReadOnly = true;
            this.textBox_Date.Size = new System.Drawing.Size(196, 29);
            this.textBox_Date.TabIndex = 12;
            this.textBox_Date.Tag = "Date";
            // 
            // comboBox_Code
            // 
            this.comboBox_Code.FormattingEnabled = true;
            this.comboBox_Code.Location = new System.Drawing.Point(189, 61);
            this.comboBox_Code.Name = "comboBox_Code";
            this.comboBox_Code.Size = new System.Drawing.Size(121, 29);
            this.comboBox_Code.TabIndex = 14;
            this.comboBox_Code.SelectedIndexChanged += new System.EventHandler(this.comboBox_Code_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Product Code";
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(566, 419);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Code);
            this.Controls.Add(this.textBox_Date);
            this.Controls.Add(this.textBox_Version);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Mod);
            this.Controls.Add(this.button_Add);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductsForm";
            this.Text = "Product Maintanence";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Mod;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.ComboBox comboBox_Code;
        private System.Windows.Forms.Label label5;
    }
}

