namespace ddns
{
    partial class authenticationForm
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
            label1 = new Label();
            user = new TextBox();
            label2 = new Label();
            password = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            host = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 59);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // user
            // 
            user.Location = new Point(106, 55);
            user.Margin = new Padding(3, 4, 3, 4);
            user.Name = "user";
            user.Size = new Size(315, 27);
            user.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 97);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // password
            // 
            password.Location = new Point(106, 93);
            password.Margin = new Padding(3, 4, 3, 4);
            password.Name = "password";
            password.PasswordChar = '⦁';
            password.Size = new Size(315, 27);
            password.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(243, 132);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 4;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(336, 132);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 20);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 2;
            label3.Text = "Servidor:";
            // 
            // host
            // 
            host.Location = new Point(106, 16);
            host.Margin = new Padding(3, 4, 3, 4);
            host.Name = "host";
            host.Size = new Size(315, 27);
            host.TabIndex = 1;
            // 
            // authenticationForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(451, 179);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(host);
            Controls.Add(password);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(user);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "authenticationForm";
            Text = "Configuración de la autenticación";
            Load += authenticationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox user;
        private Label label2;
        private TextBox password;
        private Button button1;
        private Button button2;
        private Label label3;
        private TextBox host;
    }
}