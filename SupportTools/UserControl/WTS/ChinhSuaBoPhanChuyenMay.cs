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
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data;
using DevExpress.XtraGrid;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;

namespace SupportTools
{
    public partial class ChinhSuaBoPhanChuyenMay : DevExpress.XtraEditors.XtraUserControl
    {
        string iId, sLineStyelPart, sStyleNo, iPMWorkTeamMstID, sBarCode, sWorkTeamName, tInTime;
        private bool btnExportClicked = false;
        public ChinhSuaBoPhanChuyenMay()
        {
            InitializeComponent();
            init();
          
        }

     
        private void init()
        {
            
            if (gvLineInfor.RowCount != 0)
            {
                btnExportExcel.Enabled = true;
                btnUpdate.Enabled = true;
            }
            dataPO.FillAsync();
            dataLine.FillAsync();
            dataPart.FillAsync();
            //sqlDataSource3.FillAsync();
            gvLineInfor.Columns["sLineStyelPart"].Width = 100;
            gvLineInfor.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "sLineStyelPart",
                SummaryType = SummaryItemType.Count,
                ShowInGroupColumnFooter = null
            });
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            string Sql;
            string connString = ConfigurationManager.ConnectionStrings["WTS_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            Sql = @"SELECT pcpd.iId, pcpd.sLineStyelPart, ri.sStyleNo, ri.iPMWorkTeamMstID,pcpd.sBarCode,pwtm.sWorkTeamName, ri.tInTime as InTime, sLotNo
                    FROM dbo.RFIDIn AS ri INNER JOIN dbo.PMWorkTeamMst AS pwtm
                    ON ri.iPMWorkTeamMstID = pwtm.iId
                    INNER JOIN dbo.ppCutPackageDtl AS pcpd
                    ON pcpd.sBarCode = ri.sPackBarcode
                    WHERE ri.iWorkSectionId = 60
                    AND pwtm.sWorkTeamName LIKE '" + SelectLine.Text + "'"+
                    "AND CONVERT(DATE, ri.tInTime) = '" + selectDate.Text + "'" +
                    "AND ri.sStyleNo = '" + SelectPO.Text + "'";
            try
            {
                connection.Open();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(Sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                gcLineInfor.DataSource = dt;
              
                GridColumn colD = gvLineInfor.Columns["InTime"];
                colD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                colD.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                gvLineInfor.Columns["sLineStyelPart"].Group();
                gvLineInfor.OptionsView.ShowGroupedColumns = true;

                gvLineInfor.Columns["sLineStyelPart"].OptionsColumn.AllowEdit = false;
                gvLineInfor.Columns["iId"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["sStyleNo"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["iPMWorkTeamMstID"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["sBarCode"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["InTime"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["sLotNo"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                gvLineInfor.Columns["sWorkTeamName"].OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
                if (gvLineInfor.RowCount != 0)
                {
                    btnExportExcel.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnKiemtra.Enabled = false;
                }
                loadInfor();
                btnExportClicked = false;
                splashScreenManager1.CloseWaitForm();

            }
            catch// (Exception ex)
            {
            }
        }

        private void loadInfor()
        {
            lbDate.Text = selectDate.Text;
            lbLine.Text = SelectLine.Text;
            lbPO.Text = SelectPO.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtUpdatePart.Text == "")
            {
                MessageBox.Show("Thông tin cập nhật trống.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (btnExportClicked)
                {
                    splashScreenManager1.ShowWaitForm();
                    string connString = ConfigurationManager.ConnectionStrings["WTS_Server"].ConnectionString;
                    var connection = new SqlConnection(connString);
                    string SqlUpdate = @"UPDATE pcpd
                            SET pcpd.sLineStyelPart='" + txtUpdatePart.Text.Trim() + "'" +
                                    "FROM dbo.RFIDIn AS ri INNER JOIN dbo.PMWorkTeamMst AS pwtm ON ri.iPMWorkTeamMstID = pwtm.iId INNER JOIN dbo.ppCutPackageDtl AS pcpd ON pcpd.sBarCode = ri.sPackBarcode" +
                                    " WHERE ri.iWorkSectionId = 60 " +
                                            "AND pwtm.sWorkTeamName LIKE '" + SelectLine.Text + "'" +
                                            "AND CONVERT(DATE, ri.tInTime) = '" + selectDate.Text + "'" +
                                            "AND ri.sStyleNo = '" + SelectPO.Text + "'";
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(SqlUpdate, connection);
                        command.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(SqlUpdate, connection);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        connection.Close();
                        splashScreenManager1.CloseWaitForm();
                        XtraMessageBox.Show("Thay đổi thành công." + txtUpdatePart.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcLineInfor.DataSource = dt;
                        btnKiemtra.Enabled = true;
                        btnKiemtra.PerformClick();
                        splashScreenManager1.CloseWaitForm();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn xuất file Excel trước khi cập nhật dữ liệu không? ", "Thông báo", MessageBoxButtons.YesNoCancel);
                    
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        btnExportExcel.PerformClick();
                        btnUpdate.PerformClick();
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        
                        btnExportClicked = true;
                        btnUpdate.PerformClick();
                        splashScreenManager1.CloseWaitForm();
                    }
                    if (dialogResult == DialogResult.Cancel)
                    {

                    }
                }
            }
            
        }
        #region editForm
        private void gvLineInfor_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
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
        #endregion

        private void gvLineInfor_RowUpdated(object sender, RowObjectEventArgs e)
        {
            btnKiemtra.Enabled = true;
            try
            {
                splashScreenManager1.ShowWaitForm();
                string connString = ConfigurationManager.ConnectionStrings["WTS_Server"].ConnectionString;
                var connection = new SqlConnection(connString);
                string SqlUpdate;
                GridView view = (GridView)sender;
                GridHitInfo hitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));
                if (hitInfo.InRow)
                {
                    iId = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "iId"));
                    sLineStyelPart = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "sLineStyelPart"));
                    sStyleNo = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "sStyleNo"));
                    iPMWorkTeamMstID = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "iPMWorkTeamMstID"));
                    sBarCode = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "sBarCode"));
                    sWorkTeamName = System.Convert.ToString(gvLineInfor.GetRowCellValue(hitInfo.RowHandle, "sWorkTeamName"));
                    tInTime = Convert.ToDateTime(view.GetRowCellValue(hitInfo.RowHandle, "InTime")).ToString("yyyy-MM-dd HH:mm:ss.fff");

                }

                SqlUpdate = @"UPDATE pcpd
                        SET pcpd.sLineStyelPart='" + sLineStyelPart + "'" +
                            "FROM dbo.RFIDIn AS ri INNER JOIN dbo.PMWorkTeamMst AS pwtm ON ri.iPMWorkTeamMstID = pwtm.iId INNER JOIN dbo.ppCutPackageDtl AS pcpd ON pcpd.sBarCode = ri.sPackBarcode " +
                            "WHERE ri.iWorkSectionId = 60 " +
                            "AND pwtm.sWorkTeamName LIKE '" + sWorkTeamName + "'" +
                            "AND pcpd.sBarCode LIKE '" + sBarCode + "'" +
                            "AND pcpd.iId LIKE '" + iId + "'" +
                            "AND ri.iPMWorkTeamMstID LIKE '" + iPMWorkTeamMstID + "'" +
                            "AND CONVERT(DATE, ri.tInTime) = '" + tInTime + "'" +
                            "AND ri.sStyleNo = '" + sStyleNo + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(SqlUpdate, connection);
                command.ExecuteNonQuery();
                btnKiemtra.PerformClick();
                connection.Close();
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
                XtraMessageBox.Show("Thay đổi thành công." + sLineStyelPart, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
            }
            
        }

        private void selectDate_EditValueChanged(object sender, EventArgs e)
        {
            btnKiemtra.Enabled = true;
            btnExportClicked = false;
            loadInfor();
        }

        private void SelectPO_EditValueChanged(object sender, EventArgs e)
        {
            btnKiemtra.Enabled = true;
            btnExportClicked = false;
            loadInfor();
        }

        private void SelectLine_EditValueChanged(object sender, EventArgs e)
        {
            btnKiemtra.Enabled = true;
            btnExportClicked = false;
            loadInfor();
        }


        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                btnExportClicked = true;
                
                string filePath = "";
                SaveFileDialog dialog = new SaveFileDialog();
                string po = gvLineInfor.GetRowCellValue(0, "sStyleNo").ToString() + "";
                string line = gvLineInfor.GetRowCellValue(0, "sWorkTeamName").ToString();
                DateTime d = Convert.ToDateTime(gvLineInfor.GetRowCellValue(0, "InTime").ToString());
                dialog.Filter = "Excel Files|*.xlsx";
                dialog.FileName = " " + line + "- PO " + po + " " + d.Day + "-" + d.Month + "-" + d.Year;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                    int total = filePath.Length;
                    int left = total - 5;
                    string _left = filePath.Substring(0, left);
                    string _right = filePath.Substring(filePath.Length - 5, 5);
                    gcLineInfor.ExportToXlsx(_left + " " + _right);
                    
                    XtraMessageBox.Show("Xuất excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (filePath == "")
                { }
            }
            catch
            {

            }
        }


    }
}
