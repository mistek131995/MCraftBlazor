using System.ComponentModel.DataAnnotations;

namespace MCraftBlazor.Helpers.Attributes
{
    public class BoolEqualsAttribute : ValidationAttribute
    {

        private bool validValue;

        public BoolEqualsAttribute(bool validValue)
        {
            this.validValue = validValue;
        }

        public override bool IsValid(object? value)
        {
            if(value is bool _value)
            {
                if(_value == validValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
