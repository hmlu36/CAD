#pragma checksum "D:\svnbox\google drive\CAD\Views\Setting\CategoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f5979c379a5921d08c5a1f768a3ef2e2b27b980"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setting_CategoryList), @"mvc.1.0.view", @"/Views/Setting/CategoryList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Setting/CategoryList.cshtml", typeof(AspNetCore.Views_Setting_CategoryList))]
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
#line 1 "D:\svnbox\google drive\CAD\Views\_ViewImports.cshtml"
using Dotnet;

#line default
#line hidden
#line 2 "D:\svnbox\google drive\CAD\Views\_ViewImports.cshtml"
using Dotnet.Models;

#line default
#line hidden
#line 3 "D:\svnbox\google drive\CAD\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f5979c379a5921d08c5a1f768a3ef2e2b27b980", @"/Views/Setting/CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13caabebe86de5e5ddfdfe1cb1efccd3db377dab", @"/Views/_ViewImports.cshtml")]
    public class Views_Setting_CategoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/backendBundle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\svnbox\google drive\CAD\Views\Setting\CategoryList.cshtml"
  
    ViewBag.Title = "輪播圖管理";

#line default
#line hidden
            BeginContext(37, 837, true);
            WriteLiteral(@"
<div class=""container"">
    <br /><h4>輪播圖管理</h4><br />

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
        <input type=""button"" class=""btn btn-warning"" value=""新增輪播圖"" onclick=""location.href='/Product/CarouselCreate'"" />
    </div>
    <datatable :columns=""columns"" :data=""rows""></datatable>
    <datatable-pager v-model=""page"" type=""abbreviated"" class=""d-flex justify-content-center""></datatable-pager>
</div>
");
            EndContext();
            BeginContext(874, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1398c605d4764b45a107fc701e37ef3f", async() => {
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
            BeginContext(919, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(925, 1692, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb7d1ca172364c8c81cceea338d264eb", async() => {
                BeginContext(956, 12, true);
                WriteLiteral("\r\n    \r\n    ");
                EndContext();
                BeginContext(969, 48, false);
#line 31 "D:\svnbox\google drive\CAD\Views\Setting\CategoryList.cshtml"
Write(await Component.InvokeAsync("EnumsToJavaScript"));

#line default
#line hidden
                EndContext();
                BeginContext(1017, 1591, true);
                WriteLiteral(@"

var vm =
    new Vue({
        el: '.container',
        data: {
            columns: [
                {
                    label: ""操作"", interpolate: true, align: ""center"", sortable: false,
                    representedAs: function (row) {
                        return editDeleteButton(""/Product/CategoryEdit/"", ""/Product/CategoryDelete/"", row.Id);
                    }
                },
                {
                    label: ""類型"", interpolate: true,
                    representedAs: function (row) { 
                        return ddlDescription(YesNo, row.Status);
                    }
                },
                { label: ""檔名"", field: ""Path"" },
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
     ");
                WriteLiteral(@"               vm.getData();
                }
            });
        },
        methods: {
            getData() {
                blockUI();

                axios.get('/Setting/CategoryGrid', {
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
            BeginContext(2617, 2, true);
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