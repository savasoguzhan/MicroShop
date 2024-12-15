﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroShop.Catalog.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureID { get; set; }

        public string FeatureName { get; set; }

        public string Icon { get; set; }
    }
}
