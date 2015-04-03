namespace WindowsFormsApplication3
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.NetworkLabel = new System.Windows.Forms.Label();
            this.NetworkButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NodeLabel = new System.Windows.Forms.Label();
            this.NodeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TCPLabel = new System.Windows.Forms.Label();
            this.TCPButton = new System.Windows.Forms.Button();
            this.AS01 = new System.Windows.Forms.Label();
            this.AS02 = new System.Windows.Forms.Label();
            this.AS02Box = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AS01Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AS02Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS01Box)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(2, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(380, 181);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.";
            // 
            // NetworkLabel
            // 
            this.NetworkLabel.AutoSize = true;
            this.NetworkLabel.Location = new System.Drawing.Point(53, 188);
            this.NetworkLabel.Name = "NetworkLabel";
            this.NetworkLabel.Size = new System.Drawing.Size(98, 13);
            this.NetworkLabel.TabIndex = 2;
            this.NetworkLabel.Text = "No Network Added";
            this.NetworkLabel.Click += new System.EventHandler(this.NetworkLabel_Click);
            // 
            // NetworkButton
            // 
            this.NetworkButton.Location = new System.Drawing.Point(236, 187);
            this.NetworkButton.Name = "NetworkButton";
            this.NetworkButton.Size = new System.Drawing.Size(89, 23);
            this.NetworkButton.TabIndex = 3;
            this.NetworkButton.Text = "Add Network";
            this.NetworkButton.UseVisualStyleBackColor = true;
            this.NetworkButton.Click += new System.EventHandler(this.NetworkButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "2.";
            // 
            // NodeLabel
            // 
            this.NodeLabel.AutoSize = true;
            this.NodeLabel.Location = new System.Drawing.Point(53, 217);
            this.NodeLabel.Name = "NodeLabel";
            this.NodeLabel.Size = new System.Drawing.Size(84, 13);
            this.NodeLabel.TabIndex = 5;
            this.NodeLabel.Text = "No Node Added";
            // 
            // NodeButton
            // 
            this.NodeButton.Location = new System.Drawing.Point(236, 217);
            this.NodeButton.Name = "NodeButton";
            this.NodeButton.Size = new System.Drawing.Size(89, 23);
            this.NodeButton.TabIndex = 6;
            this.NodeButton.Text = "Add Nodes";
            this.NodeButton.UseVisualStyleBackColor = true;
            this.NodeButton.Click += new System.EventHandler(this.NodeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "3.";
            // 
            // TCPLabel
            // 
            this.TCPLabel.AutoSize = true;
            this.TCPLabel.Location = new System.Drawing.Point(53, 245);
            this.TCPLabel.Name = "TCPLabel";
            this.TCPLabel.Size = new System.Drawing.Size(135, 13);
            this.TCPLabel.TabIndex = 8;
            this.TCPLabel.Text = "No Active TCP Connection";
            // 
            // TCPButton
            // 
            this.TCPButton.Location = new System.Drawing.Point(236, 245);
            this.TCPButton.Name = "TCPButton";
            this.TCPButton.Size = new System.Drawing.Size(89, 36);
            this.TCPButton.TabIndex = 9;
            this.TCPButton.Text = "Setup TCP connection";
            this.TCPButton.UseVisualStyleBackColor = true;
            this.TCPButton.Click += new System.EventHandler(this.TCPButton_Click);
            // 
            // AS01
            // 
            this.AS01.AutoSize = true;
            this.AS01.Location = new System.Drawing.Point(15, 13);
            this.AS01.Name = "AS01";
            this.AS01.Size = new System.Drawing.Size(33, 13);
            this.AS01.TabIndex = 10;
            this.AS01.Text = "AS01";
            this.AS01.Visible = false;
            this.AS01.Click += new System.EventHandler(this.label2_Click);
            // 
            // AS02
            // 
            this.AS02.AutoSize = true;
            this.AS02.Location = new System.Drawing.Point(289, 13);
            this.AS02.Name = "AS02";
            this.AS02.Size = new System.Drawing.Size(33, 13);
            this.AS02.TabIndex = 11;
            this.AS02.Text = "AS02";
            this.AS02.Visible = false;
            // 
            // AS02Box
            // 
            this.AS02Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AS02Box.Image = global::WindowsFormsApplication3.Properties.Resources.router;
            this.AS02Box.Location = new System.Drawing.Point(270, 40);
            this.AS02Box.Name = "AS02Box";
            this.AS02Box.Size = new System.Drawing.Size(100, 86);
            this.AS02Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AS02Box.TabIndex = 14;
            this.AS02Box.TabStop = false;
            this.AS02Box.Visible = false;
            this.AS02Box.Click += new System.EventHandler(this.AS02Box_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // AS01Box
            // 
            this.AS01Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AS01Box.Location = new System.Drawing.Point(15, 40);
            this.AS01Box.Name = "AS01Box";
            this.AS01Box.Size = new System.Drawing.Size(109, 86);
            this.AS01Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AS01Box.TabIndex = 12;
            this.AS01Box.TabStop = false;
            this.AS01Box.Visible = false;
            this.AS01Box.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 316);
            this.Controls.Add(this.AS02Box);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.AS01Box);
            this.Controls.Add(this.AS02);
            this.Controls.Add(this.AS01);
            this.Controls.Add(this.TCPButton);
            this.Controls.Add(this.TCPLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NodeButton);
            this.Controls.Add(this.NodeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NetworkButton);
            this.Controls.Add(this.NetworkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Network Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.AS02Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS01Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NetworkLabel;
        private System.Windows.Forms.Button NetworkButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NodeLabel;
        private System.Windows.Forms.Button NodeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TCPLabel;
        private System.Windows.Forms.Button TCPButton;
        private System.Windows.Forms.Label AS01;
        private System.Windows.Forms.Label AS02;
        private System.Windows.Forms.PictureBox AS01Box;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox AS02Box;
    }
}

