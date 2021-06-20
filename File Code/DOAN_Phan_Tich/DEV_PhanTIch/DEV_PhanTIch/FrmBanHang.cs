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
    public partial class FrmBanHang : DevExpress.XtraEditors.XtraForm
    {
        XuLiBanHang xl = new XuLiBanHang();
        public FrmBanHang()
        {
            InitializeComponent();
        }

        public void addItemCBO()
        {
            cbo_TimKiem.Items.Add("Khách hàng");
            cbo_TimKiem.Items.Add("Thuốc");
            cbo_TimKiem.Items.Add("Đơn thuốc");
            cbo_TimKiem.SelectedItem = "Khách hàng";
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiem.SelectedIndex == 0)
                loadGridKhachHang();
            else
                loadGridThuoc();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {

            addItemCBO();
        }

        public void loadGridThuoc()
        {
            dgv_KetQua.DataSource = xl.loadThuoc(txt_TimKiem.Text);
        }
        public void loadGridKhachHang()
        {
            dgv_KetQua.DataSource = xl.loadKH(txt_TimKiem.Text);
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            
            try
            {              
                txt_TongTien.Text = xl.tinhTongTien(dgv_CTDT).ToString();
                xl.themHoaDon(txt_MaHD.Text, txt_MaNV.Text, txt_MaKH.Text, dateTimePicker1.Value, int.Parse(txt_TongTien.Text));
                MessageBox.Show("Lưu thành công");
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }



        private void btn_ThemThuoc_Click(object sender, EventArgs e)
        {
            int sl;
            if (cbo_TimKiem.SelectedItem.ToString() == "Thuốc")
            {
                if (dgv_CTDT.Rows.Count == 0)
                {
                    dgv_CTDT.Rows.Add(dgv_KetQua.CurrentRow.Cells[0].Value.ToString(), dgv_KetQua.CurrentRow.Cells[7].Value.ToString(), "1");
                }
                else
                {
                    sl = 1;
                for (int j = 0; j < dgv_CTDT.Rows.Count ; j++)
                {
                    if (dgv_CTDT.Rows[j].Cells[0].Value == dgv_KetQua.CurrentRow.Cells[0].Value)
                    {

                        if (int.Parse(dgv_CTDT.Rows[j].Cells[2].Value.ToString()) < int.Parse(dgv_KetQua.CurrentRow.Cells[8].Value.ToString()))
                        {
                            sl = int.Parse(dgv_CTDT.Rows[j].Cells[2].Value.ToString()) + 1;
                            dgv_CTDT.Rows.Remove(dgv_CTDT.Rows[j]);
                            dgv_CTDT.Rows.Add(dgv_KetQua.CurrentRow.Cells[0].Value.ToString(), dgv_KetQua.CurrentRow.Cells[7].Value.ToString(), sl);
                               
                        }    
                    }
                        
                }
                    if (dgv_CTDT.Rows[dgv_CTDT.Rows.Count-1].Cells[0].Value != dgv_KetQua.CurrentRow.Cells[0].Value)
                    {
                        dgv_CTDT.Rows.Add(dgv_KetQua.CurrentRow.Cells[0].Value.ToString(), dgv_KetQua.CurrentRow.Cells[7].Value.ToString(), "1");

                    }
                }
            }
            else
                MessageBox.Show("Không thể thêm vào chi tiết đơn thuốc");
        }

        private void btn_XoaThuoc_Click(object sender, EventArgs e)
        {
            if (dgv_CTDT.CurrentRow != null)
            {
                dgv_CTDT.Rows.Remove(dgv_CTDT.CurrentRow);
            }
        }

        private void btn_HuyThuoc_Click(object sender, EventArgs e)
        {
            dgv_CTDT.Rows.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            { 
            xl.themCTHoaDon(dgv_CTDT, txt_MaHD.Text);
                MessageBox.Show("Xuất hóa đơn thành công");
            }
            catch
            {
                MessageBox.Show("ERRORRRRRRRRRRRR");
            }
        }
    }
}