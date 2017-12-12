using System;
using System.Linq;
using System.Collections.Generic;

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
                Console.Write("\n\nEnter \n1 Add Artist \n2 to List Artists \n3 Find artist \n4 Add CD \n5 List CDs \n6 Find CD \n7 Add Song \n8 List Songs \n9 Quit : ");
                char key = Console.ReadLine()[0];
				Console.Write('\n');
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
					case '4':
						AddCD(context);
						break;
					case '5':
						ListCDs(context);
						break;
					case '6':
						FindCD(context);
						break;
					case '7':
						AddSong(context);
						break;
					case '8':
						ListSongs(context);
						break;
					case '9':
                        keepGoing = false;
                        break;
                }
            }
        }

		private static void AddCD(CDStoreDbContext context)
		{
			Console.WriteLine("Enter title of new CD: ");
			var cdTitle = Console.ReadLine();
			Console.Write("Enter Record Company of new CD: ");
			string RC = Console.ReadLine();
			Console.Write("Enter published date of the new CD (YYYY/MM/DD): ");
			string date = Console.ReadLine();
			DateTime PD = Convert.ToDateTime(date);
			List<Song> songs = new List<Song>();
			while (true)
			{
				Console.Write("Enter song title (Q to stop): ");
				string title = Console.ReadLine();
				if (title.ToLower() == "q")
				{
					break;
				}
				else
				{
					var song = context.Songs.FirstOrDefault(st => st.Title.Contains(title));
					songs.Add(song);
				}
				//moreSong = title.ToLower() == "q" ? false : true;
			}
			CD cd = new CD() { Title = cdTitle, RecordCompany = RC, Published = PD, Songs = songs};
			Console.WriteLine("Saving ...");
			context.CD.Add(cd);
			context.SaveChanges();
		}

		private static void ListSongs(CDStoreDbContext context)
		{
			foreach (Song s in context.Songs)
			{
				Console.WriteLine(s.Title + '\t' + s.MusicType + '\t' + s.Artist.Name);
			}
			Console.WriteLine();
		}

		private static void AddSong(CDStoreDbContext context)
		{
			Console.WriteLine("Enter Artist's name: ");
			var name = Console.ReadLine();
			var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
			Console.Write("Enter title of new song: ");
			string title = Console.ReadLine();
			Console.Write("Enter music type of new song: ");
			string musicType = Console.ReadLine();
			Song s = new Song() { Title = title, MusicType = musicType, Artist = artist };
			Console.WriteLine("Saving ...");
			context.Songs.Add(s);
			context.SaveChanges();
		}

		private static void FindCD(CDStoreDbContext context)
		{
			Console.WriteLine("Enter CD's title: ");
			var Title = Console.ReadLine();
			var CD = context.CD.FirstOrDefault(a => a.Title.Contains(Title));
			Console.WriteLine("CD Title: " + CD.Title);
			foreach (Song s in CD.Songs)
			{
				Console.WriteLine(s.Title + '\t' + s.Artist.Name);
			}
		}

		private static void ListCDs(CDStoreDbContext context)
		{
			foreach (CD c in context.CD)
			{
				Console.WriteLine(c.Title + " " + c.Id);
			}
			Console.WriteLine();
		}

		private static void FindArtist(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Artist's name: ");
            var name = Console.ReadLine();
            var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
            Console.WriteLine("Artist: " + artist.Name);
//			Console.WriteLine("Songs" + "\n" + "Title" + '\t' + "Music Type");
			foreach (Song s in artist.Songs)
			{
				Console.WriteLine(s.Title + '\t' + s.MusicType);
			}
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
