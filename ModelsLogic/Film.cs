using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLogic
{
    public class Film
    {
        public string Title { get; set; }
        public Nullable<int> EpisodeID { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
    }
}
