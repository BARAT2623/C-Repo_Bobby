namespace CollegeApp.Models
{
    public class CollegeRepository
    {
        public static List<student> Students { get; set; } = new List<student>
            {
                new student { Id = 1, Name = "John Doe", Email = "john@gmail.com" },
                new student { Id = 2, Name = "Jane Smith", Email = "jane@gmail.com"},
                new student { Id = 3, Name = "bobby", Email="bobby@gmail.com"}
            };


    }
}

  