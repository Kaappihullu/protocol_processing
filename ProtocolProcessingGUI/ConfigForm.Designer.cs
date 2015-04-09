namespace ProtocolProcessingGUI
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_networksView = new System.Windows.Forms.TreeView();
            this.m_availableRouters = new System.Windows.Forms.ListBox();
            this.m_LinkButton = new System.Windows.Forms.Button();
            this.m_createNetworkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Routers";
            // 
            // m_networksView
            // 
            this.m_networksView.Location = new System.Drawing.Point(12, 12);
            this.m_networksView.Name = "m_networksView";
            this.m_networksView.Size = new System.Drawing.Size(278, 323);
            this.m_networksView.TabIndex = 3;
            this.m_networksView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_NetworksView_AfterSelect);
            // 
            // m_availableRouters
            // 
            this.m_availableRouters.FormattingEnabled = true;
            this.m_availableRouters.Location = new System.Drawing.Point(440, 40);
            this.m_availableRouters.Name = "m_availableRouters";
            this.m_availableRouters.Size = new System.Drawing.Size(211, 290);
            this.m_availableRouters.TabIndex = 4;
            // 
            // m_LinkButton
            // 
            this.m_LinkButton.Location = new System.Drawing.Point(527, 341);
            this.m_LinkButton.Name = "m_LinkButton";
            this.m_LinkButton.Size = new System.Drawing.Size(75, 23);
            this.m_LinkButton.TabIndex = 5;
            this.m_LinkButton.Text = "LINK";
            this.m_LinkButton.UseVisualStyleBackColor = true;
            this.m_LinkButton.Click += new System.EventHandler(this.m_LinkButton_Click);
            // 
            // m_createNetworkButton
            // 
            this.m_createNetworkButton.Location = new System.Drawing.Point(29, 341);
            this.m_createNetworkButton.Name = "m_createNetworkButton";
            this.m_createNetworkButton.Size = new System.Drawing.Size(144, 28);
            this.m_createNetworkButton.TabIndex = 6;
            this.m_createNetworkButton.Text = "Create Network";
            this.m_createNetworkButton.UseVisualStyleBackColor = true;
            this.m_createNetworkButton.Click += new System.EventHandler(this.m_createNetworkButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 381);
            this.Controls.Add(this.m_createNetworkButton);
            this.Controls.Add(this.m_LinkButton);
            this.Controls.Add(this.m_availableRouters);
            this.Controls.Add(this.m_networksView);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView m_networksView;
        private System.Windows.Forms.ListBox m_availableRouters;
        private System.Windows.Forms.Button m_LinkButton;
        private System.Windows.Forms.Button m_createNetworkButton;

    }
}