using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.DbEntities.Attachments;
using Models.DbEntities.Registration;

namespace Models.DbEntities.Hospitals;

public class Hospital : BaseEntity
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public int UserId { get; set; }

    public List<Media> MediaList { get; set; }

    public double Lat { get; set; }

    public double Long { get; set; }
    [JsonIgnore]
    public IEnumerable<Register> Register { get; set; }
}