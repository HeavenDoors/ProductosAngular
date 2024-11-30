namespace ML
{
    public class Result
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public Exception? Ex { get; set; }
        public object? Object { get; set; }
        public List<object>? Objects { get; set; }
    }
}
