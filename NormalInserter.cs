using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImdbClasses
{
    public class NormalInserter : IInserter
    {
        public void InsertData(SqlConnection sqlConn, List<Title> titles)
        {
            int i = 0;
            Console.WriteLine("Working");
            foreach (Title title in titles)
            {
                SqlCommand sqlComm = new SqlCommand("" +
                        "INSERT INTO [dbo].[Titles]" +
                        "([tconst],[titleType],[primaryTitle],[originalTitle]" +
                        ",[isAdult],[startYear],[endYear],[runTimeMinutes], [genres])" +
                        "VALUES " +
                        $"('{title.tconst}'," +
                        $"'{title.titleType}'," +
                        $"'{title.primaryTitle.Replace("'", "''")}'," +
                        $"'{title.originalTitle.Replace("'", "''")}'," +
                        $"'{title.isAdult}'," +
                        $"{CheckIntForNull(title.startYear)}," +
                        $"{CheckIntForNull(title.endYear)}," +
                        $"{CheckIntForNull(title.runTimeMinutes)}," +
                        $"'{title.genres}')"
                        , sqlConn);
                try
                {
                    sqlComm.ExecuteNonQuery();
                    i++;
                    if (i % 100000 == 0)
                    {
                        Console.WriteLine($"Progress {i}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void InsertData2(SqlConnection sqlConn, List<Crew> crews)
        {
            int i = 0;
            foreach (Crew crew in crews)
            {
                SqlCommand sqlComm2 = new SqlCommand("" +
                        "INSERT INTO [dbo].[TitleCrew]" +
                        "([tconst],[directors],[writers]) " +
                        "VALUES " +
                        $"('{crew.tconst}'," +
                        $"'{crew.directors}'," +
                        $"'{crew.writers}')"
                        , sqlConn);
                try
                {
                    sqlComm2.ExecuteNonQuery();
                    i++;
                    if (i % 100000 == 0)
                    {
                        Console.WriteLine($"Progress {i}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(sqlComm2.CommandText);
                }
            }
        }
        public void InsertData3(SqlConnection sqlConn, List<Name> names)
        {
            int i = 0;
            string message = "";
            foreach (Name name in names)
            {

                SqlCommand sqlComm3 = new SqlCommand("" +
                        "INSERT INTO [dbo].[Names]" +
                        "([nconst],[primaryName],[birthYear],[deathYear],[primaryProfession],[knownForTitles]) " +
                        "VALUES " +
                        $"('{name.nconst}'," +
                        $"'{name.primaryName.Replace("'", "''")}'," +
                        $"{CheckIntForNull(name.deathYear)}," +
                        $"{CheckIntForNull(name.deathYear)}," +
                        $"'{name.primaryProfession}'," +
                        $"'{name.knownForTitles}')"
                        , sqlConn);
                try
                {
                    i++;
                    if (i % 100000 == 0)
                    {
                        Console.WriteLine($"Progress {i}");
                    }
                    sqlComm3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    message = ex.Message + sqlComm3.CommandText;
                    Console.WriteLine(ex.Message + sqlComm3.CommandText);
                }
            }
            Console.WriteLine(message);
        }


        public string CheckIntForNull(int? input)
        {
            if (input == null)
            {
                return "NULL";
            }
            else
            {
                return "" + input;
            }
        }
    }
}
