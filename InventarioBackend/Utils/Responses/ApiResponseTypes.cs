using Commons;

namespace Utils.Responses
{
    public static class ApiResponseTypes
    {
        private static ILoggerService? _loggerService;
        public static void ConfigureLogger(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        /// <summary>
        /// Respuesta exitosa con datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse<T> Success<T>(T content, string message = "Operación exitosa")
        {
            return new ApiResponse<T>(200, false, message, content);
        }

        /// <summary>
        /// Respuesta de error general
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse<T> Error<T>(int codigo, string message)
        {
            return new ApiResponse<T>(codigo, true, message, default);
        }

        public static ApiResponse<T> BadRequest<T>(T content, Exception exception, string message = "Solicitud incorrecta")
        {
            _loggerService.RegistrarError(new ApiResponse<T>(500, true, message, content));
            return new ApiResponse<T>(400, true, message, default);
        }

        public static ApiResponse<T> InternalServerError<T>(T content, Exception exception, string message = "Error interno del servidor")
        {
            _loggerService.RegistrarError(new ApiResponse<T>(500,true,message,content));
            return new ApiResponse<T>(500, true, message, default);
        }

    }

}
