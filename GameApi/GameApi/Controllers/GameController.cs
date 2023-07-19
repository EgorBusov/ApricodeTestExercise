using GameApi.Data.EF.EFModels;
using GameApi.Models;
using GameApi.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameDataService _gameDataService;

        public GameController(IGameDataService gameDataService) 
        {
            _gameDataService = gameDataService;
        }

        /// <summary>
        /// Получение списка игр
        /// </summary>
        /// <returns></returns>
        [Route("GetGames")]
        [HttpGet]
        public List<Game> GetGames()
        {
            return _gameDataService.GetGames();
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [Route("GetGamesByGenre/{genre}")]
        [HttpGet("{genre}")]
        public List<Game> GetGamesByGenre(string genre)
        {
            return _gameDataService.GetGamesByGenre(genre);
        }

        /// <summary>
        /// Добавление новой игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [Route("AddGame")]
        [HttpPost]
        public IActionResult AddGame([FromBody] Game game)
        {
            if (!ValidateGameModelForAdd(game))
            {
                return BadRequest("Данные не валидны.\nПроверьте правильность введенных данных");
            }

            bool check = _gameDataService.AddGame(game);

            if(!check)
            {
                return BadRequest("Что-то пошло не так");
            }

            return Ok("Информация о игре добавлена");
        }

        [Route("UpdateGame")]
        [HttpPut]
        public IActionResult UpdateGame([FromBody] Game game)
        {
            if (!ValidateGameModelForUpdate(game))
            {
                return BadRequest("Данные не валидны.\nПроверьте правильность введенных данных");
            }

            bool check = _gameDataService.UpdateGame(game);

            if (!check)
            {
                return BadRequest("Что-то пошло не так");
            }

            return Ok("Информация о игре изменена");
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteGame/{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id не указан");
            }

            bool check = _gameDataService.DeleteGame(id);

            if (!check)
            {
                return BadRequest("Что-то пошло не так");
            }

            return Ok("Информация о игре удалена");
        }

        /// <summary>
        /// Валидация модели при добавлении
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private bool ValidateGameModelForAdd(Game game)
        {
            if (game == null)
            {
                return false;
            }

            if (game.Name == null || game.DevStudio == null || 
                game.Genres == null || game.Genres.Count == 0) 
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация модели при редактировании
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private bool ValidateGameModelForUpdate(Game game)
        {
            if(!ValidateGameModelForAdd(game)) 
            {
                return false;
            }

            if(game.Id == 0)
            {
                return false;
            }

            return true;
        }
    }
}
