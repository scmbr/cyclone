namespace cyclone
{
    partial class Map
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поменятьЦветаРандомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 27);
            this.gmap.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1682, 1100);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьИзображениеToolStripMenuItem,
            this.поменятьЦветаРандомToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьИзображениеToolStripMenuItem
            // 
            this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
            this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение";
            this.сохранитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеToolStripMenuItem_Click);
            // 
            // поменятьЦветаРандомToolStripMenuItem
            // 
            this.поменятьЦветаРандомToolStripMenuItem.Name = "поменятьЦветаРандомToolStripMenuItem";
            this.поменятьЦветаРандомToolStripMenuItem.Size = new System.Drawing.Size(160, 20);
            this.поменятьЦветаРандомToolStripMenuItem.Text = "Поменять цвета (Рандом)";
            this.поменятьЦветаРандомToolStripMenuItem.Click += new System.EventHandler(this.поменятьЦветаРандомToolStripMenuItem_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Map";
            this.Text = "Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поменятьЦветаРандомToolStripMenuItem;
    }
}