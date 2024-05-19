namespace cyclone
{
    partial class Cyclone
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cyclone));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromLat_tbx = new System.Windows.Forms.TextBox();
            this.fromLon_tbx = new System.Windows.Forms.TextBox();
            this.toLon_tbx = new System.Windows.Forms.TextBox();
            this.toLat_tbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.fromMonth_tbx = new System.Windows.Forms.TextBox();
            this.toMonth_tbx = new System.Windows.Forms.TextBox();
            this.season_cbx = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.clear_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(646, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлыToolStripMenuItem,
            this.папкуToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Выбрать";
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.файлыToolStripMenuItem.Text = "Файлы";
            this.файлыToolStripMenuItem.Click += new System.EventHandler(this.файлыToolStripMenuItem_Click);
            // 
            // папкуToolStripMenuItem
            // 
            this.папкуToolStripMenuItem.Name = "папкуToolStripMenuItem";
            this.папкуToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.папкуToolStripMenuItem.Text = "Папку";
            this.папкуToolStripMenuItem.Click += new System.EventHandler(this.папкуToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title});
            this.dataGridView1.Location = new System.Drawing.Point(72, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(352, 308);
            this.dataGridView1.TabIndex = 1;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Название файла";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбрано:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(140, 354);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(35, 13);
            this.countLabel.TabIndex = 3;
            this.countLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Фильтр";
            // 
            // fromLat_tbx
            // 
            this.fromLat_tbx.Location = new System.Drawing.Point(457, 97);
            this.fromLat_tbx.Name = "fromLat_tbx";
            this.fromLat_tbx.Size = new System.Drawing.Size(77, 20);
            this.fromLat_tbx.TabIndex = 5;
            this.fromLat_tbx.Text = "-90";
            this.fromLat_tbx.TextChanged += new System.EventHandler(this.fromLat_tbx_TextChanged);
            this.fromLat_tbx.Leave += new System.EventHandler(this.fromLat_tbx_Leave);
            // 
            // fromLon_tbx
            // 
            this.fromLon_tbx.Location = new System.Drawing.Point(457, 161);
            this.fromLon_tbx.Name = "fromLon_tbx";
            this.fromLon_tbx.Size = new System.Drawing.Size(77, 20);
            this.fromLon_tbx.TabIndex = 6;
            this.fromLon_tbx.Text = "-180";
            this.fromLon_tbx.Leave += new System.EventHandler(this.fromLon_tbx_Leave);
            // 
            // toLon_tbx
            // 
            this.toLon_tbx.Location = new System.Drawing.Point(562, 161);
            this.toLon_tbx.Name = "toLon_tbx";
            this.toLon_tbx.Size = new System.Drawing.Size(77, 20);
            this.toLon_tbx.TabIndex = 7;
            this.toLon_tbx.Text = "180";
            this.toLon_tbx.Leave += new System.EventHandler(this.toLon_tbx_Leave);
            // 
            // toLat_tbx
            // 
            this.toLat_tbx.Location = new System.Drawing.Point(562, 97);
            this.toLat_tbx.Name = "toLat_tbx";
            this.toLat_tbx.Size = new System.Drawing.Size(77, 20);
            this.toLat_tbx.TabIndex = 8;
            this.toLat_tbx.Text = "90";
            this.toLat_tbx.TextChanged += new System.EventHandler(this.toLat_tbx_TextChanged);
            this.toLat_tbx.Leave += new System.EventHandler(this.toLat_tbx_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Широта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Долгота";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Месяцы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "от";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(537, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "до";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "от";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "от";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(537, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "до";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(537, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "до";
            // 
            // fromMonth_tbx
            // 
            this.fromMonth_tbx.Location = new System.Drawing.Point(457, 224);
            this.fromMonth_tbx.Name = "fromMonth_tbx";
            this.fromMonth_tbx.Size = new System.Drawing.Size(77, 20);
            this.fromMonth_tbx.TabIndex = 6;
            this.fromMonth_tbx.Text = "1";
            this.fromMonth_tbx.Leave += new System.EventHandler(this.fromMonth_tbx_Leave);
            // 
            // toMonth_tbx
            // 
            this.toMonth_tbx.Location = new System.Drawing.Point(562, 224);
            this.toMonth_tbx.Name = "toMonth_tbx";
            this.toMonth_tbx.Size = new System.Drawing.Size(77, 20);
            this.toMonth_tbx.TabIndex = 6;
            this.toMonth_tbx.Text = "12";
            this.toMonth_tbx.Leave += new System.EventHandler(this.toMonth_tbx_Leave);
            // 
            // season_cbx
            // 
            this.season_cbx.FormattingEnabled = true;
            this.season_cbx.Items.AddRange(new object[] {
            "Любой",
            "Весна",
            "Лето",
            "Осень",
            "Зима"});
            this.season_cbx.Location = new System.Drawing.Point(457, 284);
            this.season_cbx.Name = "season_cbx";
            this.season_cbx.Size = new System.Drawing.Size(77, 21);
            this.season_cbx.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(436, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Сезон";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(353, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 21);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(257, 353);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(90, 23);
            this.clear_btn.TabIndex = 20;
            this.clear_btn.Text = "Очистить всё";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Показать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cyclone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 390);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.season_cbx);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toLat_tbx);
            this.Controls.Add(this.toLon_tbx);
            this.Controls.Add(this.toMonth_tbx);
            this.Controls.Add(this.fromMonth_tbx);
            this.Controls.Add(this.fromLon_tbx);
            this.Controls.Add(this.fromLat_tbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cyclone";
            this.Text = "Cyclone";
            this.Load += new System.EventHandler(this.Cyclone_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromLat_tbx;
        private System.Windows.Forms.TextBox fromLon_tbx;
        private System.Windows.Forms.TextBox toLon_tbx;
        private System.Windows.Forms.TextBox toLat_tbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox fromMonth_tbx;
        private System.Windows.Forms.TextBox toMonth_tbx;
        private System.Windows.Forms.ComboBox season_cbx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкуToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button button2;
    }
}

