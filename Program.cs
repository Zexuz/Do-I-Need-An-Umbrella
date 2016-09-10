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


            if (response.List[0].Rain == null) {
                Console.WriteLine("No rain today!");
                TerminateProgram();
            }

            var rain = response.List[0].Rain;
            if (rain != null && rain.rainfallinthreehours > 0)
                Console.WriteLine("You should bring a umbrella man!");


            Console.WriteLine(response.List[0].Rain.rainfallinthreehours);

            TerminateProgram();
        }


        public static void TerminateProgram() {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }

}