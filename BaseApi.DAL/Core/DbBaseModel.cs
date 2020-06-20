using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.DAL.Core
{
    public class DbBaseModel
    {
        [Key]
        [Required]
        [Column("Id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}