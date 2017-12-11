using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CDStore
{
	public class CustomInitializer : DropCreateDatabaseAlways<CDStoreDbContext>
	{
		private Artist CreateArtist(CDStoreDbContext context, string name)
		{
			var a = new Artist() { Name = name };
			context.Artists.Add(a);
			context.SaveChanges();
			return a;
		}

		private Song CreateSong(CDStoreDbContext context, string title, Artist artist, string type)
		{
			var a = new Song() { Title = title, MusicType = type, Artist = artist };
			context.Songs.Add(a);
			context.SaveChanges();
			return a;
		}
	}

	public class CDStoreDbContext : DbContext
	{
		public CDStoreDbContext() : base("myConnectionString")
		{
			Database.SetInitializer(new CustomInitializer());
		}

		public DbSet<Artist> Artists { get; set; }
		public DbSet<Song> Songs { get; set; }
//		public DbSet<CD> CDs { get; set; }
	}
}
