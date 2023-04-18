using System;
using System.Collections.Generic;
using Models.DbEntities.Attachments;

namespace Models.DbEntities.Post;

public class Blog : BaseEntity
{
    public string Content { get; set; }
    
    public string Title { get; set; }
    
    public string Avatar { get; set; }

    public string Description {get;set;}

    public int ViewCount {get;set;}
    
    public List<Media> Media { get; set; }
    
    public DateTime PublicTime { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public IEnumerable<BlogTag> BlogTags { get; set; } = new List<BlogTag>();

}