namespace ServerBootstrapper
{
    partial class StartupForm
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
            this.txtServiceUrl = new System.Windows.Forms.TextBox();
            this.btnStartService = new System.Windows.Forms.Button();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.btnStopService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServiceUrl
            // 
            this.txtServiceUrl.Location = new System.Drawing.Point(23, 24);
            this.txtServiceUrl.Name = "txtServiceUrl";
            this.txtServiceUrl.Size = new System.Drawing.Size(236, 20);
            this.txtServiceUrl.TabIndex = 0;
            this.txtServiceUrl.Text = "http://localhost:8080";
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(97, 72);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(75, 23);
            this.btnStartService.TabIndex = 1;
            this.btnStartService.Text = "Start";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(20, 146);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(35, 13);
            this.lblServiceStatus.TabIndex = 2;
            this.lblServiceStatus.Text = "label1";
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(178, 72);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(75, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "Stop";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblServiceStatus);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.txtServiceUrl);
            this.Name = "StartupForm";
            this.Text = "StartupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceUrl;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Button btnStopService;
    }
}