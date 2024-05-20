using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsPresentation;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;
namespace cyclone
{
    public partial class Map : Form
    {
        List<Cyclones> cyclones;
        private Random rnd = new Random();

        public Map(List<Cyclones> cyclones)
        {
            InitializeComponent();
            this.cyclones = cyclones;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

            gmap.Height = this.Height;
            gmap.Width = this.Width;
            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание правой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButtons.Left;

            gmap.GrayScaleMode = true;

            // Все маркеры будут показаны
            gmap.MarkersEnabled = true;
            // Максимальное приближение
            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 1;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;
            // Разрешение полигонов
            gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 5;
            gmap.BorderStyle = BorderStyle.FixedSingle;
            // Изменение размеров
            //gmap.Dock = DockStyle.Fill;

            // Чья карта используется
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;

            // Загрузка этой точки на карте
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(62, 129);

            //// Создаём новый список маркеров
            //GMapOverlay markersOverlay = new GMapOverlay("markers");

            //// Инициализация красного маркера с указанием его коордиант
            //List<GMarkerGoogle> marker = new List<GMarkerGoogle>();
            //for (int i = 0; i < cyclones.Count; i++)
            //{
            //    marker.Add(new GMarkerGoogle(new PointLatLng(cyclones[i].lat, cyclones[i].lon), GMarkerGoogleType.blue_dot));

            //    marker[i].ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker[i]);

            //    // Текст отображаемый с маркером
            //    marker[i].ToolTipText = $"{cyclones[i].year}/{cyclones[i].month}/{cyclones[i].day}  {cyclones[i].hour}:00 UTC";
            //}

            //// Добавляем маркер в список маркеров
            //for (int i = 0; i<marker.Count; i++)
            //{
            //    markersOverlay.Markers.Add(marker[i]);
            //}

            //gmap.Overlays.Add(markersOverlay);
            // Создание слоя для маркеров
            //GMapOverlay markersOverlay = new GMapOverlay("markers");

            //// Создание слоя для линий
            //GMapOverlay linesOverlay = new GMapOverlay("lines");

            //// Отображение циклонов на карте
            //foreach (var cyclone in cyclones)
            //{
            //    // Создание маркера для циклона
            //    GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(cyclone.lat, cyclone.lon), GMarkerGoogleType.red);
            //    markersOverlay.Markers.Add(marker);

            //    // Поиск других циклонов с таким же id

            //    var sameIdCyclones = cyclones.Where(c => c.id == cyclone.id);

            //    // Создание линии между циклонами с одинаковым id
            //    if (sameIdCyclones.Count() > 1)
            //    {
            //        List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();
            //        foreach (var sameCyclone in sameIdCyclones)
            //        {
            //            points.Add(new GMap.NET.PointLatLng(sameCyclone.lat, sameCyclone.lon));
            //        }
            //        GMap.NET.WindowsForms.GMapRoute route = new GMap.NET.WindowsForms.GMapRoute(points, $"Route {cyclone.id}");
            //        linesOverlay.Routes.Add(route);
            //    }
            //}


            //Создание слоя для маркеров
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            string hex = $"#{GetRandomHexString(6)}";
            string darkHex = DarkenHexColor(hex, 15);
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(hex);
            System.Drawing.Color darkCol = System.Drawing.ColorTranslator.FromHtml(darkHex);
            // Создание слоя для линий
            GMapOverlay linesOverlay = new GMapOverlay("lines");
            System.Drawing.Color randomColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            for (int i = 0; i < cyclones.Count; i++)
            {
               
               

                // Создание маркера для циклона
                GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(cyclones[i].lat, cyclones[i].lon), CreateCircleBitmap(4, randomColor));
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);

                // Текст отображаемый с маркером
                marker.ToolTipText = $"{cyclones[i].lat} {cyclones[i].lon} {hex} {darkHex}";
                markersOverlay.Markers.Add(marker);
                List < GMap.NET.WindowsForms.GMapRoute > routes = new List<GMap.NET.WindowsForms.GMapRoute>();

                // Поиск других циклонов с таким же id
                Cyclones sameIdCyclone = new Cyclones();
                bool same = false;
                if (i != cyclones.Count-1)
                {
                    if (cyclones[i + 1].CycloneId == cyclones[i].CycloneId)
                    {
                        sameIdCyclone = cyclones[i + 1];
                        same = true;
                    }
                }


                

