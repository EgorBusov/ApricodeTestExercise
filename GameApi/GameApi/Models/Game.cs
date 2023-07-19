using GameApi.Data.EF.EFModels;

namespace GameApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DevStudio { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
