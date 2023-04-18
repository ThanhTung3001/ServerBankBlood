namespace Models.DTOs.Blogs
{
    public class BlogTagDto: DbEntities.BaseEntity
    {

        public int BlogId { get; set; }
        public BlogDto Blog { get; set; }

        public int TagId { get; set; }

        public TagDto Tag { get; set; }

    }
}