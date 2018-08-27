using System.Collections.Generic;

namespace Dotnet.Models.Web {

    public class ValidateMessage {
        public bool Success { get; set; }
        public List<string> Message { get; set; }
        public string Link { get; set; }
    }
}