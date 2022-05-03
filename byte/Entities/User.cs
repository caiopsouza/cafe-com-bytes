namespace Take.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public ICollection<Rate> Rates { get; set; }

        private User()
        {
            Gender = null!;
            Occupation = null!;
            Rates = null!;
        }

        public User(int age, string gender, string occupation)
        {
            Age = age;
            Gender = gender;
            Occupation = occupation;
            Rates = new List<Rate>();
        }
    }
}
