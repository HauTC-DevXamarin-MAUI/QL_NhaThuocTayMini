using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DEV_PhanTIch
{
    public class XuLiBanHang
    {
        DataThuocDataContext data = new DataThuocDataContext();
        public IQueryable<Thuoc> loadThuoc()
        {
            return data.Thuocs.Select(t => t);
        }
        public IQueryable<Thuoc> loadThuoc(string ten)
        {
            return data.Thuocs.Where(t => t.ten_thuoc == ten);
        }
        public IQueryable<KhachHang> loadKH(string pMaKH)
        {
            return data.KhachHangs.Where(t => t.maKH == pMaKH);
        }
        public int tinhTongTien(DataGridView dgv)
        {
            int tongtien = 0,a,b;
            for(int i=0;i<=dgv.Rows.Count-1;i++)
            {
                a = int.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                b=int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                tongtien = tongtien + a*b ;
            }
            return tongtien;
        }
        public void themHoaDon(String pMaHD,String maNV, String maKH, DateTime NgayXuat, int tongTien)
        {
            //HoaDonXuat hd = new HoaDonXuat();
            //hd.maHD_Xuat = pMaHD;
            //hd.maNV = maNV;
            //hd.maKH = maKH;
            //hd.ngay_xuat = NgayXuat;
            //hd.tong_tien = tongTien;
            HoaDonXuat hd = new HoaDonXuat()
            {
                maHD_Xuat = pMaHD,
                maNV = maNV,
                maKH = maKH,
                ngay_xuat = NgayXuat,
                tong_tien = tongTien,
            };
            data.HoaDonXuats.InsertOnSubmit(hd);
            data.SubmitChanges();
        }

        public void themCTHoaDon(DataGridView dgv,string pMa)
        {
            for (int i = 0; i <= dgv.Rows.Count - 1; i++)
            {
                CTHoaDonXuat hd = new CTHoaDonXuat()
                {
                    maHD_Xuat = pMa,
                    ma_thuoc = dgv.Rows[i].Cells[0].Value.ToString(),
                    gia_ban = int.Parse(dgv.Rows[i].Cells[1].Value.ToString()),
                    SL_ban = int.Parse(dgv.Rows[0].Cells[2].Value.ToString()),

                };
                data.CTHoaDonXuats.InsertOnSubmit(hd);
                data.SubmitChanges();
            }

        }

    }
}
