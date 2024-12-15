﻿namespace MicroShop.Catalog.Settings
{
    public class DatabaseSettings : IDataBaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImagesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }

    }
}
