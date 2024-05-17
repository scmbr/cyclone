using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;
namespace cyclone
{
    public class Cyclones
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public string time { get; set; }
        public int id { get; set; }
        public int pid { get; set; }
        public double ptid { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string p_cent { get; set; }
        public string p_edge { get; set; }
        public int area { get; set; }
        public string radius { get; set; }
        public string depth { get; set; }
        public string p_grad { get; set; }
        public string DsqP { get; set; }
        public int type { get; set; }
        public int centers { get; set; }
        public int Ege { get; set; }
        public int Erg { get; set; }
        public int Ely {get;set;}
        public int Esp { get; set; }
        public int Emg { get; set; }
        public string Dp { get; set; }
        public string u { get; set; }
        public string v { get; set; }
        public string uv { get; set; }
        public string DpDt { get; set; }
        public string season { get; set; }
        public int CycloneId { get; set; }
        public Cyclones()
        {

        }
        public Cyclones(string year, string month, string day, string hour, string time, string id, string pid, string ptid, string x, string y, string lat, string lon, string p_cent, string p_edge, string area, string radius, string depth, string p_grad, string DsqP, string type, string centers, string Ege, string Erg, string Ely, string Esp, string Emg, string Dp, string u, string v, string uv, string DpDt) 
        {
            this.year = int.Parse(year);
            this.month = int.Parse(month);
            this.day = int.Parse(day);
            this.hour = int.Parse(hour);
            this.time = time;
            this.id = int.Parse(id);
            this.pid = int.Parse(pid);
            this.ptid = double.Parse(ptid, CultureInfo.InvariantCulture);
            this.x = int.Parse(x);
            this.y = int.Parse(y);
            this.lat = Math.Round(Convert.ToDouble(lat.Replace(".", ",")),2);
            this.lon = Math.Round(Convert.ToDouble(lon.Replace(".", ",")),2);
            this.p_cent = p_cent;
            this.p_edge = p_edge;
            this.area = int.Parse(area);
            this.radius = radius;
            this.depth = depth;
            this.p_grad = p_grad;
            this.type = int.Parse(type);
            this.centers = int.Parse(centers);
            this.Ege = int.Parse(Ege);
            this.Erg = int.Parse(Erg);
            this.Ely = int.Parse(Ely);
            this.Esp = int.Parse(Esp);
            this.Emg = int.Parse(Emg);
            this.Dp = Dp;
            this.u = u;
            this.v = v;
            this.uv = uv;
            this.DpDt = DpDt;
            if (month == "12" || month == "1" || month == "2")
            {
                season = "Зима";
            }
            if (month == "3" || month == "4" || month == "5")
            {
                season = "Весна";
            }
            if (month == "6" || month == "7" || month == "8")
            {
                season = "Лето";
            }
            if (month == "9" || month == "10" || month == "11")
            {
                season = "Осень";
            }
        }   
        public override string ToString()
        {
            string str = $"{year} {month} {day} {hour} {time} {id} {pid} {ptid} {x} {y} {lat} {lon} {p_cent} {p_edge} {area} {radius} {depth} {p_grad} {DsqP} {type} {centers} {Ege} {Erg} {Ely} {Esp} {Emg} {Dp} {u} {v} {uv} {DpDt}";
            return str;
        }

    }
}
