using System.Collections.Generic;

namespace Models.DbEntities.Post;

public class Tag : BaseEntity
{
    public string TagName { get; set; }
    
    public string Description { get; set; }
    
    public string Color { get; set; }
    
    public IEnumerable<BlogTag> BlogTags { get; set; }
    
    public IEnumerable<EventTag> EventTags { get; set; }
}

public class BlogTag : BaseEntity
{
    public int BlogId { get; set; }
    public Blog  Blog { get; set; }
    
    public int TagId { get; set; }
    
    public Tag Tag { get; set; }
}

public class EventTag : BaseEntity
{
    public int EventId { get; set; }
    public Event  Event { get; set; }
    
    public int TagId { get; set; }
    
    public Tag Tag { get; set; }
}