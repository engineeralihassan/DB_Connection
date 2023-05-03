namespace DB_Connection
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string standard { get; set; }
        public string section { get; set; }

        public Item() { }
        public Item(int id, string name, string standard, string section)
        {
            this.id = id;
            this.name = name;
            this.standard = standard;
            this.section = section;

        }

    }
}
