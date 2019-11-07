using System;
using System.Collections.Generic;
using System.Text;

namespace Alligator.Domain.Model
{
   public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        
    }
}
