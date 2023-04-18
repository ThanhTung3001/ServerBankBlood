using Models.DbEntities;
using Models.DbEntities.Post;
using System;
using System.Collections.Generic;

namespace Models.DTOs.Blogs
{
    public class BlogDto : BaseEntity
    {
        public string Content { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }
        public string Description { get; set; }

        public int ViewCount { get; set; }
        // public List<Media> Media { get; set; }
        public DateTime PublicTime { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<BlogTagDto> BlogTags { get; set; }

    }
}