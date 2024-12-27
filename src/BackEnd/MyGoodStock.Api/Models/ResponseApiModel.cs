using FluentValidation.Results;

namespace MyGoodStock.Api.Models
{
    public class ResponseApiModel
    {
        public bool Success { get; private set; }
        public bool IsInternalError { get; private set; }
        public string InternalErrorMessage { get; private set; } = string.Empty;
        public int StatusCode { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; private set; } = new List<KeyValuePair<string, string>>();

        public ResponseApiModel()
        {

        }

        public ResponseApiModel(string internalError)
        {
            this.IsInternalError = true;
            this.Success = false;
            this.InternalErrorMessage = internalError;
        }

        public ResponseApiModel(List<ValidationFailure> errors)
        {
            this.IsInternalError = false;
            this.Success = false;
            foreach (var item in errors)
                this.Errors.Add(new KeyValuePair<string, string>(item.PropertyName, item.ErrorMessage));
        }

        public ResponseApiModel(string errorProperty, string errorMessage)
        {
            this.IsInternalError = false;
            this.Success = false;
            this.Errors.Add(new KeyValuePair<string, string>(errorProperty, errorMessage));
        }
    }

}
