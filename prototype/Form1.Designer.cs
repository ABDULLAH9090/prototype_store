namespace prototype
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddQty = new System.Windows.Forms.Button();
            this.btnReduceQty = new System.Windows.Forms.Button();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SorTorO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcbox = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabLoob = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtBarcode.Location = new System.Drawing.Point(172, 297);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(514, 48);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(361, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 161);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtTotal.Location = new System.Drawing.Point(431, 174);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(162, 48);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCredit
            // 
            this.txtCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtCredit.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtCredit.Location = new System.Drawing.Point(220, 201);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(162, 48);
            this.txtCredit.TabIndex = 4;
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "الرصيد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "الإجمالي";
            // 
            // btnAddQty
            // 
            this.btnAddQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQty.Location = new System.Drawing.Point(337, 160);
            this.btnAddQty.Name = "btnAddQty";
            this.btnAddQty.Size = new System.Drawing.Size(91, 161);
            this.btnAddQty.TabIndex = 7;
            this.btnAddQty.Text = "إضافة الكمية";
            this.btnAddQty.UseVisualStyleBackColor = true;
            this.btnAddQty.Click += new System.EventHandler(this.btnAddQty_Click);
            // 
            // btnReduceQty
            // 
            this.btnReduceQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReduceQty.Location = new System.Drawing.Point(202, 158);
            this.btnReduceQty.Name = "btnReduceQty";
            this.btnReduceQty.Size = new System.Drawing.Size(91, 161);
            this.btnReduceQty.TabIndex = 8;
            this.btnReduceQty.Text = "إنقاص الكمية";
            this.btnReduceQty.UseVisualStyleBackColor = true;
            this.btnReduceQty.Click += new System.EventHandler(this.btnReduceQty_Click);
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvMain.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMain.ColumnHeadersHeight = 50;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.amount,
            this.dataGridViewTextBoxColumn1,
            this.SorTorO,
            this.type});
            this.gvMain.Location = new System.Drawing.Point(-11, 229);
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvMain.RowHeadersVisible = false;
            this.gvMain.RowHeadersWidth = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gvMain.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gvMain.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gvMain.RowTemplate.Height = 40;
            this.gvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMain.Size = new System.Drawing.Size(604, 249);
            this.gvMain.TabIndex = 12;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.SelectionChanged += new System.EventHandler(this.gvMain_SelectionChanged);
            // 
            // number
            // 
            this.number.DataPropertyName = "id";
            this.number.HeaderText = "الرقم";
            this.number.MinimumWidth = 20;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.number.Visible = false;
            this.number.Width = 20;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "barcode";
            this.amount.HeaderText = "الترميز";
            this.amount.MinimumWidth = 150;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amount.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "الاسم";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SorTorO
            // 
            this.SorTorO.DataPropertyName = "qty";
            this.SorTorO.HeaderText = "الكمية";
            this.SorTorO.MinimumWidth = 60;
            this.SorTorO.Name = "SorTorO";
            this.SorTorO.ReadOnly = true;
            this.SorTorO.Width = 125;
            // 
            // type
            // 
            this.type.DataPropertyName = "price";
            this.type.HeaderText = "السعر";
            this.type.MinimumWidth = 60;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 120;
            // 
            // pcbox
            // 
            this.pcbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.pcbox.Location = new System.Drawing.Point(121, 63);
            this.pcbox.Name = "pcbox";
            this.pcbox.Size = new System.Drawing.Size(426, 76);
            this.pcbox.TabIndex = 13;
            this.pcbox.TabStop = false;
            this.pcbox.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.Brown;
            this.lblMessage.Location = new System.Drawing.Point(317, 91);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(64, 24);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "label3";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabLoob);
            this.panel1.Location = new System.Drawing.Point(42, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 284);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // LabLoob
            // 
            this.LabLoob.AutoSize = true;
            this.LabLoob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabLoob.ForeColor = System.Drawing.Color.Green;
            this.LabLoob.Location = new System.Drawing.Point(77, 85);
            this.LabLoob.Name = "LabLoob";
            this.LabLoob.Size = new System.Drawing.Size(52, 24);
            this.LabLoob.TabIndex = 12;
            this.LabLoob.Text = "اللب";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pcbox);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.btnReduceQty);
            this.Controls.Add(this.btnAddQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(30, 88, 30, 29);
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Right;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddQty;
        private System.Windows.Forms.Button btnReduceQty;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SorTorO;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.PictureBox pcbox;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabLoob;
    }
}

