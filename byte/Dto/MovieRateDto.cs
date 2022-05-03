namespace Take.Dto
{
    public class MovieRateDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Uri? Uri { get; set; }

        public double Rate { get; set; }

        public int Votes { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;
    }
}
