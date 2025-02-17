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
            lblContext = new Label();
            lblConfirm = new Label();
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
            btnConfirm.Location = new Point(239, 288);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(305, 121);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm Your Identity";
            btnConfirm.UseVisualStyleBackColor = true;
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
            // lblContext
            // 
            lblContext.AutoSize = true;
            lblContext.BackColor = Color.Gainsboro;
            lblContext.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblContext.Location = new Point(200, 139);
            lblContext.MinimumSize = new Size(400, 50);
            lblContext.Name = "lblContext";
            lblContext.Size = new Size(400, 50);
            lblContext.TabIndex = 3;
            lblContext.Text = "Status Code:";
            lblContext.TextAlign = ContentAlignment.MiddleCenter;
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
            // PopUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(lblConfirm);
            Controls.Add(lblContext);
            Controls.Add(lblAttention);
            Controls.Add(btnConfirm);
            Controls.Add(lblTime);
            MinimizeBox = false;
            Name = "PopUp";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopUp";
            TopMost = true;
            FormClosing += PopUp_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tmrConfirm;
        private Label lblTime;
        private Button btnConfirm;
        private Label lblAttention;
        private Label lblContext;
        private Label lblConfirm;
    }
}