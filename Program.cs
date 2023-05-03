using System.Data;
using System.Data.SqlClient;

namespace DB_Connection
{
    public class Program
    {
        public const string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog = test; Integrated Security = True";
        private static void InsertIntoDB(Item item)
        {
            string insertQuery = "INSERT INTO Tbl_2(id,name,standard,section) Values(@id,@name,@standard,@section)";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = item.name;
            cmd.Parameters.Add("@standard", SqlDbType.VarChar, 50).Value = item.standard;
            cmd.Parameters.Add("@section", SqlDbType.VarChar, 50).Value = item.section;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private static List<Item> GetData()
        {
            List<Item> items = new List<Item>();
            string query = "SELECT * FROM Tbl_2";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Item item = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                items.Add(item);
            }
            return items;
        }
        public static void UpdateRecord()
        {
            string name = Console.ReadLine();
            string query = "UPDATE Tbl_2 SET name = @name WHERE id = 12;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record is updated");


        }

        public static void PrintData(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.id} {item.name} {item.standard} {item.section}");
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //List<Item> items = new List<Item>()
            //{
            //    new Item(12,"Ali Hassan","BSSE-A",'A'),
            //    new Item(2,"Rana Rubaz","BSSE-B",'B'),
            //    new Item(3,"Ahsan Mughal","BSSE-A",'A'),
            //    new Item(4,"Ray Adnan","BSSE-B",'B'),
            //    new Item(5,"Hafsa Yousaf","BSSE-A",'A'),
            //    new Item(6,"Laiba Doll","BSSE-B",'B'),

            //};
            //foreach (Item item in items)
            //{
            //    InsertIntoDB(item);
            //}
            // Item item1 = new Item(14, "Amjad sabri", "BSSE-A", "A");
            // InsertIntoDB(item1);
            // List<Item> items = GetData();
            // PrintData(items);
            UpdateRecord();



        }


    }
}