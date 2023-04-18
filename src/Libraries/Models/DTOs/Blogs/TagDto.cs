using Models.DbEntities;

namespace Models.DTOs.Blogs
{
    public class TagDto:BaseEntity
    {
        public string TagName { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }
    }
}