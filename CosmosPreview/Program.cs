using CosmosPreview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new SchroedingerContext())
            {
                await context.Database.EnsureCreatedAsync();

                var cat = new Cat { CatId = 1, IsAlive = false };
                var box = new Box { BoxId = 1, Cat = cat };

                await context.Boxes.AddAsync(box);

                //Persistiert alle Änderungen im Context
                await context.SaveChangesAsync();

                var remoteBox = context.Boxes.First();
                Console.WriteLine(remoteBox.ToString());
                Console.ReadLine();
            }
        }
    }
}