                    if (same == true)
                    {
                       
                        if(GetDistance(cyclones[i].lat, cyclones[i].lon, sameIdCyclone.lat, sameIdCyclone.lon)<30000)
                        {
                        List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();
                        points.Add(new GMap.NET.PointLatLng(cyclones[i].lat, cyclones[i].lon));
                        points.Add(new GMap.NET.PointLatLng(sameIdCyclone.lat, sameIdCyclone.lon));
                        GMap.NET.WindowsForms.GMapRoute route = new GMap.NET.WindowsForms.GMapRoute(points, $"Route {cyclones[i].id}");
                        route.Stroke = new System.Drawing.Pen(System.Drawing.Color.FromArgb(200, randomColor), 2);

                        linesOverlay.Routes.Add(route);
                        }
                        else
                        {
                        if (cyclones[i].lon < 0)
                        {
                            List<GMap.NET.PointLatLng> points1 = new List<GMap.NET.PointLatLng>();
                            List<GMap.NET.PointLatLng> points2 = new List<GMap.NET.PointLatLng>();
                            points1.Add(new GMap.NET.PointLatLng(cyclones[i].lat, cyclones[i].lon));
                            points2.Add(new GMap.NET.PointLatLng(sameIdCyclone.lat, sameIdCyclone.lon));

                            double y = Math.Abs(cyclones[i].lat - sameIdCyclone.lat);
                            double x = Math.Abs(cyclones[i].lon - sameIdCyclone.lon);
                            double x0 = Math.Abs(-180 - cyclones[i].lon);
                            double y0 = (y * x0) / x;
                            points2.Add((new GMap.NET.PointLatLng(y0 + cyclones[i].lat, 180)));
                            points1.Add((new GMap.NET.PointLatLng(y0 + cyclones[i].lat, -180)));
                            GMap.NET.WindowsForms.GMapRoute route1 = new GMap.NET.WindowsForms.GMapRoute(points1, $"Route {cyclones[i].id}");
                            route1.Stroke = new System.Drawing.Pen(System.Drawing.Color.FromArgb(200, randomColor), 2);
                            GMap.NET.WindowsForms.GMapRoute route2 = new GMap.NET.WindowsForms.GMapRoute(points2, $"Route {cyclones[i].id}");
                            route2.Stroke = new System.Drawing.Pen(System.Drawing.Color.FromArgb(200, randomColor), 2);
                            linesOverlay.Routes.Add(route1);
                            linesOverlay.Routes.Add(route2);
                        }
                    }
                        

                    }
                    else
                    {
                        hex = $"#{GetRandomHexString(6)}";
                        darkHex = DarkenHexColor(hex, 10);
                        col = System.Drawing.ColorTranslator.FromHtml(hex);
                        darkCol = System.Drawing.ColorTranslator.FromHtml(darkHex);
                        randomColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        //MessageBox.Show(hex + darkHex);
                        // Создание слоя для линий
                    }
                
                
            }
          
            gmap.Overlays.Add(linesOverlay);
            
            
            gmap.Overlays.Add(markersOverlay);
            gmap.Show();
        }
       
        public static string GetRandomHexString(int length)
        {
            Random random = new Random();

            // Generate random bytes
            byte[] bytes = new byte[length / 2];
            random.NextBytes(bytes);

            // Convert bytes to hex string
            string hexString = BitConverter.ToString(bytes).Replace("-", "").Substring(0, length);

            return hexString;
        }
        public Bitmap CreateCircleBitmap(int diameter, System.Drawing.Color color)
        {
            Bitmap bitmap = new Bitmap(diameter, diameter);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (System.Drawing.Brush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, 0, 0, diameter, diameter);
                }
            }

            return bitmap;
        }
        public string DarkenHexColor(string hexColor, double percent)
        {
            System.Drawing.Color color = ColorTranslator.FromHtml(hexColor);

            double factor = 1 - percent / 100;
            int red = (int)Math.Round(color.R * factor);
            int green = (int)Math.Round(color.G * factor);
            int blue = (int)Math.Round(color.B * factor);

            red = Math.Max(0, red);
            green = Math.Max(0, green);
            blue = Math.Max(0, blue);

            System.Drawing.Color darkenedColor = System.Drawing.Color.FromArgb(red, green, blue);

            return ColorTranslator.ToHtml(darkenedColor);
        }
        public double GetDistance(double lat1, double lon1, double lat2, double lon2) 
        {
            double a = Math.Abs(lon1 - lon2);
            double b = Math.Abs(lat1 - lat2);
            double c = Math.Sqrt(a * a + b * b);
            return c * 111.19492664138056;
        }
        private void gmap_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    var point = gmap.FromLocalToLatLng(e.X, e.Y);
            //    double lat = point.Lat;
            //    double lon = point.Lng;
            //    //this the the values of latitude in double when you click 
            //    double newPointLat = lat;
            //    //this the the values of longitude in double when you click 
            //    double newPointLong = lon;
            //    MessageBox.Show($"{lat} {lon}");
            //}
            //MessageBox.Show("ЗАЛУПА");
        }
        
    }
}
