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
    public partial class FrmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        XuLiKhachHang kh = new XuLiKhachHang();
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            gridDSKH.DataSource = kh.loadKH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kh.ThemKH(txtmaKH.Text, txtHoTen.Text, cbgioitinh.SelectedItem.ToString(), int.Parse(txtTuoi.Text), txtSDT.Text))
            {
                MessageBox.Show("Thêm Khách Hàng Thành Công");

            }
            else
                MessageBox.Show("Khách Hàng Này Đã Tồn Tại");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            kh.Luu();
            gridDSKH.DataSource = kh.loadKH();
            MessageBox.Show("Lưu Thông Tin Thành Công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kh.deleteNV(txtmaKH.Text))
            {
                MessageBox.Show("Xóa Khách Hàng Thành Công");
                gridDSKH.DataSource = kh.loadKH();
            }
            else
                MessageBox.Show("Xóa Thất Bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kh.editNV(txtmaKH.Text, txtHoTen.Text, cbgioitinh.SelectedItem.ToString(), int.Parse(txtTuoi.Text), txtSDT.Text) == true)
            {
                MessageBox.Show("Sửa Thông Tin Khách Hàng Thành Công");
                gridDSKH.DataSource = kh.loadKH();
            }
            else
                MessageBox.Show("Sửa Thất Bại");
        }

        private void gridDSKH_SelectionChanged(object sender, EventArgs e)
        {
            if (gridDSKH.CurrentRow != null)
            {
                txtmaKH.Text = gridDSKH.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = gridDSKH.CurrentRow.Cells[1].Value.ToString();
                cbgioitinh.Text = gridDSKH.CurrentRow.Cells[2].Value.ToString();
                txtTuoi.Text = gridDSKH.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = gridDSKH.CurrentRow.Cells[4].Value.ToString();
            }
        }
    }
}