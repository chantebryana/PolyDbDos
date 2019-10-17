using System;

namespace PolyDbDos
{
    public abstract class DbConnection
    {
        private string ConnectionString;
        private TimeSpan Timeout;

        public DbConnection(string userConnectionString)
        {
            Timeout = TimeSpan.FromSeconds(2); // default timeout interval
            var validate = validateConnectionString(userConnectionString);
            Console.WriteLine(validate);
            //have some sort of thrown exception if vCS returns false
            if (validate == true)
            {
                ConnectionString = userConnectionString;
            }
        }

        public DbConnection(string userConnectionString, int seconds)
            : this(userConnectionString)
        {
            Timeout = TimeSpan.FromSeconds(seconds); // user-defined timeout interval
        }

        private bool validateConnectionString(string stringToValidate)
        {
            if (stringToValidate == null)
            {
                throw new System.InvalidOperationException("Connection String cannot be null");
                //return false;
            }
            else if (stringToValidate == "")
            {
                throw new System.InvalidOperationException("Connection String cannot be empty");
                //return false;
            }
            else
            {
                return true;
            }
        }

        public abstract void Opening();
        public abstract void Opening(int seconds);
        public abstract void Closing();

        public void setTimespan(int seconds)
        {
            Timeout = TimeSpan.FromSeconds(seconds);
        }
    }

    public class DbCommand
    {
        private string instruction; 
        public DbCommand(string userInstruction)
        {
            //db command cannot be in valid state w/o having a connection. in constructor, pass dbconnection -- don't forget about empty / null
            if (userInstruction == null)
            {
                throw new System.InvalidOperationException("DB Command cannot be null");
            }
            instruction = userInstruction;
        }


        public void Execute(string userInstruction)
        {
            //opening
            Console.WriteLine("Running the following command: {0}", userInstruction);
            //closing
        }
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string userConnectionString) : base(userConnectionString)
        {

        }
        //add new constructor here
        public SqlConnection(string userConnectionString, int seconds) : base(userConnectionString, seconds)
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
            setTimespan(seconds);
            Console.WriteLine("Opening SQL Database; timeout after {0} seconds", seconds);
        }

        public override void Closing()
        {
            Console.WriteLine("Closing SQL Database");
        }
    }

    public class OracleConnection : DbConnection
    {
        public OracleConnection(string userConnectionString) : base(userConnectionString)
        {

        }
        //add new constructor here
        public OracleConnection(string userConnectionString, int seconds) : base(userConnectionString, seconds)
        {

        }

        public override void Opening()
        {
            //default timeout
            Console.WriteLine("Opening Oracle Database");
        }

        public override void Opening(int seconds)
        {
            //something about timeing out later
            setTimespan(seconds);
            Console.WriteLine("Opening Oracle Database; timeout after {0} seconds", seconds);
        }

        public override void Closing()
        {
            Console.WriteLine("Closing Oracle Database");
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

            //var sql = new SqlConnection("mssql://user:pass@10.0.0.14:1234/dbname");
            var sql = new SqlConnection("10.0.0.14", 4);
            //var sql = new SqlConnection("");
            //var sql = new SqlConnection(null);
            // optional second parameter (perhaps hash); 
            sql.Opening();
            sql.Opening(2);
            sql.Closing();
            // required or option paramter: connection timeout, 2 sec maybe (have reasonable default value, then let user also optionally define their own)
            //var oracle = new OracleConnection("10.0.0.14");
            var oracle = new OracleConnection("", 4);
            oracle.Opening();
            oracle.Closing();
        }
    }
}
