using System.Reflection.Metadata.Ecma335;

namespace MicroShop.Catalog.Entities
{
    public class SpecialOffer
    {
        public string SpecialOfferId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
