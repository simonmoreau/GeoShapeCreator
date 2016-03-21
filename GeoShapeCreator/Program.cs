using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace GeoShapeCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path =  @"C:\Google Drive\05 - Travail\Code\RentFerret\CodesGéographiques\correspondance-code-insee-code-postal.csv";

            List<geo>  geos = GetAreas(path);
            List<Polygon> polygons = new List<Polygon>();

            foreach (geo g in geos)
            {
                if (g.geo_shape.Contains("MultiPolygon"))
                {
                    geo_shape_multiPolygon deserializedProduct = JsonConvert.DeserializeObject<geo_shape_multiPolygon>(g.geo_shape);
                    int polygonCount = 1;

                    foreach (List<List<double>> coordinates in deserializedProduct.coordinates.FirstOrDefault())
                    {
                        int point_order = 1;
                        foreach (List<double> coordinate in coordinates)
                        {
                            Polygon polygon = new Polygon();
                            polygon.code_insee = g.code_insee;
                            polygon.latitude = coordinate.FirstOrDefault();
                            polygon.longitude = coordinate.LastOrDefault();
                            polygon.polygon_count = polygonCount;
                            polygon.point_order = point_order;

                            polygons.Add(polygon);
                            point_order++;
                        }

                        polygonCount++;
                    }
                }
                else
                {
                    geo_shape_polygon deserializedProduct = JsonConvert.DeserializeObject<geo_shape_polygon>(g.geo_shape);

                    int polygonCount = 1;

                    int point_order = 1;
                    foreach (List<double> coordinate in deserializedProduct.coordinates.FirstOrDefault())
                    {
                        Polygon polygon = new Polygon();
                        polygon.code_insee = g.code_insee;
                        polygon.latitude = coordinate.FirstOrDefault();
                        polygon.longitude = coordinate.LastOrDefault();
                        polygon.polygon_count = polygonCount;
                        polygon.point_order = point_order;

                        polygons.Add(polygon);
                        point_order++;
                    }
                }
            }
        }

        static List<geo> GetAreas(string path)
        {
            List<geo> geos = new List<geo>();

            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.WillThrowOnMissingField = false;
                geos = csvReader.GetRecords<geo>().ToList();
            }

            return geos;
        }
    }
}
