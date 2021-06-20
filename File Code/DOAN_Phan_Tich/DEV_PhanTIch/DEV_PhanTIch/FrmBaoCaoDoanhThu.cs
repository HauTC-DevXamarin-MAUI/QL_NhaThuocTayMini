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
    public partial class FrmBaoCaoDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        XuLiBaoCaoDoanhThu bc = new XuLiBaoCaoDoanhThu();
        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridHDN.DataSource = bc.loadHDN(dateBD, dateKT, lblSHDN, lblSHDX, lblGTN, lblTGTX);
            gridHDX.DataSource = bc.loadHDX(dateBD,dateKT);
        }
    }
}