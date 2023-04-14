using System.Collections.Generic;

namespace Models.DbEntities.Post;

public class Category : BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Avatar { get; set; }
    
    
    public List<Blog> Blogs { get; set; } 

}