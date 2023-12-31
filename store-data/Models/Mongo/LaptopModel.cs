﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace store_data.Models.Mongo
{
    public class LaptopModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public object ImgURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
