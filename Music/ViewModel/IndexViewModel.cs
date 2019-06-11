using Microsoft.AspNetCore.Components;
using Music.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Model;

namespace Music.ViewModel
{
    public class IndexViewModel
    {
        public bool isFind { get; set; } = false;
        public YoutubeModel exampleModel { get; set; } = new YoutubeModel();
    }
}
