namespace ZaferTurizm.Business
{
    public class ValidationResult
    {
        public bool IsValid
        {
            get
            {
                return !Messages.Any();
            }
        }

        public ICollection<string> Messages { get; } = new List<string>();
    }
}
