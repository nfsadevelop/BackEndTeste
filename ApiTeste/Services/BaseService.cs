namespace ApiTeste.Services
{
    public abstract class BaseService
    {
        public List<string?> Errors { get; set; }
        public bool HasError { get { return Errors.Count > 0; } }

        public BaseService()
        {
            Errors = new List<string?>();
        }

        protected void AddErrors(List<string?> errors) 
        {
            Errors.AddRange(errors);
        }

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrors() 
        {
            Errors.Clear();
        }
    }
}
