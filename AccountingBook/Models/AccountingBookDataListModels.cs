using AccountingBook.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountingBook.Models
{
    public class AccountingBookDataListModels
    {
        [Required]
        [Display(Name ="類別")]
        public string type { get; set; }

        [Required]
        [Display(Name ="日期")]
        [DataType(DataType.Date)]
        [DateValid(ErrorMessage = "輸入日期不可大於今天")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name ="金額")]
        [Range(0,int.MaxValue,ErrorMessage ="金額必須為正整數")]
        public int money { get; set; }

        [Required]
        [Display(Name ="備註")]
        [StringLength(100,ErrorMessage = "最多輸入100個字元")]
        public string Remark { get; set; }
    }
}