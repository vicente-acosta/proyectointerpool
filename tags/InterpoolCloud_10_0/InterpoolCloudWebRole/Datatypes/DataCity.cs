﻿
namespace InterpoolCloudWebRole.Datatypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Class statement DataCity
    /// </summary>
    public class DataCity
    {
        public string name_city { get; set; }

        public string name_file_city { get; set; }

        public double latitud { get; set; }

        public double longitud { get; set; }
    }
}