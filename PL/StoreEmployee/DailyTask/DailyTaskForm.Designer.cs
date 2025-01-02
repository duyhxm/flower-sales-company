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
            ColNeededCreationQuantity = new DataGridViewTextBoxColumn();
            ColImplementationTime = new DataGridViewTextBoxColumn();
            ColDetails = new DataGridViewImageColumn();
            ColCreate = new DataGridViewImageColumn();
            lblDailyTask = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDailyTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvDailyTasks
            // 
            dgvDailyTasks.AllowUserToAddRows = false;
            dgvDailyTasks.AllowUserToDeleteRows = false;
            dgvDailyTasks.AllowUserToResizeColumns = false;
            dgvDailyTasks.AllowUserToResizeRows = false;
            dgvDailyTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDailyTasks.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColNeededCreationQuantity, ColImplementationTime, ColDetails, ColCreate });
            dgvDailyTasks.Location = new Point(73, 164);
            dgvDailyTasks.Name = "dgvDailyTasks";
            dgvDailyTasks.RowHeadersVisible = false;
            dgvDailyTasks.RowHeadersWidth = 62;
            dgvDailyTasks.Size = new Size(889, 292);
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
            ColProductName.Width = 200;
            // 
            // ColNeededCreationQuantity
            // 
            ColNeededCreationQuantity.FillWeight = 50F;
            ColNeededCreationQuantity.HeaderText = "Q";
            ColNeededCreationQuantity.MinimumWidth = 8;
            ColNeededCreationQuantity.Name = "ColNeededCreationQuantity";
            ColNeededCreationQuantity.ReadOnly = true;
            ColNeededCreationQuantity.Width = 150;
            // 
            // ColImplementationTime
            // 
            ColImplementationTime.HeaderText = "Imple Time";
            ColImplementationTime.MinimumWidth = 8;
            ColImplementationTime.Name = "ColImplementationTime";
            ColImplementationTime.ReadOnly = true;
            ColImplementationTime.Width = 200;
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
            // DailyTaskForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(lblDailyTask);
            Controls.Add(dgvDailyTasks);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DailyTaskForm";
            Text = "DailyTaskForm";
            ((System.ComponentModel.ISupportInitialize)dgvDailyTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDailyTasks;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColNeededCreationQuantity;
        private DataGridViewTextBoxColumn ColImplementationTime;
        private DataGridViewImageColumn ColDetails;
        private DataGridViewImageColumn ColCreate;
        private Label lblDailyTask;
    }
}