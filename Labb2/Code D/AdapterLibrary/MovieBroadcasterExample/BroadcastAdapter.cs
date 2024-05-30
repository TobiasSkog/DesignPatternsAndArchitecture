using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Library.MovieBroadcasterExample
{

    public class Broadcast : IBroadcaster
    {
        private readonly MovieRegistry _movieRegistry;
        private readonly ThirdPartyBroadcaster _thirdPartyBroadcaster;

        public Broadcast(MovieRegistry movieRegistry)
        {
            _movieRegistry = movieRegistry;
            _thirdPartyBroadcaster = new ThirdPartyBroadcaster();
        }

        public void BroadcastToExternalPartners()
        {
            string jsonMovies = ConvertRegistryMoviesToJson();

            _thirdPartyBroadcaster.Broadcast(jsonMovies);
        }

        private string ConvertRegistryMoviesToJson()
        {
            XDocument xmlMovies = _movieRegistry.GetAll();

            Console.WriteLine("Movies from internal registry...");
            Console.WriteLine(xmlMovies);

            IEnumerable<Movie> modelMovies = xmlMovies
                .Element("Movies")
                .Elements("Movie")
                .Select(movie => new Movie
                {
                    Name = movie.Attribute("Name").Value,
                    ReleaseDate = DateTime.Parse(movie.Attribute("ReleaseDate").Value),
                    Rating = Convert.ToDouble(movie.Attribute("Rating").Value),
                });

            string jsonMovies = JsonConvert.SerializeObject(modelMovies, Formatting.Indented);

            return jsonMovies;
        }
    }
}
