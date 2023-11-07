using System.Data.SqlClient;

namespace ImdbClasses
{
    public interface IInserter
    {
        void InsertData(SqlConnection sqlConn, List<Title> titles);
    }
}
