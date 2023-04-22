using System;
using System.Collections.Generic;
using Models.DbEntities;
using Models.DbEntities.Post;
using Models.DbEntities.User;

namespace Models.DTOs.Event;

public class EventDto : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Avatar { get; set; }



    public DateTime StartTime { get; set; }

    public DateTime FinishTime { get; set; }

    // public IEnumerable<EventTag> EventTags { get; set; }

    public IEnumerable<EventUserSubDto> EventUserSubs { get; set; }
}

public class EventUserSubDto
{
    public int UserInfoId { get; set; }
    public UserInfoDto userInfo { get; set; }
    public int EventId { get; set; }
    public EventDto Event { get; set; }
}