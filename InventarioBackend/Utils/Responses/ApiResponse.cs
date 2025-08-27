namespace Utils.Responses
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Código de respuesta (200, 400, 500, etc.) Based Http Response
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Indica si hubo un error
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// Mensaje descriptivo
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Contenido de la respuesta (puede ser null en caso de error)
        /// </summary>
        public T Content { get; set; }

        public ApiResponse(int codigo, bool isError, string message, T content)
        {
            Codigo = codigo;
            IsError = isError;
            Message = message;
            Content = content;
        }
    }
}
