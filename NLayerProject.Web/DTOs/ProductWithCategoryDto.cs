using NLayerProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public Category Category{ get; set; }
    }
}
