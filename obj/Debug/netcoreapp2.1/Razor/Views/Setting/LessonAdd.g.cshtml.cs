#pragma checksum "D:\hmlu\svnbox\Research\heroku\CAD\Views\Setting\LessonAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f2e1936874304a28095738e0e9d58d0bd3fce37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setting_LessonAdd), @"mvc.1.0.view", @"/Views/Setting/LessonAdd.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Setting/LessonAdd.cshtml", typeof(AspNetCore.Views_Setting_LessonAdd))]
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
#line 1 "D:\hmlu\svnbox\Research\heroku\CAD\Views\_ViewImports.cshtml"
using Dotnet;

#line default
#line hidden
#line 2 "D:\hmlu\svnbox\Research\heroku\CAD\Views\_ViewImports.cshtml"
using Dotnet.Models;

#line default
#line hidden
#line 3 "D:\hmlu\svnbox\Research\heroku\CAD\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f2e1936874304a28095738e0e9d58d0bd3fce37", @"/Views/Setting/LessonAdd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c23ac2b254178383bf9c8339dfcaa7701789132c", @"/Views/_ViewImports.cshtml")]
    public class Views_Setting_LessonAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\hmlu\svnbox\Research\heroku\CAD\Views\Setting\LessonAdd.cshtml"
  
    ViewBag.Title = "新增課程";

#line default
#line hidden
            BeginContext(33, 2737, true);
            WriteLiteral(@"
<div class=""container"">
    <br /><h4>新增課程</h4>
    <!-- 畫面驗證訊息 -->
    <div class='validation-summary-errors'><ul /></div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right""><span style=""color: red"">＊</span>名稱</label>
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
                        <th class=""col-4"">說明");
            WriteLiteral(@"</th>
                        <th class=""col-6""><span style=""color: red"">＊</span>圖片</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for=""(row, index) in rows"" class=""d-flex"">
                        <td class=""text-center col-1"">
                            <button type=""button"" class=""btn btn-danger btn-sm"" v-on:click=""removeRow(row)""><i class='fa fa-remove'></i>刪除</button>
                        </td>
                        <td class=""text-center col-1"" style=""vertical-align:middle"">
                            {{index + 1}}
                            <input type=""hidden"" v-model=""row.Seq"" />
                        </td>
                        <td class=""text-center col-4"">
                            <input v-model=""row.Description"" class=""form-control"">
                        </td>
                        <td class=""col-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, index)"" v-bind:data-pla");
            WriteLiteral(@"ceholder=""row.FileName"" />
                            <img v-bind:src=""'/images/Lesson/' + row.FileName"" v-if=""!previewImage[index] && !!row.FileName"" class=""w-25"" />
                            <span v-else>
                                <img v-bind:src=""previewImage[index]"" class=""w-25"" />
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
            BeginContext(2770, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fe0b10264814edc83c2188fff560837", async() => {
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
            BeginContext(2808, 3, true);
            WriteLiteral("\n\n\n");
            EndContext();
            BeginContext(2811, 3102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5454fe69f6e0405988205c301947de8f", async() => {
                BeginContext(2842, 3062, true);
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
        watch: {
            rows: function () {
                // 處理filestyle, 新增列後再驅動timer
                setTimeout(function () {
                    $('.filestyle').each(function () {
                        if (!$(this).attr(""id"")) {
                            $(this).filestyle();
                        }
                    });
                }, 0);
            }
        },
        methods: {
            fileChange: async function (e, index) {
                var files = e.target.files || e.dataTransfer.files;
                if (!files.length) {
                    return;
                }

                this.formdata.append(files[0].name, files[0]);
                await uploadFile(files[0]).then(function (file) {

                    if (vm.previewImage[index] === ""undefined"") {");
                WriteLiteral(@"
                        vm.previewImage.push(file);
                    } else {
                        vm.previewImage[index] = file;
                    }
                    vm.rows[index].FileName = files[0].name;
                });
            },
            save() {
                this.model.TeachingAids = this.rows;
                alert(JSON.stringify(this.model));

                ajaxUpload('/Setting/LessonAdd', this.model, '/Setting/UploadImage/Lesson', this.formdata);
            },
            addRow() {
                this.rows.push({ Seq: this.rows.length + 1, Description: """", FileName: """" });
                this.previewImage.push('');
                //console.log(""previewImage length:"" + this.previewImage.length);
            },
            removeRow(selectedRow) {
                if (this.rows.length == 1) {
                    warningMessage(""明細資料至少要有一列"");
                } else {
                    var index = this.rows.indexOf(selectedRow);
                    //console.log(index);");
                WriteLiteral(@"
                    this.$delete(this.rows, index);
                    //this.rows.splice(index, 1);

                    // 重置序號
                    this.rows.forEach(function (row, idx) {
                        row.Seq = idx + 1;
                    });


                    this.previewImage.splice(index, 1);
                    //console.log(""previewImage length:"" + this.previewImage.length);

                    $("".filestyle"").each(function (idx) {
                        if (idx >= index) {
                            $(this).filestyle('clear');
                            if (!!vm.rows[idx] && !!vm.rows[idx].FileName) {
                                //console.log(""idx:"" + idx + "", value:"" + vm.rows[idx].FileName);
                                $(this).filestyle('placeholder', vm.rows[idx].FileName);
                            }
                        }
                    });
                }
            }
        },
        created() {
            this.addRow();
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
