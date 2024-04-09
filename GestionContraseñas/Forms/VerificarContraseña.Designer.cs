namespace GestionContraseñas.Forms
{
    partial class VerificarContraseña
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
            txtContreseña = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(294, 15);
            label1.TabIndex = 0;
            label1.Text = "INGRESE SU CONTRASEÑA PARA VALIDAR SU ACCION";
            label1.Click += label1_Click;
            // 
            // txtContreseña
            // 
            txtContreseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContreseña.Location = new Point(43, 38);
            txtContreseña.Name = "txtContreseña";
            txtContreseña.Size = new Size(225, 29);
            txtContreseña.TabIndex = 17;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(43, 73);
            button1.Name = "button1";
            button1.Size = new Size(108, 34);
            button1.TabIndex = 18;
            button1.Text = "Verificar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(160, 73);
            button2.Name = "button2";
            button2.Size = new Size(108, 34);
            button2.TabIndex = 19;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // VerificarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(317, 117);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtContreseña);
            Controls.Add(label1);
            Name = "VerificarContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VerificarContraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtContreseña;
        private Button button1;
        private Button button2;
    }
}