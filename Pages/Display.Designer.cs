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
            entryNo = new DataGridViewTextBoxColumn();
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
            btnSimulateOp.Location = new Point(12, 66);
            btnSimulateOp.Name = "btnSimulateOp";
            btnSimulateOp.Size = new Size(324, 142);
            btnSimulateOp.TabIndex = 0;
            btnSimulateOp.Text = "Simulate Operation";
            btnSimulateOp.UseVisualStyleBackColor = true;
            btnSimulateOp.Click += btnSimulateOp_Click;
            // 
            // btnLists
            // 
            btnLists.Location = new Point(1070, 66);
            btnLists.Name = "btnLists";
            btnLists.Size = new Size(324, 142);
            btnLists.TabIndex = 1;
            btnLists.Text = "Echo Verbose";
            btnLists.UseVisualStyleBackColor = true;
            btnLists.Click += btnLists_Click;
            // 
            // gridLog
            // 
            gridLog.AllowUserToAddRows = false;
            gridLog.AllowUserToDeleteRows = false;
            gridLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLog.Columns.AddRange(new DataGridViewColumn[] { entryNo, logID, computerHash, ipAddress, userID, username, accessLocation, accessDirection, verifyStatusCode, additionalInfo, logTime });
            gridLog.Cursor = Cursors.Cross;
            gridLog.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridLog.Location = new Point(12, 246);
            gridLog.Name = "gridLog";
            gridLog.ReadOnly = true;
            gridLog.RowHeadersVisible = false;
            gridLog.RowHeadersWidth = 51;
            gridLog.ShowEditingIcon = false;
            gridLog.Size = new Size(1382, 234);
            gridLog.TabIndex = 3;
            gridLog.TabStop = false;
            // 
            // entryNo
            // 
            entryNo.HeaderText = "Entry No";
            entryNo.MinimumWidth = 6;
            entryNo.Name = "entryNo";
            entryNo.ReadOnly = true;
            // 
            // logID
            // 
            logID.HeaderText = "Log ID";
            logID.MinimumWidth = 6;
            logID.Name = "logID";
            logID.ReadOnly = true;
            // 
            // computerHash
            // 
            computerHash.HeaderText = "Computer Hash";
            computerHash.MinimumWidth = 6;
            computerHash.Name = "computerHash";
            computerHash.ReadOnly = true;
            // 
            // ipAddress
            // 
            ipAddress.HeaderText = "IP Address";
            ipAddress.MinimumWidth = 6;
            ipAddress.Name = "ipAddress";
            ipAddress.ReadOnly = true;
            // 
            // userID
            // 
            userID.HeaderText = "User ID";
            userID.MinimumWidth = 6;
            userID.Name = "userID";
            userID.ReadOnly = true;
            // 
            // username
            // 
            username.HeaderText = "Username";
            username.MinimumWidth = 6;
            username.Name = "username";
            username.ReadOnly = true;
            // 
            // accessLocation
            // 
            accessLocation.HeaderText = "Access Location";
            accessLocation.MinimumWidth = 6;
            accessLocation.Name = "accessLocation";
            accessLocation.ReadOnly = true;
            // 
            // accessDirection
            // 
            accessDirection.HeaderText = "Access Direction";
            accessDirection.MinimumWidth = 6;
            accessDirection.Name = "accessDirection";
            accessDirection.ReadOnly = true;
            // 
            // verifyStatusCode
            // 
            verifyStatusCode.HeaderText = "Verify Status Code";
            verifyStatusCode.MinimumWidth = 6;
            verifyStatusCode.Name = "verifyStatusCode";
            verifyStatusCode.ReadOnly = true;
            // 
            // additionalInfo
            // 
            additionalInfo.HeaderText = "Additional Info";
            additionalInfo.MinimumWidth = 6;
            additionalInfo.Name = "additionalInfo";
            additionalInfo.ReadOnly = true;
            // 
            // logTime
            // 
            logTime.HeaderText = "Log Time";
            logTime.MinimumWidth = 6;
            logTime.Name = "logTime";
            logTime.ReadOnly = true;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1406, 492);
            Controls.Add(gridLog);
            Controls.Add(btnLists);
            Controls.Add(btnSimulateOp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Display";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Display";
            TopMost = true;
            FormClosing += Display_FormClosing;
            ((System.ComponentModel.ISupportInitialize)gridLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSimulateOp;
        private Button btnLists;
        private DataGridView gridLog;
        private DataGridViewTextBoxColumn entryNo;
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
