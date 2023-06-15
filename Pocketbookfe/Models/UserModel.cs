using Newtonsoft.Json;
using Pocketbookfe.Shared;

namespace pocketbookfe.Models
{
    public class UserModel
{
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool Admin_role { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreationDate { get; set;}
        public DateTime? UpdateDate { get; set;}
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
        public List<NoteModel> Notes { get; set; } = new List<NoteModel>();
}
}
