using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.Attribute
{
    public sealed class DateValidAttribute: ValidationAttribute,IClientValidatable
    {
        private DateTime Input { get; set; }
        private DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }      

        public DateValidAttribute()//:base("aaa")
        {
            
        }
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }
            if(value != null)
            {
                Input = (DateTime)value;
                if( Input > Now)
                {
                    return false;
                }
            }
            return true;
        }

        //這段會在前端的tag 產生一個屬性:data-你給的ValidationTypeName，在前端去做驗證
        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule Rule = new ModelClientValidationRule
            {
                //這個屬性的值必須要是小寫內容，否則會出錯
                ValidationType = "daterange",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };

            //Rule.ValidationParameters["input"] = Input;
            yield return Rule;
        }
    }
}