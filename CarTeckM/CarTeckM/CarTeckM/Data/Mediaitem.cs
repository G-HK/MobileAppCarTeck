using Android.Provider;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTeckM.Data
{
    public class Mediaitem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public byte[] itemData { get; set; }

        public MediaType mediaType { get; set; }


    }
}
