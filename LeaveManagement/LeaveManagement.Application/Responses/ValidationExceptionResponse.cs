using FluentValidation.Results;

namespace LeaveManagement.Application.Responses
{
    public class ValidationExceptionResponse : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationExceptionResponse(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
