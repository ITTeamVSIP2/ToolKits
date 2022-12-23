namespace SupportTools
{
    partial class ThoiGianLamViec
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThoiGianLamViec));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonDongbo = new DevExpress.XtraEditors.SimpleButton();
            this.gctrlDuLieuITS = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonTra = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoMSNV = new DevExpress.XtraEditors.MemoEdit();
            this.gctrlDuLieuHR = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditCongTy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrlDuLieuITS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMSNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrlDuLieuHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCongTy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.simpleButtonDongbo);
            this.groupControl3.Controls.Add(this.gctrlDuLieuITS);
            this.groupControl3.Controls.Add(this.simpleButtonTra);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.dateEditDate);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.labelControl9);
            this.groupControl3.Controls.Add(this.memoMSNV);
            this.groupControl3.Controls.Add(this.gctrlDuLieuHR);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.comboBoxEditCongTy);
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(769, 550);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "groupControl3";
            // 
            // simpleButtonDongbo
            // 
            this.simpleButtonDongbo.Location = new System.Drawing.Point(543, 29);
            this.simpleButtonDongbo.Name = "simpleButtonDongbo";
            this.simpleButtonDongbo.Size = new System.Drawing.Size(100, 40);
            this.simpleButtonDongbo.TabIndex = 136;
            this.simpleButtonDongbo.Text = "Đồng bộ";
            this.simpleButtonDongbo.Click += new System.EventHandler(this.simpleButtonDongbo_Click);
            // 
            // gctrlDuLieuITS
            // 
            this.gctrlDuLieuITS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gctrlDuLieuITS.Location = new System.Drawing.Point(145, 90);
            this.gctrlDuLieuITS.MainView = this.gridView1;
            this.gctrlDuLieuITS.Name = "gctrlDuLieuITS";
            this.gctrlDuLieuITS.Size = new System.Drawing.Size(618, 189);
            this.gctrlDuLieuITS.TabIndex = 131;
            this.gctrlDuLieuITS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gctrlDuLieuITS;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawFooter);
            // 
            // simpleButtonTra
            // 
            this.simpleButtonTra.Location = new System.Drawing.Point(437, 29);
            this.simpleButtonTra.Name = "simpleButtonTra";
            this.simpleButtonTra.Size = new System.Drawing.Size(100, 40);
            this.simpleButtonTra.TabIndex = 130;
            this.simpleButtonTra.Text = "Tra";
            this.simpleButtonTra.Click += new System.EventHandler(this.simpleButtonTra_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(145, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 129;
            this.labelControl2.Text = "Ngày:";
            // 
            // dateEditDate
            // 
            this.dateEditDate.EditValue = null;
            this.dateEditDate.Location = new System.Drawing.Point(145, 39);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.MaskSettings.Set("mask", "dd-MM-yyyy");
            this.dateEditDate.Size = new System.Drawing.Size(140, 20);
            this.dateEditDate.TabIndex = 128;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(291, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 127;
            this.labelControl1.Text = "Công ty:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(6, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(59, 13);
            this.labelControl9.TabIndex = 126;
            this.labelControl9.Text = "Nhập MSNV:";
            // 
            // memoMSNV
            // 
            this.memoMSNV.EditValue = "";
            this.memoMSNV.Location = new System.Drawing.Point(6, 22);
            this.memoMSNV.Name = "memoMSNV";
            this.memoMSNV.Size = new System.Drawing.Size(133, 257);
            this.memoMSNV.TabIndex = 125;
            // 
            // gctrlDuLieuHR
            // 
            this.gctrlDuLieuHR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gctrlDuLieuHR.Location = new System.Drawing.Point(6, 317);
            this.gctrlDuLieuHR.MainView = this.gridView2;
            this.gctrlDuLieuHR.Name = "gctrlDuLieuHR";
            this.gctrlDuLieuHR.Size = new System.Drawing.Size(757, 230);
            this.gctrlDuLieuHR.TabIndex = 134;
            this.gctrlDuLieuHR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gctrlDuLieuHR;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView2_CustomDrawFooter);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(6, 295);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(135, 16);
            this.labelControl4.TabIndex = 133;
            this.labelControl4.Text = "Dữ liệu công nhân sự";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(145, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 16);
            this.labelControl3.TabIndex = 132;
            this.labelControl3.Text = "Dữ liệu ITS";
            // 
            // comboBoxEditCongTy
            // 
            this.comboBoxEditCongTy.Location = new System.Drawing.Point(291, 39);
            this.comboBoxEditCongTy.Name = "comboBoxEditCongTy";
            this.comboBoxEditCongTy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditCongTy.Properties.Items.AddRange(new object[] {
            "Vsip1",
            "Vsip2"});
            this.comboBoxEditCongTy.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditCongTy.TabIndex = 135;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Controls.Add(this.groupBox1);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(775, 562);
            this.groupControl2.TabIndex = 218;
            this.groupControl2.Text = "groupControl2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupControl3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 556);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "refresh256_24854.png");
            this.imageCollection1.Images.SetKeyName(1, "delete_256_icon-icons.com_75991.png");
            // 
            // ThoiGianLamViec
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ThoiGianLamViec";
            this.Size = new System.Drawing.Size(781, 565);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrlDuLieuITS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMSNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrlDuLieuHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCongTy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDongbo;
        private DevExpress.XtraGrid.GridControl gctrlDuLieuITS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTra;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoMSNV;
        private DevExpress.XtraGrid.GridControl gctrlDuLieuHR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCongTy;
    }
}
