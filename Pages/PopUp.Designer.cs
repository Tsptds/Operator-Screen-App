namespace Operator_Screen_App.Pages
{
    partial class PopUp
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
            components = new System.ComponentModel.Container();
            tmrConfirm = new System.Windows.Forms.Timer(components);
            lblTime = new Label();
            btnConfirm = new Button();
            lblAttention = new Label();
            lblStatus = new Label();
            lblConfirm = new Label();
            tmrAlert = new System.Windows.Forms.Timer(components);
            barTimer = new ProgressBar();
            barConfirm = new ProgressBar();
            lblUsername = new Label();
            btnDeny = new Button();
            SuspendLayout();
            // 
            // tmrConfirm
            // 
            tmrConfirm.Interval = 1000;
            tmrConfirm.Tick += tmrConfirm_Tick;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.FromArgb(224, 224, 224);
            lblTime.Font = new Font("Segoe UI", 16F);
            lblTime.Location = new Point(736, 9);
            lblTime.Name = "lblTime";
            lblTime.Padding = new Padding(5);
            lblTime.Size = new Size(57, 47);
            lblTime.TabIndex = 0;
            lblTime.Text = "30";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(128, 255, 128);
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnConfirm.Location = new Point(488, 288);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(305, 121);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm This Entry";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblAttention
            // 
            lblAttention.AutoSize = true;
            lblAttention.BackColor = Color.Red;
            lblAttention.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAttention.Location = new Point(200, 9);
            lblAttention.MinimumSize = new Size(400, 50);
            lblAttention.Name = "lblAttention";
            lblAttention.Size = new Size(400, 50);
            lblAttention.TabIndex = 2;
            lblAttention.Text = "ACTION REQUIRED";
            lblAttention.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoEllipsis = true;
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Gainsboro;
            lblStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(200, 94);
            lblStatus.MinimumSize = new Size(400, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(400, 50);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.BackColor = Color.Gainsboro;
            lblConfirm.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblConfirm.Location = new Point(200, 226);
            lblConfirm.MinimumSize = new Size(400, 50);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(400, 50);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Please Confirm Manually";
            lblConfirm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tmrAlert
            // 
            tmrAlert.Interval = 1000;
            tmrAlert.Tick += tmrAlert_Tick;
            // 
            // barTimer
            // 
            barTimer.Enabled = false;
            barTimer.Location = new Point(12, 415);
            barTimer.Maximum = 5;
            barTimer.Name = "barTimer";
            barTimer.Size = new Size(781, 29);
            barTimer.Step = -1;
            barTimer.TabIndex = 5;
            barTimer.Value = 5;
            barTimer.Visible = false;
            // 
            // barConfirm
            // 
            barConfirm.Location = new Point(200, 62);
            barConfirm.Maximum = 30;
            barConfirm.Name = "barConfirm";
            barConfirm.Size = new Size(400, 29);
            barConfirm.Step = -1;
            barConfirm.TabIndex = 6;
            barConfirm.Value = 30;
            // 
            // lblUsername
            // 
            lblUsername.AutoEllipsis = true;
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Gainsboro;
            lblUsername.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUsername.ForeColor = SystemColors.ControlText;
            lblUsername.Location = new Point(200, 144);
            lblUsername.MinimumSize = new Size(400, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(400, 50);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "User:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDeny
            // 
            btnDeny.BackColor = Color.FromArgb(255, 128, 128);
            btnDeny.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDeny.Location = new Point(12, 288);
            btnDeny.Name = "btnDeny";
            btnDeny.Size = new Size(305, 121);
            btnDeny.TabIndex = 8;
            btnDeny.Text = "Deny";
            btnDeny.UseVisualStyleBackColor = false;
            btnDeny.Click += btnDeny_Click;
            // 
            // PopUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnDeny);
            Controls.Add(lblUsername);
            Controls.Add(barConfirm);
            Controls.Add(barTimer);
            Controls.Add(lblConfirm);
            Controls.Add(lblStatus);
            Controls.Add(lblAttention);
            Controls.Add(btnConfirm);
            Controls.Add(lblTime);
            MinimizeBox = false;
            Name = "PopUp";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopUp";
            FormClosing += PopUp_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tmrConfirm;
        private Label lblTime;
        private Button btnConfirm;
        private Label lblAttention;
        private Label lblStatus;
        private Label lblConfirm;
        private System.Windows.Forms.Timer tmrAlert;
        private ProgressBar barTimer;
        private ProgressBar barConfirm;
        private Label lblUsername;
        private Button btnDeny;
    }
}