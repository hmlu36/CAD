#pragma checksum "D:\svnbox\google drive\CAD\Views\Product\PostEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c68b39eab567fd3becb5ec5aa0f8f034fcd3125"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_PostEdit), @"mvc.1.0.view", @"/Views/Product/PostEdit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/PostEdit.cshtml", typeof(AspNetCore.Views_Product_PostEdit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c68b39eab567fd3becb5ec5aa0f8f034fcd3125", @"/Views/Product/PostEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13caabebe86de5e5ddfdfe1cb1efccd3db377dab", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_PostEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\svnbox\google drive\CAD\Views\Product\PostEdit.cshtml"
  
    ViewBag.Title = "編輯商品";

#line default
#line hidden
            BeginContext(36, 10512, true);
            WriteLiteral(@"
<div class=""container"">
    <br /><h4>編輯商品</h4>
    <!-- 畫面驗證訊息 -->
    <div class='validation-summary-errors'><ul /></div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right""><span style=""color: red"">＊</span>類型</label>
        <div class=""col-lg-4"">
            <v-select v-model=""model.Category"" :options=""productCategories"" :blank=""true"" />
        </div>
    </div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right""><span style=""color: red"">＊</span>產品名稱</label>
        <div class=""col-lg-4"">
            <input class=""form-control"" v-model=""model.Name"" />
        </div>
    </div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right""><span style=""color: red"">＊</span>型號</label>
        <div class=""col-lg-4"">
            <input class=""form-control"" v-model=""model.Mold"" />
        </div>
    </div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right"">說明</label>
        <div class=""col-l");
            WriteLiteral(@"g-4"">
            <textarea class=""form-control"" v-model=""model.Description"" rows=""3"" cols=""10""></textarea>
        </div>
    </div>

    <div class=""form-group row"">
        <label class=""col-lg-2 text-right""><span style=""color: red"">＊</span>圖片</label>
        <div class=""col-lg-4"">
            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'Path')"" v-bind:data-placeholder=""model.Path"" /><br />
            <img v-bind:src=""'/images/Post/' + model.Path"" v-if=""!previewImage[0] && !!model.Path"" class=""w-100""/>
            <span v-show=""!!previewImage[0]"">
                <img v-bind:src=""previewImage[0]"" class=""w-100""/>
            </span>
        </div>
    </div>

    <div class=""card w-75"">
        <div class=""card-header"">
            <ul class=""nav nav-tabs card-header-tabs justify-content-center"">
                <li class=""nav-item"">
                    <a class=""nav-link active"" data-toggle=""tab"" href=""#Function"" aria-selected=""true"">功能</a>
                </l");
            WriteLiteral(@"i>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-toggle=""tab"" href=""#Recipe"" aria-selected=""false"">食譜</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-toggle=""tab"" href=""#Design"" aria-selected=""false"">設計</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-toggle=""tab"" href=""#Story"" aria-selected=""false"">故事</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-toggle=""tab"" href=""#Spec"" aria-selected=""false"">規格</a>
                </li>
            </ul>
        </div>
        <div class=""card-body"">
            <div class=""tab-content"">
                <div class=""tab-pane fade show active"" id=""Function"">
                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">標題</label>
                        <div class=""col-lg-6"">
                ");
            WriteLiteral(@"            <input class=""form-control"" v-model=""model.FunctionTitle"" />
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">說明</label>
                        <div class=""col-lg-6"">
                            <textarea class=""form-control"" v-model=""model.FunctionDescription"" rows=""3"" cols=""10""></textarea>
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">圖片</label>
                        <div class=""col-lg-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'FunctionPath')"" v-bind:data-placeholder=""model.FunctionPath"" /><br />
                            <img v-bind:src=""'/images/Post/' + model.FunctionPath"" v-if=""!previewImage[1] && !!model.FunctionPath"" class=""w-100"" />
                            <span v-show=""!");
            WriteLiteral(@"!previewImage[1]"">
                                <img v-bind:src=""previewImage[1]"" class=""w-100"" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class=""tab-pane fade"" id=""Recipe"">
                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">標題</label>
                        <div class=""col-lg-6"">
                            <input class=""form-control"" v-model=""model.RecipeTitle"" />
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">說明</label>
                        <div class=""col-lg-6"">
                            <textarea class=""form-control"" v-model=""model.RecipeDescription"" rows=""3"" cols=""10""></textarea>
                        </div>
                    </div>

                    <div class=""form-group row"">
                 ");
            WriteLiteral(@"       <label class=""col-lg-2 text-right"">圖片</label>
                        <div class=""col-lg-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'RecipePath')"" v-bind:data-placeholder=""model.RecipePath"" /><br />
                            <img v-bind:src=""'/images/Post/' + model.RecipePath"" v-if=""!previewImage[2] && !!model.RecipePath"" class=""w-100"" />
                            <span v-show=""!!previewImage[2]"">
                                <img v-bind:src=""previewImage[2]"" class=""w-100"" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class=""tab-pane fade"" id=""Design"">
                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">標題</label>
                        <div class=""col-lg-6"">
                            <input class=""form-control"" v-model=""model.DesignTitle"" />
                        </div>");
            WriteLiteral(@"
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">說明</label>
                        <div class=""col-lg-6"">
                            <textarea class=""form-control"" v-model=""model.DesignDescription"" rows=""3"" cols=""10""></textarea>
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">圖片</label>
                        <div class=""col-lg-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'DesignPath')"" v-bind:data-placeholder=""model.DesignPath"" /><br />
                            <img v-bind:src=""'/images/Post/' + model.DesignPath"" v-if=""!previewImage[3] && !!model.DesignPath"" class=""w-100"" />
                            <span v-show=""!!previewImage[3]"">
                                <img v-bind:src=""previewImage[3]"" class=""w-100"" />
          ");
            WriteLiteral(@"                  </span>
                        </div>
                    </div>
                </div>
                <div class=""tab-pane fade"" id=""Story"">
                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">標題</label>
                        <div class=""col-lg-6"">
                            <input class=""form-control"" v-model=""model.StoryTitle"" />
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">說明</label>
                        <div class=""col-lg-6"">
                            <textarea class=""form-control"" v-model=""model.StoryDescription"" rows=""3"" cols=""10""></textarea>
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">圖片</label>
                        <div class=""col-lg-6"">
               ");
            WriteLiteral(@"             <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'StoryPath')"" v-bind:data-placeholder=""model.StoryPath"" /><br />
                            <img v-bind:src=""'/images/Post/' + model.StoryPath"" v-if=""!previewImage[4] && !!model.StoryPath"" class=""w-100"" />
                            <span v-show=""!!previewImage[4]"">
                                <img v-bind:src=""previewImage[4]"" class=""w-100"" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class=""tab-pane fade"" id=""Spec"">
                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">標題</label>
                        <div class=""col-lg-6"">
                            <input class=""form-control"" v-model=""model.SpecTitle"" />
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-l");
            WriteLiteral(@"g-2 text-right"">說明</label>
                        <div class=""col-lg-6"">
                            <textarea class=""form-control"" v-model=""model.SpecDescription"" rows=""3"" cols=""10""></textarea>
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-2 text-right"">圖片</label>
                        <div class=""col-lg-6"">
                            <input type=""file"" class=""filestyle"" v-on:change=""fileChange($event, 'SpecPath')"" v-bind:data-placeholder=""model.SpecPath"" /><br />
                            <img v-bind:src=""'/images/Post/' + model.SpecPath"" v-if=""!previewImage[5] && !!model.SpecPath"" class=""w-100"" />
                            <span v-show=""!!previewImage[5]"">
                                <img v-bind:src=""previewImage[5]"" class=""w-100"" />
                            </span>
                        </div>
                    </div>
                </div>
            </div>
    ");
            WriteLiteral(@"    </div>
    </div>

    <br />
    <div class=""text-center"">
        <input type=""button"" class=""btn btn-primary"" value=""儲存"" v-on:click=""save"" />
        <input type=""button"" class=""btn btn-warning"" value=""上一頁"" v-on:click=""previousPage"" />
    </div>
</div>

");
            EndContext();
            BeginContext(10548, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ab9b0c3f69a450fab27c678f68ffa20", async() => {
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
            BeginContext(10593, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(10597, 2033, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f41dcd4132f4925926f278480114872", async() => {
                BeginContext(10628, 12, true);
                WriteLiteral("\r\n    \r\n    ");
                EndContext();
                BeginContext(10641, 48, false);
#line 216 "D:\svnbox\google drive\CAD\Views\Product\PostEdit.cshtml"
Write(await Component.InvokeAsync("EnumsToJavaScript"));

#line default
#line hidden
                EndContext();
                BeginContext(10689, 95, true);
                WriteLiteral("\r\n    var vm = \r\n    new Vue({\r\n        el: \'.container\',\r\n        data: {\r\n            model: ");
                EndContext();
                BeginContext(10785, 31, false);
#line 221 "D:\svnbox\google drive\CAD\Views\Product\PostEdit.cshtml"
              Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
                EndContext();
                BeginContext(10816, 1805, true);
                WriteLiteral(@",
            errors: [],
            productCategories: ProductCategory,
            formdata: new FormData(),
            previewImage: ['', '', '', '', '', '']
        },
        methods: {
            fileChange: async function (e, type) {
                var files = e.target.files || e.dataTransfer.files;
                if (!files.length) { 
                    return;
                }

                vm.formdata.append(files[0].name, files[0]);

                await uploadFile(files[0]).then(function (file) {
                    vm.setPath(type, files[0].name, file);
                });
            },
            setPath(type, path, file) {
                if (""Path"" == type) {
                    vm.model.Path = path;
                    vm.previewImage[0] = file
                } else if (""FunctionPath"" == type) {
                    vm.model.FunctionPath = path;
                    vm.previewImage[1] = file;
                } else if (""RecipePath"" == type) {
           ");
                WriteLiteral(@"         vm.model.RecipePath = path;
                    vm.previewImage[2] = file;
                } else if (""DesignPath"" == type) {
                    vm.model.DesignPath = path;
                    vm.previewImage[3] = file;
                } else if (""StoryPath"" == type) {
                    vm.model.StoryPath = path;
                    vm.previewImage[4] = file;
                } else if (""SpecPath"" == type) {
                    vm.model.SpecPath = path;
                    vm.previewImage[5] = file;
                }
            },
            save() {
                // alert(JSON.stringify(this.model));
                ajaxUpload('/Product/PostEdit', this.model, '/Product/UploadImage/Post', this.formdata);
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
