using OptipushFirebaseCommunicationApi;
using OptipushFirebaseCommunicationApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            OptipushBrand brand = new OptipushBrand();
            brand.DynamicLinkDomain = "bw4se.app.goo.gl";
            brand.WebApiKey = "AIzaSyCP0YJY5vxmxS5OR1nob7BkD8Qkdk5PPmE";
            OptipushApp app = new OptipushApp();
            app.PackageName = "com.optimove.sdk.optimovemobileclientfull";
            FirebaseInteractor firebaseInteractor = new FirebaseInteractor(brand, app);
            firebaseInteractor.CreateDynamicLink("test_screen", new Dictionary<string, object>
            {
                { "sale", "Free Rock" },
                { "price", 1000 }
            }, (uri, error) => 
            {
                if (error != null)
                    Console.WriteLine(error.Message);
                else
                    Console.WriteLine(uri.ToString());
            });
            Console.ReadKey();
        }
    }
}
