<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Treeview.aspx.vb" Inherits="TreeviewTest.Treeview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script
        src="https://code.jquery.com/jquery-3.3.1.js"
        integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60="
        crossorigin="anonymous"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/jstree/3.3.5/themes/default/style.min.css" />
<script src="//cdnjs.cloudflare.com/ajax/libs/jstree/3.3.5/jstree.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#demo1").jstree({
                'core': {
                    'data': {
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;",
                        url: "Treeview.aspx/GetAllNodes",
                        data: function (node) {
                            return '{ "operation" : "get_children", "id" : 1 }';
                        },
                        success: function (retval) {
                            return retval.d;
                        },
                        error: function (jqxhr, status, exception) {
                            alert('Exception:', exception);
                        }
                    }
                },
                "plugins": ["themes", "json_data", "search"]
            });
        });
        $(document).on('input propertychange paste',"#searchtest", function () {
            console.log($('#searchtest').val());
            $("#demo1").jstree(true).search($("#searchtest").val());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="searchtest"></asp:TextBox>
        <div id ="demo1">
            
        </div>
    </form>
</body>
</html>
