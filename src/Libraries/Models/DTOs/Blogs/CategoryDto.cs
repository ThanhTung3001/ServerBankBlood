

using Models.DbEntities;

namespace Models.DTOs.Blogs
{

    public class CategoryDto:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Avatar { get; set; }
    }
}