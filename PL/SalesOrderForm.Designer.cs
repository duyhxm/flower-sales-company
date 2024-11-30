namespace PL
{
    partial class SalesOrderForm
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
            txtBx_SalesOrderID = new TextBox();
            lbl_SalesOrderID = new Label();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            order_column = new DataGridViewTextBoxColumn();
            orderid_column = new DataGridViewTextBoxColumn();
            name_column = new DataGridViewTextBoxColumn();
            quantity_column = new DataGridViewTextBoxColumn();
            unit_price_column = new DataGridViewTextBoxColumn();
            line_price_column = new DataGridViewTextBoxColumn();
            remove_column = new DataGridViewImageColumn();
            lbl_customerDiscountValue = new Label();
            lbl_orderDiscountValue = new Label();
            lbl_finalPrice = new Label();
            lbl_basePrice = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            btn_complete = new Button();
            btn_clear = new Button();
            label5 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtBx_SalesOrderID
            // 
            txtBx_SalesOrderID.Location = new Point(349, 308);
            txtBx_SalesOrderID.Margin = new Padding(3, 4, 3, 4);
            txtBx_SalesOrderID.Name = "txtBx_SalesOrderID";
            txtBx_SalesOrderID.Size = new Size(177, 39);
            txtBx_SalesOrderID.TabIndex = 0;
            // 
            // lbl_SalesOrderID
            // 
            lbl_SalesOrderID.AutoSize = true;
            lbl_SalesOrderID.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_SalesOrderID.ForeColor = Color.FromArgb(47, 47, 48);
            lbl_SalesOrderID.Location = new Point(247, 316);
            lbl_SalesOrderID.Name = "lbl_SalesOrderID";
            lbl_SalesOrderID.Size = new Size(104, 27);
            lbl_SalesOrderID.TabIndex = 1;
            lbl_SalesOrderID.Text = "Order ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(30, 57);
            label1.Name = "label1";
            label1.Size = new Size(146, 27);
            label1.TabIndex = 2;
            label1.Text = "Customer ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(354, 57);
            label2.Name = "label2";
            label2.Size = new Size(183, 27);
            label2.TabIndex = 3;
            label2.Text = "Customer name";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(507, 111);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(281, 31);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "non-member customer";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(19, 312);
            label3.Name = "label3";
            label3.Size = new Size(207, 32);
            label3.TabIndex = 5;
            label3.Text = "Order Information";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(30, 115);
            label4.Name = "label4";
            label4.Size = new Size(170, 27);
            label4.TabIndex = 6;
            label4.Text = "Customer rank";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(19, 119);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(859, 169);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Customer Information";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(529, 53);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(259, 35);
            textBox3.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(173, 57);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 35);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(193, 109);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 35);
            textBox2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { order_column, orderid_column, name_column, quantity_column, unit_price_column, line_price_column, remove_column });
            dataGridView1.Location = new Point(84, 369);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1272, 239);
            dataGridView1.TabIndex = 8;
            // 
            // order_column
            // 
            order_column.HeaderText = "#";
            order_column.MinimumWidth = 8;
            order_column.Name = "order_column";
            order_column.Width = 80;
            // 
            // orderid_column
            // 
            orderid_column.HeaderText = "ID";
            orderid_column.MinimumWidth = 8;
            orderid_column.Name = "orderid_column";
            orderid_column.Width = 150;
            // 
            // name_column
            // 
            name_column.HeaderText = "Product Name";
            name_column.MinimumWidth = 8;
            name_column.Name = "name_column";
            name_column.Width = 250;
            // 
            // quantity_column
            // 
            quantity_column.HeaderText = "Q";
            quantity_column.MinimumWidth = 8;
            quantity_column.Name = "quantity_column";
            quantity_column.Width = 80;
            // 
            // unit_price_column
            // 
            unit_price_column.HeaderText = "Unit Price";
            unit_price_column.MinimumWidth = 8;
            unit_price_column.Name = "unit_price_column";
            unit_price_column.Width = 200;
            // 
            // line_price_column
            // 
            line_price_column.HeaderText = "Line Price";
            line_price_column.MinimumWidth = 8;
            line_price_column.Name = "line_price_column";
            line_price_column.Width = 200;
            // 
            // remove_column
            // 
            remove_column.HeaderText = "--";
            remove_column.MinimumWidth = 100;
            remove_column.Name = "remove_column";
            remove_column.Width = 150;
            // 
            // lbl_customerDiscountValue
            // 
            lbl_customerDiscountValue.AutoSize = true;
            lbl_customerDiscountValue.Location = new Point(518, 685);
            lbl_customerDiscountValue.Name = "lbl_customerDiscountValue";
            lbl_customerDiscountValue.Size = new Size(279, 32);
            lbl_customerDiscountValue.TabIndex = 9;
            lbl_customerDiscountValue.Text = "Customer discount value";
            // 
            // lbl_orderDiscountValue
            // 
            lbl_orderDiscountValue.AutoSize = true;
            lbl_orderDiscountValue.Location = new Point(518, 731);
            lbl_orderDiscountValue.Name = "lbl_orderDiscountValue";
            lbl_orderDiscountValue.Size = new Size(237, 32);
            lbl_orderDiscountValue.TabIndex = 10;
            lbl_orderDiscountValue.Text = "Order discount value";
            // 
            // lbl_finalPrice
            // 
            lbl_finalPrice.AutoSize = true;
            lbl_finalPrice.Location = new Point(518, 777);
            lbl_finalPrice.Name = "lbl_finalPrice";
            lbl_finalPrice.Size = new Size(123, 32);
            lbl_finalPrice.TabIndex = 11;
            lbl_finalPrice.Text = "Final price";
            // 
            // lbl_basePrice
            // 
            lbl_basePrice.AutoSize = true;
            lbl_basePrice.Location = new Point(518, 639);
            lbl_basePrice.Name = "lbl_basePrice";
            lbl_basePrice.Size = new Size(122, 32);
            lbl_basePrice.TabIndex = 13;
            lbl_basePrice.Text = "Base price";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Info;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(849, 633);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(134, 39);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Info;
            textBox5.Location = new Point(849, 727);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(134, 39);
            textBox5.TabIndex = 15;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Info;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Location = new Point(849, 680);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(134, 39);
            textBox6.TabIndex = 16;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Info;
            textBox7.Location = new Point(849, 774);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(134, 39);
            textBox7.TabIndex = 17;
            // 
            // btn_complete
            // 
            btn_complete.Location = new Point(665, 855);
            btn_complete.Margin = new Padding(3, 4, 3, 4);
            btn_complete.Name = "btn_complete";
            btn_complete.Size = new Size(168, 50);
            btn_complete.TabIndex = 18;
            btn_complete.Text = "Complete";
            btn_complete.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(860, 855);
            btn_clear.Margin = new Padding(3, 4, 3, 4);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(122, 50);
            btn_clear.TabIndex = 19;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Info;
            label5.Location = new Point(316, 642);
            label5.Name = "label5";
            label5.Size = new Size(0, 32);
            label5.TabIndex = 20;
            // 
            // SalesOrderForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1653, 944);
            Controls.Add(label5);
            Controls.Add(btn_clear);
            Controls.Add(btn_complete);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(lbl_basePrice);
            Controls.Add(lbl_finalPrice);
            Controls.Add(lbl_orderDiscountValue);
            Controls.Add(lbl_customerDiscountValue);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(lbl_SalesOrderID);
            Controls.Add(txtBx_SalesOrderID);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SalesOrderForm";
            Text = "Sales_Form";
            Load += Sales_Form_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBx_SalesOrderID;
        private Label lbl_SalesOrderID;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Label lbl_customerDiscountValue;
        private Label lbl_orderDiscountValue;
        private Label lbl_finalPrice;
        private Label lbl_basePrice;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button btn_complete;
        private Button btn_clear;
        private Label label5;
        private DataGridViewTextBoxColumn order_column;
        private DataGridViewTextBoxColumn orderid_column;
        private DataGridViewTextBoxColumn name_column;
        private DataGridViewTextBoxColumn quantity_column;
        private DataGridViewTextBoxColumn unit_price_column;
        private DataGridViewTextBoxColumn line_price_column;
        private DataGridViewImageColumn remove_column;
    }
}