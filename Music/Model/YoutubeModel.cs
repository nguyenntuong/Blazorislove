using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Model
{
    public class YoutubeModel
    {
        [Required]
        [RegularExpression(@"^(http(s)??\:\/\/)?(www\.)?((youtube\.com\/watch\?v=)|(youtu.be\/))([a-zA-Z0-9\-_])+", ErrorMessage = "This isn't Youtube link")]
        public string Url { get; set; }

        public List<MusicInforModel> Result { get; set; } = new List<MusicInforModel>();

        public MusicInforModel Current { get; set; }
    }
}
