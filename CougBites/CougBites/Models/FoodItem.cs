using System;
using System.Collections.Generic;
using SQLite;

namespace CougBites.Models
{
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID   { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public List<int> DaysAvailable { get; set; }
        public List<int> TimesAvailable { get; set; }
        public string Picture { get; set; }

    }
}