using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkCast.Entities
{
    [Table("Command")]
    public class Command
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string CommandString { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EnqueueTime { get; set; }
        public DateTime? DequeueTime { get; set; }
        public bool Complete { get; set; }
    }
}