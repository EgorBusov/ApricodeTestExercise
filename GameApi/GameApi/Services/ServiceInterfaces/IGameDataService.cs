using GameApi.Data.EF.EFModels;
using GameApi.Models;

namespace GameApi.Services.ServiceInterfaces
{
    /// <summary>
    /// Работа с бд
    /// </summary>
    public interface IGameDataService
    {
        List<Game> GetGames();
        List<Game> GetGamesByGenre(string genre);
        bool AddGame(Game game);
        bool UpdateGame(Game game);
        bool DeleteGame(int gameId);
    }
}
