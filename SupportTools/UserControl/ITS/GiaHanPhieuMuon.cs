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
    public partial class GiaHanPhieuMuon : DevExpress.XtraEditors.XtraUserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["ITS_Server"].ConnectionString;
        string ReasonName, Description;
        string id, date;
        private string OrderCode;
        private string IdExItem;
        private string ReasonID;

        public GiaHanPhieuMuon()
        {
            InitializeComponent();
            
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            try
            {
                splashScreenManager1.ShowWaitForm();
                var connection2 = new SqlConnection(connString);
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
                connection2.Open();
                SqlCommand command = new SqlCommand(sqlUpdate, connection2);
                command.ExecuteNonQuery();
                connection2.Close();
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Cập nhật thời gian thành công", "Thông báo", MessageBoxButtons.OK);
                btnCheck.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                var connection1 = new SqlConnection(connString);
                GridView view = (GridView)sender;
                GridHitInfo hitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));
                if (hitInfo.InRow)
                {
                    OrderCode = System.Convert.ToString(gridView1.GetRowCellValue(hitInfo.RowHandle, "OrderCode"));
                    IdExItem = System.Convert.ToString(gridView1.GetRowCellValue(hitInfo.RowHandle, "ID"));
                    ReasonID = System.Convert.ToString(gridView1.GetRowCellValue(hitInfo.RowHandle, "ReasonID"));
                    ReasonName = System.Convert.ToString(gridView1.GetRowCellValue(hitInfo.RowHandle, "ReasonName"));
                    Description = System.Convert.ToString(gridView1.GetRowCellValue(hitInfo.RowHandle, "Description"));
                }
                string sqlUpdate1 = @"UPDATE dbo.ExportItem 
                            SET ReasonName =N'" + ReasonName + "', Description=N'" + Description + "'" +
                            "WHERE OrderCode = '" + OrderCode + "'" +
                            "AND ID = '" + IdExItem + "'" +
                            "AND ReasonID = '" + ReasonID + "'";


                connection1.Open();
                SqlCommand command = new SqlCommand(sqlUpdate1, connection1);
                command.ExecuteNonQuery();
                connection1.Close();
                //gridView1.Columns["CostCenterCode"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                //gridView1.Columns["Specification"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                //gridView1.Columns["UnitID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                //gridView1.Columns["Quantity"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                //gridView1.Columns["ItemDetailID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                //gridView1.Columns["Note"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                


                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);
                btnCheck.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
        #region

        public static class MyExtenstions
        {
            public static Control FindControl(Control root, string text)
            {
                if (root == null) throw new ArgumentNullException("root");
                foreach (Control child in root.Controls)
                {
                    if (child.Text == text) return child;
                    Control found = FindControl(child, text);
                    if (found != null) return found;
                }
                return null;
            }
        }
        

        private void gridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            changeTextButton(sender, e);
        }

        private void changeTextButton(object sender, EditFormPreparedEventArgs e)
        {
            Control ctrl = MyExtenstions.FindControl(e.Panel, "Update");
            if (ctrl != null)
            {
                ctrl.Text = "Cập nhật";
            }

            ctrl = MyExtenstions.FindControl(e.Panel, "Cancel");
            if (ctrl != null)
            {
                ctrl.Text = "Hủy";
            }
        }

        private void gridView2_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            changeTextButton(sender, e);

        }
        #endregion
        private void btnCheck_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl2.DataSource = null;
            gridView2.Columns.Clear();
            splashScreenManager1.ShowWaitForm();
            if (txtID.Text == "")
            {
                MessageBox.Show("Thiếu thông tin mã phiếu", "Thông báo", MessageBoxButtons.OK);
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
            }
            else
            {
                var connect = new SqlConnection(connString);
                string sql1 = @"SELECT ID,
                           OrderCode,
                           ReasonID,
                           ReasonName,
                           Description,
                           CreateDate,
                           ConfirmDate
                           FROM dbo.ExportItem WHERE OrderCode = '" + txtID.Text.Trim() + "'";

                try
                {
                    connect.Open();
                    SqlDataAdapter adapter;
                    adapter = new SqlDataAdapter(sql1, connect);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridControl1.DataSource = dt;

                    GridColumn id = gridView1.Columns["ID"];
                    gridView1.Columns["ID"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["CreateDate"].OptionsColumn.ReadOnly = true;
                    gridView1.Columns["ConfirmDate"].OptionsColumn.ReadOnly = true;
                    gridView1.Columns["OrderCode"].OptionsColumn.ReadOnly = true;
                    gridView1.Columns["ID"].OptionsColumn.ReadOnly = true;
                    gridView1.Columns["ID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView1.Columns["ReasonID"].OptionsColumn.ReadOnly = true;
                    gridView1.Columns["ReasonID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView1.Columns["CreateDate"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView1.Columns["ConfirmDate"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView1.Columns["ReasonName"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Description"].OptionsColumn.AllowEdit = true;

                    string idDetail = gridView1.GetRowCellValue(0, id).ToString();
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

                    gridView2.Columns["CostCenterCode"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["Specification"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["UnitID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["Quantity"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["ItemDetailID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["Note"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["ID"].OptionsColumn.AllowEdit = false;
                    gridView2.Columns["ID"].OptionsColumn.ReadOnly = true;
                    gridView2.Columns["ItemID"].OptionsColumn.ReadOnly = true;
                    gridView2.Columns["ItemID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                    gridView2.Columns["ReturnDate"].OptionsColumn.AllowEdit = true;
                    gridView2.Columns["ItemID"].OptionsColumn.AllowEdit = false;
                    gridView2.Columns["ItemDetailID"].OptionsColumn.AllowEdit = false;
                    gridView2.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                    gridView2.Columns["UnitID"].OptionsColumn.AllowEdit = false;
                    splashScreenManager1.CloseWaitForm();
                    splashScreenManager1.Dispose();
                }
                catch
                {
                    MessageBox.Show("Mã sai hay gì kìa, không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK);
                    splashScreenManager1.CloseWaitForm();
                    splashScreenManager1.Dispose();
                }
            }
            
        }
    }
}
