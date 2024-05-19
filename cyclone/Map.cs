using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace cyclone
{
    public partial class Map : Form
    {
        List<Cyclones> cyclones;
        public Map(List<Cyclones> cyclones)
        {
            InitializeComponent();
            this.cyclones = cyclones;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gmap.Size = this.Size;
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
            gmap.MinZoom = 2;
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
            gmap.Zoom = 4;

            // Изменение размеров
            // gmap.Dock = DockStyle.Fill;

            // Чья карта используется
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;

            // Загрузка этой точки на карте
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(62, 129);

            // Создаём новый список маркеров
            GMapOverlay markersOverlay = new GMapOverlay("markers");

            // Инициализация красного маркера с указанием его коордиант
            List<GMarkerGoogle> marker = new List<GMarkerGoogle>();
            for (int i = 0; i < cyclones.Count; i++)
            {
                marker.Add(new GMarkerGoogle(new PointLatLng(cyclones[i].lat, cyclones[i].lon), GMarkerGoogleType.red));
                
                marker[i].ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker[i]);

                // Текст отображаемый с маркером
                marker[i].ToolTipText = $"{cyclones[i].year}/{cyclones[i].month}/{cyclones[i].day}  {cyclones[i].hour}:00 UTC";
            }
            
            // Добавляем маркер в список маркеров
            for (int i = 0; i<marker.Count; i++)
            {
                markersOverlay.Markers.Add(marker[i]);
            }
          
            gmap.Overlays.Add(markersOverlay);

          
        }
    }
}
