#pragma checksum "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8adec5729916c857cbdc458cf3f9b07f31f75773"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8adec5729916c857cbdc458cf3f9b07f31f75773", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d09d122bad99a9bdca5e34e7cba2d437e3cbce2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(25, 35, false);
#line 3 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("Carousel"));

#line default
#line hidden
            EndContext();
            BeginContext(60, 62, true);
            WriteLiteral("\r\n\r\n<h2>Featured Products</h2>\r\n<h4>Customer\'s Choice</h4>\r\n\r\n");
            EndContext();
#line 8 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Home\Index.cshtml"
 foreach (var product in Model.PreferredProducts)
{
    

#line default
#line hidden
            BeginContext(181, 40, false);
#line 10 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Home\Index.cshtml"
Write(Html.Partial("ProductsSummary", product));

#line default
#line hidden
            EndContext();
#line 10 "I:\VC\Backup\BCAD\Year 3\Semester 1\PROG3A\Task 2\PROG7311 Task 2 - Karl Dicks - 17667327\v23\ACME\ACME\Views\Home\Index.cshtml"
                                             
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
