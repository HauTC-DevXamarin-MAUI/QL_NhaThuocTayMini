using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DEV_PhanTIch
{
    public partial class frmQLThuoc : DevExpress.XtraEditors.XtraForm
    {
        XuLiThuoc thuoc = new XuLiThuoc();
        DataThuocDataContext data = new DataThuocDataContext();
        public frmQLThuoc()
        {
            InitializeComponent();
        }

        private void frmQLThuoc_Load(object sender, EventArgs e)
        {
            gridDsThuoc.DataSource = thuoc.loadThuoc();
            cbMaNhomThuoc.DataSource = thuoc.loadNhomThuoc();
            cbMaNhomThuoc.DisplayMember = "ten_nhom";
            cbMaNhomThuoc.ValueMember = "ma_nhom";
        }
        private void txtThongTin_TextChanged(object sender, EventArgs e)
        {
           
            if(cbPhuongThuc.SelectedItem.ToString() == "Mã Thuốc")
                gridKQTK.DataSource = data.Thuocs.Where(c => c.ma_thuoc.Contains(txtThongTin.Text));
            else if (cbPhuongThuc.SelectedItem.ToString() == "Tên Thuốc")
                gridKQTK.DataSource = data.Thuocs.Where(c => c.ten_thuoc.Contains(txtThongTin.Text));
            else if (cbPhuongThuc.SelectedItem.ToString() == "Mã Nhóm")
                gridKQTK.DataSource = data.Thuocs.Where(c => c.ma_nhom.Contains(txtThongTin.Text));
            else
                gridKQTK.DataSource = data.Thuocs.Where(c => c.cong_dung.Contains(txtThongTin.Text));
            
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtThongTin.Clear();
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            cbMaNhomThuoc.Text = "";
            txtCongDung.Clear();
            txtThanhPhan.Clear();
            cbDVT.Text = "";
            txtXuatSu.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (thuoc.themThuoc(txtMaThuoc.Text, txtTenThuoc.Text, cbMaNhomThuoc.SelectedValue.ToString(), txtCongDung.Text, txtThanhPhan.Text, cbDVT.SelectedItem.ToString(), txtXuatSu.Text, int.Parse(txtGiaBan.Text), int.Parse(txtSoLuong.Text)))
            {
                MessageBox.Show("Thêm Thuốc Thành Công");

            }
            else
                MessageBox.Show("Thêm Thuốc Thất Bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc.edtiThuoc(txtMaThuoc.Text, txtTenThuoc.Text, cbMaNhomThuoc.SelectedValue.ToString(), txtCongDung.Text, txtThanhPhan.Text, cbDVT.SelectedItem.ToString(), txtXuatSu.Text, int.Parse(txtGiaBan.Text), int.Parse(txtSoLuong.Text)))
            {
                MessageBox.Show("Sửa Thuốc Thành Công");

            }
            else
                MessageBox.Show("Sửa Thuốc Thất Bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (thuoc.deleteThuoc(txtMaThuoc.Text))
            {
                MessageBox.Show("Xóa Thuốc Thành Công");

            }
            else
                MessageBox.Show("Xóa Thuốc Thất Bại");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu Thành Công");
            thuoc.Luu();
            gridDsThuoc.DataSource = thuoc.loadThuoc();
        }

        private void gridDsThuoc_SelectionChanged(object sender, EventArgs e)
        {
            try { 
                txtMaThuoc.Text = gridDsThuoc.CurrentRow.Cells[0].Value.ToString();
            txtTenThuoc.Text = gridDsThuoc.CurrentRow.Cells[2].Value.ToString();
            cbMaNhomThuoc.Text = gridDsThuoc.CurrentRow.Cells[1].Value.ToString();
            txtCongDung.Text = gridDsThuoc.CurrentRow.Cells[3].Value.ToString();
            txtThanhPhan.Text = gridDsThuoc.CurrentRow.Cells[4].Value.ToString();
            cbDVT.Text = gridDsThuoc.CurrentRow.Cells[6].Value.ToString();
            txtXuatSu.Text = gridDsThuoc.CurrentRow.Cells[5].Value.ToString();
            txtGiaBan.Text = gridDsThuoc.CurrentRow.Cells[7].Value.ToString();
            txtSoLuong.Text = gridDsThuoc.CurrentRow.Cells[8].Value.ToString();
            }
            catch { MessageBox.Show("Chưa chọn phương thức"); }
        }

        private void gridKQTK_SelectionChanged(object sender, EventArgs e)
        {
            txtMaThuoc.Text = gridKQTK.CurrentRow.Cells[0].Value.ToString();
            txtTenThuoc.Text = gridKQTK.CurrentRow.Cells[2].Value.ToString();
            cbMaNhomThuoc.Text = gridKQTK.CurrentRow.Cells[1].Value.ToString();
            txtCongDung.Text = gridKQTK.CurrentRow.Cells[3].Value.ToString();
            txtThanhPhan.Text = gridKQTK.CurrentRow.Cells[4].Value.ToString();
            cbDVT.Text = gridKQTK.CurrentRow.Cells[6].Value.ToString();
            txtXuatSu.Text = gridKQTK.CurrentRow.Cells[5].Value.ToString();
            txtGiaBan.Text = gridKQTK.CurrentRow.Cells[7].Value.ToString();
            txtSoLuong.Text = gridKQTK.CurrentRow.Cells[8].Value.ToString();

        }
    }
}