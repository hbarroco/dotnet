using System.Net;

namespace LoginJWT_Sample_API.Models
{
    public sealed class ApiResponseDto<TData>
    {
        public ApiResponseDto(TData data = default!) => Data = data;

        public bool Status { get; set; } = true;
        public IEnumerable<string>? Errors { get; set; }
        public int StatusCode { get; set; } = 200;
        public TData Data { get; set; }

        public static ApiResponseDto<TData> Success(int statusCode, TData data = default!) =>
            new(data)
            {
                StatusCode = statusCode,
                Status = true
            };

        public static ApiResponseDto<TData> Success(TData data = default!, HttpStatusCode statusCode = HttpStatusCode.OK) => Success((int)statusCode, data);

        public static ApiResponseDto<TData> Success(int statusCode) =>
            new()
            {
                StatusCode = statusCode,
                Status = true
            };

        public static ApiResponseDto<TData> Success(HttpStatusCode statusCode = HttpStatusCode.OK) => Success((int)statusCode);

        public static ApiResponseDto<TData> Failure(IEnumerable<string> errors, int statusCode) =>
            new(default!)
            {
                StatusCode = statusCode,
                Status = false,
                Errors = errors
            };
        public static ApiResponseDto<TData> Failure(IEnumerable<string> errors, HttpStatusCode statusCode) => Failure(errors, (int)statusCode);

        public static ApiResponseDto<TData> Failure(string errors, int statusCode) => Failure(new List<string> { errors }, statusCode);
        public static ApiResponseDto<TData> Failure(string errors, HttpStatusCode statusCode) => Failure(new List<string> { errors }, (int)statusCode);
    }
}
