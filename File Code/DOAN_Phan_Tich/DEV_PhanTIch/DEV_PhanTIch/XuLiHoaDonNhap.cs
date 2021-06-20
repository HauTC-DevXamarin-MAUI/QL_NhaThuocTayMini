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
    public class XuLiHoaDonNhap
    {
        DataThuocDataContext data = new DataThuocDataContext();

        public IQueryable<Thuoc> loadthuoc_MaThuoc(string maThuoc)
        {
            return data.Thuocs.Where(c => c.ma_thuoc.Contains(maThuoc));
        }
        public IQueryable<Thuoc> loadthuoc_TenThuoc(string tenThuoc)
        {
            return data.Thuocs.Where(c => c.ten_thuoc.Contains(tenThuoc));
        }
        public IQueryable<Thuoc> loadthuoc_CongDung(string congDung)
        {
            return data.Thuocs.Where(c => c.cong_dung.Contains(congDung));
        }
        public IQueryable<Thuoc> loadThuoc_MaNhom(string maNhom)
        {
            return data.Thuocs.Where(c => c.ma_nhom.Contains(maNhom));
        }
        public IQueryable<HoaDonNhap> loadhd_Nhap()
        {
            return data.HoaDonNhaps.Select(t => t);
        }
        public bool ktraHD(String pmaHD)
        {
            if (data.HoaDonNhaps.Select(t => t).Where(t => t.maHD_Nhap == pmaHD).Count() > 0)
                return false;
            return true;
        }
        public bool ThemHd(String pmaHD, String pmaNV, DateTime NgayThem, String NCC, int tongTien)
        {

            if (ktraHD(pmaHD))
            {
                HoaDonNhap hd = new HoaDonNhap()
                {
                    maHD_Nhap = pmaHD,
                    maNV = pmaNV,
                    ngaynhap = NgayThem,
                    ten_nha_cung_cap = NCC,
                    tong_tien = tongTien
                };
                data.HoaDonNhaps.InsertOnSubmit(hd);
                //data.SubmitChanges();

                return true;
            }
            else
                return false;
        }
        public void Luu()
        {
            data.SubmitChanges();

        }
        public bool editHD(String pmaHD, String pmaNV, DateTime NgayThem, String NCC, int tongTien)
        {
            if (!ktraHD(pmaHD))
            {
                HoaDonNhap hd = data.HoaDonNhaps.Where(t => t.maHD_Nhap == pmaHD).Single();
                hd.maHD_Nhap = pmaHD;
                hd.maNV = pmaNV;
                hd.ngaynhap = NgayThem;
                hd.ten_nha_cung_cap = NCC;
                hd.tong_tien = tongTien;
                //data.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool deleteHD(String pmaHD)
        {
            if (ktraHD(pmaHD) == false)
            {
                HoaDonNhap hd = data.HoaDonNhaps.Where(t => t.maHD_Nhap == pmaHD).Single();
                hd.maHD_Nhap = pmaHD;
                data.HoaDonNhaps.DeleteOnSubmit(hd);
                //data.SubmitChanges();
                return true;
            }
            return false;
        }
        public IQueryable<CTHoaDonNhap> load_CTHD(string maHD)
        {
            return data.CTHoaDonNhaps.Where(t => t.maHD_Nhap == maHD);
        }
        //CTHD
        public bool ktraCTHD(String pmaHD,String pmaThuoc)
        {
            if (data.CTHoaDonNhaps.Select(t => t).Where(t => t.maHD_Nhap == pmaHD && t.ma_thuoc== pmaThuoc).Count() > 0)
                return false;
            return true;
        }
        public bool ThemCTHD(String pmaHD, String pmaThuoc , int Gia, int SL)
        {

            if (ktraCTHD(pmaHD, pmaThuoc))
            {
                CTHoaDonNhap CTHD= new CTHoaDonNhap()
                {
                    maHD_Nhap = pmaHD,
                    ma_thuoc = pmaThuoc,
                    gia_von = Gia,
                    SL_Nhap = SL,
                    
                };
                data.CTHoaDonNhaps.InsertOnSubmit(CTHD);
                //data.SubmitChanges();

                return true;
            }
            else
                return false;
        }

        public bool editCTHD(String pmaHD, String pmaThuoc, int Gia, int SL)
        {
            if (!ktraCTHD(pmaHD, pmaThuoc))
            {
                CTHoaDonNhap cthd = data.CTHoaDonNhaps.Where(t => t.maHD_Nhap == pmaHD&&t.ma_thuoc==pmaThuoc).Single();
                cthd.maHD_Nhap = pmaHD;
                cthd.ma_thuoc = pmaThuoc;
                cthd.gia_von = Gia;
                cthd.SL_Nhap = SL;
                //data.SubmitChanges();
                return true;
            }


            return false;
        }

        public bool deleteCTHD(String pmaHD,String pmaThuoc)
        {
            if (ktraCTHD(pmaHD, pmaThuoc) == false)
            {
                CTHoaDonNhap cthd = data.CTHoaDonNhaps.Where(t => t.maHD_Nhap == pmaHD && t.ma_thuoc == pmaThuoc).Single();
                cthd.maHD_Nhap = pmaHD;
                cthd.ma_thuoc = pmaThuoc;
                data.CTHoaDonNhaps.DeleteOnSubmit(cthd );
                //data.SubmitChanges();
                return true;
            }
            return false;
        }

    }
}
        


