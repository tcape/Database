using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class Product
	{
        public string Code { get; set;  }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string GetDisplayText() => Code + ", " + Price.ToString("c") + ", " + Description;

		public string GetDisplayText(string sep) => Code + sep + Price.ToString("c") + sep + Description;

	    public override bool Equals(object obj)
	    {
	        var product = obj as Product;

	        if (product != null)
	            return Code.Equals(product.Code, StringComparison.Ordinal) && Description.Equals(product.Description) && Price == product.Price;

	        return false;
	    }

	    public override int GetHashCode()
	    {
	        return 1;
	    }
	}
}
