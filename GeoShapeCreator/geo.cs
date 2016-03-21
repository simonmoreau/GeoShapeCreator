using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoShapeCreator
{
    class geo
    {
        public string code_insee { get; set; }
        public string code_postal { get; set; }
        public string commune { get; set; }
        public string département { get; set; }
        public string région { get; set; }
        public string statut { get; set; }
        public string altitude_moyenne { get; set; }
        public string superficie { get; set; }
        public string population { get; set; }
        public string geo_point_2d { get; set; }
        public string geo_shape { get; set; }
        public string id_geogla { get; set; }
        public string code_commune { get; set; }
        public string code_canton { get; set; }
        public string code_arrondissement { get; set; }
        public string code_département { get; set; }
        public string code_région { get; set; }
    }

    class geo_shape_polygon
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
        //public List<List<List<List<double>>>> coordinates { get; set; }
    }

    class geo_shape_multiPolygon
    {
        public string type { get; set; }
        //public List<List<List<double>>> coordinates { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }

    class Polygon
    {
        public string code_insee { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int point_order { get; set; }
        public int polygon_count { get; set; }
    }
}
