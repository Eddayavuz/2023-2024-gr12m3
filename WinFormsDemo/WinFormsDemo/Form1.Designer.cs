namespace WinFormsDemo
{
    partial class rgstr
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
            button1 = new Button();
            uNameTxt = new TextBox();
            emailTxt = new TextBox();
            passwordTxt = new TextBox();
            label2 = new Label();
            cPasswordTxt = new TextBox();
            length = new Label();
            capital = new Label();
            lowercase = new Label();
            number = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift Light", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(59, 306);
            button1.Name = "button1";
            button1.Size = new Size(184, 30);
            button1.TabIndex = 0;
            button1.Text = "Sign Up";
            button1.UseVisualStyleBackColor = false;
            // 
            // uNameTxt
            // 
            uNameTxt.BackColor = Color.MintCream;
            uNameTxt.BorderStyle = BorderStyle.FixedSingle;
            uNameTxt.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            uNameTxt.Location = new Point(59, 170);
            uNameTxt.Name = "uNameTxt";
            uNameTxt.PlaceholderText = "username";
            uNameTxt.Size = new Size(184, 28);
            uNameTxt.TabIndex = 1;
            uNameTxt.Validating += uNameTxt_Validating;
            // 
            // emailTxt
            // 
            emailTxt.BackColor = Color.MintCream;
            emailTxt.BorderStyle = BorderStyle.FixedSingle;
            emailTxt.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            emailTxt.Location = new Point(59, 204);
            emailTxt.Name = "emailTxt";
            emailTxt.PlaceholderText = "e-mail";
            emailTxt.Size = new Size(184, 28);
            emailTxt.TabIndex = 2;
            emailTxt.Validating += emailTxt_Validating;
            // 
            // passwordTxt
            // 
            passwordTxt.BackColor = Color.MintCream;
            passwordTxt.BorderStyle = BorderStyle.FixedSingle;
            passwordTxt.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTxt.Location = new Point(59, 238);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PasswordChar = '*';
            passwordTxt.PlaceholderText = "password";
            passwordTxt.Size = new Size(184, 28);
            passwordTxt.TabIndex = 3;
            passwordTxt.TextChanged += passwordTxt_TextChanged;
            passwordTxt.Validating += passwordTxt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bahnschrift Light", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.CadetBlue;
            label2.Location = new Point(52, 134);
            label2.Name = "label2";
            label2.Size = new Size(152, 33);
            label2.TabIndex = 4;
            label2.Text = "Get Started";
            // 
            // cPasswordTxt
            // 
            cPasswordTxt.BackColor = Color.MintCream;
            cPasswordTxt.BorderStyle = BorderStyle.FixedSingle;
            cPasswordTxt.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cPasswordTxt.Location = new Point(59, 272);
            cPasswordTxt.Name = "cPasswordTxt";
            cPasswordTxt.PlaceholderText = "re-type password";
            cPasswordTxt.Size = new Size(184, 28);
            cPasswordTxt.TabIndex = 6;
            // 
            // length
            // 
            length.AutoSize = true;
            length.BackColor = Color.Transparent;
            length.Font = new Font("Yu Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            length.ForeColor = Color.Gray;
            length.Location = new Point(57, 354);
            length.Name = "length";
            length.Size = new Size(185, 14);
            length.TabIndex = 7;
            length.Text = "should have more than 8 characters";
            length.Visible = false;
            // 
            // capital
            // 
            capital.AutoSize = true;
            capital.BackColor = Color.Transparent;
            capital.Font = new Font("Yu Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            capital.ForeColor = Color.Gray;
            capital.Location = new Point(57, 369);
            capital.Name = "capital";
            capital.Size = new Size(147, 14);
            capital.TabIndex = 8;
            capital.Text = "should contain capital letter";
            capital.Visible = false;
            // 
            // lowercase
            // 
            lowercase.AutoSize = true;
            lowercase.BackColor = Color.Transparent;
            lowercase.Font = new Font("Yu Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lowercase.ForeColor = Color.Gray;
            lowercase.Location = new Point(57, 384);
            lowercase.Name = "lowercase";
            lowercase.Size = new Size(165, 14);
            lowercase.TabIndex = 9;
            lowercase.Text = "should contain lowercase letter";
            lowercase.Visible = false;
            // 
            // number
            // 
            number.AutoSize = true;
            number.BackColor = Color.Transparent;
            number.Font = new Font("Yu Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            number.ForeColor = Color.Gray;
            number.Location = new Point(57, 399);
            number.Name = "number";
            number.Size = new Size(120, 14);
            number.TabIndex = 10;
            number.Text = "should contain number";
            number.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(104, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 83);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // rgstr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(301, 468);
            Controls.Add(pictureBox1);
            Controls.Add(number);
            Controls.Add(lowercase);
            Controls.Add(capital);
            Controls.Add(length);
            Controls.Add(cPasswordTxt);
            Controls.Add(label2);
            Controls.Add(passwordTxt);
            Controls.Add(emailTxt);
            Controls.Add(uNameTxt);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "rgstr";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox uNameTxt;
        private TextBox emailTxt;
        private TextBox passwordTxt;
        private Label label2;
        private Label loginBtn;
        private TextBox cPasswordTxt;
        private Label length;
        private Label capital;
        private Label lowercase;
        private Label number;
        private PictureBox pictureBox1;
    }
}