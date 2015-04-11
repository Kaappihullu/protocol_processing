namespace ProtocolProcessingGUI
{
    partial class NetworkNodeForm
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
            this.components = new System.ComponentModel.Container();
            this.m_logBox = new System.Windows.Forms.TextBox();
            this.m_commandBox = new System.Windows.Forms.TextBox();
            this.m_commandButton = new System.Windows.Forms.Button();
            this.m_updateInterval = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // m_logBox
            // 
            this.m_logBox.Location = new System.Drawing.Point(10, 11);
            this.m_logBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_logBox.Multiline = true;
            this.m_logBox.Name = "m_logBox";
            this.m_logBox.ReadOnly = true;
            this.m_logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_logBox.Size = new System.Drawing.Size(272, 268);
            this.m_logBox.TabIndex = 0;
            // 
            // m_commandBox
            // 
            this.m_commandBox.Location = new System.Drawing.Point(10, 283);
            this.m_commandBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_commandBox.Name = "m_commandBox";
            this.m_commandBox.Size = new System.Drawing.Size(186, 20);
            this.m_commandBox.TabIndex = 1;
            // 
            // m_commandButton
            // 
            this.m_commandButton.Location = new System.Drawing.Point(225, 283);
            this.m_commandButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_commandButton.Name = "m_commandButton";
            this.m_commandButton.Size = new System.Drawing.Size(56, 19);
            this.m_commandButton.TabIndex = 2;
            this.m_commandButton.Text = "Enter";
            this.m_commandButton.UseVisualStyleBackColor = true;
            this.m_commandButton.Click += new System.EventHandler(this.m_commandButton_Click);
            // 
            // m_updateInterval
            // 
            this.m_updateInterval.Enabled = true;
            this.m_updateInterval.Interval = 500;
            this.m_updateInterval.Tick += new System.EventHandler(this.m_updateInterval_Tick);
            // 
            // NetworkNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 307);
            this.Controls.Add(this.m_commandButton);
            this.Controls.Add(this.m_commandBox);
            this.Controls.Add(this.m_logBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NetworkNodeForm";
            this.Text = "NetworkNodeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_logBox;
        private System.Windows.Forms.TextBox m_commandBox;
        private System.Windows.Forms.Button m_commandButton;
        private System.Windows.Forms.Timer m_updateInterval;
    }
}