using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //Create a menu that will retrieve data from the Dog API
            //https://dog.ceo/dog-api/

            //list all dogs breeds
            //https://dog.ceo/api/breeds/list/all

            //list all sub-breeds for a breed
            //https://dog.ceo/api/breed/hound/list

            //list random image for random breed
            //https://dog.ceo/api/breeds/image/random

            //list random image for a breed
            //https://dog.ceo/api/breed/hound/images/random

            //list image for a sub-breed
            //https://dog.ceo/api/breed/hound/images
            Console.WriteLine("Dogs API Client");


            // var keepGoing = true;
            // while (keepGoing)
            // {


            // }

            var client = new HttpClient();

            var responseAsString = await client.GetStringAsync("https://dog.ceo/api/breeds/list/all");

            Console.WriteLine(responseAsString);
        }
    }
}
