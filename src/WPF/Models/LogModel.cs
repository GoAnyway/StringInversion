using System;

namespace Models
{
    public class LogModel : BaseModel
    {
        public Guid Id { get; set; }

        public DateTime Time { get; set; }
        public string Info { get; set; }
        public Guid? InformationId { get; set; }
    }
}