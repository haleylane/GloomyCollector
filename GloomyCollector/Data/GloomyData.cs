using System;
using System.Collections.Generic;
using GloomyCollector.Models;

namespace GloomyCollector.Data
{
    public class GloomyData
    {
        // store gloomys
        private static Dictionary<int, Gloomy> Gloomies = new Dictionary<int, Gloomy>();

        // add gloomys
        public static void Add(Gloomy newGloomy)
        {
            Gloomies.Add(newGloomy.Id, newGloomy);
        }
        // retreive gloomys
        public static IEnumerable<Gloomy> GetAll()
        {
            return Gloomies.Values;
        }
        // retrieve single gloomy
        public static Gloomy GetById(int Id)
        {
            return Gloomies[Id];
        }
        // remove gloomy
        public static void Remove(int id)
        {
            Gloomies.Remove(id);
        }
    }
}
