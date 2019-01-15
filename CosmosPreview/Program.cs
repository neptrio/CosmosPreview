using CosmosPreview.Models;
using System;
using System.Linq;

namespace CosmosPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchroedingerContext())
            {
                context.Database.EnsureCreated();

                var cat = new Cat { CatId = 1, IsAlive = false };
                var box = new Box { BoxId = 1, Cat = cat };

                context.Boxes.Add(box);

                //Persistiert alle Änderungen im Context
                context.SaveChanges();

                var remoteBox = context.Boxes.First();
                Console.WriteLine(remoteBox.ToString());
                Console.ReadLine();
            }
        }
    }
}
