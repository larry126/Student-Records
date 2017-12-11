using System;
using System.Data.Entity;

namespace CDStore
{
    public class CustomInitializer : DropCreateDatabaseAlways<CDStoreDbContext>
    {
        protected override void Seed(CDStoreDbContext context)
        {
            var fb = CreateArtist(context, "Fred Bates");
            var mo = CreateArtist(context, "Maria Okello");
            var bh = CreateArtist(context, "Bobby Harris");
            var jm = CreateArtist(context, "Jo Morris");
            var jj = CreateArtist(context, "JJ");
            var rap = CreateArtist(context, "Rapport");

            var waterfall = CreateSong(context, "Waterfall", jj, "Americana");
            var shakeIt = CreateSong(context, "Shake it", fb, "Heavy Metal");
            var comeAway = CreateSong(context, "Come Away", bh, "Americana");
            var volcano = CreateSong(context, "Volcano", mo, "Art Pop");
            var complicatedGame = CreateSong(context, "Complicated Game", jj, "Americana");
            var ghostTown = CreateSong(context, "Ghost Town", fb, "Heavy Metal");
            var gentleWaves = CreateSong(context, "Gentle Waves", mo, "Art Pop");
            var rightHere = CreateSong(context, "Right Here", mo, "Art Pop");
            var clouds = CreateSong(context, "Clouds", jm, "Art Pop");
            var sheetSteel = CreateSong(context, "Sheet Steel", rap, "Heavy Metal");
            var hereWithYou = CreateSong(context, "Here with you", bh, "Art Pop");
        }

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
}

