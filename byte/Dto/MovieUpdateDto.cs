namespace Take.Dto
{
    public class MovieUpdateDto
    {
        public string Name { get; set; } = null!;

        public Uri? Uri { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;
    }
}
