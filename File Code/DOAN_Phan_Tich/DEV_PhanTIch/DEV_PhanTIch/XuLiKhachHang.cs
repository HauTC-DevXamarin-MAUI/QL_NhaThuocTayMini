using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_PhanTIch
{
    public class XuLiKhachHang
    {
        DataThuocDataContext data = new DataThuocDataContext();

        public IQueryable<KhachHang> loadKH()
        {
            return data.KhachHangs.Select(t => t);
        }
        public bool ktraKH(String pmaKH)
        {
            if (data.KhachHangs.Select(t => t).Where(t => t.maKH == pmaKH).Count() > 0)
                return false;
            return true;
        }

        public bool ThemKH(String pmaKH, String phoTen, String pgioitinh, int ptuoi, String pSDT)
        {

            if (ktraKH(pmaKH))
            {
                KhachHang kh = new KhachHang()
                {
                    maKH = pmaKH,
                    ho_ten = phoTen,
                    gioi_tinh = pgioitinh,
                    tuoi = ptuoi,
                    soDT = pSDT,
                    diem = 0,
                };
                data.KhachHangs.InsertOnSubmit(kh);
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

        public bool editNV(String pmaKH, String phoTen, String pgioitinh, int ptuoi, String pSDT)
        {
            if (!ktraKH(pmaKH))
            {
                KhachHang nv = data.KhachHangs.Where(t => t.maKH == pmaKH).Single();
                nv.maKH = pmaKH;
                nv.ho_ten = phoTen;
                nv.gioi_tinh = pgioitinh;
                nv.tuoi = ptuoi;
                nv.soDT = pSDT;
                //data.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool deleteNV(String pmaKH)
        {
            if (ktraKH(pmaKH) == false)
            {
                KhachHang kh = data.KhachHangs.Where(t => t.maKH == pmaKH).Single();
                kh.maKH = pmaKH;
                data.KhachHangs.DeleteOnSubmit(kh);
                //data.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
