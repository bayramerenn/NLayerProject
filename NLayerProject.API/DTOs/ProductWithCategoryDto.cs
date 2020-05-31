using NLayerProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public Category Category{ get; set; }
    }
}
