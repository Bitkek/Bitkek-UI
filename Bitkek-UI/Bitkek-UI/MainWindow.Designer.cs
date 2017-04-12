namespace Bitkek_UI
{
    partial class MainWindow
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reciveBTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.walletToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWalletToolStripMenuItem,
            this.newWalletToolStripMenuItem,
            this.saveWalletToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openWalletToolStripMenuItem
            // 
            this.openWalletToolStripMenuItem.Name = "openWalletToolStripMenuItem";
            this.openWalletToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openWalletToolStripMenuItem.Text = "Open Wallet";
            // 
            // newWalletToolStripMenuItem
            // 
            this.newWalletToolStripMenuItem.Name = "newWalletToolStripMenuItem";
            this.newWalletToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.newWalletToolStripMenuItem.Text = "New Wallet/Restore";
            this.newWalletToolStripMenuItem.Click += new System.EventHandler(this.newWalletToolStripMenuItem_Click);
            // 
            // saveWalletToolStripMenuItem
            // 
            this.saveWalletToolStripMenuItem.Name = "saveWalletToolStripMenuItem";
            this.saveWalletToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveWalletToolStripMenuItem.Text = "Save Wallet";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.donateToolStripMenuItem.Text = "Donate";
            // 
            // walletToolStripMenuItem
            // 
            this.walletToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendBTKToolStripMenuItem,
            this.reciveBTKToolStripMenuItem});
            this.walletToolStripMenuItem.Name = "walletToolStripMenuItem";
            this.walletToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.walletToolStripMenuItem.Text = "Wallet";
            // 
            // sendBTKToolStripMenuItem
            // 
            this.sendBTKToolStripMenuItem.Name = "sendBTKToolStripMenuItem";
            this.sendBTKToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.sendBTKToolStripMenuItem.Text = "Send BTK";
            // 
            // reciveBTKToolStripMenuItem
            // 
            this.reciveBTKToolStripMenuItem.Name = "reciveBTKToolStripMenuItem";
            this.reciveBTKToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.reciveBTKToolStripMenuItem.Text = "Recive BTK";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Description,
            this.Amount,
            this.Balance});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(36, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(464, 211);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 465);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWalletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWalletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWalletToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendBTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reciveBTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Balance;
    }
}