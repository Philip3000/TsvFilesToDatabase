// See https://aka.ms/new-console-template for more information
using ImdbClasses;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
//    System.IO.File.ReadLines(@"C:\IMDBFiles\data.tsv").Skip(1).Take(1000))
string ConnString = "server=localhost;database=IMDB;" +
            "user id=sa;password=hellothere;TrustServerCertificate=True";
List<Title> titles = new List<Title>();
List<Crew> crews = new List<Crew>();
List<Name> names = new List<Name>();
NormalInserter myInserter = null;

SqlConnection sqlConn = new SqlConnection(ConnString);
sqlConn.Open();







myInserter = new NormalInserter();
Console.WriteLine(myInserter);


DateTime before = DateTime.Now;
Console.WriteLine("Beginning with titles");
foreach (string line in
    System.IO.File.ReadLines
    (@"C:\IMDBFiles\data.tsv")
    .Skip(9557078).Take(442923))
{
    if (titles.Count % 1000000 == 0)
    {
        Console.WriteLine("It's progressing" + titles.Count);
    }
    string[] values = line.Split("\t");
    if (values.Length == 9)
    {
        titles.Add(new Title(
            values[0], values[1], values[2], values[3],
            ConvertToBool(values[4]), ConvertToInt(values[5]),
            ConvertToInt(values[6]), ConvertToInt(values[7]), values[8]
            ));
    } else
    {
        Console.WriteLine(values.Length);
    }
}

Console.WriteLine($"Beginning with crew titles was {titles.Count}");
foreach (string line in
    System.IO.File.ReadLines
    (@"C:\IMDBFiles\data2.tsv")
    .Skip(9500001).Take(500000))
{


    string[] values = line.Split("\t");
    if (values.Length == 3)
    {
        crews.Add(new Crew(
            values[0], values[1], values[2]));
    }

}
Console.WriteLine("It's progressing" + crews.Count);






Console.WriteLine(titles.Count);
if (myInserter != null)
{
    //Danger! Uncomment at own peril
    Console.WriteLine("Not null");
    //myInserter.InsertData(sqlConn, titles);
    //myInserter.InsertData2(sqlConn, crews);
    //myInserter.InsertData3(sqlConn, names);



}
Console.WriteLine("Beginning names");
foreach (string line in
    System.IO.File.ReadLines
    (@"C:\IMDBFiles\data3.tsv")
    .Skip(9500001).Take(500000))
{


    string[] values = line.Split("\t");
    if (values.Length == 6)
    {
        names.Add(new Name(
            values[0], values[1], ConvertToInt(values[2]),
            ConvertToInt(values[3]), values[4], values[5]
            ));
    }

}
Console.WriteLine("It's progressing" + names.Count);


DateTime after = DateTime.Now;

//Console.WriteLine("Tid: " + (after - before));


sqlConn.Close();



bool ConvertToBool(string input)
{
    if (input == "0")
    {
        return false;
    }
    else if (input == "1")
    {
        return true;
    }
    throw new ArgumentException(
        "Kolonne er ikke 0 eller 1, men " + input);
}



int? ConvertToInt(string input)
{
    if (input.ToLower() == @"\n")
    {
        return null;
    }
    else
    {
        return int.Parse(input);
    }
}

