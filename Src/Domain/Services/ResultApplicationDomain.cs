namespace backend.Domain
{
    public class ResultApplicationDomain<TEntity> where TEntity : class
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public List<TEntity> Data { get; set; } = [];
        public string? Error { get; internal set; }
    }
}