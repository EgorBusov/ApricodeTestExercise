using GameApi.Models;
using GameApi.Services.ServiceInterfaces;

namespace GameApi.Services
{
    /// <summary>
    /// Работа с бд с помощью EF
    /// </summary>
    public class GameDataEFService : IGameDataService
    {
        public bool AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
