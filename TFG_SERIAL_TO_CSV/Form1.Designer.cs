namespace TFG_SERIAL_TO_CSV
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Puerto_Serie = new System.IO.Ports.SerialPort(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PuertoCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudRateCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Parar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Puerto_Serie
            // 
            this.Puerto_Serie.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Puerto_Serie_DataReceived);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(78, 134);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(65, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Empezar";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 66);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PuertoCombo
            // 
            this.PuertoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PuertoCombo.FormattingEnabled = true;
            this.PuertoCombo.Location = new System.Drawing.Point(67, 12);
            this.PuertoCombo.Name = "PuertoCombo";
            this.PuertoCombo.Size = new System.Drawing.Size(65, 21);
            this.PuertoCombo.TabIndex = 0;
            this.PuertoCombo.DropDown += new System.EventHandler(this.PuertoCombo_DropDown);
            this.PuertoCombo.SelectedIndexChanged += new System.EventHandler(this.Seleccion_Puerto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puerto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BaudRate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BaudRateCombo
            // 
            this.BaudRateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRateCombo.FormattingEnabled = true;
            this.BaudRateCombo.Location = new System.Drawing.Point(67, 39);
            this.BaudRateCombo.Name = "BaudRateCombo";
            this.BaudRateCombo.Size = new System.Drawing.Size(65, 21);
            this.BaudRateCombo.TabIndex = 4;
            this.BaudRateCombo.SelectedIndexChanged += new System.EventHandler(this.BaudRateCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iteraciones";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Parar
            // 
            this.Parar.Location = new System.Drawing.Point(7, 134);
            this.Parar.Name = "Parar";
            this.Parar.Size = new System.Drawing.Size(65, 23);
            this.Parar.TabIndex = 9;
            this.Parar.Text = "Parar";
            this.Parar.UseVisualStyleBackColor = true;
            this.Parar.Click += new System.EventHandler(this.Parar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(155, 169);
            this.Controls.Add(this.Parar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BaudRateCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.PuertoCombo);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort Puerto_Serie;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox PuertoCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BaudRateCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Parar;
    }
}

