namespace Operator_Screen_App
{
    partial class Display
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
            btnSimulateOp = new Button();
            btnLists = new Button();
            gridLog = new DataGridView();
            logID = new DataGridViewTextBoxColumn();
            computerHash = new DataGridViewTextBoxColumn();
            ipAddress = new DataGridViewTextBoxColumn();
            userID = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            accessLocation = new DataGridViewTextBoxColumn();
            accessDirection = new DataGridViewTextBoxColumn();
            verifyStatusCode = new DataGridViewTextBoxColumn();
            additionalInfo = new DataGridViewTextBoxColumn();
            logTime = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridLog).BeginInit();
            SuspendLayout();
            // 
            // btnSimulateOp
            // 
            btnSimulateOp.Location = new Point(12, 42);
            btnSimulateOp.Name = "btnSimulateOp";
            btnSimulateOp.Size = new Size(324, 142);
            btnSimulateOp.TabIndex = 0;
            btnSimulateOp.Text = "Simulate Operation";
            btnSimulateOp.UseVisualStyleBackColor = true;
            btnSimulateOp.Click += btnSimulateOp_Click;
            // 
            // btnLists
            // 
            btnLists.Location = new Point(992, 42);
            btnLists.Name = "btnLists";
            btnLists.Size = new Size(324, 142);
            btnLists.TabIndex = 1;
            btnLists.Text = "Echo Verbose";
            btnLists.UseVisualStyleBackColor = true;
            btnLists.Click += btnLists_Click;
            // 
            // gridLog
            // 
            gridLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLog.Columns.AddRange(new DataGridViewColumn[] { logID, computerHash, ipAddress, userID, username, accessLocation, accessDirection, verifyStatusCode, additionalInfo, logTime });
            gridLog.Location = new Point(12, 246);
            gridLog.Name = "gridLog";
            gridLog.RowHeadersWidth = 51;
            gridLog.Size = new Size(1304, 234);
            gridLog.TabIndex = 3;
            // 
            // logID
            // 
            logID.HeaderText = "logID";
            logID.MinimumWidth = 6;
            logID.Name = "logID";
            logID.ReadOnly = true;
            logID.Width = 125;
            // 
            // computerHash
            // 
            computerHash.HeaderText = "computerHash";
            computerHash.MinimumWidth = 6;
            computerHash.Name = "computerHash";
            computerHash.ReadOnly = true;
            computerHash.Width = 125;
            // 
            // ipAddress
            // 
            ipAddress.HeaderText = "ipAddress";
            ipAddress.MinimumWidth = 6;
            ipAddress.Name = "ipAddress";
            ipAddress.ReadOnly = true;
            ipAddress.Width = 125;
            // 
            // userID
            // 
            userID.HeaderText = "userID";
            userID.MinimumWidth = 6;
            userID.Name = "userID";
            userID.ReadOnly = true;
            userID.Width = 125;
            // 
            // username
            // 
            username.HeaderText = "username";
            username.MinimumWidth = 6;
            username.Name = "username";
            username.ReadOnly = true;
            username.Width = 125;
            // 
            // accessLocation
            // 
            accessLocation.HeaderText = "accessLocation";
            accessLocation.MinimumWidth = 6;
            accessLocation.Name = "accessLocation";
            accessLocation.ReadOnly = true;
            accessLocation.Width = 125;
            // 
            // accessDirection
            // 
            accessDirection.HeaderText = "accessDirection";
            accessDirection.MinimumWidth = 6;
            accessDirection.Name = "accessDirection";
            accessDirection.ReadOnly = true;
            accessDirection.Width = 125;
            // 
            // verifyStatusCode
            // 
            verifyStatusCode.HeaderText = "verifyStatusCode";
            verifyStatusCode.MinimumWidth = 6;
            verifyStatusCode.Name = "verifyStatusCode";
            verifyStatusCode.ReadOnly = true;
            verifyStatusCode.Width = 125;
            // 
            // additionalInfo
            // 
            additionalInfo.HeaderText = "additionalInfo";
            additionalInfo.MinimumWidth = 6;
            additionalInfo.Name = "additionalInfo";
            additionalInfo.ReadOnly = true;
            additionalInfo.Width = 125;
            // 
            // logTime
            // 
            logTime.HeaderText = "logTime";
            logTime.MinimumWidth = 6;
            logTime.Name = "logTime";
            logTime.ReadOnly = true;
            logTime.Width = 125;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1331, 492);
            Controls.Add(gridLog);
            Controls.Add(btnLists);
            Controls.Add(btnSimulateOp);
            Name = "Display";
            Text = "Display";
            FormClosing += Display_FormClosing;
            ((System.ComponentModel.ISupportInitialize)gridLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSimulateOp;
        private Button btnLists;
        private DataGridView gridLog;
        private DataGridViewTextBoxColumn logID;
        private DataGridViewTextBoxColumn computerHash;
        private DataGridViewTextBoxColumn ipAddress;
        private DataGridViewTextBoxColumn userID;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn accessLocation;
        private DataGridViewTextBoxColumn accessDirection;
        private DataGridViewTextBoxColumn verifyStatusCode;
        private DataGridViewTextBoxColumn additionalInfo;
        private DataGridViewTextBoxColumn logTime;
    }
}
