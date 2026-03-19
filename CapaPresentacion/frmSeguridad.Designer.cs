namespace PantallasSistemaFacturacion
{
    partial class frmSeguridad
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
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            txtClave = new TextBox();
            txtUsuario = new TextBox();
            cmbEmpleado = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txtGuardar = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtClave);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(cmbEmpleado);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(118, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(795, 370);
            panel1.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Location = new Point(190, 286);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 2);
            panel3.TabIndex = 28;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Location = new Point(190, 228);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 2);
            panel2.TabIndex = 27;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.White;
            txtClave.BorderStyle = BorderStyle.None;
            txtClave.Font = new Font("Segoe UI", 12F);
            txtClave.Location = new Point(190, 263);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Clave";
            txtClave.Size = new Size(250, 22);
            txtClave.TabIndex = 26;
            txtClave.UseSystemPasswordChar = true;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(190, 205);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(250, 22);
            txtUsuario.TabIndex = 25;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.Font = new Font("Segoe UI", 12F);
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(172, 104);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(400, 29);
            cmbEmpleado.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(77, 107);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 2;
            label2.Text = "Empleado";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(793, 50);
            label1.TabIndex = 1;
            label1.Text = "Administración De Usuarios Del Sistema";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtGuardar
            // 
            txtGuardar.BackColor = Color.SteelBlue;
            txtGuardar.BackgroundImageLayout = ImageLayout.None;
            txtGuardar.FlatStyle = FlatStyle.Flat;
            txtGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtGuardar.ForeColor = SystemColors.ButtonFace;
            txtGuardar.Location = new Point(309, 466);
            txtGuardar.Name = "txtGuardar";
            txtGuardar.Size = new Size(123, 39);
            txtGuardar.TabIndex = 23;
            txtGuardar.Text = "Actualizar";
            txtGuardar.UseVisualStyleBackColor = false;
            txtGuardar.Click += txtGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.SteelBlue;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(591, 466);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(123, 39);
            btnSalir.TabIndex = 24;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmSeguridad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 587);
            Controls.Add(panel1);
            Controls.Add(txtGuardar);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmSeguridad";
            Text = "frmSeguridad";
            Load += frmSeguridad_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button txtGuardar;
        private Button btnSalir;
        private ComboBox cmbEmpleado;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Panel panel2;
        private Panel panel3;
    }
}