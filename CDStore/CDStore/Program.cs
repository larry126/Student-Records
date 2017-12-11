using System;
using System.Linq;

namespace CDStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CDStoreDbContext();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\n\nEnter 1 to add an Artist \n2 to List Artists \n3 Find artist\n9 to Quit : ");
                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddArtist(context);
                        break;
                    case '2':
                        ListArtists(context);
                        break;
                    case '3':
                        FindArtist(context);
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                }
            }
        }

        private static void FindArtist(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Artist's name: ");
            var name = Console.ReadLine();
            var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
            Console.WriteLine("Artist: " + artist.Name);
        }

        private static void ListArtists(CDStoreDbContext context)
        {
            foreach (Artist a in context.Artists)
            {
                Console.WriteLine(a.Name + " " + a.ArtistId);
            }
            Console.WriteLine();
        }

        private static void AddArtist(CDStoreDbContext context)
        {
            Console.Write("Enter name of new Artist: ");
            string name = Console.ReadLine();
            Artist a = new Artist() { Name = name };
            Console.WriteLine("Saving ...");
            context.Artists.Add(a);
            context.SaveChanges();
        }
    }
}
