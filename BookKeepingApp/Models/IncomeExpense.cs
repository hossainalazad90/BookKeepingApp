using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Models
{
    public class IncomeExpense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        [Display(Name ="Head Name")]
        public int IncomeExpenseHeadId { get; set; }  //Income or Expanse
        [DataType(DataType.Date)]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }
        public int Amount { get; set; }
        [ForeignKey("IncomeExpenseHeadId")]
        [Display(Name = "Head Name")]
        public virtual IncomeExpenseHead IncomeExpenseHead { get; set; }





    }
}
