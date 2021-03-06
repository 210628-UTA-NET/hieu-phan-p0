using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SSDModel
{
    public class Inventories{
        private int _id;
        private int _storeFrontId;
        private int _productId;
        private int _quantity;


        public Inventories()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public int StoreFrontId { get => _storeFrontId; set => _storeFrontId = value; }
        public int ProductId { get => _productId; set => _productId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public override string ToString()
        {
            return $"ID: {Id} ||| Store Front Id: {StoreFrontId} ||| Product Id: {ProductId} ||| Quantity: {Quantity}";
        }

        
        
    }
}
