#pragma checksum "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "546c518b570dba00c44140f0638e67e1880141c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ProductsSummary), @"mvc.1.0.view", @"/Views/Shared/ProductsSummary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/ProductsSummary.cshtml", typeof(AspNetCore.Views_Shared_ProductsSummary))]
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
#line 1 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\_ViewImports.cshtml"
using ACME;

#line default
#line hidden
#line 2 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\_ViewImports.cshtml"
using ACME.Data.ViewModels;

#line default
#line hidden
#line 3 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\_ViewImports.cshtml"
using ACME.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"546c518b570dba00c44140f0638e67e1880141c7", @"/Views/Shared/ProductsSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d09d122bad99a9bdca5e34e7cba2d437e3cbce2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ProductsSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cartButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
  
    var photoPath = "/Images/" + (Model.ImageUrl);

#line default
#line hidden
            BeginContext(77, 77, true);
            WriteLiteral("\r\n\r\n<div class=\"col-sm-3 col-lg-3 col-md-3\" style=\"margin-left: -0.15%;\">\r\n\r\n");
            EndContext();
#line 10 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
     if (!User.IsInRole("Admin"))
    {

#line default
#line hidden
            BeginContext(196, 169, true);
            WriteLiteral("        <div class=\"thumbnail\" style=\"min-height: 350px; min-width:350px; max-height:350px; max-width:350px; border-radius: 15px; border-color: darkgrey;\">\r\n            ");
            EndContext();
            BeginContext(365, 549, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfb86b1554a04295bc7d4b3a5fc8a0e0", async() => {
                BeginContext(446, 22, true);
                WriteLiteral("\r\n                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 468, "\"", 484, 1);
#line 14 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
WriteAttributeValue("", 474, photoPath, 474, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(485, 115, true);
                WriteLiteral(" alt=\"\" class=\"thumbnailImg\" />\r\n                <div class=\"caption\">\r\n                    <h4 class=\"pull-right\">");
                EndContext();
                BeginContext(601, 25, false);
#line 16 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                      Write(Model.Price.ToString("c"));

#line default
#line hidden
                EndContext();
                BeginContext(626, 85, true);
                WriteLiteral("</h4>\r\n                    <h4 style=\"padding-right: 5px;\">\r\n                        ");
                EndContext();
                BeginContext(712, 10, false);
#line 18 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                   Write(Model.Name);

#line default
#line hidden
                EndContext();
                BeginContext(722, 123, true);
                WriteLiteral("\r\n                    </h4>\r\n                    <p style=\"position:inherit; padding-bottom:25px; word-break: break-word;\">");
                EndContext();
                BeginContext(846, 22, false);
#line 20 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                                                                         Write(Model.ShortDescription);

#line default
#line hidden
                EndContext();
                BeginContext(868, 42, true);
                WriteLiteral("</p>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 13 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                                                      WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(914, 172, true);
            WriteLiteral("\r\n                <div class=\"addToCart text-right\">\r\n                    <p class=\"button\" style=\" position:absolute; right: 12px; bottom:20px;\">\r\n                        ");
            EndContext();
            BeginContext(1086, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eaea27c34a4b4e76a6306c5f49da3daa", async() => {
                BeginContext(1222, 67, true);
                WriteLiteral("\r\n                            Add to cart\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 25 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                                                                                                                         WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1293, 68, true);
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n        </div>\r\n");
            EndContext();
#line 31 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1385, 169, true);
            WriteLiteral("        <div class=\"thumbnail\" style=\"min-height: 320px; min-width:350px; max-height:320px; max-width:350px; border-radius: 15px; border-color: darkgray;\">\r\n            ");
            EndContext();
            BeginContext(1554, 521, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8649c0d476864f74a5ff5179c4075c16", async() => {
                BeginContext(1635, 22, true);
                WriteLiteral("\r\n                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1657, "\"", 1673, 1);
#line 36 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
WriteAttributeValue("", 1663, photoPath, 1663, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1674, 115, true);
                WriteLiteral(" alt=\"\" class=\"thumbnailImg\" />\r\n                <div class=\"caption\">\r\n                    <h4 class=\"pull-right\">");
                EndContext();
                BeginContext(1790, 25, false);
#line 38 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                      Write(Model.Price.ToString("c"));

#line default
#line hidden
                EndContext();
                BeginContext(1815, 57, true);
                WriteLiteral("</h4>\r\n                    <h4>\r\n                        ");
                EndContext();
                BeginContext(1873, 10, false);
#line 40 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                   Write(Model.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1883, 123, true);
                WriteLiteral("\r\n                    </h4>\r\n                    <p style=\"position:inherit; padding-bottom:25px; word-break: break-word;\">");
                EndContext();
                BeginContext(2007, 22, false);
#line 42 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                                                                         Write(Model.ShortDescription);

#line default
#line hidden
                EndContext();
                BeginContext(2029, 42, true);
                WriteLiteral("</p>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 35 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
                                                                      WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2075, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 46 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Shared\ProductsSummary.cshtml"
    }

#line default
#line hidden
            BeginContext(2100, 14, true);
            WriteLiteral("\r\n</div>\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591