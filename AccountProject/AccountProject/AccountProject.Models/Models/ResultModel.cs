namespace AccountProject.Models.Models
{
    public enum Status
    {
        Success = 200,
        Error = 400
    }

    public class ResultModel<T>: IResultModel
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
    }
}
