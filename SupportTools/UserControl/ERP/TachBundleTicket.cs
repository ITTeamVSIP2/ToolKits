using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupportTools
{
    public partial class TachBundleTicket : DevExpress.XtraEditors.XtraUserControl
    {
        string ID, code;
        public TachBundleTicket()
        {
            InitializeComponent();
        }
        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            string connString = ConfigurationManager.ConnectionStrings["ERP_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            string Sql = "SELECT CuttingOrderID, OrderCode, OrderDate, DealPerson, Status FROM.dbo.[CuttingOrder]" + " "
                         + "WHERE OrderCode='" + textEdit1.Text + "'";
            try
            {
                connection.Open();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(Sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                gridControl1.DataSource = dt;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["CuttingOrderID"].Width = 240;
                gridView1.Columns["OrderCode"].Width = 150;
                gridView1.Columns["OrderDate"].Width = 80;
                gridView1.Columns["DealPerson"].Width = 80;
                splashScreenManager1.CloseWaitForm();
            }
            catch// (Exception ex)
            {
                gridControl1.DataSource = null;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ERP_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            string Sql = "UPDATE CuttingOrder" + " "
                            + "SET OrderCode='" + textEdit1.Text + "'" + " "
                            + "WHERE OrderCode='" + code + "' AND CuttingOrderID='" + ID + "'";
            try
            {
                connection.Open();
                SqlCommand commandPrefix = new SqlCommand(Sql, connection);
                commandPrefix.ExecuteNonQuery();
                connection.Close();
                XtraMessageBox.Show("OK.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch //(Exception ex)
            {

            }
        }

        private void gridView1_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var rect = e.Bounds;
            rect.X += 10;

            e.DefaultDraw();
            e.Cache.DrawString(gridView1.RowCount + " rows", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat);
            e.Handled = true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));

            if (hitInfo.InRow)
            {
                ID = view.GetRowCellValue(hitInfo.RowHandle, "CuttingOrderID").ToString();
                code = view.GetRowCellValue(hitInfo.RowHandle, "OrderCode").ToString();
            }
            labelControl2.Text = ID + "   |   " + code;
        }
    }
}
