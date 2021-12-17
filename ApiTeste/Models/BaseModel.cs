using System.ComponentModel.DataAnnotations;

namespace ApiTeste.Models
{
    public abstract class BaseModel<T>
    {
        protected List<ValidationResult> ValidationResults { get; set; }
        protected bool IsValid { get; set; }
        public BaseModel()
        {
            ValidationResults = new List<ValidationResult>();
            IsValid = false;
        }
        public bool Validate()
        {
            ValidationResults = new List<ValidationResult>();
            IsValid = Validator.TryValidateObject(this,
                new ValidationContext(this, null, null), ValidationResults, true);

            return IsValid;
        }

        public List<string?> GetErrors() 
        {
            return ValidationResults.Select(x => x.MemberNames.FirstOrDefault() == null ? "" : x.MemberNames.FirstOrDefault() + ": " + x.ErrorMessage).ToList(); 
        }
    }
}
