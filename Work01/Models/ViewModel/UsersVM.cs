using System;
using Work01.CustomValidation;

namespace Work01.Models.ViewModel
{
    public class UsersVM
    {
        public int Id { get; set; }
        [DateValidAttribute]
        public DateTime ExpenseDate { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public string Categories { get; set; }


    }
}
