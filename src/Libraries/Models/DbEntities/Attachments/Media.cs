using System.Collections.Generic;
using Models.DbEntities.Registration;
using Models.Enums;

namespace Models.DbEntities.Attachments;

public class Media : BaseEntity
{
    public string FileName { get; set; }

    public string Path { get; set; }

    public FileType Type { get; set; }

    public int UserId { get; set; }

    public List<MediaRegister> registrations { get; set; } = new List<MediaRegister>();

}

public class MediaRegister : BaseEntity
{
    public int RegisterId { get; set; }

    public Register register { get; set; }

    public int MediaId { get; set; }

    public Media media { get; set; }
}