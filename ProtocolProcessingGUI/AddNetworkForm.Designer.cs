namespace ProtocolProcessingGUI
{
    partial class AddNetworkForm
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
            this.m_nameTagBox = new System.Windows.Forms.TextBox();
            this.m_ipRangeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_nameTagBox
            // 
            this.m_nameTagBox.Location = new System.Drawing.Point(12, 12);
            this.m_nameTagBox.Name = "m_nameTagBox";
            this.m_nameTagBox.Size = new System.Drawing.Size(202, 20);
            this.m_nameTagBox.TabIndex = 0;
            // 
            // m_ipRangeBox
            // 
            this.m_ipRangeBox.Location = new System.Drawing.Point(12, 76);
            this.m_ipRangeBox.Name = "m_ipRangeBox";
            this.m_ipRangeBox.Size = new System.Drawing.Size(202, 20);
            this.m_ipRangeBox.TabIndex = 1;
            this.m_ipRangeBox.Text = "169.0.0.1/1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IPRange";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NameTag";
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Location = new System.Drawing.Point(21, 144);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 5;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Click += new System.EventHandler(this.m_cancelButton_Click);
            // 
            // m_okButton
            // 
            this.m_okButton.Location = new System.Drawing.Point(133, 144);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 6;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.m_okButton_Click);
            // 
            // AddNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 175);
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_ipRangeBox);
            this.Controls.Add(this.m_nameTagBox);
            this.Name = "AddNetworkForm";
            this.Text = "AddNetworkForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_nameTagBox;
        private System.Windows.Forms.TextBox m_ipRangeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Button m_okButton;
    }
}