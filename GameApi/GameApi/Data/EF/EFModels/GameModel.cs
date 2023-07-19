
namespace GameApi.Data.EF.EFModels
{
    /// <summary>
    /// Игра
    /// </summary>
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DevStudio { get; set; }
        public List<GenreModel> Genres { get; set; }
    }
}
