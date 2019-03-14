using System;
using System.Data;
using System.Data.SqlServerCe;

namespace ConsoleApp7
{
    internal class Program
    {
        private static void Insert(string name)
        {
            try
            {
                SqlCeCommand _cmd;
                SqlCeConnection _con;
                _con = new SqlCeConnection(@"Data Source=C:\Users\jsasprec\source\repos\ConsoleApp7\db.sdf;Password=123");
                _con.Open();
                _cmd = new SqlCeCommand($"select * from [nameCollection]",_con);
                var _da = new SqlCeDataAdapter(_cmd);
                var _dt = new DataTable();
                _da.Fill(_dt);
                _cmd.ExecuteReader();
                var cnt = _dt.Rows.Count;
                cnt++;
                _cmd = new SqlCeCommand($"INSERT INTO [nameCollection]([name])VALUES('{name}')", _con);
                _cmd.ExecuteNonQuery();
                Console.WriteLine("You Successfully Inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void QueryAll()
        {
            try
            {
                SqlCeCommand _cmd;
                SqlCeConnection _con;
                _con = new SqlCeConnection(@"Data Source=C:\Users\jsasprec\source\repos\ConsoleApp7\db.sdf;Password=123");
                _con.Open();
                _cmd = new SqlCeCommand($"select * from [nameCollection]",_con);
                var _da = new SqlCeDataAdapter(_cmd);
                var _dt = new DataTable();
                _da.Fill(_dt);
                _cmd.ExecuteReader();
                foreach (DataRow item in _dt.Rows)
                {
                    Console.WriteLine($"Id:{item["id"].ToString()} name:{item["name"].ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Delete(int id)
        {
            try
            {
                SqlCeCommand _cmd;
                SqlCeConnection _con;
                _con = new SqlCeConnection(@"Data Source=C:\Users\jsasprec\source\repos\ConsoleApp7\db.sdf;Password=123");
                _con.Open();
                _cmd = new SqlCeCommand($"DELETE FROM [nameCollection] WHERE Id = {id}", _con);
                _cmd.ExecuteNonQuery();
                Console.WriteLine("You Successfully Deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void Update(string name,int id)
        {
            try
            {
                SqlCeCommand _cmd;
                SqlCeConnection _con;
                _con = new SqlCeConnection(@"Data Source=C:\Users\jsasprec\source\repos\ConsoleApp7\db.sdf;Password=123");
                _con.Open();
                _cmd = new SqlCeCommand($"UPDATE [nameCollection]  SET [name] = '{name}' WHERE Id = {id}", _con);
                _cmd.ExecuteNonQuery();
                Console.WriteLine("You Successfully Updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void Main()
        {            
            Console.WriteLine("Please input your name");
            Insert(Console.ReadLine());
            Console.WriteLine("Please insert your Crush Name");
            Insert(Console.ReadLine());
            Console.WriteLine("This are the list of name");
            QueryAll();
            Console.WriteLine("Please input id of the target to delete.");
            Delete(int.Parse(Console.ReadLine()));
            QueryAll();
            Console.WriteLine("Please input id of the target to update.");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input new name.");
            var name = Console.ReadLine();
            Update(name,id);
            QueryAll();
            Console.WriteLine("Press Any Key to Exit.");
            Console.ReadLine();
        }
    }
}