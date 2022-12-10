using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Data.SqlClient;

namespace SupportTools
{
    public partial class XoaInputChuyenMay : DevExpress.XtraEditors.XtraUserControl
    {
        public XoaInputChuyenMay()
        {
            InitializeComponent();
        }

        private void simpleButtonKiemTra_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["WTS_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            string connStringERP = ConfigurationManager.ConnectionStrings["ERP_Server"].ConnectionString;
            var connectionERP = new SqlConnection(connStringERP);
            string a = memoBarcode.Text.TrimEnd().ToString().Replace("\r\n", ",");
            string Sql_BTP_ERP = @"SELECT cso.CuttingStockOutID, cso.OrderCode, cso.OrderDate, cso.Checked, csod.Quantity, o.FEPOCode, a.sPackBarcode, cso.OrderType
                            FROM FEAERP.FEAERP_VN.dbo.CuttingStockOut AS cso
                            INNER JOIN FEAERP.FEAERP_VN.dbo.CuttingStockOutDetail AS csod
                            ON csod.CuttingStockOutID = cso.CuttingStockOutID
                            INNER JOIN FEAERP.FEAERP_VN.dbo.CuttingOrderItem AS coi
                            ON csod.CuttingOrderItemID = coi.ItemID
                            INNER JOIN FEAERP.FEAERP_VN.dbo.[Order] AS o
                            ON coi.OrderID = o.OrderID
                            INNER JOIN( 
                            SELECT ri.sLotNo, ri.iPackageNo, ri.sPackBarcode FROM dbo.RFIDIn AS ri) a
                            ON a.sLotNo = o.FEPOCode
                            INNER JOIN dbo.SplitString('" + a + "', ',')"
                            + " AS ss ON ss.s = a.sPackBarcode"
                            + " AND a.iPackageNo = coi.CardNo";
            string Sql_Input_ERP = @"SELECT RFIDInput.*
                                    FROM dbo.SplitString('" + a + "', ',')" + " AS ss INNER JOIN dbo.RFIDInput ON ss.s = Barcode";
            string Sql_Input_GP = @"SELECT RFIDIn.*
                                    FROM dbo.SplitString('" + a + "', ',')" + " AS ss INNER JOIN dbo.RFIDIn ON ss.s = sPackBarcode";
            try
            {
                connection.Open();
                SqlDataAdapter adapter1;
                adapter1 = new SqlDataAdapter(Sql_BTP_ERP, connection);
                System.Data.DataTable dt1 = new System.Data.DataTable();
                adapter1.Fill(dt1);
                //
                SqlDataAdapter adapter2;
                adapter2 = new SqlDataAdapter(Sql_Input_ERP, connectionERP);
                System.Data.DataTable dt2 = new System.Data.DataTable();
                adapter2.Fill(dt2);
                //
                SqlDataAdapter adapter3;
                adapter3 = new SqlDataAdapter(Sql_Input_GP, connection);
                System.Data.DataTable dt3 = new System.Data.DataTable();
                adapter3.Fill(dt3);
                connection.Close();
                gridControldulieuBTPERP.DataSource = dt1;
                gridControldulieuInputERP.DataSource = dt2;
                gridViewdulieuInputERP.Columns["InputTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewdulieuInputERP.Columns["InputTime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                gridViewdulieuInputERP.Columns["UpdateDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewdulieuInputERP.Columns["UpdateDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                gridControldulieuInputGP.DataSource = dt3;
                gridViewdulieuInputGP.Columns["tInTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewdulieuInputGP.Columns["tInTime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                int x = gridViewdulieuInputGP.RowCount;
                int k = gridViewdulieuBTPERP.RowCount;
                int i;
                
                if (x > 1)
                {
                    for (i = 0; i < gridViewdulieuBTPERP.RowCount; i++)
                    {
                        string QC = gridViewdulieuInputGP.GetRowCellValue(i, "iWorkSectionId").ToString();
                        if (QC == "60")
                        {
                            simpleButtonXoa.Enabled = false;
                            break;
                        }
                        else
                        {
                            simpleButtonXoa.Enabled = true;
                        }
                    }
                }
                if (x == 1)
                {
                    for (i = 0; i < gridViewdulieuBTPERP.RowCount; i++)
                    {
                        string _trueflase = gridViewdulieuBTPERP.GetRowCellValue(i, "Checked").ToString();
                        if (_trueflase == "True")
                        {
                            simpleButtonXoa.Enabled = false;
                            break;
                        }
                        else
                        {
                            simpleButtonXoa.Enabled = true;
                        }
                    }
                    
                }
            }
            catch
            {

            }
        }

        private void simpleButtonXuatExcel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel Files|*.xlsx";
            
            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
                int total = filePath.Length;
                int left = total - 5;
                string _left = filePath.Substring(0, left);
                string _right = filePath.Substring(filePath.Length - 5, 5);
                gridControldulieuBTPERP.ExportToXlsx(_left + " (BTP_ERP)" + _right);
                XtraMessageBox.Show("Lưu excel BTP ERP thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControldulieuInputERP.ExportToXlsx(_left + " (Input_ERP)" + _right);
                XtraMessageBox.Show("Lưu excel RFIDInput ERP thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControldulieuInputGP.ExportToXlsx(_left + " (RFIDIn_GP)" + _right);
                XtraMessageBox.Show("Lưu excel RFIDIn GP thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (filePath == "")
            { }
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
