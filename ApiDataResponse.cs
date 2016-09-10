using System.Collections.Generic;

namespace ConsoleApplication1 {

    public class ApiDataResponse {

        public City City;

        public string Cod;
        public string Message;
        public int Cnt;

        public List<WeatherPoints> List;

    }


    public class City {

        public Coord Coord;
        public int Id;
        public string Name;
        public string Contry;

    }

    public class Coord {

        public double Lon;
        public double Lat;

    }

    public class WeatherPoints {

        public List<Weather> Weather;
        public Rain Rain;

    }


    public class Weather {

        public int Id;
        public string Main;
        public string Description;
        public string Icon;

    }

    public class Rain {

        public float rainfallinthreehours;

    }

}