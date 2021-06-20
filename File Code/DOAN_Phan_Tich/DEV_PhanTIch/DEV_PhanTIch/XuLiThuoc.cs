using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_PhanTIch
{
    public class XuLiThuoc
    {

        DataThuocDataContext data = new DataThuocDataContext();

        public IQueryable<Thuoc> loadThuoc()
        {
            return data.Thuocs.Select(t => t);
        }


        public IQueryable<Thuoc> timKiem(String pvalues, String pinfo)
        {
            if (pvalues == "Mã Thuốc")
                return data.Thuocs.Select(t => t).Where(t => t.ma_thuoc == "% " + pinfo + " %");
            else if (pvalues == "Tên Thuốc")
                return data.Thuocs.Select(t => t).Where(t => t.ten_thuoc == "% " + pinfo + " %");
            else
                return data.Thuocs.Select(t => t).Where(t => t.ma_nhom == "% " + pinfo + " %");

        }
        public IQueryable<NhomThuoc> loadNhomThuoc()
        {
            return data.NhomThuocs.Select(t => t);
        }


        //Kiem Tra Thuoc
        public bool ktrThuoc(String pmathuoc)
        {
            if (data.Thuocs.Select(t => t).Where(t => t.ma_thuoc == pmathuoc).Count() > 0)
                return false;
            return true;
        }
        public bool themThuoc(String pmathuoc, String ptenthuoc, String pmanhom, String pcongdung, String pThanhPhan, String pdonvitinh,String pxuatsu, int pgiaban, int pSL)
        {
            if (ktrThuoc(pmathuoc))
            {
                Thuoc thuoc = new Thuoc()
                {
                    ma_thuoc = pmathuoc,
                    ten_thuoc = ptenthuoc,
                    ma_nhom = pmanhom,
                    cong_dung = pcongdung,
                    thanh_phan = pThanhPhan,
                    dvt = pdonvitinh,
                    xuat_xu = pxuatsu,
                    gia_ban = pgiaban,
                    so_luong = pSL,
                };
                data.Thuocs.InsertOnSubmit(thuoc);
                return true;
            }
            else
                return false;
        }

        public bool edtiThuoc(String pmathuoc, String ptenthuoc, String pmanhom, String pcongdung, String pThanhPhan, String pdonvitinh, String pxuatsu, int pgiaban, int pSL)
        {
            if (!ktrThuoc(pmathuoc))
            {
                Thuoc thuoc = data.Thuocs.Where(t => t.ma_thuoc == pmathuoc).Single();
                thuoc.ma_thuoc = pmathuoc;
                thuoc.ten_thuoc = ptenthuoc;
                thuoc.ma_nhom = pmanhom;
                thuoc.cong_dung = pcongdung;
                thuoc.thanh_phan = pThanhPhan;
                thuoc.dvt = pdonvitinh;
                thuoc.xuat_xu = pxuatsu;
                thuoc.gia_ban = pgiaban;
                thuoc.so_luong = pSL;
                return true; 
            }
            return false;
        }

        public bool deleteThuoc(String pmathuoc)
        {
            if (ktrThuoc(pmathuoc) == false)
            {
                Thuoc thuoc = data.Thuocs.Where(t => t.ma_thuoc == pmathuoc).Single();
                thuoc.ma_thuoc = pmathuoc;
                data.Thuocs.DeleteOnSubmit(thuoc);
                return true;
            }
            return false;
        }
        public void Luu()
        {
            data.SubmitChanges();
        }
    }
}
