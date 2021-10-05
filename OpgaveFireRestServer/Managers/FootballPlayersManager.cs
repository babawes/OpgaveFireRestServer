using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpgaveFireRestServer.Models;

namespace OpgaveFireRestServer.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>();

        public List<FootballPlayer> GetAll(string substring)
        {
            if (substring != null || substring != "")
            {
                List<FootballPlayer> items = new List<FootballPlayer>(Data);
                return items.FindAll(item => item.Name.Contains(substring));
            }
            else
            {
                return new List<FootballPlayer>(Data);
            }
        }
        public FootballPlayer GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballPlayer = Data.Find(footballPlayer => footballPlayer.Id == id);
            if (footballPlayer == null) { return null; }

            Data.Remove(footballPlayer);
            return footballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer footballPlayer = Data.Find(footballPlayer => footballPlayer.Id == id);
            if (footballPlayer == null) return null;
            footballPlayer.Name = updates.Name;
            footballPlayer.Price = updates.Price;
            footballPlayer.ShirtNumber = updates.ShirtNumber;
            return footballPlayer;
        }
    }
}
