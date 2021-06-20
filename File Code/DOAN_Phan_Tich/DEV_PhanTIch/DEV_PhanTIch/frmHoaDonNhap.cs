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
    public partial class frmHoaDonNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmHoaDonNhap()
        {

            //cbPhuongThuc.SelectedIndex = cbPhuongThuc.FindStringExact("Mã Hóa Đơn");
            InitializeComponent();
        }
        XuLiHoaDonNhap xl = new XuLiHoaDonNhap();
        private void cbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbPhuongThuc.SelectedItem.ToString() == "Mã Thuốc")
                gridKQTK.DataSource = xl.loadthuoc_MaThuoc(txtThongTin.Text);
            else if (cbPhuongThuc.SelectedItem.ToString() == "Tên Thuốc")
                gridKQTK.DataSource = xl.loadthuoc_TenThuoc(txtThongTin.Text);
            else if (cbPhuongThuc.SelectedItem.ToString() == "Mã Nhóm")
                gridKQTK.DataSource = xl.loadThuoc_MaNhom(txtThongTin.Text);
            else
                gridKQTK.DataSource = xl.loadthuoc_CongDung(txtThongTin.Text);
        }


        private void txtThongTin_TextChanged(object sender, EventArgs e)
        {
            if (cbPhuongThuc.SelectedItem.ToString() == "Mã Thuốc")
                gridKQTK.DataSource = xl.loadthuoc_MaThuoc(txtThongTin.Text);
            else if (cbPhuongThuc.SelectedItem.ToString() == "Tên Thuốc")
                gridKQTK.DataSource = xl.loadthuoc_TenThuoc(txtThongTin.Text);
            else if (cbPhuongThuc.SelectedItem.ToString() == "Mã Nhóm")
                gridKQTK.DataSource = xl.loadThuoc_MaNhom(txtThongTin.Text);
            else
                gridKQTK.DataSource = xl.loadthuoc_CongDung(txtThongTin.Text);
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadgrid();
        }
        public void loadgrid()
        {
            dataGridView1.DataSource = xl.loadhd_Nhap();
            gridCTHD.DataSource = xl.load_CTHD(txtMaHDN.Text);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (xl.ThemHd(txtMaHDN.Text, txtMaNV.Text, dateTimePicker1.Value, txtNCC.Text, int.Parse(txtTongTien.Text)))
            {
                MessageBox.Show("Thêm Hóa Đơn Thành Công");
                loadgrid();
            }
            else
                MessageBox.Show("Thêm Hóa Đơn Thất Bại");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xl.Luu();
            loadgrid();
            MessageBox.Show("Lưu Thông Tin Thành Công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xl.deleteHD(txtMaHDN.Text))
            {
                MessageBox.Show("Xóa Khách Hàng Thành Công");
                loadgrid();
            }
            else
                MessageBox.Show("Xóa Thất Bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                if (xl.editHD(txtMaHDN.Text, txtMaNV.Text, dateTimePicker1.Value, txtNCC.Text, int.Parse(txtTongTien.Text)) == true)
                        {
                            MessageBox.Show("Sửa Thông Tin Khách Hàng Thành Công");
                            loadgrid();
                        }
                        else
                            MessageBox.Show("Sửa Thất Bại");                
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
        if (dataGridView1.CurrentRow != null)
                    {
                
                        txtMaHDN.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txtMaNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                        txtNCC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        txtTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    }
        }

        private void gridCTHD_SelectionChanged(object sender, EventArgs e)
        {
            txtMaCTHD.Text = gridCTHD.CurrentRow.Cells[0].Value.ToString();
            txtMaThuoc.Text = gridCTHD.CurrentRow.Cells[1].Value.ToString();
            txtDonGiVon.Text = gridCTHD.CurrentRow.Cells[2].Value.ToString();
            txtSLNhap.Text = gridCTHD.CurrentRow.Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (xl.ThemCTHD(txtMaCTHD.Text, txtMaThuoc.Text, int.Parse(txtDonGiVon.Text), int.Parse(txtSLNhap.Text)))
            {
                MessageBox.Show("Thêm Thành Công");
                loadgrid();
            }
            else
                MessageBox.Show("Thêm Thất Bại");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (xl.deleteCTHD(txtMaHDN.Text,txtMaThuoc.Text))
            {
                MessageBox.Show("Xóa Thành Công");
                loadgrid();
            }
            else
                MessageBox.Show("Xóa Thất Bại");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (xl.editCTHD(txtMaCTHD.Text, txtMaThuoc.Text, int.Parse(txtDonGiVon.Text), int.Parse(txtSLNhap.Text)) == true)
            {
                MessageBox.Show("Sửa Thành Công");
                loadgrid();
            }
            else
                MessageBox.Show("Sửa Thất Bại");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xl.Luu();
            loadgrid();
        }
    }
}