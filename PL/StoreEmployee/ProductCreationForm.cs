using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Material;
using BL;
using DTO;
using System.Diagnostics;

namespace PL
{
    public partial class ProductCreationForm : Form
    {
        private NotificationService notificationService;
        private MaterialService materialService;
        private readonly string? storeId = StoreMainForm.Instance.StoreId;
        private BindingSource flowerBs;
        private BindingSource accessoryBs;
        private BindingSource productDetailsBs;
        private bool isHandlingCellValueChangedOfProductDetails = false;
        private ProductService _productService;

        public ProductCreationForm()
        {
            InitializeComponent();
            notificationService = StoreMainForm.Instance.NotificationService;
            materialService = new MaterialService();
            _productService = new ProductService();
            flowerBs = new BindingSource();
            accessoryBs = new BindingSource();
            productDetailsBs = new BindingSource();

            //Set DataPropertyName
            dgvFlowerList.Columns[0].DataPropertyName = "FlowerID";
            dgvFlowerList.Columns[1].DataPropertyName = "FlowerName";
            dgvFlowerList.Columns[2].DataPropertyName = "FTypeName";
            dgvFlowerList.Columns[3].DataPropertyName = "FColorName";
            dgvFlowerList.Columns[4].DataPropertyName = "FCharacteristicName";

            dgvAccessoryList.Columns[0].DataPropertyName = "MaterialID";
            dgvAccessoryList.Columns[1].DataPropertyName = "MaterialName";
            dgvAccessoryList.AutoGenerateColumns = false;

            txtBxCreationQuantity.ReadOnly = true;
        }

        private async void ProductCreationForm_Load(object sender, EventArgs e)
        {
            await LoadFlowerListAsync();
            await LoadAccessoryListAsync();
            await LoadFloralRepresentation();
        }

        //===================Xử lý cho tab Product Information===================

