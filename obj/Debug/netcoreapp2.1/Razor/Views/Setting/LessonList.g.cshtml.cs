#pragma checksum "D:\svnbox\CAD\Views\Setting\LessonList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eadf5ac2daab4cd1b3ff3e2c25b4fcefe79d363"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setting_LessonList), @"mvc.1.0.view", @"/Views/Setting/LessonList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Setting/LessonList.cshtml", typeof(AspNetCore.Views_Setting_LessonList))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\svnbox\CAD\Views\_ViewImports.cshtml"
using Dotnet;

#line default
#line hidden
#line 2 "D:\svnbox\CAD\Views\_ViewImports.cshtml"
using Dotnet.Models;

#line default
#line hidden
#line 3 "D:\svnbox\CAD\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eadf5ac2daab4cd1b3ff3e2c25b4fcefe79d363", @"/Views/Setting/LessonList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13caabebe86de5e5ddfdfe1cb1efccd3db377dab", @"/Views/_ViewImports.cshtml")]
    public class Views_Setting_LessonList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bundle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::WebOptimizer.Taghelpers.ScriptTagHelper __WebOptimizer_Taghelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\svnbox\CAD\Views\Setting\LessonList.cshtml"
  
    ViewBag.Title = "課程管理";

#line default
#line hidden
            BeginContext(36, 830, true);
            WriteLiteral(@"
<div class=""container"">
    <br /><h4>課程管理</h4><br />

    <section class=""well"">
        <div class=""form-group row"">
            <label class=""col-lg-2"">顯示</label>
            <div class=""col-lg-2"">
                <v-select v-model=""model.Status"" :options=""yesNo"" :blank=""true"" />
            </div>

            <div class=""col-lg-offset-6"">
                <button type=""button"" class=""btn btn-primary"" v-on:click=""getData();"">查詢</button>
            </div>
        </div>
    </section>
    <div>
        <input type=""button"" class=""btn btn-warning"" value=""新增課程"" onclick=""location.href='/Setting/LessonAdd'"" />
    </div>
    <datatable :columns=""columns"" :data=""rows""></datatable>
    <datatable-pager v-model=""page"" type=""abbreviated"" class=""d-flex justify-content-center""></datatable-pager>
</div>
");
            EndContext();
            BeginContext(866, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ceb7bdb1de0440649e22d61d34c93828", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __WebOptimizer_Taghelpers_ScriptTagHelper = CreateTagHelper<global::WebOptimizer.Taghelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__WebOptimizer_Taghelpers_ScriptTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(904, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(910, 1501, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a94ec5f8fd064ddd96dabf8fd5738925", async() => {
                BeginContext(941, 12, true);
                WriteLiteral("\r\n    \r\n    ");
                EndContext();
                BeginContext(954, 48, false);
#line 31 "D:\svnbox\CAD\Views\Setting\LessonList.cshtml"
Write(await Component.InvokeAsync("EnumsToJavaScript"));

#line default
#line hidden
                EndContext();
                BeginContext(1002, 1400, true);
                WriteLiteral(@"

var vm =
    new Vue({
        el: '.container',
        data: {
            columns: [
                {
                    label: ""操作"", interpolate: true, align: ""center"", sortable: false,
                    representedAs: function (row) {
                        return editDeleteButton(""/Setting/LessonEdit/"", ""/Setting/LessonDelete/"", row.Id) + projectButton(""/Setting/LessonProject/"", row.Id);
                    }
                },
                { label: ""名稱"", field: ""Name"" },
                { label: ""說明"", field: ""Description"" }
            ],
            rows: [],
            model: {},
            page: 1,
            yesNo: YesNo
        },
        mounted: function () {
            window.addEventListener('keypress', function (event) {
                if (event.key == ""Enter"") {
                    vm.getData();
                }
            });
        },
        methods: {
            getData() {
                blockUI();

                axios.get('/Setting/");
                WriteLiteral(@"LessonGrid', {
                    params: this.model
                })
                .then(response => {
                    //alert(JSON.stringify(response.data));
                    this.rows = response.data;
                    $.unblockUI();
                });
            }
        },
        created() {
            this.getData();
        }
    });
");
                EndContext();
            }
            );
            __WebOptimizer_Taghelpers_ScriptTagHelper = CreateTagHelper<global::WebOptimizer.Taghelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__WebOptimizer_Taghelpers_ScriptTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2411, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
