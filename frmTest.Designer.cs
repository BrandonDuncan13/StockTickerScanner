namespace StockLoadTest
{
    partial class frmTest
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
            btnTestLoad = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            btnPath = new Button();
            txtPath = new TextBox();
            lblPath = new Label();
            dlgPath = new FolderBrowserDialog();
            topTenDataGridView = new DataGridView();
            Ticker0 = new DataGridViewTextBoxColumn();
            LastTradePrice0 = new DataGridViewTextBoxColumn();
            PercentChange0 = new DataGridViewTextBoxColumn();
            AverageVolume0 = new DataGridViewTextBoxColumn();
            TotalMinVolume0 = new DataGridViewTextBoxColumn();
            RelativeVolume0 = new DataGridViewTextBoxColumn();
            TopTenLabel = new Label();
            BottomTenLabel = new Label();
            HighestRelativeLabel = new Label();
            bottomTenDataGridView = new DataGridView();
            Ticker1 = new DataGridViewTextBoxColumn();
            LastTradePrice1 = new DataGridViewTextBoxColumn();
            PercentChange1 = new DataGridViewTextBoxColumn();
            AverageVolume1 = new DataGridViewTextBoxColumn();
            TotalMinVolume1 = new DataGridViewTextBoxColumn();
            RelativeVolume1 = new DataGridViewTextBoxColumn();
            highestRelativeVolumeDataGridView = new DataGridView();
            Ticker2 = new DataGridViewTextBoxColumn();
            LastTradePrice2 = new DataGridViewTextBoxColumn();
            PercentChange2 = new DataGridViewTextBoxColumn();
            AverageVolume2 = new DataGridViewTextBoxColumn();
            TotalMinVolume2 = new DataGridViewTextBoxColumn();
            RelativeVolume2 = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)topTenDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bottomTenDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)highestRelativeVolumeDataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnTestLoad
            // 
            btnTestLoad.Location = new Point(568, 8);
            btnTestLoad.Margin = new Padding(2);
            btnTestLoad.Name = "btnTestLoad";
            btnTestLoad.Size = new Size(109, 21);
            btnTestLoad.TabIndex = 0;
            btnTestLoad.Text = "Scan Stocks";
            btnTestLoad.UseVisualStyleBackColor = true;
            btnTestLoad.Click += btnTestLoad_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 717);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(1072, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Status";
            // 
            // btnPath
            // 
            btnPath.Location = new Point(514, 9);
            btnPath.Margin = new Padding(2);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(36, 18);
            btnPath.TabIndex = 2;
            btnPath.Text = "...";
            btnPath.TextAlign = ContentAlignment.TopCenter;
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(113, 9);
            txtPath.Margin = new Padding(2);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(394, 23);
            txtPath.TabIndex = 3;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(25, 9);
            lblPath.Margin = new Padding(2, 0, 2, 0);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(72, 15);
            lblPath.TabIndex = 4;
            lblPath.Text = "Path to files:";
            // 
            // topTenDataGridView
            // 
            topTenDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            topTenDataGridView.Columns.AddRange(new DataGridViewColumn[] { Ticker0, LastTradePrice0, PercentChange0, AverageVolume0, TotalMinVolume0, RelativeVolume0 });
            topTenDataGridView.Location = new Point(25, 48);
            topTenDataGridView.Margin = new Padding(3, 2, 3, 2);
            topTenDataGridView.Name = "topTenDataGridView";
            topTenDataGridView.RowHeadersWidth = 51;
            topTenDataGridView.RowTemplate.Height = 29;
            topTenDataGridView.Size = new Size(960, 202);
            topTenDataGridView.TabIndex = 5;
            // 
            // Ticker0
            // 
            Ticker0.HeaderText = "Ticker";
            Ticker0.MinimumWidth = 6;
            Ticker0.Name = "Ticker0";
            Ticker0.Width = 125;
            // 
            // LastTradePrice0
            // 
            LastTradePrice0.HeaderText = "Trade Price";
            LastTradePrice0.MinimumWidth = 6;
            LastTradePrice0.Name = "LastTradePrice0";
            LastTradePrice0.Width = 125;
            // 
            // PercentChange0
            // 
            PercentChange0.HeaderText = "Percent Gain";
            PercentChange0.MinimumWidth = 6;
            PercentChange0.Name = "PercentChange0";
            PercentChange0.Width = 125;
            // 
            // AverageVolume0
            // 
            AverageVolume0.HeaderText = "Avg Volume";
            AverageVolume0.MinimumWidth = 6;
            AverageVolume0.Name = "AverageVolume0";
            AverageVolume0.Width = 125;
            // 
            // TotalMinVolume0
            // 
            TotalMinVolume0.HeaderText = "Total Volume Previous Min";
            TotalMinVolume0.MinimumWidth = 6;
            TotalMinVolume0.Name = "TotalMinVolume0";
            TotalMinVolume0.Width = 125;
            // 
            // RelativeVolume0
            // 
            RelativeVolume0.HeaderText = "Relative Volume";
            RelativeVolume0.MinimumWidth = 6;
            RelativeVolume0.Name = "RelativeVolume0";
            RelativeVolume0.Width = 125;
            // 
            // TopTenLabel
            // 
            TopTenLabel.AutoSize = true;
            TopTenLabel.Location = new Point(25, 31);
            TopTenLabel.Name = "TopTenLabel";
            TopTenLabel.Size = new Size(159, 15);
            TopTenLabel.TabIndex = 8;
            TopTenLabel.Text = "Top Ten Stocks By % Increase";
            // 
            // BottomTenLabel
            // 
            BottomTenLabel.AutoSize = true;
            BottomTenLabel.Location = new Point(25, 253);
            BottomTenLabel.Name = "BottomTenLabel";
            BottomTenLabel.Size = new Size(180, 15);
            BottomTenLabel.TabIndex = 9;
            BottomTenLabel.Text = "Bottom Ten Stocks By % Increase";
            // 
            // HighestRelativeLabel
            // 
            HighestRelativeLabel.AutoSize = true;
            HighestRelativeLabel.Location = new Point(25, 481);
            HighestRelativeLabel.Name = "HighestRelativeLabel";
            HighestRelativeLabel.Size = new Size(238, 15);
            HighestRelativeLabel.TabIndex = 10;
            HighestRelativeLabel.Text = "Highest Relative Value Stocks In Last Minute";
            // 
            // bottomTenDataGridView
            // 
            bottomTenDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bottomTenDataGridView.Columns.AddRange(new DataGridViewColumn[] { Ticker1, LastTradePrice1, PercentChange1, AverageVolume1, TotalMinVolume1, RelativeVolume1 });
            bottomTenDataGridView.Location = new Point(25, 270);
            bottomTenDataGridView.Margin = new Padding(3, 2, 3, 2);
            bottomTenDataGridView.Name = "bottomTenDataGridView";
            bottomTenDataGridView.RowHeadersWidth = 51;
            bottomTenDataGridView.RowTemplate.Height = 29;
            bottomTenDataGridView.Size = new Size(960, 208);
            bottomTenDataGridView.TabIndex = 13;
            // 
            // Ticker1
            // 
            Ticker1.HeaderText = "Ticker";
            Ticker1.MinimumWidth = 6;
            Ticker1.Name = "Ticker1";
            Ticker1.Width = 125;
            // 
            // LastTradePrice1
            // 
            LastTradePrice1.HeaderText = "Trade Price";
            LastTradePrice1.MinimumWidth = 6;
            LastTradePrice1.Name = "LastTradePrice1";
            LastTradePrice1.Width = 125;
            // 
            // PercentChange1
            // 
            PercentChange1.HeaderText = "Percent Loss";
            PercentChange1.MinimumWidth = 6;
            PercentChange1.Name = "PercentChange1";
            PercentChange1.Width = 125;
            // 
            // AverageVolume1
            // 
            AverageVolume1.HeaderText = "Avg Volume";
            AverageVolume1.MinimumWidth = 6;
            AverageVolume1.Name = "AverageVolume1";
            AverageVolume1.Width = 125;
            // 
            // TotalMinVolume1
            // 
            TotalMinVolume1.HeaderText = "Total Volume Previous Min";
            TotalMinVolume1.MinimumWidth = 6;
            TotalMinVolume1.Name = "TotalMinVolume1";
            TotalMinVolume1.Width = 125;
            // 
            // RelativeVolume1
            // 
            RelativeVolume1.HeaderText = "Relative Volume";
            RelativeVolume1.MinimumWidth = 6;
            RelativeVolume1.Name = "RelativeVolume1";
            RelativeVolume1.Width = 125;
            // 
            // highestRelativeVolumeDataGridView
            // 
            highestRelativeVolumeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            highestRelativeVolumeDataGridView.Columns.AddRange(new DataGridViewColumn[] { Ticker2, LastTradePrice2, PercentChange2, AverageVolume2, TotalMinVolume2, RelativeVolume2 });
            highestRelativeVolumeDataGridView.Location = new Point(25, 498);
            highestRelativeVolumeDataGridView.Margin = new Padding(3, 2, 3, 2);
            highestRelativeVolumeDataGridView.Name = "highestRelativeVolumeDataGridView";
            highestRelativeVolumeDataGridView.RowHeadersWidth = 51;
            highestRelativeVolumeDataGridView.RowTemplate.Height = 29;
            highestRelativeVolumeDataGridView.Size = new Size(960, 212);
            highestRelativeVolumeDataGridView.TabIndex = 14;
            // 
            // Ticker2
            // 
            Ticker2.HeaderText = "Ticker";
            Ticker2.MinimumWidth = 6;
            Ticker2.Name = "Ticker2";
            Ticker2.Width = 125;
            // 
            // LastTradePrice2
            // 
            LastTradePrice2.HeaderText = "Trade Price";
            LastTradePrice2.MinimumWidth = 6;
            LastTradePrice2.Name = "LastTradePrice2";
            LastTradePrice2.Width = 125;
            // 
            // PercentChange2
            // 
            PercentChange2.HeaderText = "Percent Change";
            PercentChange2.MinimumWidth = 6;
            PercentChange2.Name = "PercentChange2";
            PercentChange2.Width = 125;
            // 
            // AverageVolume2
            // 
            AverageVolume2.HeaderText = "Avg Volume";
            AverageVolume2.MinimumWidth = 6;
            AverageVolume2.Name = "AverageVolume2";
            AverageVolume2.Width = 125;
            // 
            // TotalMinVolume2
            // 
            TotalMinVolume2.HeaderText = "Total Volume Previous Min";
            TotalMinVolume2.MinimumWidth = 6;
            TotalMinVolume2.Name = "TotalMinVolume2";
            TotalMinVolume2.Width = 125;
            // 
            // RelativeVolume2
            // 
            RelativeVolume2.HeaderText = "Relative Volume";
            RelativeVolume2.MinimumWidth = 6;
            RelativeVolume2.Name = "RelativeVolume2";
            RelativeVolume2.Width = 125;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 739);
            Controls.Add(highestRelativeVolumeDataGridView);
            Controls.Add(bottomTenDataGridView);
            Controls.Add(HighestRelativeLabel);
            Controls.Add(BottomTenLabel);
            Controls.Add(TopTenLabel);
            Controls.Add(topTenDataGridView);
            Controls.Add(lblPath);
            Controls.Add(txtPath);
            Controls.Add(btnPath);
            Controls.Add(statusStrip1);
            Controls.Add(btnTestLoad);
            Margin = new Padding(2);
            Name = "frmTest";
            Text = "Stock Load Test";
            Load += frmTest_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)topTenDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bottomTenDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)highestRelativeVolumeDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestLoad;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private Button btnPath;
        private TextBox txtPath;
        private Label lblPath;
        private FolderBrowserDialog dlgPath;
        private DataGridView topTenDataGridView;
        private Label TopTenLabel;
        private Label BottomTenLabel;
        private Label HighestRelativeLabel;
        private DataGridView bottomTenDataGridView;
        private DataGridView highestRelativeVolumeDataGridView;
        private DataGridViewTextBoxColumn Ticker0;
        private DataGridViewTextBoxColumn LastTradePrice0;
        private DataGridViewTextBoxColumn PercentChange0;
        private DataGridViewTextBoxColumn AverageVolume0;
        private DataGridViewTextBoxColumn TotalMinVolume0;
        private DataGridViewTextBoxColumn RelativeVolume0;
        private DataGridViewTextBoxColumn Ticker1;
        private DataGridViewTextBoxColumn LastTradePrice1;
        private DataGridViewTextBoxColumn PercentChange1;
        private DataGridViewTextBoxColumn AverageVolume1;
        private DataGridViewTextBoxColumn TotalMinVolume1;
        private DataGridViewTextBoxColumn RelativeVolume1;
        private DataGridViewTextBoxColumn Ticker2;
        private DataGridViewTextBoxColumn LastTradePrice2;
        private DataGridViewTextBoxColumn PercentChange2;
        private DataGridViewTextBoxColumn AverageVolume2;
        private DataGridViewTextBoxColumn TotalMinVolume2;
        private DataGridViewTextBoxColumn RelativeVolume2;
    }
}