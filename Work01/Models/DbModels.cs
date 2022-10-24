using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work01.CustomValidation;

namespace Work01.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Categories { get; set; }
        //nev
        public ICollection<User> Users { get; set; }

    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        //Categories

        [ForeignKey("Category")]
        [Required, Display(Name = "Category")]
        
        public int CategoryId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateValidAttribute]
        public  DateTime ExpenseDate { get; set; }
        [Required]
        public int Amount { get; set; }
        //nev
        public virtual Category Category { get; set; }





    }
}
