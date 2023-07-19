namespace GameApi.Data.EF.EFModels
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
