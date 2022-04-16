using BookKeepingApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Models
{
    public class ReconcilationHeadType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public HeadEnum Head { get; set; }
        [Display(Name = "Type Name")]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
