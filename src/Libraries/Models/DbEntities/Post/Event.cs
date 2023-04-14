using System;
using System.Collections.Generic;
using Models.DbEntities.Attachments;

namespace Models.DbEntities.Post;

public class Event : BaseEntity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Avatar { get; set; }
    
    public List<Media> Media { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime FinishTime { get; set; }
    
    public IEnumerable<EventTag> EventTags { get; set; }
}