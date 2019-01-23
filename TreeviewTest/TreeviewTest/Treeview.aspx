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
            $('#demo1').jstree({
                'core': {
                    'data': {
                        'url': function (node) {
                            return '/Treeview.aspx/GetAllNodes';
                        },
                        "type": 'POST',
                        "dataType": 'JSON',
                        "contentType": 'application/json;',
                        'data': function (node) {
                            return '{ "id" : ' + '"' + node.id + '"' + ' }';

                        },
                        'success': function (nodes) {

                            var validateChildrenArray = function (node) {

                                if (!node.children || node.children.length === 0) {
                                    node.children = node.hasChildren;
                                }
                                else {
                                    for (var i = 0; i < node.children.length; i++) {
                                        validateChildrenArray(node.children[i]);
                                    }
                                }
                            };

                            for (var i = 0; i < nodes.d.length; i++) {
                                validateChildrenArray(nodes.d[i]);
                            }
                        }
                    }
                }
            });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hiddenTest" runat="server" />
        <asp:HiddenField ID="hiddenSelected" runat="server" />
        <div>
            <asp:TextBox runat="server" ID="searchtest"></asp:TextBox>
        </div>

        <div id="demo1" runat="server">
        </div>
    </form>
</body>
</html>
