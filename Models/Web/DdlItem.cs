
namespace Dotnet.Models.Web {

    [ToString]
    public class DdlItem {
        public DdlItem(string Code, string Description) {
            this.Code = Code;
            this.Description = Description;
        }

        public string Code;
        public string Description;
        public string ToolTip;
    }
}
