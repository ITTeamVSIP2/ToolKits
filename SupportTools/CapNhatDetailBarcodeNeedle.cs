using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SupportTools
{
    public partial class CapNhatDetailBarcodeNeedle : DevExpress.XtraEditors.XtraUserControl
    {
        
        private string connString = "Server=10.17.215.212;Database=ITS;Connection Timeout=60;User Id=FEAWUser; PWD=!FEAWUser89";
        string id, date;
        public CapNhatDetailBarcodeNeedle()
        {
            InitializeComponent();

            txtID.Text = "SA-220316/038";
        }
       
        private void btnCheck_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            var connect = new SqlConnection(connString);
            string sql1 = @"SELECT ID,
                           OrderCode,
                           ReasonID,
                           ReasonName,
                           Description,
                           CreateDate,
                           ConfirmDate
                           FROM dbo.ExportItem WHERE OrderCode = '" + txtID.Text + "'";
            
            try
            {
                connect.Open();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(sql1, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridControl1.DataSource = dt;

                GridColumn id = gridView1.Columns["ID"];
                
                string idDetail = gridView1.GetRowCellValue(0,id).ToString();
                string sql2 = @"SELECT ID,
                               CostCenterCode,
                               ItemID,
                                ItemDetailID,
                               Specification,
                               Note,
                               ReturnDate,
                               Quantity,
                               UnitID
                               FROM dbo.ExportItemDetail  WHERE ExportItemID =  '" + idDetail + "'";

                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connect);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                
                gridControl2.DataSource = dt2;
                
                connect.Close();
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
                

            }
            catch// (Exception ex)
            {
            }

        }
        
        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                var connection1 = new SqlConnection(connString);
                GridView view = (GridView)sender;
                GridHitInfo hitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));
                if (hitInfo.InRow)
                {
                    id = System.Convert.ToString(gridView2.GetRowCellValue(hitInfo.RowHandle, "ID"));
                    date = Convert.ToDateTime(view.GetRowCellValue(hitInfo.RowHandle, "ReturnDate")).ToString("yyyy-MM-dd HH:mm:ss.fff");
                }
                string sqlUpdate = @"UPDATE dbo.ExportItemDetail 
                            SET ReturnDate = '" + date + "'" +
                            "WHERE ID = '" + id + "'";
                connection1.Open();
                SqlCommand command = new SqlCommand(sqlUpdate, connection1);
                command.ExecuteNonQuery();
                connection1.Close();
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Cập nhật thời gian thành công", "Thông báo", MessageBoxButtons.OK);
                btnCheck.PerformClick();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
