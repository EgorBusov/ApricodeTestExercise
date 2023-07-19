using GameApi.Data.EF;
using GameApi.Data.EF.EFModels;
using GameApi.Models;
using GameApi.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GameApi.Services
{
    /// <summary>
    /// Работа с бд с помощью EF
    /// </summary>
    public class GameDataEFService : IGameDataService
    {
        private readonly GameContext _gameContext;

        public GameDataEFService(GameContext gameContext) 
        {
            _gameContext = gameContext;
        }

        /// <summary>
        /// Добавление Игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddGame(Game game)
        {
            try
            {
                GameModel gameModel = MapToGameModel(game);

                _gameContext.Games.Add(gameModel);
                _gameContext.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление Игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteGame(int gameId)
        {
            try
            {
                GameModel model = _gameContext.Games.First(x => x.Id == gameId);

                _gameContext.Games.Remove(model);
                _gameContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получение полного списка игр
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Game> GetGames()
        {
            List<GameModel> games = _gameContext.Games.Include(x => x.Genres).ToList() ?? new List<GameModel>();

            return MapToGameCollection(games);
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Game> GetGamesByGenre(string genre)
        {
            List<GameModel> games = _gameContext.Games.Include(x => x.Genres)
                .Where(x => x.Genres.Any(g => g.Name == genre))
                .ToList() ?? new List<GameModel>();

            return MapToGameCollection(games);
        }

        /// <summary>
        /// Изменение игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateGame(Game game)
        {
            try
            {
                GameModel gameModel = MapToGameModel(game);
                GameModel editModel = _gameContext.Games.First(x => x.Id == game.Id);

                _gameContext.Games.Update(editModel);

                _gameContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Мапинг Коллекции для EF в коллекцию для контроллера
        /// </summary>
        /// <param name="gameModels"></param>
        /// <returns></returns>
        private List<Game> MapToGameCollection(List<GameModel> gameModels)
        {
            var games = new List<Game>();

            foreach (var gameModel in gameModels)
            {
                Game game = new Game()
                {
                    Id = gameModel.Id,
                    Name = gameModel.Name,
                    DevStudio = gameModel.DevStudio,
                    Genres = new List<Genre>()
                };

                foreach (var g in gameModel.Genres)
                {
                    Genre genre = new Genre()
                    {
                        Id = g.Id,
                        Name = g.Name
                    };

                    game.Genres.Add(genre);
                }

                games.Add(game);
            }

            return games;
        }

        /// <summary>
        /// Мапинг модели игры в модель для EF
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private GameModel MapToGameModel(Game game) 
        {
            var gameModel = new GameModel()
            {
                Id = game.Id,
                Name = game.Name,
                DevStudio = game.DevStudio,
                Genres = new List<GenreModel>()
            };

            foreach(var g in game.Genres)
            {
                GenreModel genre = new GenreModel()
                {
                    Id = g.Id,
                    Name = g.Name
                };

                gameModel.Genres.Add(genre);
            }

            return gameModel;
        }
    }
}