        private async Task LoadFloralRepresentation()
        {
            List<FloralRepresentationDTO>? fRepresentations = await materialService.GetFloralRepresentationAsync();

            if (fRepresentations != null)
            {
                foreach (var f in fRepresentations)
                {
                    cmbBxFloralRepresentations.Items.Add(f.Frname!);
                }
            }
        }
        private void ibtnIncrease_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.ReadOnly == false && int.TryParse(txtBxCreationQuantity.Text, out int value) && value > 0)
            {
                ++value;
                txtBxCreationQuantity.Text = value.ToString();
            }
        }

        private void ibtnDecrease_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.ReadOnly == false && int.TryParse(txtBxCreationQuantity.Text, out int value) && value > 1)
            {
                --value;
                txtBxCreationQuantity.Text = value.ToString();
            }
        }

        //Thêm product
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        //Xử lý khi user nhấn Clear dữ liệu 
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xoá bỏ các thông tin đã nhập?", "Cảnh báo", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                txtBxProductId.Clear();
                txtBxProductName.Clear();
                cmbBxFloralRepresentations.Text = string.Empty;
                txtBxCreationQuantity.Clear();
                txtBxUnitPrice.Clear();

                CancelSelection(dgvFlowerList);
                CancelSelection(dgvAccessoryList);
            }
        }

        //Xử lý khi user nhấn Clear dữ liệu giống trên
        private void CancelSelection(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCell cell = dgv.Name == "dgvFlowerList" ? row.Cells[0] : row.Cells[dgv.Columns.Count - 1];

                // Kiểm tra giá trị của ô có phải là true không
                if (cell.Value != null && cell.Value is bool isChecked && isChecked)
                {
                    cell.Value = false;
                }
            }

        }

        //Xử lý khi user click tăng giảm số lượng
        private void dgvProductDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProductDetails.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                // Kiểm tra giá trị của ô có phải là null không
                var cellValue = dgvProductDetails.Rows[e.RowIndex].Cells[3].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int currentValue))
                {
                    if (e.ColumnIndex == 2)
                    {

                        int newValue = currentValue - 1;
                        dgvProductDetails.Rows[e.RowIndex].Cells[3].Value = newValue.ToString();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        int newValue = currentValue + 1;
                        dgvProductDetails.Rows[e.RowIndex].Cells[3].Value = newValue.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("The cell value is not a valid integer.");
                }
            }
        }

        private void txtBxCreationQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private bool TryFindRowById(string id, out int index)
        {
            int numberOfRows = dgvProductDetails.Rows.Count;
            index = -1;

            for (int i = 0; i < numberOfRows; i++)
            {
                string? idValue = dgvProductDetails.Rows[i].Cells[0].Value.ToString();

                if (idValue != null && idValue == id)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        //Đồng bộ các vật liệu ở tab Flower và Accessory sang tab Product
        private void UpdateDataOfProductDetails(DataGridView dgvSource, DataGridViewCellEventArgs eOfThatDgv)
        {
            if (eOfThatDgv.RowIndex >= 0 && eOfThatDgv.ColumnIndex >= 0 && dgvSource.Columns[eOfThatDgv.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int idIndex = dgvSource.Name == "dgvFlowerList" ? 1 : 0;
                int nameIndex = dgvSource.Name == "dgvFlowerList" ? 2 : 1;

                // Lấy giá trị của ô checkbox
                var cellValue = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[eOfThatDgv.ColumnIndex].Value;
                string? idCell = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[idIndex].Value.ToString();
                string? nameCell = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[nameIndex].Value.ToString();

                Debug.WriteLine($"id cell: {idCell}; name cell: {nameCell}");


                // Kiểm tra giá trị của ô checkbox có phải là null không
                if (cellValue != null && cellValue is bool isChecked)
                {
                    if (isChecked)
                    {
                        dgvProductDetails.Rows.Add(idCell, nameCell, null, "1", null);
                    }
                    else
                    {

                        if (idCell != null && TryFindRowById(idCell, out int index))
                        {
                            dgvProductDetails.Rows.RemoveAt(index);
                        }
                    }
                }
            }
        }

        //Kiểm tra số lượng vật liệu nhập vô
        private void dgvProductDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isHandlingCellValueChangedOfProductDetails)
            {
                return;
            }

            // Kiểm tra chỉ số hàng và cột hợp lệ
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                var cellValue = dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Kiểm tra giá trị của ô có phải là null không
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int i))
                {
                    MessageBox.Show("Số lượng phải là một chữ số và là số nguyên!!");

                    isHandlingCellValueChangedOfProductDetails = true;
                    dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                    isHandlingCellValueChangedOfProductDetails = false;
                }
                else
                {
                    if (i <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0!");

                        isHandlingCellValueChangedOfProductDetails = true;
                        dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                        isHandlingCellValueChangedOfProductDetails = false;
                    }
                    else if (i > GetStockMaterialQuantity(dgvProductDetails.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Số lượng vượt quá tồn kho hiện tại");

                        isHandlingCellValueChangedOfProductDetails = true;
                        dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                        isHandlingCellValueChangedOfProductDetails = false;
                    }
                }
            }
        }

        //Kiểm tra số lượng tồn kho để đối chiếu với số lượng vật liệu nhập vô
        private int GetStockMaterialQuantity(string? id)
        {
            throw new NotImplementedException();
        }

        //Lắng nghe event khi row được thêm vô
        private void dgvProductDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvProductDetails.Rows.Count == 1)
            {
                txtBxCreationQuantity.ReadOnly = false;
                txtBxCreationQuantity.Text = "1";
                //Lấy thông tin ProductID
            }

            //tính toán unit price
        }

        //Lắng nghe event khi row bị xoá
        private void dgvProductDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvProductDetails.Rows.Count == 0)
            {
                txtBxCreationQuantity.ReadOnly = true;
            }
        }

        //================Xử lý cho tab Flower=========================

        //Load dữ liệu flower của cửa hàng
        private async Task LoadFlowerListAsync()
        {
            try
            {
                List<FlowerDTO>? flowerList = null;

                if (storeId != null)
                {
                    flowerList = await materialService.GetAllFlowerByStoreAsync(storeId);
                }

                if (flowerList != null)
                {
                    flowerBs.DataSource = flowerList;
                    dgvFlowerList.DataSource = flowerBs;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }


        //Lọc dữ liệu theo loại hoa
        private void cmbBxFloralType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Lọc dữ liệu theo màu hoa
        private void cmbBxFloralColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Lọc dữ liệu theo đặc điểm hoa
        private void cmbBxFloralCharacteristic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Xác nhận action ngay lập tức khi user tick vô checkbox
        private void dgvFlowerList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFlowerList.IsCurrentCellDirty)
            {
                // Xác nhận giá trị của ô hiện tại ngay lập tức
                dgvFlowerList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Lắng nghe event user tick vô checkbox
        private void dgvFlowerList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataOfProductDetails(dgvFlowerList, e);
        }

        //================Xử lý cho tab Accessory=================


        //Load dữ liệu accessory lên
        private async Task LoadAccessoryListAsync()
        {
            try
            {
                if (storeId != null)
                {
                    List<MaterialInventoryDTO> acessoryList = await materialService.GetAllMaterialByStoreAsync(storeId, "phụ liệu");
                    accessoryBs.DataSource = acessoryList;
                    dgvAccessoryList.DataSource = accessoryBs;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }

        //Update dữ liệu bên Product khi user tick vô checkbox
        private void dgvAccessoryList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataOfProductDetails(dgvAccessoryList, e);
        }

        //Cập nhật action ngay lập tức khi có change
        private void dgvAccessoryList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAccessoryList.IsCurrentCellDirty)
            {
                // Xác nhận giá trị của ô hiện tại ngay lập tức
                dgvAccessoryList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //
        private void dgvAccessoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccessoryList.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                dgvAccessoryList.CurrentCell = null;
            }
        }

        private void btnTestBindingSource_Click(object sender, EventArgs e)
        {
            accessoryBs.RemoveAt(0);
            accessoryBs.ResetBindings(false);
        }

        private DateTimeOffset GetLocalTime()
        {
            return DateTimeOffset.UtcNow.ToLocalTime();
        }
    }
}
