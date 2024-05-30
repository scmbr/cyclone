using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace cyclone
{
    public partial class Cyclone : Form
    {
        List<string> uniqFiles = new List<string>();
        List<string> FilesPath = new List<string>();
        List<Cyclones> cyclones = new List<Cyclones>();
        int progress = 0;
        int percent = 0;


        public Cyclone()
        {
            InitializeComponent();
            countLabel.Text = "0";


        }
        

        private void файлыToolStripMenuItem_Click(object sender, EventArgs e)
        {

                ofd.Filter = "Files|*.xls;*.xlsx;*csv";
                ofd.Multiselect = true;


                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string[] ofdSelectedFilesNames = ofd.SafeFileNames;
                    string[] ofdSelectedFilesPaths = ofd.FileNames;

                    bool uniq = true;
                    string repeats = "\n";

                    for (int i = 0; i < ofdSelectedFilesNames.Length; i++)
                    {
                        if (!uniqFiles.Contains(ofdSelectedFilesNames[i]))
                        {
                            dataGridView1.Rows.Add(ofdSelectedFilesNames[i]);
                            uniqFiles.Add(ofdSelectedFilesNames[i]);
                            FilesPath.Add(ofdSelectedFilesPaths[i]);
                        }
                        else
                        {
                            repeats += ofdSelectedFilesNames[i] + "   ";
                            
                        }
                    }
                    if (repeats != "\n")
                    {
                        MessageBox.Show("Эти файлы уже были добавлены!" + repeats);
                    }
                    countLabel.Text = Convert.ToString(uniqFiles.Count);
                   
         
                }

        }

        private void папкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
     


                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string folderName = fbd.SelectedPath;
                    DirectoryInfo folder = new DirectoryInfo(folderName); 

                    FileInfo[] Files = folder.GetFiles("*.csv", SearchOption.AllDirectories); 
                    string repeats = "\n";
                    for (int i = 0; i < Files.Length; i++)
                    {
                        if (!uniqFiles.Contains(Files[i].Name))
                        {
                            dataGridView1.Rows.Add(Files[i].Name);
                            uniqFiles.Add(Files[i].Name);
                            FilesPath.Add(Files[i].FullName);
                        }
                        else
                        {
                            
                            repeats += Files[i].Name+"   ";
                    
                        }
                    }
                    if (repeats != "\n") {
                        MessageBox.Show("Эти файлы уже были добавлены!" + repeats); 
                    }

                    
                    countLabel.Text = Convert.ToString(uniqFiles.Count);
                    
                }
     

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    string delFileName = dataGridView1.Rows[oneCell.RowIndex].Cells[oneCell.ColumnIndex].Value.ToString();

                    FilesPath.RemoveAt(uniqFiles.IndexOf(delFileName));
                    uniqFiles.Remove(delFileName);
               
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                   
                }
            }
            countLabel.Text = Convert.ToString(uniqFiles.Count);
          
            
        }
        private void Sort()
        {
            cyclones = cyclones.OrderBy(x => x.CycloneId).ThenBy(x =>x.year).ThenBy(x => x.month).ThenBy(x => x.day).ThenBy(x => x.hour).ToList();
        }
        private void SortByDate()
        {
            int i = 0;
            int j = 0;
            for(int i1 = 0; i1 < cyclones.Count; i1++)
            {

            }
            cyclones = QuickSortByDate(cyclones, 0, cyclones.Count - 1);
        }
        private List<Cyclones> QuickSortByDate(List<Cyclones> cyclones, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return cyclones;

            int pivot = FindPivotByDate(cyclones, minIndex, maxIndex);
            QuickSortByDate(cyclones, minIndex, pivot - 1);
            QuickSortByDate(cyclones, pivot + 1, maxIndex);
            return cyclones;
        }

        private int FindPivotByDate(List<Cyclones> cyclones, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            Cyclones temp = new Cyclones();
            for (int i = minIndex; i < maxIndex; i++)
            {
                    if (double.Parse(cyclones[i].time, CultureInfo.InvariantCulture) < double.Parse(cyclones[maxIndex].time, CultureInfo.InvariantCulture))
                    {
                        pivot++;
                        temp = cyclones[pivot];
                        cyclones[pivot] = cyclones[i];
                        cyclones[i] = temp;
                    }
                
            }

            pivot++;
            temp = cyclones[pivot];
            cyclones[pivot] = cyclones[maxIndex];
            cyclones[maxIndex] = temp;
            return pivot;
        }




        private void SortById()
        {
            cyclones = QuickSortById(cyclones, 0, cyclones.Count - 1);
        }
        private List<Cyclones> QuickSortById(List<Cyclones> cyclones, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return cyclones;

            int pivot = FindPivotById(cyclones, minIndex, maxIndex);
            QuickSortById(cyclones, minIndex, pivot - 1);
            QuickSortById(cyclones, pivot + 1, maxIndex);
            return cyclones;
        }

        private int FindPivotById(List<Cyclones> cyclones, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            Cyclones temp = new Cyclones();
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (cyclones[i].CycloneId < cyclones[maxIndex].CycloneId)
                {
                    pivot++;
                    temp = cyclones[pivot];
                    cyclones[pivot] = cyclones[i];
                    cyclones[i] = temp;
                }
            }

            pivot++;
            temp = cyclones[pivot];
            cyclones[pivot] = cyclones[maxIndex];
            cyclones[maxIndex] = temp;
            return pivot;
        }
        private void UpdateCyclones()
        {
            string problemFile = "";
            int id = 1;
            try
            {
                cyclones.Clear();
                foreach (string path in FilesPath)
                {


                    string fileExtension = System.IO.Path.GetExtension(path);
                    if (fileExtension == ".xlsx")
                    {
                        ExcelPackage excelPackage = new ExcelPackage(path);
                        var workbook = excelPackage.Workbook;
                        var worksheet = workbook.Worksheets[0];
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            Cyclones cyclone = new Cyclones();
                            cyclone.year = int.Parse(worksheet.Cells[row, 2].Value.ToString());
                            cyclone.month = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                            cyclone.day = int.Parse(worksheet.Cells[row, 4].Value.ToString());
                            cyclone.hour = int.Parse(worksheet.Cells[row, 5].Value.ToString());
                            cyclone.CycloneId = int.Parse(worksheet.Cells[row, 6].Value.ToString());
                           
                            cyclone.lat = double.Parse(worksheet.Cells[row, 7].Value.ToString());
                            cyclone.lon = double.Parse(worksheet.Cells[row, 8].Value.ToString());
                            cyclone.radius = worksheet.Cells[row, 9].Value.ToString();
                            cyclone.area = int.Parse(worksheet.Cells[row, 10].Value.ToString());
                            cyclone.depth = worksheet.Cells[row, 11].Value.ToString();
                            cyclones.Add(cyclone);
                            //MessageBox.Show(cyclone.CycloneId.ToString());
                        }

                        //MessageBox.Show("Hello, world!");
                    }
                    else
                    {
                        problemFile = path;
                        string[] csvLines = System.IO.File.ReadAllLines(path);
                        string[] order = csvLines[0].Split(',', ';');
                        int[] rightOrderIndex = new int[order.Length];
                        string[] rightOrder = { "year", "month", "day", "hour", "time", "id", "pid", "ptid", "x", "y", "lat", "lon", "p_cent", "p_edge", "area", "radius", "depth", "p_grad", "DsqP", "type", "centers", "Ege", "Erg", "Ely", "Esp", "Emg", "Dp", "u", "v", "uv", "DpDt" };
                        for (int i = 0; i < rightOrder.Length; i++)
                        {
                            for (int j = 0; j < order.Length; j++)
                            {
                                if (rightOrder[i] == order[j])
                                {
                                    rightOrderIndex[i] = j; break;
                                }
                            }
                        }

                        for (int i = 1; i < csvLines.Length; i++)
                        {
                            try
                            {
                                string[] data = csvLines[i].Split(',', ';');
                                Cyclones c = new Cyclones(data[rightOrderIndex[0]], data[rightOrderIndex[1]], data[rightOrderIndex[2]], data[rightOrderIndex[3]], data[rightOrderIndex[4]], data[rightOrderIndex[5]], data[rightOrderIndex[6]], data[rightOrderIndex[7]], data[rightOrderIndex[8]], data[rightOrderIndex[9]], data[rightOrderIndex[10]], data[rightOrderIndex[11]], data[rightOrderIndex[12]], data[rightOrderIndex[13]], data[rightOrderIndex[14]], data[rightOrderIndex[15]], data[rightOrderIndex[16]], data[rightOrderIndex[17]], data[rightOrderIndex[18]], data[rightOrderIndex[19]], data[rightOrderIndex[20]], data[rightOrderIndex[21]], data[rightOrderIndex[22]], data[rightOrderIndex[23]], data[rightOrderIndex[24]], data[rightOrderIndex[25]], data[rightOrderIndex[26]], data[rightOrderIndex[27]], data[rightOrderIndex[28]], data[rightOrderIndex[29]], data[rightOrderIndex[30]]);
                                c.CycloneId = id;
                                cyclones.Add(c);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }

                        }
                        id++;
                    }
                    //MessageBox.Show(cyclones[0].ToString());
                }
            }
            catch (Exception updateExc) {
                MessageBox.Show(updateExc.Message);
                MessageBox.Show($"Выбранный вами файл ({problemFile}) не соответствуют шаблону, по которому выполняется данная операция. \nПожалуйста, выберите другой файл", "Неверный тип файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Rows.RemoveAt(FilesPath.IndexOf(problemFile));
                uniqFiles.RemoveAt(FilesPath.IndexOf(problemFile));
                FilesPath.Remove(problemFile);

      
                
                UpdateCyclones();
                countLabel.Text = Convert.ToString(uniqFiles.Count);
                
            }
        
}
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // Радиус Земли в км

            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            return distance;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        private void Categorize()
        {
            int id = 1;
            for(int i=0;i<cyclones.Count-1;i++)
            {
                if (cyclones[i].CycloneId == 0)
                {
                    cyclones[i].CycloneId = id;
                    id++;
                }
                for (int j=i+1;j<cyclones.Count;j++) 
                {
                    if (cyclones[i].time != cyclones[j].time)
                    {
                        if ((double.Parse(cyclones[j].time, CultureInfo.InvariantCulture) - double.Parse(cyclones[i].time, CultureInfo.InvariantCulture) > 1))
                        {
                            break;
                        }
                        if (Distance(cyclones[i].lat, cyclones[i].lon, cyclones[j].lat, cyclones[j].lon) < 400)
                        {
                            cyclones[j].CycloneId = cyclones[i].CycloneId;
                        }
                    }
                }
                

            }
        }
        private void IdNorm()
        {
            
            List<int> ids = new List<int>();
            for (int i = 0; i < cyclones.Count; i++)
            {
                ids.Add(cyclones[i].CycloneId);
            }
            int currentValue = 0;

            for (int i = 0; i < cyclones.Count; i++)
            {
                if (i > 0 && ids[i] == ids[i-1])
                {
                    cyclones[i].CycloneId = currentValue;
                }
                else
                {
                    currentValue++;
                    cyclones[i].CycloneId = currentValue;
                }
            }
        }
        private void SelByLat()
        {
            if (fromLat_tbx.Text == "" || (double.Parse(fromLat_tbx.Text,CultureInfo.InvariantCulture)<-90))
            {
                fromLat_tbx.Text = "-90";

            }
            if (toLat_tbx.Text == "" || (double.Parse(toLat_tbx.Text, CultureInfo.InvariantCulture)>90))
            {
                toLat_tbx.Text = "90";
            }
            double parsedValue;
            if (!double.TryParse(fromLat_tbx.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(toLat_tbx.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Cyclones> tempCyclones = new List<Cyclones>();
            for (int i = 0; i < cyclones.Count; i++)
            {
                if ((cyclones[i].lat > double.Parse(fromLat_tbx.Text, CultureInfo.InvariantCulture)) & (cyclones[i].lat < double.Parse(toLat_tbx.Text,CultureInfo.InvariantCulture)))
                {
                    tempCyclones.Add(cyclones[i]);
                }
            }
            cyclones = tempCyclones;

        }
        
        private void SelByLon()
        {
            if (fromLon_tbx.Text == "" || (double.Parse(fromLon_tbx.Text,CultureInfo.InvariantCulture)<-180))
            {
                fromLon_tbx.Text = "-180";

            }
            if (toLon_tbx.Text == "" || (double.Parse(toLon_tbx.Text,CultureInfo.InvariantCulture)>180))
            {
                toLon_tbx.Text = "180";
            }
            double parsedValue;
            if (!double.TryParse(fromLon_tbx.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(toLon_tbx.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            List<Cyclones> tempCyclones = new List<Cyclones>();
            for (int i = 0; i < cyclones.Count; i++)
            {
                if ((cyclones[i].lon > double.Parse(fromLon_tbx.Text, CultureInfo.InvariantCulture)) & (cyclones[i].lon < double.Parse(toLon_tbx.Text, CultureInfo.InvariantCulture)))
                {
                    tempCyclones.Add(cyclones[i]);
                }
            }
            cyclones = tempCyclones;
        }
        private void SelByMonth()
        {
            if (fromMonth_tbx.Text == "")
            {
                fromMonth_tbx.Text = "1";

            }
            if (toMonth_tbx.Text == "")
            {
                toMonth_tbx.Text = "12";
            }
            int parsedValue;
            if (!int.TryParse(fromMonth_tbx.Text, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(toMonth_tbx.Text, out parsedValue))
            {
                MessageBox.Show("Неверный формат данных! Поле должно содержать только числа!", "Ошибка формата данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(fromMonth_tbx.Text) < 1)
            {
                fromMonth_tbx.Text = "1";

            }
            if (Convert.ToInt32(toMonth_tbx.Text) > 12)
            {
                toMonth_tbx.Text = "12";
            }
            List<Cyclones> tempCyclones = new List<Cyclones>();
            for (int i = 0; i < cyclones.Count; i++)
            {
                if ((cyclones[i].month >= Convert.ToInt32(fromMonth_tbx.Text)) & (cyclones[i].month <= Convert.ToInt32(toMonth_tbx.Text)))
                {
                    tempCyclones.Add(cyclones[i]);
                }
            }
            cyclones = tempCyclones;
        }
        private void SelBySeason()
        {
            
            List<Cyclones> tempCyclones = new List<Cyclones>();
            for (int i = 0; i < cyclones.Count; i++)
            {

                if (Equals(cyclones[i].season, season_cbx.GetItemText(season_cbx.SelectedItem)))
                {
                    //MessageBox.Show(cyclones[i].Season + " = " + season_cbx.GetItemText(season_cbx.SelectedItem));
                    tempCyclones.Add(cyclones[i]);
                }
            }
            if ((!Equals(season_cbx.GetItemText(season_cbx.SelectedItem), ""))&(!Equals(season_cbx.GetItemText(season_cbx.SelectedItem), "Любой")))
            {
                cyclones = tempCyclones;
            }
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateCyclones();
            SelByLat();
            SelByLon();
            SelByMonth();
            SelBySeason();
            //SortByDate();
            //Categorize();
            Sort();
            IdNorm();
            //SortById();
            //SortByDate();
            sfd.Filter = "Excel файлы|*.xlsx";
            sfd.DefaultExt = "xlsx";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filePath = sfd.FileName;
            
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Лист1");

                //// Записываем заголовки столбцов
                worksheet.Cells[1, 1].Value = "Номер строки";
                worksheet.Cells[1, 2].Value = "Год";
                worksheet.Cells[1, 3].Value = "Месяц";
                worksheet.Cells[1, 4].Value = "День";
                worksheet.Cells[1, 5].Value = "Время";
                worksheet.Cells[1, 6].Value = "Номер циклона";
                worksheet.Cells[1, 7].Value = "Долгота";
                worksheet.Cells[1, 8].Value = "Широта";
                worksheet.Cells[1, 9].Value = "Радиус";
                worksheet.Cells[1, 10].Value = "Площадь";
                worksheet.Cells[1, 11].Value = "Глубина";
                //worksheet.Cells[1, 12].Value = "lon";
                //worksheet.Cells[1, 13].Value = "p_cent";
                //worksheet.Cells[1, 14].Value = "p_edge";
                //worksheet.Cells[1, 15].Value = "area";
                //worksheet.Cells[1, 16].Value = "radius";
                //worksheet.Cells[1, 17].Value = "depth";
                //worksheet.Cells[1, 18].Value = "p_grad";
                //worksheet.Cells[1, 19].Value = "DsqP";
                //worksheet.Cells[1, 20].Value = "type";
                //worksheet.Cells[1, 21].Value = "centers";
                //worksheet.Cells[1, 22].Value = "Ege";
                //worksheet.Cells[1, 23].Value = "Erg";
                //worksheet.Cells[1, 24].Value = "Ely";
                //worksheet.Cells[1, 25].Value = "Esp";
                //worksheet.Cells[1, 26].Value = "Emg";
                //worksheet.Cells[1, 27].Value = "Dp";
                //worksheet.Cells[1, 28].Value = "u";
                //worksheet.Cells[1, 29].Value = "v";
                //worksheet.Cells[1, 30].Value = "uv";
                //worksheet.Cells[1, 31].Value = "DpDt";

                int row = 2;
                int i = 1;
                foreach (Cyclones cyclone in cyclones)
                {
                    worksheet.Cells[row, 1].Value = i;
                    worksheet.Cells[row, 2].Value = cyclone.year;
                    worksheet.Cells[row, 3].Value = cyclone.month;
                    worksheet.Cells[row, 4].Value = cyclone.day;
                    worksheet.Cells[row, 5].Value = cyclone.hour;
                    worksheet.Cells[row, 6].Value = cyclone.CycloneId;
                    worksheet.Cells[row, 7].Value = cyclone.lat;
                    worksheet.Cells[row, 8].Value = cyclone.lon;
                    //worksheet.Cells[row, 10].Value = cyclone.y;
                    //worksheet.Cells[row, 11].Value = cyclone.lat;
                    //worksheet.Cells[row, 12].Value = cyclone.lon;
                    //worksheet.Cells[row, 13].Value = cyclone.p_cent;
                    //worksheet.Cells[row, 14].Value = cyclone.p_edge;
                    worksheet.Cells[row, 9].Value = cyclone.radius;
                    worksheet.Cells[row, 10].Value = cyclone.area;
                    worksheet.Cells[row, 11].Value = cyclone.depth;
                    //worksheet.Cells[row, 18].Value = cyclone.p_grad;
                    //worksheet.Cells[row, 19].Value = cyclone.DsqP;
                    //worksheet.Cells[row, 20].Value = cyclone.type;
                    //worksheet.Cells[row, 21].Value = cyclone.centers;
                    //worksheet.Cells[row, 22].Value = cyclone.Ege;
                    //worksheet.Cells[row, 23].Value = cyclone.Erg;
                    //worksheet.Cells[row, 24].Value = cyclone.Ely;
                    //worksheet.Cells[row, 25].Value = cyclone.Esp;
                    //worksheet.Cells[row, 26].Value = cyclone.Emg;
                    //worksheet.Cells[row, 27].Value = cyclone.Dp;
                    //worksheet.Cells[row, 28].Value = cyclone.u;
                    //worksheet.Cells[row, 29].Value = cyclone.v;
                    //worksheet.Cells[row, 30].Value = cyclone.uv;
                    //worksheet.Cells[row, 31].Value = cyclone.DpDt;
                    row++;
                    i++;
                }

                try
                {
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                    MessageBox.Show("Файл успешно сохранен!","", MessageBoxButtons.OK);
                }
                catch(Exception exc) {
                    MessageBox.Show("Операция не может быть выполнена, так как этот файл открыт в другой программе", "Файл уже используется",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }





          
     


        }
        

     

        private void clear_btn_Click(object sender, EventArgs e)
        {

            cyclones.Clear();
            uniqFiles.Clear();
            FilesPath.Clear();
            dataGridView1.Rows.Clear();

            countLabel.Text = "0";
        }

        private void fromLat_tbx_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toLat_tbx_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void fromLat_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (fromLat_tbx.Text == "" || (double.Parse(fromLat_tbx.Text, CultureInfo.InvariantCulture) < -90))
                {
                    fromLat_tbx.Text = "-90";

                }
                if ((double.Parse(fromLat_tbx.Text, CultureInfo.InvariantCulture) > 90))
                {
                    fromLat_tbx.Text = "90";

                }
                if ((double.Parse(fromLat_tbx.Text, CultureInfo.InvariantCulture) > (double.Parse(toLat_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    fromLat_tbx.Text = toLat_tbx.Text;
                }

            }
            catch (Exception fromLat_exc)
            {
                MessageBox.Show(fromLat_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void toLat_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (toLat_tbx.Text == "" || (double.Parse(toLat_tbx.Text, CultureInfo.InvariantCulture) > 90))
                {
                    toLat_tbx.Text = "90";
                }
                if ((double.Parse(toLat_tbx.Text, CultureInfo.InvariantCulture) < -90))
                {
                    toLat_tbx.Text = "-90";

                }
                if ((double.Parse(toLat_tbx.Text, CultureInfo.InvariantCulture) < (double.Parse(fromLat_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    toLat_tbx.Text = fromLat_tbx.Text;
                }
            }
            catch (Exception toLat_exc)
            {
                MessageBox.Show(toLat_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void fromLon_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (fromLon_tbx.Text == "" || (double.Parse(fromLon_tbx.Text, CultureInfo.InvariantCulture) < -180))
                {
                    fromLon_tbx.Text = "-180";

                }
                if ((double.Parse(fromLon_tbx.Text, CultureInfo.InvariantCulture) > 180))
                {
                    fromLon_tbx.Text = "180";

                }
                if ((double.Parse(fromLon_tbx.Text, CultureInfo.InvariantCulture) > (double.Parse(toLon_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    fromLon_tbx.Text = toLon_tbx.Text;
                }

            }
            catch (Exception fromLon_exc)
            {
                MessageBox.Show(fromLon_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void toLon_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (toLon_tbx.Text == "" || (double.Parse(toLon_tbx.Text, CultureInfo.InvariantCulture) > 180))
                {
                    toLon_tbx.Text = "180";
                }
                if ((double.Parse(toLon_tbx.Text, CultureInfo.InvariantCulture) < -180))
                {
                    toLon_tbx.Text = "-180";

                }
                if ((double.Parse(toLon_tbx.Text, CultureInfo.InvariantCulture) < (double.Parse(fromLon_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    toLon_tbx.Text = fromLon_tbx.Text;
                }
            }
            catch (Exception toLon_exc)
            {
                MessageBox.Show(toLon_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void fromMonth_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (fromMonth_tbx.Text == "" || (double.Parse(fromMonth_tbx.Text, CultureInfo.InvariantCulture) < 1))
                {
                    fromMonth_tbx.Text = "1";

                }
                if ((double.Parse(fromMonth_tbx.Text, CultureInfo.InvariantCulture) > 12))
                {
                    fromMonth_tbx.Text = "12";

                }
                if ((double.Parse(fromMonth_tbx.Text, CultureInfo.InvariantCulture) > (double.Parse(toMonth_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    fromMonth_tbx.Text = toMonth_tbx.Text;
                }

            }
            catch (Exception fromMonth_exc)
            {
                MessageBox.Show(fromMonth_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void toMonth_tbx_Leave(object sender, EventArgs e)
        {
            try
            {
                if (toMonth_tbx.Text == "" || (double.Parse(toMonth_tbx.Text, CultureInfo.InvariantCulture) > 12))
                {
                    toMonth_tbx.Text = "12";
                }
                if ((double.Parse(toMonth_tbx.Text, CultureInfo.InvariantCulture) < 1))
                {
                    toMonth_tbx.Text = "1";

                }
                if ((double.Parse(toMonth_tbx.Text, CultureInfo.InvariantCulture) < (double.Parse(fromMonth_tbx.Text, CultureInfo.InvariantCulture))))
                {
                    toMonth_tbx.Text = fromMonth_tbx.Text;
                }
            }
            catch (Exception toMonth_exc)
            {
                MessageBox.Show(toMonth_exc.Message, "", MessageBoxButtons.OK); ;
            }
        }

        private void Cyclone_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCyclones();
            SelByLat();
            SelByLon();
            SelByMonth();
            SelBySeason();
            Sort();
            IdNorm();
            Map map = new Map(cyclones);
            map.ShowDialog();
        }
    }
}
