using FluentValidation.Results;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Models
{
    public class ResponseApiModel<T> where T : BaseViewModel
    {
        public bool Success { get; private set; }
        public bool IsInternalError { get; private set; }
        public string InternalErrorMessage { get; private set; } = string.Empty;
        public int StatusCode { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; private set; } = new List<KeyValuePair<string, string>>();
        public T Model { get; set; }

        public ResponseApiModel()
        {
            Success = true;
            IsInternalError = false;
            Model = default!;
        }

        public ResponseApiModel(T model)
        {
            Model = model;
            Success = true;
            IsInternalError = false;
        }

        public ResponseApiModel(string internalError)
        {
            IsInternalError = true;
            Success = false;
            InternalErrorMessage = internalError;
            Model = default!;
        }

        public ResponseApiModel(List<ValidationFailure> errors)
        {
            IsInternalError = false;
            Success = false;
            foreach (var item in errors)
                Errors.Add(new KeyValuePair<string, string>(item.PropertyName, item.ErrorMessage));
            Model = default!;
        }

        public ResponseApiModel(string errorProperty, string errorMessage)
        {
            IsInternalError = false;
            Success = false;
            Errors.Add(new KeyValuePair<string, string>(errorProperty, errorMessage));
            Model = default!;
        }
    }

}
