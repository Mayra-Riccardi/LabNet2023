using Practica4.LQ.Data;
using Practica4.LQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LQ.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public ProductsLogic() : base(){ }

        public List<Products> ProductsWithNoStock()
        {
            var productsWithNoStock = _context.Products
                .Where(p => p.UnitsInStock == 0)
                .ToList();

            return productsWithNoStock;
        }

        public List<Products> ProductsWithStock()
        {
            var query = from product in _context.Products
                        where product.UnitsInStock > 0 && product.UnitPrice > 3
                        select product;

            return query.ToList();
        }

        public Products FirsProductOrNull(int productID)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public string GetProductId(int productID)
        {
            var product = FirsProductOrNull(productID);

            if (product != null)
            {
                return $"Product ID: {product.ProductID} - Product Name: {product.ProductName} - Unit Price: {product.UnitPrice} - Units In Stock: {product.UnitsInStock}";
            }
            else
            {
                return "Product with ID 789 not found.";
            }
        }//Pruebo esto para evitar hacer validaciones en program

        public List<Products> GetProductsOrderedByName()
        {
            var productsOrderedByName = _context.Products.OrderBy(p => p.ProductName).ToList();
            return productsOrderedByName;
        }

        public List<Products> GetProductsOrderedByUnitsInStockDesc()
        {
            var query = from product in _context.Products
                        orderby product.UnitsInStock descending
                        select product;

            var productsOrderedByStock = query.ToList();
            return productsOrderedByStock;
        }

        public Products GetFirstProduct()
        {
            var firstProduct = _context.Products.FirstOrDefault();
            if (firstProduct == null)
            {
                throw new Exception("No products found.");
            }
            return firstProduct;
        }
    }
}
