using System;

namespace BaseApi.PAL.Core
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}