using Practica4.LQ.Data;
using Practica4.LQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LQ.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public CategoriesLogic() : base() { }

        public List<string> DifferentsCategories()
        {
            var distinctCategories = _context.Products
                .Select(product => product.Categories.CategoryName)
                .Distinct()
                .ToList();

            return distinctCategories;
        }
    }
}
