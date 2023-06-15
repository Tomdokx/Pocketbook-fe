using Newtonsoft.Json;
using Pocketbookfe.Shared;

namespace pocketbookfe.Models
{
    public class NoteModel
{
	public int Id { get; set; }
	public string? Title {get;set;}
	public string Content {get;set;}
	public bool Deleted {get;set;}
    public DateTime? DeletedDate {get;set;}
    public DateTime? CreationDate {get;set;}
    public DateTime? UpdateDate {get;set;}
	public UserModel? Owner { get; set; }
	public TaskModel? Assignment { get; set; }	
	}
}
