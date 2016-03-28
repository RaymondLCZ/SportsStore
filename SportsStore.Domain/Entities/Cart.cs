using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Product product, int quantity)
        {
            CartLine lineItem = lineCollection.Where(item => item.Product.ProductID == product.ProductID).FirstOrDefault();

            if (lineItem == null)
            {
                lineCollection.Add(new CartLine(product, quantity));
            }
            else { lineItem.Quantity += quantity; }
        }

        public void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(item => item.Product.ProductID == product.ProductID);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(item => item.Product.Price * item.Quantity);
        }

    }
}
