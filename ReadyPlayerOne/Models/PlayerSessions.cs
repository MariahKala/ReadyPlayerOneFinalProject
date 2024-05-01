using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ReadyPlayerOne.Models
{
    public class PlayerSession
    {
        private const string PlayersKey = "myplayers";
        private const string CountKey = "playercount";
        private const string AlignKey = "align";

        private ISession session { get; set; }
        public PlayerSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyPlayers(List<Player> players)
        {
            session.SetObject(PlayersKey, players);
            session.SetInt32(CountKey, players.Count);
        }
        public List<Player> GetMyPlayers() =>
            session.GetObject<List<Player>>(PlayersKey) ?? new List<Player>();
        public int? GetMyPlayerCount() => session.GetInt32(CountKey);

        public void SetActiveAlign(string activeAlign) =>
            session.SetString(AlignKey, activeAlign);
        public string GetActiveAlign() =>
            session.GetString(AlignKey) ?? string.Empty;

        public void RemoveMyPlayers(){
            session.Remove(PlayersKey);
            session.Remove(CountKey);
        }
    }
}
