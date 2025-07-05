using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyTracker.BusinessEntityComponent
{
    public class HobbyItemModel
    {
        public int Id { get; set; } // Auto-increment or unique
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int PersonalValue { get; set; }
        public int YearsToEstimate { get; set; }
        public decimal DepreciationRate { get; set; }
        public decimal DepreciatedPrice { get; set; }
        public string User { get; set; }
        public decimal ConvertedPrice { get; set; }


    }
}
