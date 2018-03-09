﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerIcon.Model.BonanzaModel
{
    public class BonanzaRecord
    {
        public string id { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string shipping_type { get; set; }
        public int shipping_price { get; set; }
        public string shipping_carrier { get; set; }
        public string shipping_service { get; set; }
        public string shipping_package { get; set; }
        //public int worldwide_shipping_price { get; set; }
        //public string worldwide_shipping_type { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string brand { get; set; }
        public string size { get; set; }
        public string condition { get; set; }
        public string upc { get; set; }
        public string force_update { get; set; }
        public string MPN { get; set; }
        public string width { get; set; }
        public string traits { get; set; }
    }
}
