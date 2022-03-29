namespace ETS2_DualSenseAT_Mod
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DynamicTriggers = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rgbledHealth = new System.Windows.Forms.CheckBox();
            this.ammoAdpTriggers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 165);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(89, 13);
            this.statusLbl.TabIndex = 0;
            this.statusLbl.Text = "Status: Unknown";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ResidentEvil4HDProject.Properties.Resources.resident_evil_4_hd_project_trailer_lancamento3;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // DynamicTriggers
            // 
            this.DynamicTriggers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DynamicTriggers_DoWork);
            this.DynamicTriggers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DynamicTriggers_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ammoAdpTriggers);
            this.groupBox1.Controls.Add(this.rgbledHealth);
            this.groupBox1.Location = new System.Drawing.Point(13, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 121);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DualSense Settings";
            // 
            // rgbledHealth
            // 
            this.rgbledHealth.AutoSize = true;
            this.rgbledHealth.Checked = true;
            this.rgbledHealth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rgbledHealth.Location = new System.Drawing.Point(7, 20);
            this.rgbledHealth.Name = "rgbledHealth";
            this.rgbledHealth.Size = new System.Drawing.Size(132, 17);
            this.rgbledHealth.TabIndex = 0;
            this.rgbledHealth.Text = "RGBLed Health Effect";
            this.rgbledHealth.UseVisualStyleBackColor = true;
            // 
            // ammoAdpTriggers
            // 
            this.ammoAdpTriggers.AutoSize = true;
            this.ammoAdpTriggers.Checked = true;
            this.ammoAdpTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ammoAdpTriggers.Location = new System.Drawing.Point(7, 43);
            this.ammoAdpTriggers.Name = "ammoAdpTriggers";
            this.ammoAdpTriggers.Size = new System.Drawing.Size(150, 17);
            this.ammoAdpTriggers.TabIndex = 1;
            this.ammoAdpTriggers.Text = "Ammo Adaptative Triggers";
            this.ammoAdpTriggers.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 354);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 223);
            this.Name = "Form1";
            this.Text = "Resident Evil 4 HD Project| DualSense AT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker DynamicTriggers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox rgbledHealth;
        private System.Windows.Forms.CheckBox ammoAdpTriggers;
    }
}

