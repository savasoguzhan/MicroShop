using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Dto.CatologDtos.ProductImagesDtos
{
    public class ResultProductImageDto
    {
        public string ProductImagesID { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }

        public string ProductID { get; set; }
    }
}
