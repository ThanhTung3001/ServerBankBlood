using Models.Enums;

namespace Models.DbEntities.Attachments;

public class Media : BaseEntity
{
    public string FileName { get; set; }
    
    public string Path { get; set; }
    
    public FileType Type { get; set; }
    
    public int UserId { get; set; }
    
}