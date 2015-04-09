namespace ProtocolProcessingGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_networkView = new System.Windows.Forms.TreeView();
            this.m_addNetworkButton = new System.Windows.Forms.Button();
            this.m_intervalTimer = new System.Windows.Forms.Timer(this.components);
            this.m_packetCounterLabel = new System.Windows.Forms.Label();
            this.m_toolBar = new System.Windows.Forms.ToolStrip();
            this.m_configButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_networkView
            // 
            this.m_networkView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_networkView.Location = new System.Drawing.Point(9, 27);
            this.m_networkView.Margin = new System.Windows.Forms.Padding(2);
            this.m_networkView.Name = "m_networkView";
            this.m_networkView.Size = new System.Drawing.Size(359, 369);
            this.m_networkView.TabIndex = 0;
            this.m_networkView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_networkView_NodeMouseDoubleClick);
            // 
            // m_addNetworkButton
            // 
            this.m_addNetworkButton.Location = new System.Drawing.Point(276, 400);
            this.m_addNetworkButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_addNetworkButton.Name = "m_addNetworkButton";
            this.m_addNetworkButton.Size = new System.Drawing.Size(92, 29);
            this.m_addNetworkButton.TabIndex = 1;
            this.m_addNetworkButton.Text = "Add Network";
            this.m_addNetworkButton.UseVisualStyleBackColor = true;
            this.m_addNetworkButton.Click += new System.EventHandler(this.m_addNetworkButton_Click);
            // 
            // m_intervalTimer
            // 
            this.m_intervalTimer.Enabled = true;
            this.m_intervalTimer.Interval = 20;
            this.m_intervalTimer.Tick += new System.EventHandler(this.m_intervalTimer_Tick);
            // 
            // m_packetCounterLabel
            // 
            this.m_packetCounterLabel.AutoSize = true;
            this.m_packetCounterLabel.Location = new System.Drawing.Point(6, 408);
            this.m_packetCounterLabel.Name = "m_packetCounterLabel";
            this.m_packetCounterLabel.Size = new System.Drawing.Size(84, 13);
            this.m_packetCounterLabel.TabIndex = 2;
            this.m_packetCounterLabel.Text = "PacketCounter: ";
            // 
            // m_toolBar
            // 
            this.m_toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_configButton});
            this.m_toolBar.Location = new System.Drawing.Point(0, 0);
            this.m_toolBar.Name = "m_toolBar";
            this.m_toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.m_toolBar.Size = new System.Drawing.Size(376, 25);
            this.m_toolBar.TabIndex = 3;
            this.m_toolBar.Text = "toolStrip1";
            this.m_toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // m_configButton
            // 
            this.m_configButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_configButton.Image = ((System.Drawing.Image)(resources.GetObject("m_configButton.Image")));
            this.m_configButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_configButton.Name = "m_configButton";
            this.m_configButton.Size = new System.Drawing.Size(47, 22);
            this.m_configButton.Text = "Config";
            this.m_configButton.Click += new System.EventHandler(this.m_configButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 439);
            this.Controls.Add(this.m_toolBar);
            this.Controls.Add(this.m_packetCounterLabel);
            this.Controls.Add(this.m_addNetworkButton);
            this.Controls.Add(this.m_networkView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.m_toolBar.ResumeLayout(false);
            this.m_toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView m_networkView;
        private System.Windows.Forms.Button m_addNetworkButton;
        private System.Windows.Forms.Timer m_intervalTimer;
        private System.Windows.Forms.Label m_packetCounterLabel;
        private System.Windows.Forms.ToolStrip m_toolBar;
        private System.Windows.Forms.ToolStripButton m_configButton;
    }
}

