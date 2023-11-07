using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImdbClasses
{
    public class Title
    {
        public Title(string? tconst, string titleType, string primaryTitle,
            string? originalTitle, bool isAdult, int? startYear, int? endYear,
            int? runTimeMinutes, string genresString)
        {
            this.tconst = tconst;
            this.titleType = titleType;
            this.primaryTitle = primaryTitle;
            this.originalTitle = originalTitle;
            this.isAdult = isAdult;
            this.startYear = startYear;
            this.endYear = endYear;
            this.runTimeMinutes = runTimeMinutes;
            genres = genresString;

        }

        public string? tconst { get; set; } // VARCHAR(10) PRIMARY KEY
        public string titleType { get; set; } // INT
        public string primaryTitle { get; set; } // VARCHAR(255) NOT NULL
        public string? originalTitle { get; set; } // VARCHAR(255)
        public bool isAdult { get; set; } // TINYINT NOT NULL
        public int? startYear { get; set; } // INT
        public int? endYear { get; set; } // INT
        public int? runTimeMinutes { get; set; }
        public string genres { get; set; }



    }
}