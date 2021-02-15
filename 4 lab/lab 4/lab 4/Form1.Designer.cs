namespace lab_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sin_b = new System.Windows.Forms.Button();
            this.cos_b = new System.Windows.Forms.Button();
            this.tang_b = new System.Windows.Forms.Button();
            this.sqrt_b = new System.Windows.Forms.Button();
            this.pow_b = new System.Windows.Forms.Button();
            this.clear_b = new System.Windows.Forms.Button();
            this.pow_result_b = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sin_b
            // 
            this.sin_b.BackColor = System.Drawing.Color.Gold;
            this.sin_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sin_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sin_b.Location = new System.Drawing.Point(13, 57);
            this.sin_b.Name = "sin_b";
            this.sin_b.Size = new System.Drawing.Size(68, 42);
            this.sin_b.TabIndex = 1;
            this.sin_b.Text = "sin";
            this.sin_b.UseVisualStyleBackColor = false;
            this.sin_b.Click += new System.EventHandler(this.button1_Click);
            // 
            // cos_b
            // 
            this.cos_b.BackColor = System.Drawing.Color.Gold;
            this.cos_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cos_b.Location = new System.Drawing.Point(13, 105);
            this.cos_b.Name = "cos_b";
            this.cos_b.Size = new System.Drawing.Size(68, 38);
            this.cos_b.TabIndex = 2;
            this.cos_b.Text = "cos";
            this.cos_b.UseVisualStyleBackColor = false;
            this.cos_b.Click += new System.EventHandler(this.button2_Click);
            // 
            // tang_b
            // 
            this.tang_b.BackColor = System.Drawing.Color.Gold;
            this.tang_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tang_b.Location = new System.Drawing.Point(89, 57);
            this.tang_b.Name = "tang_b";
            this.tang_b.Size = new System.Drawing.Size(68, 42);
            this.tang_b.TabIndex = 3;
            this.tang_b.Text = "tang";
            this.tang_b.UseVisualStyleBackColor = false;
            this.tang_b.Click += new System.EventHandler(this.button3_Click);
            // 
            // sqrt_b
            // 
            this.sqrt_b.BackColor = System.Drawing.Color.Gold;
            this.sqrt_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqrt_b.Location = new System.Drawing.Point(89, 105);
            this.sqrt_b.Name = "sqrt_b";
            this.sqrt_b.Size = new System.Drawing.Size(68, 38);
            this.sqrt_b.TabIndex = 5;
            this.sqrt_b.Text = "sqrt";
            this.sqrt_b.UseVisualStyleBackColor = false;
            this.sqrt_b.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pow_b
            // 
            this.pow_b.BackColor = System.Drawing.Color.Gold;
            this.pow_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pow_b.Location = new System.Drawing.Point(165, 57);
            this.pow_b.Name = "pow_b";
            this.pow_b.Size = new System.Drawing.Size(68, 42);
            this.pow_b.TabIndex = 6;
            this.pow_b.Text = "pow";
            this.pow_b.UseVisualStyleBackColor = false;
            this.pow_b.Click += new System.EventHandler(this.button4_Click);
            // 
            // clear_b
            // 
            this.clear_b.BackColor = System.Drawing.Color.DarkKhaki;
            this.clear_b.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_b.Location = new System.Drawing.Point(216, 326);
            this.clear_b.Name = "clear_b";
            this.clear_b.Size = new System.Drawing.Size(96, 53);
            this.clear_b.TabIndex = 7;
            this.clear_b.Text = "clear";
            this.clear_b.UseVisualStyleBackColor = false;
            this.clear_b.Click += new System.EventHandler(this.button5_Click);
            // 
            // pow_result_b
            // 
            this.pow_result_b.BackColor = System.Drawing.Color.Gold;
            this.pow_result_b.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pow_result_b.Location = new System.Drawing.Point(165, 105);
            this.pow_result_b.Name = "pow_result_b";
            this.pow_result_b.Size = new System.Drawing.Size(68, 38);
            this.pow_result_b.TabIndex = 8;
            this.pow_result_b.Text = "pow result";
            this.pow_result_b.UseVisualStyleBackColor = false;
            this.pow_result_b.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 53);
            this.button1.TabIndex = 9;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(114, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 53);
            this.button2.TabIndex = 10;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(216, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 53);
            this.button3.TabIndex = 11;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(216, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 53);
            this.button4.TabIndex = 14;
            this.button4.Text = "6";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button5.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(114, 208);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 53);
            this.button5.TabIndex = 13;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button6.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(13, 208);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 53);
            this.button6.TabIndex = 12;
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button7.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(216, 267);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 53);
            this.button7.TabIndex = 17;
            this.button7.Text = "9";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button8.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(114, 267);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 53);
            this.button8.TabIndex = 16;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button9.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(13, 267);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 53);
            this.button9.TabIndex = 15;
            this.button9.Text = "7";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button10.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(12, 326);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(198, 53);
            this.button10.TabIndex = 18;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Gold;
            this.button11.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(242, 57);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(68, 42);
            this.button11.TabIndex = 19;
            this.button11.Text = "save result";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Gold;
            this.button12.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(242, 105);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(68, 38);
            this.button12.TabIndex = 20;
            this.button12.Text = "return result";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(323, 391);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pow_result_b);
            this.Controls.Add(this.clear_b);
            this.Controls.Add(this.pow_b);
            this.Controls.Add(this.sqrt_b);
            this.Controls.Add(this.tang_b);
            this.Controls.Add(this.cos_b);
            this.Controls.Add(this.sin_b);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sin_b;
        private System.Windows.Forms.Button cos_b;
        private System.Windows.Forms.Button tang_b;
        private System.Windows.Forms.Button sqrt_b;
        private System.Windows.Forms.Button pow_b;
        private System.Windows.Forms.Button clear_b;
        private System.Windows.Forms.Button pow_result_b;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}

