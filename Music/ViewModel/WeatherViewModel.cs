using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Model;

namespace Music.ViewModel
{
    public class WeatherViewModel
    {
        public Weather _Weather { get; set; }
        public bool onFetchData { get; set; } = false;
        public string Location { get; set; } = "";
        public string APPID { get; } = "9703824485f2947ef704251072320094";
        public string invalid { get; set; } = "";
    }
}
