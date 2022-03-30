using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CougBites.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}
