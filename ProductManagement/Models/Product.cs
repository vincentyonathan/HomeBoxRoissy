using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string supplier { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
    }
}