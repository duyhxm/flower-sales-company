namespace PL.StoreEmployee
{
    partial class DailyTaskForm
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
            dgvDailyTasks = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColFRName = new DataGridViewTextBoxColumn();
            ColNeededCreationQuantity = new DataGridViewTextBoxColumn();
            ColImplementationTime = new DataGridViewTextBoxColumn();
            ColDetails = new DataGridViewImageColumn();
            ColCreate = new DataGridViewImageColumn();
            lblDailyTask = new Label();
            dgvFlowers = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColUsedFQuantity = new DataGridViewTextBoxColumn();
            dgvAccessories = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColUsedAQuantity = new DataGridViewTextBoxColumn();
            lblFlowerList = new Label();
            lblAccessoryList = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDailyTasks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).BeginInit();
            SuspendLayout();
            // 
            // dgvDailyTasks
            // 
            dgvDailyTasks.AllowUserToAddRows = false;
            dgvDailyTasks.AllowUserToDeleteRows = false;
            dgvDailyTasks.AllowUserToResizeColumns = false;
            dgvDailyTasks.AllowUserToResizeRows = false;
            dgvDailyTasks.BackgroundColor = SystemColors.Control;
            dgvDailyTasks.BorderStyle = BorderStyle.None;
            dgvDailyTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDailyTasks.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColFRName, ColNeededCreationQuantity, ColImplementationTime, ColDetails, ColCreate });
            dgvDailyTasks.Location = new Point(1, 113);
            dgvDailyTasks.Name = "dgvDailyTasks";
            dgvDailyTasks.RowHeadersVisible = false;
            dgvDailyTasks.RowHeadersWidth = 62;
            dgvDailyTasks.Size = new Size(972, 737);
            dgvDailyTasks.TabIndex = 0;
            dgvDailyTasks.CellClick += dgvDailyTasks_CellClick;
            // 
            // ColProductId
            // 
            ColProductId.FillWeight = 50F;
            ColProductId.HeaderText = "ID";
            ColProductId.MinimumWidth = 8;
            ColProductId.Name = "ColProductId";
            ColProductId.ReadOnly = true;
            ColProductId.Width = 150;
            // 
            // ColProductName
            // 
            ColProductName.HeaderText = "Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 250;
            // 
            // ColFRName
            // 
            ColFRName.HeaderText = "FRName";
            ColFRName.MinimumWidth = 8;
            ColFRName.Name = "ColFRName";
            ColFRName.ReadOnly = true;
            ColFRName.Width = 120;
            // 
            // ColNeededCreationQuantity
            // 
            ColNeededCreationQuantity.FillWeight = 50F;
            ColNeededCreationQuantity.HeaderText = "Q";
            ColNeededCreationQuantity.MinimumWidth = 8;
            ColNeededCreationQuantity.Name = "ColNeededCreationQuantity";
            ColNeededCreationQuantity.ReadOnly = true;
            ColNeededCreationQuantity.Width = 80;
            // 
            // ColImplementationTime
            // 
            ColImplementationTime.HeaderText = "Imple Time";
            ColImplementationTime.MinimumWidth = 8;
            ColImplementationTime.Name = "ColImplementationTime";
            ColImplementationTime.ReadOnly = true;
            ColImplementationTime.Width = 250;
            // 
            // ColDetails
            // 
            ColDetails.FillWeight = 40F;
            ColDetails.HeaderText = "";
            ColDetails.Image = Properties.Resources.details;
            ColDetails.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColDetails.MinimumWidth = 8;
            ColDetails.Name = "ColDetails";
            ColDetails.Width = 50;
            // 
            // ColCreate
            // 
            ColCreate.FillWeight = 40F;
            ColCreate.HeaderText = "";
            ColCreate.Image = Properties.Resources.check;
            ColCreate.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColCreate.MinimumWidth = 8;
            ColCreate.Name = "ColCreate";
            ColCreate.Width = 50;
            // 
            // lblDailyTask
            // 
            lblDailyTask.AutoSize = true;
            lblDailyTask.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDailyTask.Location = new Point(73, 40);
            lblDailyTask.Name = "lblDailyTask";
            lblDailyTask.Size = new Size(157, 45);
            lblDailyTask.TabIndex = 1;
            lblDailyTask.Text = "Daily Task";
            // 
            // dgvFlowers
            // 
            dgvFlowers.AllowUserToAddRows = false;
            dgvFlowers.AllowUserToDeleteRows = false;
            dgvFlowers.AllowUserToResizeColumns = false;
            dgvFlowers.AllowUserToResizeRows = false;
            dgvFlowers.BackgroundColor = SystemColors.Control;
            dgvFlowers.BorderStyle = BorderStyle.None;
            dgvFlowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowers.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFColor, ColFChar, ColUsedFQuantity });
            dgvFlowers.Location = new Point(979, 113);
            dgvFlowers.Name = "dgvFlowers";
            dgvFlowers.RowHeadersVisible = false;
            dgvFlowers.RowHeadersWidth = 62;
            dgvFlowers.Size = new Size(670, 336);
            dgvFlowers.TabIndex = 2;
            // 
            // ColFlowerId
            // 
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            ColFlowerId.Width = 150;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 200;
            // 
            // ColFColor
            // 
            ColFColor.HeaderText = "Color";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.ReadOnly = true;
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.HeaderText = "Char";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.ReadOnly = true;
            ColFChar.Width = 150;
            // 
            // ColUsedFQuantity
            // 
            ColUsedFQuantity.HeaderText = "Q";
            ColUsedFQuantity.MinimumWidth = 8;
            ColUsedFQuantity.Name = "ColUsedFQuantity";
            ColUsedFQuantity.ReadOnly = true;
            ColUsedFQuantity.Width = 80;
            // 
            // dgvAccessories
            // 
            dgvAccessories.AllowUserToAddRows = false;
            dgvAccessories.AllowUserToDeleteRows = false;
            dgvAccessories.AllowUserToResizeColumns = false;
            dgvAccessories.AllowUserToResizeRows = false;
            dgvAccessories.BackgroundColor = SystemColors.Control;
            dgvAccessories.BorderStyle = BorderStyle.None;
            dgvAccessories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessories.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColUsedAQuantity });
            dgvAccessories.Location = new Point(979, 532);
            dgvAccessories.Name = "dgvAccessories";
            dgvAccessories.RowHeadersVisible = false;
            dgvAccessories.RowHeadersWidth = 62;
            dgvAccessories.Size = new Size(639, 400);
            dgvAccessories.TabIndex = 3;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Width = 150;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 200;
            // 
            // ColUsedAQuantity
            // 
            ColUsedAQuantity.HeaderText = "Q";
            ColUsedAQuantity.MinimumWidth = 8;
            ColUsedAQuantity.Name = "ColUsedAQuantity";
            ColUsedAQuantity.ReadOnly = true;
            ColUsedAQuantity.Width = 80;
            // 
            // lblFlowerList
            // 
            lblFlowerList.AutoSize = true;
            lblFlowerList.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFlowerList.Location = new Point(979, 40);
            lblFlowerList.Name = "lblFlowerList";
            lblFlowerList.Size = new Size(128, 45);
            lblFlowerList.TabIndex = 4;
            lblFlowerList.Text = "Flowers";
            // 
            // lblAccessoryList
            // 
            lblAccessoryList.AutoSize = true;
            lblAccessoryList.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccessoryList.Location = new Point(979, 462);
            lblAccessoryList.Name = "lblAccessoryList";
            lblAccessoryList.Size = new Size(185, 45);
            lblAccessoryList.TabIndex = 5;
            lblAccessoryList.Text = "Accessories";
            // 
            // DailyTaskForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(lblAccessoryList);
            Controls.Add(lblFlowerList);
            Controls.Add(dgvAccessories);
            Controls.Add(dgvFlowers);
            Controls.Add(lblDailyTask);
            Controls.Add(dgvDailyTasks);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DailyTaskForm";
            Text = "DailyTaskForm";
            Load += DailyTaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDailyTasks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDailyTasks;
        private Label lblDailyTask;
        private DataGridView dgvFlowers;
        private DataGridView dgvAccessories;
        private Label lblFlowerList;
        private Label lblAccessoryList;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColUsedFQuantity;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColUsedAQuantity;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColFRName;
        private DataGridViewTextBoxColumn ColNeededCreationQuantity;
        private DataGridViewTextBoxColumn ColImplementationTime;
        private DataGridViewImageColumn ColDetails;
        private DataGridViewImageColumn ColCreate;
    }
}