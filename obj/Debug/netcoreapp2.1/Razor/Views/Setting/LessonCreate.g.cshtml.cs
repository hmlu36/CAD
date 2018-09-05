#pragma checksum "D:\svnbox\CAD\Views\Setting\LessonCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ec51108a001e5db0f4721651fbc065656e29429"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setting_LessonCreate), @"mvc.1.0.view", @"/Views/Setting/LessonCreate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Setting/LessonCreate.cshtml", typeof(AspNetCore.Views_Setting_LessonCreate))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ec51108a001e5db0f4721651fbc065656e29429", @"/Views/Setting/LessonCreate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13caabebe86de5e5ddfdfe1cb1efccd3db377dab", @"/Views/_ViewImports.cshtml")]
    public class Views_Setting_LessonCreate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\svnbox\CAD\Views\Setting\LessonCreate.cshtml"
  
    ViewBag.Title = "新增課程";

#line default
#line hidden
            BeginContext(36, 2708, true);
            WriteLiteral(@"
<div class=""container"">
    <br /><h4>新增課程</h4>
    <!-- 畫面驗證訊息 -->
    <div class='validation-summary-errors'><ul /></div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right"">名稱</label>
        <div class=""col-lg-4"">
            <input class=""form-control"" v-model=""model.Name"" />
        </div>
    </div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right"">說明</label>
        <div class=""col-lg-4"">
            <textarea class=""form-control"" v-model=""model.Description"" rows=""3"" cols=""10""></textarea>
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-lg-12"">
            <button type=""button"" class=""btn btn-warning"" v-on:click=""addRow"">新增明細</button>
            <table class=""table-bordered w-100"">
                <thead>
                    <tr class=""d-flex"">
                        <th class=""col-1"">操作</th>
                        <th class=""col-1"">序號</th>
                        <th class=""col-4"">說明</th>");
            WriteLiteral(@"
                        <th class=""col-6"">圖片</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for=""(row, index) in rows"" class=""d-flex"">
                        <td class=""text-center col-1"">
                            <button type=""button"" class=""btn btn-danger btn-sm"" v-on:click=""removeRow(row)""><i class='fa fa-remove'></i>刪除</button>
                        </td>
                        <td class=""text-center col-1"" style=""vertical-align:middle"">
                            {{++index}}
                            <input type=""hidden"" v-model=""row.Seq"" />
                        </td>
                        <td class=""text-center col-4"">
                            <input v-model=""row.Name"" class=""form-control"">
                        </td>
                        <td class=""col-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event)"" v-bind:data-placeholder=""row.Path"" />
              ");
            WriteLiteral(@"              <img v-bind:src=""'/images/Lesson/' + row.Path"" v-if=""!previewImage && !!row.Path"" class=""w-25"" />
                            <span v-show=""!!previewImage"">
                                <img v-bind:src=""previewImage"" class=""w-25"" />
                            </span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class=""text-center"">
        <input type=""button"" class=""btn btn-primary"" value=""儲存"" v-on:click=""save"" />
        <input type=""button"" class=""btn btn-warning"" value=""上一頁"" v-on:click=""previousPage"" />
    </div>
</div>

");
            EndContext();
            BeginContext(2744, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58cd29552bfb4f459dcd0a71bd72a025", async() => {
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
            BeginContext(2782, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(2788, 1590, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc00c3e452f1409ab42c221a66c4974f", async() => {
                BeginContext(2819, 1550, true);
                WriteLiteral(@"
    
var vm =
    new Vue({
        el: '.container',
        data: {
            errors: [],
            model: {},
            rows: [],
            formdata: new FormData(),
            previewImage: []
        },
        methods: {
            fileChange: async function (e) {
                var files = e.target.files || e.dataTransfer.files;
                if (!files.length) {
                    return;
                }

                this.formdata.append(files[0].name, files[0]);
                await uploadFile(files[0]).then(function (file) {
                    vm.previewImage = file;
                    vm.model.Path = files[0].name;
                });
            },
            save() {
                this.model.TeachingAids = this.rows;
                alert(JSON.stringify(this.model));

                var saveUrl = '/Setting/LessonCreate';
                ajaxSave(saveUrl, this.model);
            },
            addRow() {
                this.rows.push({");
                WriteLiteral(@" Seq: this.rows.length + 1, Name: """", Path: """"});
            },
            removeRow(selectedRow) {
                if (this.rows.length == 1) {
                    warningMessage(""明細資料至少要有一列"");
                } else {
                    this.$delete(this.rows, this.rows.indexOf(selectedRow));

                    // 重置序號
                    this.rows.forEach(function (row, index) {
                        row.Seq = index + 1;
                    });
                }
            }
        }
    })

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
