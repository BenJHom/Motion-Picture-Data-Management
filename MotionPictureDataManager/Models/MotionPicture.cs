using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataManager.Models
{
    public class MotionPicture
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int releaseYear { get; set; }
    }
}
