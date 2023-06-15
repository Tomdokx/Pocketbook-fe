using Newtonsoft.Json;
using Pocketbookfe.Shared;

namespace pocketbookfe.Models
{
    public class TaskModel
{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public UserModel Author { get; set; }
        public List<NoteModel> Notes { get; set; } = new List<NoteModel>();

		public override bool Equals(object? obj)
		{
			return obj is TaskModel model &&
				   Id == model.Id;
		}
	}
}
