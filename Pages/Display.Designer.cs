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
            SuspendLayout();
            // 
            // btnSimulateOp
            // 
            btnSimulateOp.Location = new Point(337, 43);
            btnSimulateOp.Name = "btnSimulateOp";
            btnSimulateOp.Size = new Size(324, 142);
            btnSimulateOp.TabIndex = 0;
            btnSimulateOp.Text = "Simulate Operation";
            btnSimulateOp.UseVisualStyleBackColor = true;
            btnSimulateOp.Click += this.btnSimulateOp_Click;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSimulateOp);
            Name = "Display";
            Text = "Display";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSimulateOp;
    }
}
