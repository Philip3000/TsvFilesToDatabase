using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbClasses
{
    public class Crew
    {
        public Crew(string tconst, string directorsString, string writesString) {
            this.tconst = tconst;
            directors = directorsString;
            writers = writesString;
        }
        public string tconst { get; set; }
        public string directors {  get; set; }
        public string writers { get; set; }

    }
}
