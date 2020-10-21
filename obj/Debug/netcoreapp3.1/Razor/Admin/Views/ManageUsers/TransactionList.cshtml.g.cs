#pragma checksum "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9c4674d86b78f66d2aa9eaf5ee3b9c0141540a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Admin_Views_ManageUsers_TransactionList), @"mvc.1.0.view", @"/Admin/Views/ManageUsers/TransactionList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9c4674d86b78f66d2aa9eaf5ee3b9c0141540a6", @"/Admin/Views/ManageUsers/TransactionList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74fccd026dea2f6b8f2a7eadfd256798d2ea5c97", @"/Admin/Views/_ViewImports.cshtml")]
    public class Admin_Views_ManageUsers_TransactionList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TransactionListModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
  
    var totalBuy = Model.Sum(x => x.Price);
    var totalDeposite = Model.Sum(x => x.Deposite);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card text-center\" style=\"padding:20px; margin-bottom:10px;\">\r\n    <span>খরজ : ");
#nullable restore
#line 13 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
           Write(totalBuy);

#line default
#line hidden
#nullable disable
            WriteLiteral(" টাকা</span>\r\n    <span>জমা : ");
#nullable restore
#line 14 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
           Write(totalDeposite);

#line default
#line hidden
#nullable disable
            WriteLiteral(" টাকা</span>\r\n    <span>বাকি : ");
#nullable restore
#line 15 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
             Write(totalBuy - totalDeposite);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" টাকা</span>
</div>

<table id=""transaction-list-table"" class=""table-striped"">
    <thead>
        <tr>
            <th>Date</th>
            <th>Description</th>
            <th>Price</th>
            <th>Deposite</th>
            <th>Added by</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 29 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
         foreach (var transaction in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 32 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
               Write(transaction.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
               Write(transaction.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
               Write(transaction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
               Write(transaction.Deposite);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
               Write(transaction.AddedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 38 "E:\Learning\HanifStore\Admin\Views\ManageUsers\TransactionList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <th>Date</th>\r\n            <th>Description</th>\r\n            <th>Price</th>\r\n            <th>Deposite</th>\r\n            <th>Added by</th>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n\r\n");
            DefineSection("renderTransactionScript", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#transaction-list-table\').DataTable();\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TransactionListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
