#pragma checksum "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a446cbe9403cf92834680e2a39ae6a980405e19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Admin_Views_ManageUsers_UserList), @"mvc.1.0.view", @"/Admin/Views/ManageUsers/UserList.cshtml")]
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
#line 1 "E:\Learning\HanifStore\Admin\Views\_ViewImports.cshtml"
using HanifStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Learning\HanifStore\Admin\Views\_ViewImports.cshtml"
using HanifStore.Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Learning\HanifStore\Admin\Views\_ViewImports.cshtml"
using HanifStore.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Learning\HanifStore\Admin\Views\_ViewImports.cshtml"
using HanifStore.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Learning\HanifStore\Admin\Views\_ViewImports.cshtml"
using HanifStore.Admin.Models.Role;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a446cbe9403cf92834680e2a39ae6a980405e19", @"/Admin/Views/ManageUsers/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74fccd026dea2f6b8f2a7eadfd256798d2ea5c97", @"/Admin/Views/_ViewImports.cshtml")]
    public class Admin_Views_ManageUsers_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UsersInformationModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-balance"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "user", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("ajax-modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#add-contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<table id=""table_id"" class=""table-striped"">
    <thead>
        <tr>
            <th>Name</th>
            <th>User name</th>
            <th>Phone number</th>
            <th>Village</th>
            <th>Father name</th>
            <th>Amount</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 437, "\"", 476, 2);
            WriteAttributeValue("", 444, "transactions?userId=", 444, 20, true);
#nullable restore
#line 19 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
WriteAttributeValue("", 464, user.UserId, 464, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
                                                          Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 19 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
                                                                           Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a446cbe9403cf92834680e2a39ae6a980405e196865", async() => {
                WriteLiteral("\r\n                        ");
#nullable restore
#line 23 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
                   Write(user.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
AddHtmlAttributeValue("", 717, user.UserId, 717, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>");
#nullable restore
#line 26 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
               Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
               Write(user.VillageName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
               Write(user.FatherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
               Write(user.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
    <tfoot>
        <tr>
            <th>Name</th>
            <th>User name</th>
            <th>Phone number</th>
            <th>Village</th>
            <th>Father name</th>
            <th>Amount</th>
        </tr>
    </tfoot>
</table>


<div class=""modal fade"" id=""add-contact"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addPositionsLabel"" aria-hidden=""true"">
    <div id=""AddContent"">
    </div>
</div>

");
            DefineSection("renderScript", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#table_id\').DataTable();\r\n        });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("regesterEvent", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 60 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script type=\"text/javascript\">\r\n            $(\"#");
#nullable restore
#line 63 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
           Write(user.UserId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""").click(function () {
                var userId = $(this)[0].id;
                $.ajax({
                    url: $(this).attr(""formaction"")+""?userId=""+userId,
                }).done(function (msg) {
                    $(""#AddContent"").html(msg);
                    $(""#add-contact"").modal(""show"");
                });
            });
        </script>
");
#nullable restore
#line 73 "E:\Learning\HanifStore\Admin\Views\ManageUsers\UserList.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Popup", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(""body"").on(""click"", ""#save"", function () {
            var form = $('form');
            var token = $('input[name=""__RequestVerificationToken""]', form).val();
            $.ajax({
                type: ""post"",
                url: form.attr('action'),
                data: {
                    __RequestVerificationToken: token,
                    customersBuy: {
                        Description: $(""#Description"").val(),
                        Price: $(""#Price"").val(),
                        Username: $(""#Username"").val(),
                        Deposite: $(""#Deposite"").val()
                    }
                },
                dataType: ""html"",
                success: function (result) {
                    $(""#add-contact"").modal(""hide"");
                    $(""#partial"").html(result);
                }
            });
            return false;
        });
    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UsersInformationModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
