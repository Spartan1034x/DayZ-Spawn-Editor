namespace DayZLootEditor
{
    partial class frmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.btnAccept = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.AddCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHSAddItem = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picCheckMark = new System.Windows.Forms.PictureBox();
            this.lblAdded = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHSAddItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMark)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(532, 717);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(162, 48);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.ColumnHeadersHeight = 29;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddCol,
            this.ItemCol,
            this.QuantityCol,
            this.HSCol});
            this.dgvItems.Location = new System.Drawing.Point(58, 12);
            this.dgvItems.MinimumSize = new System.Drawing.Size(250, 300);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(701, 661);
            this.dgvItems.TabIndex = 2;
            // 
            // AddCol
            // 
            this.AddCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddCol.FillWeight = 1F;
            this.AddCol.HeaderText = "Add";
            this.AddCol.MinimumWidth = 6;
            this.AddCol.Name = "AddCol";
            // 
            // ItemCol
            // 
            this.ItemCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemCol.FillWeight = 2F;
            this.ItemCol.HeaderText = "Item";
            this.ItemCol.MinimumWidth = 6;
            this.ItemCol.Name = "ItemCol";
            this.ItemCol.ReadOnly = true;
            // 
            // QuantityCol
            // 
            this.QuantityCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityCol.FillWeight = 1F;
            this.QuantityCol.HeaderText = "Quantity";
            this.QuantityCol.MinimumWidth = 6;
            this.QuantityCol.Name = "QuantityCol";
            // 
            // HSCol
            // 
            this.HSCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HSCol.FillWeight = 1F;
            this.HSCol.HeaderText = "Hot Slot";
            this.HSCol.MinimumWidth = 6;
            this.HSCol.Name = "HSCol";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(720, 717);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(162, 48);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&ResetAll";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(153, 698);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 30);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(153, 744);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 36);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSearch.Location = new System.Drawing.Point(246, 744);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(84, 36);
            this.btnClearSearch.TabIndex = 6;
            this.btnClearSearch.Text = "&Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(851, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Add Item";
            // 
            // txtAddItem
            // 
            this.txtAddItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddItem.Location = new System.Drawing.Point(873, 47);
            this.txtAddItem.Name = "txtAddItem";
            this.txtAddItem.Size = new System.Drawing.Size(197, 27);
            this.txtAddItem.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(767, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item Name:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(792, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "HotSlot:";
            // 
            // nudHSAddItem
            // 
            this.nudHSAddItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudHSAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHSAddItem.Location = new System.Drawing.Point(873, 114);
            this.nudHSAddItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudHSAddItem.Name = "nudHSAddItem";
            this.nudHSAddItem.Size = new System.Drawing.Size(63, 30);
            this.nudHSAddItem.TabIndex = 11;
            this.nudHSAddItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(873, 173);
            this.btnAdd.MaximumSize = new System.Drawing.Size(101, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 34);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.picCheckMark);
            this.groupBox1.Controls.Add(this.lblAdded);
            this.groupBox1.Location = new System.Drawing.Point(766, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 266);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // picCheckMark
            // 
            this.picCheckMark.Image = ((System.Drawing.Image)(resources.GetObject("picCheckMark.Image")));
            this.picCheckMark.Location = new System.Drawing.Point(83, 224);
            this.picCheckMark.Name = "picCheckMark";
            this.picCheckMark.Size = new System.Drawing.Size(38, 29);
            this.picCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCheckMark.TabIndex = 120;
            this.picCheckMark.TabStop = false;
            this.picCheckMark.Visible = false;
            // 
            // lblAdded
            // 
            this.lblAdded.AutoSize = true;
            this.lblAdded.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdded.Location = new System.Drawing.Point(121, 227);
            this.lblAdded.Name = "lblAdded";
            this.lblAdded.Size = new System.Drawing.Size(103, 20);
            this.lblAdded.TabIndex = 119;
            this.lblAdded.Text = "Item Added";
            this.lblAdded.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 701);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Search:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(908, 717);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 48);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 823);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.nudHSAddItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1100, 870);
            this.MinimumSize = new System.Drawing.Size(1100, 870);
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHSAddItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AddCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSCol;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHSAddItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picCheckMark;
        private System.Windows.Forms.Label lblAdded;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
    }
}