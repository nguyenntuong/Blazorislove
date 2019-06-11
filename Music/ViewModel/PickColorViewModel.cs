using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Music.ViewModel
{
    public class PickColorViewModel
    {
        private IJSRuntime _jsRuntime;
        public PickColorViewModel(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async void Init(Action callback)
        {
            Console.WriteLine("is there");
            string sR = await _jsRuntime.InvokeAsync<string>("getItem", "R");
            string sG = await _jsRuntime.InvokeAsync<string>("getItem", "G");
            string sB = await _jsRuntime.InvokeAsync<string>("getItem", "B");

            long.TryParse(sR, out long r);
            long.TryParse(sG, out long g);
            long.TryParse(sB, out long b);
            _R = r;
            _G = g;
            _B = b;
            callback?.Invoke();
        }
        private long _R=255;
        private long _G=0;
        private long _B=0;
        public long R {
            get => _R;
            set {
                _R = value;
                _jsRuntime.InvokeAsync<string>("setItem", "R",value);
            }
        }
        public long G {
            get =>_G;
            set
            {
                _G = value;
                _jsRuntime.InvokeAsync<string>("setItem", "G", value);
            }
        }
        public long B {
            get =>_B;
            set
            {
                _B = value;
                _jsRuntime.InvokeAsync<string>("setItem", "B", value);
            }
        }
        public Color currentColor {
            get => Color.FromArgb((byte)R, (byte)G, (byte)B); } 
        public Color FromRgb(long r,long g,long b)
        {
            return Color.FromArgb((byte)r, (byte)g, (byte)b);
        }
        public static String RGBConverter(System.Drawing.Color c)
        {            
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }
    }
}
