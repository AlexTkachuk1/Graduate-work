#pragma checksum "C:\Users\Кирито\source\repos\Graduate-work\Graduate-work\Views\User\Denied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "445d00efcd97d4ea02f8540cf2dc5a588f0d47df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Denied), @"mvc.1.0.view", @"/Views/User/Denied.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Кирито\source\repos\Graduate-work\Graduate-work\Views\_ViewImports.cshtml"
using Graduate_work;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Кирито\source\repos\Graduate-work\Graduate-work\Views\_ViewImports.cshtml"
using Graduate_work.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"445d00efcd97d4ea02f8540cf2dc5a588f0d47df", @"/Views/User/Denied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c83505a1ae71caef0bb2bd89da8c4609c657fb63", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Denied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"title\">\r\n    Приносим свои извинения ");
#nullable restore
#line 2 "C:\Users\Кирито\source\repos\Graduate-work\Graduate-work\Views\User\Denied.cshtml"
                       Write(ViewBag.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", но у вас недостаточно прав для посещения данной страницы.\r\n</div>");
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
