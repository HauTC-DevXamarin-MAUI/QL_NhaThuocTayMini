using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DEV_PhanTIch
{
    public class XuLiBaoCaoDoanhThu
    {

        DataThuocDataContext data = new DataThuocDataContext();


        public IQueryable<HoaDonNhap> loadHDN(DateTimePicker d1, DateTimePicker d2, Label shdn, Label shdx, Label gtrinhap, Label gtrixuat)
        {
            shdn.Text = data.HoaDonNhaps.Where(t => t.ngaynhap >= d1.Value && t.ngaynhap <= d2.Value).Count().ToString();
            shdx.Text = data.HoaDonXuats.Where(t => t.ngay_xuat >= d1.Value && t.ngay_xuat <= d2.Value).Count().ToString();
            gtrinhap.Text = data.HoaDonNhaps.Where(t => t.ngaynhap >= d1.Value && t.ngaynhap <= d2.Value).Sum(t => t.tong_tien).ToString();
            gtrixuat.Text = data.HoaDonXuats.Where(t => t.ngay_xuat >= d1.Value && t.ngay_xuat <= d2.Value).Sum(t=>t.tong_tien).ToString();
            return data.HoaDonNhaps.Select(t => t).Where(t => t.ngaynhap >= d1.Value && t.ngaynhap <= d2.Value);
        }

        public IQueryable<HoaDonXuat> loadHDX(DateTimePicker d1, DateTimePicker d2)
        {
            return data.HoaDonXuats.Select(t => t).Where(t => t.ngay_xuat >= d1.Value && t.ngay_xuat <= d2.Value);
        }

        public void setValue(Label shdn, Label shdx, Label gtrinhap, Label gtrixuat)
        {
            
        }
    }
}
