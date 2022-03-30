using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CougBites.Models
{
    public class Rating
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public string Description { get; set; }
        public double RatingNum { get; set; }
    }
}
