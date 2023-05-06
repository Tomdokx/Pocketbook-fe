namespace pocketbookfe.Models
{
    public class UserModel
{
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime? Deleted_Date { get; set; }

        public DateTime? Creation_Date { get; set;}

        public DateTime? Update_Date { get; set;}

        public List<TaskModel> Tasks { get; set; }
        public List<NoteModel> Notes { get; set; }
}
}
