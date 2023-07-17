namespace GameApi.Models
{
    /// <summary>
    /// Игра
    /// </summary>
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DevStudio { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
