using System;

namespace ConsoleApplication1 {

    internal class Program {

        public static void Main(string[] args) {
            var restApi = new RestApi("a9a7c79f1d86e52c69292f86d198736f");
            restApi.CityName = "gothenburg";
            restApi.ContryCode = "SE";


            if (!restApi.CanMakeRequest()) {
                Console.WriteLine("we can't make the request due to some variables not being asigned");

                TerminateProgram();
                return;
            }

            ApiDataResponse response = restApi.GetResonse();



            var rain = response.List[0].Rain;
            if (rain != null && rain.rainfallinthreehours > 0) {
                Console.WriteLine("You should bring a umbrella man!");
                Console.WriteLine($"it's going to rain {rain.rainfallinthreehours}mm");
            }
            else {
                Console.WriteLine("HARAMBRE DIED FOR OUR SINS!");
                Console.WriteLine("HARAMBRE DIED FOR OUR SINS!");
                Console.WriteLine("HARAMBRE DIED FOR OUR SINS!");
                Console.WriteLine("HARAMBRE DIED FOR OUR SINS!");
                Console.WriteLine("No rain today, !");
                TerminateProgram();
            }


            TerminateProgram();
        }


        public static void TerminateProgram() {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }

}