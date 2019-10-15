using System;

namespace PolyDb
{
    public abstract class DbConnection
    {
        private string ConnectionString;
        private TimeSpan Timeout;

        private bool validateConnectionString(string stringToValidate)
        {
            if()
            {

            } else
            {

            }
        }

        public DbConnection(string useThisConnectionString)
        {
            //validateConnectionString(useThisConnectionString);
            //have some sort of thrown exception if vCS returns false
            ConnectionString = useThisConnectionString;
        }

        public abstract void Opening();
        public abstract void Closing();
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string useThisConnectionString) : base(useThisConnectionString)
        {

        }

        public override void Opening()
        {
            Console.WriteLine("Opening SQL Database");
        }

        public override void Closing()
        {
            Console.WriteLine("Closing SQL Database");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var timeTest = new TimeSpan(5, 6, 22);
            Console.WriteLine(timeTest.ToString());
            string stringTest = "abc";
            Console.WriteLine(stringTest);

            var sql = new SqlConnection("mssql://user:pass@10.0.0.14:1234/dbname"); 
            // optional second parameter (perhaps hash); 
            sql.Opening();
            // required or option paramter: connection timeout, 2 sec maybe (have reasonable default value, then let user also optionally define their own)
        }
    }
}
