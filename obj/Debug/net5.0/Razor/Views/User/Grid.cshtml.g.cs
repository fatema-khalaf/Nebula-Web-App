#pragma checksum "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17fcea20485160891ec1e7499fb7a58f78934d6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Grid), @"mvc.1.0.view", @"/Views/User/Grid.cshtml")]
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
#line 1 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\_ViewImports.cshtml"
using Nebula;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\_ViewImports.cshtml"
using Nebula.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17fcea20485160891ec1e7499fb7a58f78934d6d", @"/Views/User/Grid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abb9c5bf3006f027fb83018853e24be3b85b8df6", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Grid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nebula.VM.HomeVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Retis lapen casen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
  
    Layout = "UseLayout";


#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"main-container col2-left-layout bounceInUp animated\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 343, "\"", 351, 0);
            EndWriteAttribute();
            WriteLiteral(@">

                <article class=""col-main"">
                    <div class=""page-title"">
                        <h1>All Books</h1>
                    </div>
                    <div class=""toolbar"">
                        <div class=""sorter"">
                            <div class=""view-mode""> <span title=""Grid"" class=""button button-active button-grid"">&nbsp;</span><a href=""#"" title=""List"" class=""button-list"">&nbsp;</a> </div>
                        </div>
                        <div id=""sort-by"">
                            <label class=""left"">Sort By: </label>
                            <ul>
                                <li>
                                    <a href=""#"">Position<span class=""right-arrow""></span></a>
                                    <ul>
                                        <li><a href=""#"">Name</a></li>
                                        <li><a href=""#"">Price</a></li>
                                        <li><a href=""#"">Position</a></li>
         ");
            WriteLiteral(@"                           </ul>
                                </li>
                            </ul>
                            <a class=""button-asc left"" href=""#"" title=""Set Descending Direction""><span class=""top_arrow""></span></a>
                        </div>
                        <div class=""pager"">
                            <div id=""limiter"">
                                <label>View: </label>
                                <ul>
                                    <li>
                                        <a href=""#"">15<span class=""right-arrow""></span></a>
                                        <ul>
                                            <li><a href=""#"">20</a></li>
                                            <li><a href=""#"">30</a></li>
                                            <li><a href=""#"">35</a></li>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
            WriteLiteral(@"
                            <div class=""pages"">
                                <label>Page:</label>
                                <ul class=""pagination"">
                                    <li><a href=""#"">«</a></li>
                                    <li class=""active""><a href=""#"">1</a></li>
                                    <li><a href=""#"">2</a></li>
                                    <li><a href=""#"">3</a></li>
                                    <li><a href=""#"">4</a></li>
                                    <li><a href=""#"">5</a></li>
                                    <li><a href=""#"">»</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class=""category-products"">
                        <ul class=""products-grid"">
");
#nullable restore
#line 70 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
                             foreach (var book in Model.ListBooks)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <li class=""item col-lg-4 col-md-3 col-sm-4 col-xs-6"" style=""width: auto;"">
                                    <div class=""item-inner"">
                                        <div class=""item-img"">
                                            <div class=""item-img-info"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 3720, "\"", 3800, 1);
#nullable restore
#line 76 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
WriteAttributeValue("", 3727, Url.ActionLink("Test", controller: "User", values: new { id = book.Id }), 3727, 73, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Retis lapen casen\" class=\"product-image\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "17fcea20485160891ec1e7499fb7a58f78934d6d8079", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3860, "~/uploads/Books/", 3860, 16, true);
#nullable restore
#line 76 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
AddHtmlAttributeValue("", 3876, book.ImageId, 3876, 15, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 3891, ".png", 3891, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                                                <div class=""new-label new-top-left"">New</div>
                                                <div class=""actions"">
                                                    <div class=""quick-view-btn""><a href=""#"" data-toggle=""tooltip"" data-placement=""right""");
            BeginWriteAttribute("title", " title=\"", 4229, "\"", 4237, 0);
            EndWriteAttribute();
            WriteLiteral(" data-original-title=\"Quick View\"> <span>Quick View</span></a></div>\r\n                                                    <div class=\"link-wishlist\"><a href=\"#\" data-toggle=\"tooltip\" data-placement=\"right\"");
            BeginWriteAttribute("title", " title=\"", 4443, "\"", 4451, 0);
            EndWriteAttribute();
            WriteLiteral(" data-original-title=\"Wishlist\"><span>Add to Wishlist</span></a></div>\r\n                                                    <div class=\"link-compare\"><a href=\"#\" data-toggle=\"tooltip\" data-placement=\"right\"");
            BeginWriteAttribute("title", " title=\"", 4658, "\"", 4666, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""Compare""><span>Add to Compare</span></a></div>
                                                    <div class=""add_cart"">
                                                        <button class=""button btn-cart"" type=""button"" data-toggle=""tooltip"" data-placement=""right""");
            BeginWriteAttribute("title", " title=\"", 4959, "\"", 4967, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""Add to Cart""><span>Add to Cart</span></button>
                                                    </div>
                                                </div>
                                                <div class=""rating"">
                                                    <div class=""ratings"">
                                                        <div class=""rating-box"">
                                                            <div class=""rating"" style=""width:80%""></div>
                                                        </div>
                                                        <p class=""rating-links""><a href=""#"">1 Review(s)</a> <span class=""separator"">|</span> <a href=""#"">Add Review</a> </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class=");
            WriteLiteral("\"item-info\">\r\n                                            <div class=\"info-inner\">\r\n                                                <div class=\"item-title\"><a href=\"#\" title=\"Retis lapen casen\">");
#nullable restore
#line 98 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
                                                                                                         Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a> </div>
                                                <div class=""item-content"">
                                                    <div class=""item-price"">
                                                        <div class=""price-box""><span class=""regular-price""><span class=""price"">$ ");
#nullable restore
#line 101 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
                                                                                                                            Write(book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </span> </span> </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
");
#nullable restore
#line 108 "C:\Users\Fatema\source\repos\Nebula\Nebula\Views\User\Grid.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                    </div>\r\n                </article>\r\n                <!--\t///*///======    End article  ========= //*/// -->\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Nebula.VM.HomeVm> Html { get; private set; }
    }
}
#pragma warning restore 1591