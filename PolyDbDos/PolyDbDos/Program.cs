using System;

namespace PolyDb
{
    public abstract class DbConnection
    {
        private string ConnectionString;
        public TimeSpan Timeout;

        private bool validateConnectionString(string stringToValidate)
        {
            if(stringToValidate == null)
            {
                throw new System.InvalidOperationException("Connection String cannot be null");
                //return false;
            } else if (stringToValidate == "")
            {
                throw new System.InvalidOperationException("Connection String cannot be empty");
                //return false;
            } else
            {
                return true;
            }
        }

        public DbConnection(string useThisConnectionString)
        {
            var validate = validateConnectionString(useThisConnectionString);
            Console.WriteLine(validate);
            //have some sort of thrown exception if vCS returns false
            if (validate == true)
            {
                ConnectionString = useThisConnectionString;
            }
        }

        public abstract void Opening();
        public abstract void Opening(int seconds);
        public abstract void Closing();
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string useThisConnectionString) : base(useThisConnectionString)
        {

        }

        public override void Opening()
        {
            //default timeout
            Console.WriteLine("Opening SQL Database");
        }

        public override void Opening(int seconds)
        {
            //something about timeing out later
            Timeout = TimeSpan.FromSeconds(seconds);
            Console.WriteLine("Opening SQL Database; timeout after {0} seconds", seconds);
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
            //Console.WriteLine("Hello World!");
            var timeTest = new TimeSpan(5, 6, 22);
            Console.WriteLine(timeTest.ToString());
            //string stringTest = "abc";
            //Console.WriteLine(stringTest);

            var sql = new SqlConnection("mssql://user:pass@10.0.0.14:1234/dbname");
            //var sql = new SqlConnection("");
            //var sql = new SqlConnection(null);
            // optional second parameter (perhaps hash); 
            sql.Opening();
            sql.Opening(2);
            // required or option paramter: connection timeout, 2 sec maybe (have reasonable default value, then let user also optionally define their own)
        }
    }
}
