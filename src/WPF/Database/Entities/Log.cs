using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Time { get; set; }
        public string Info { get; set; }

        [ForeignKey(nameof(Information))] public Guid? InformationId { get; set; }
    }
}