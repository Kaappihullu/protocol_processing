namespace ProtocolProcessingGUI
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
            this.SenderNetCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NodeList1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RouteList = new System.Windows.Forms.ListView();
            this.ReceiverNetCOmbo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NodeList2 = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.ReceiveBox = new System.Windows.Forms.TextBox();
            this.MessageSend = new System.Windows.Forms.Button();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.PacketCounterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SenderNetCombo
            // 
            this.SenderNetCombo.FormattingEnabled = true;
            this.SenderNetCombo.Location = new System.Drawing.Point(59, 39);
            this.SenderNetCombo.Name = "SenderNetCombo";
            this.SenderNetCombo.Size = new System.Drawing.Size(121, 21);
            this.SenderNetCombo.TabIndex = 0;
            this.SenderNetCombo.SelectedIndexChanged += new System.EventHandler(this.SenderNetCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SENDER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Network:";
            // 
            // NodeList1
            // 
            this.NodeList1.Location = new System.Drawing.Point(59, 66);
            this.NodeList1.Name = "NodeList1";
            this.NodeList1.Size = new System.Drawing.Size(121, 193);
            this.NodeList1.TabIndex = 4;
            this.NodeList1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select \r\nNode:";
            // 
            // SendBox
            // 
            this.SendBox.Location = new System.Drawing.Point(72, 271);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(100, 20);
            this.SendBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Send \r\nMessage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ROUTES";
            // 
            // RouteList
            // 
            this.RouteList.Location = new System.Drawing.Point(218, 42);
            this.RouteList.Name = "RouteList";
            this.RouteList.Size = new System.Drawing.Size(242, 243);
            this.RouteList.TabIndex = 9;
            this.RouteList.UseCompatibleStateImageBehavior = false;
            // 
            // ReceiverNetCOmbo
            // 
            this.ReceiverNetCOmbo.FormattingEnabled = true;
            this.ReceiverNetCOmbo.Location = new System.Drawing.Point(566, 42);
            this.ReceiverNetCOmbo.Name = "ReceiverNetCOmbo";
            this.ReceiverNetCOmbo.Size = new System.Drawing.Size(121, 21);
            this.ReceiverNetCOmbo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "RECEIVER";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Network:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Select \r\nNode:";
            // 
            // NodeList2
            // 
            this.NodeList2.Location = new System.Drawing.Point(566, 69);
            this.NodeList2.Name = "NodeList2";
            this.NodeList2.Size = new System.Drawing.Size(121, 190);
            this.NodeList2.TabIndex = 14;
            this.NodeList2.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(478, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "Receieved \r\nMessage:";
            // 
            // ReceiveBox
            // 
            this.ReceiveBox.Location = new System.Drawing.Point(576, 271);
            this.ReceiveBox.Name = "ReceiveBox";
            this.ReceiveBox.Size = new System.Drawing.Size(100, 20);
            this.ReceiveBox.TabIndex = 16;
            // 
            // MessageSend
            // 
            this.MessageSend.Location = new System.Drawing.Point(86, 304);
            this.MessageSend.Name = "MessageSend";
            this.MessageSend.Size = new System.Drawing.Size(75, 23);
            this.MessageSend.TabIndex = 17;
            this.MessageSend.Text = "SEND";
            this.MessageSend.UseVisualStyleBackColor = true;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(218, 304);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(242, 57);
            this.LaunchButton.TabIndex = 18;
            this.LaunchButton.Text = "LAUNCH SIMULATION";
            this.LaunchButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(487, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Packet Counter:";
            // 
            // PacketCounterLabel
            // 
            this.PacketCounterLabel.AutoSize = true;
            this.PacketCounterLabel.Location = new System.Drawing.Point(607, 325);
            this.PacketCounterLabel.Name = "PacketCounterLabel";
            this.PacketCounterLabel.Size = new System.Drawing.Size(19, 13);
            this.PacketCounterLabel.TabIndex = 20;
            this.PacketCounterLabel.Text = "pc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 363);
            this.Controls.Add(this.PacketCounterLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.MessageSend);
            this.Controls.Add(this.ReceiveBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NodeList2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ReceiverNetCOmbo);
            this.Controls.Add(this.RouteList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NodeList1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SenderNetCombo);
            this.Name = "Form1";
            this.Text = "FormStart";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SenderNetCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView NodeList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView RouteList;
        private System.Windows.Forms.ComboBox ReceiverNetCOmbo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView NodeList2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ReceiveBox;
        private System.Windows.Forms.Button MessageSend;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label PacketCounterLabel;
    }
}