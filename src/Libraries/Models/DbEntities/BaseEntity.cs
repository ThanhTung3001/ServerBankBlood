using System;

namespace Models.DbEntities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        
        public string CreateBy { get; set; }
        
        public string UpdateBy { get; set; }
        
        public DateTime UpdateTime { get; init; } = DateTime.Now;
        public DateTime CreateUTC { get; set; }
    }
}
