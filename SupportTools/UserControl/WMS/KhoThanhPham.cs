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
    
    public partial class KhoThanhPham : DevExpress.XtraEditors.XtraUserControl
    {
        string sqlPDO;
        string sqlStaging;
        public KhoThanhPham()
        {
            InitializeComponent();
        }

       
        private void btnCheckPDO1_Click(object sender, EventArgs e)
        {
            //string PDO = txtPDO.Text.Trim() ;
            ////221231/001
            //string y = "20" + PDO.Substring(0, 2);//2022
            //string fm = PDO.Remove(0, 2);
            //string m = fm.Remove(2);
            //string fd = PDO.Remove(0, 4);
            //string d = fd.Remove(2);
            //string date = d+"/"+m+"/"+y;
            //DateTime mydate = DateTime.ParseExact(date,"dd/MM/yyyy",System.Globalization.CultureInfo.CurrentCulture);
            //DateTime now =DateTime.Now;
            //int result = DateTime.Compare(mydate, DateTime.Now);
            
            //if(mydate.Year == now.Year)
            //{
            //    int z = mydate.Day - now.Day;
            //    if (mydate.Month == now.Month)
            //    {
            //        if (z>=0&&z<30)
            //        {
            //            MessageBox.Show("Đồng bộ " + z + " ngày", "Thông báo", MessageBoxButtons.OK);
                        
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không đồng bộ được " + z, "Thông báo", MessageBoxButtons.OK);
            //    }
            //}
            splashScreenManager.ShowWaitForm();
            string connString = ConfigurationManager.ConnectionStrings["WMS_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            if (txtSaE.Text == "")
            {
                sqlPDO = "SELECT OrderCode, CustomerName, StartNo, EndNo, CartonBarCodePrefix, BarcodeStart, BarcodeEnd FROM ProductPackageDetailItem WHERE OrderCode = 'PDO-" + txtPDO.Text + "'";
            }
            else
            {
                sqlPDO = "SELECT OrderCode, CustomerName, StartNo, EndNo, CartonBarCodePrefix, BarcodeStart, BarcodeEnd FROM ProductPackageDetailItem WHERE OrderCode = 'PDO-" + txtPDO.Text + "' AND '" + txtSaE.Text + "' BETWEEN StartNo  AND EndNo";
            }
            try
            {
                
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlPDO, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                var canOpen = connection.State == ConnectionState.Open;
                connection.Close();
                gridControlListPDO.DataSource = dt;
                splashScreenManager.CloseWaitForm();
                
            }
            catch (Exception ex)
            {
                splashScreenManager.Dispose();
                txtPDO.Text = ex.Message;
            }
            

        }

        private void btnCheck3_Click(object sender, EventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            string connString = ConfigurationManager.ConnectionStrings["WMS_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            sqlStaging = memoSQL.Text + "'PDO-" + txtPDO3.Text + "'";
            try
            {
                
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStaging, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                gridControlDataStaging.DataSource = dt;
                splashScreenManager.CloseWaitForm();
            }
            catch (Exception ex)
            {
               
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                splashScreenManager.Dispose();
            }

        }

        private void btnDeletePDO1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["WMS_Server"].ConnectionString;
            var connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE ProductPackageDetailItem WHERE OrderCode = 'PDO-" + txtPDO.Text + "'", connection);
                command.ExecuteNonQuery();
                XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCheckPDO1.PerformClick();
            }
            catch (Exception ex)
            {
                txtPDO.Text = ex.Message;
            }

        }

        private void btnSyncPDO1_Click(object sender, EventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            int day = Convert.ToInt32(txtDaySync1.Text);
            if (day > 30)
            { XtraMessageBox.Show("Không thể đồng bộ lớn hơn 30 ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                string connString = ConfigurationManager.ConnectionStrings["WMS_Server"].ConnectionString;
                var connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_SyncStockInProduct", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pDifferenceDays", -day);
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    splashScreenManager.CloseWaitForm();
                    XtraMessageBox.Show("Đồng bộ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCheckPDO1.PerformClick();
                   
                }
                catch (Exception ex)
                {
                    
                    txtPDO.Text = ex.Message;
                    splashScreenManager.CloseWaitForm();
                }
            }

            
        }


        private void gridViewListPDO_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var rect = e.Bounds;
            rect.X += 10;
            e.DefaultDraw();
            e.Cache.DrawString(gridViewListPDO.RowCount + " rows", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat);
            e.Handled = true;
        }

        private void gridViewDataStaging_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var rect = e.Bounds;
            rect.X += 10;
            e.DefaultDraw();
            e.Cache.DrawString(gridViewDataStaging.RowCount + " rows", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat);
            e.Handled = true;
        }
    }
}
