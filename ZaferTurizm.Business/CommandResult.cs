namespace ZaferTurizm.Business
{
    public class CommandResult
    {
        private const string DefaultSuccessMessage = "İşlem başarılı";
        private const string DefaultFailureMessage = "İşlem başarısız";

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        // Factory Pattern
        public static CommandResult Success()
        {
            return Success(DefaultSuccessMessage);
        }

        public static CommandResult Success(string message)
        {
            return new CommandResult()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static CommandResult Failure()
        {
            return Failure(DefaultFailureMessage);
        }

        public static CommandResult Failure(string message)
        {
            return new CommandResult()
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static CommandResult Error(Exception ex, string message)
        {
            return null;
        }
    }
}
