using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetgoUploadBot
{
    internal class product
    {
        public string category;
        public string price;
        public string title;
        public string filePath;
        public string description;
        public List<string> images = new List<string>();
        public Color filigrafRenk;
        public string filigranMetin;
        public int filigranBoyut;
        public List<string> sehirler = new List<string>();
        public product()
        {

        }
    }
}
