namespace Dotnet.Models.Web {

    public class ResultModel {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}