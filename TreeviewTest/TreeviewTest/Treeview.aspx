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

        //var jstreeControl = $("demo1");
        $(document).ready(function () {
            var state = $("#hiddenTest");
            if (state.val() !== '') {
                $("#demo1").jstree({
                    'core': {
                        'data': function (node, cb) {

                            var thisVar = this;
                            cb.call(thisVar, { d: JSON.parse(state.val()) });



                        },
                    },
                    "search": {

                        "case_insensitive": true,
                        'show_only_matches': true
                    },
                    "checkbox": { cascade: "", three_state: false, whole_node : false, tie_selection : false },
                    "state": { "key": "demo1" },

                    "plugins": ["themes", "json_data", "search", "checkbox", "wholerow", "state"]
                })
                    .on('check_node.jstree uncheck_node.jstree', function (e, data) {
                        alert('tsstsfghrtgrdyj');
                    })
                $(document).on('input propertychange paste', "#searchtest", function () {
                    var state = $("#hiddenTest");
                    var jstreeControl = $("#demo1");
                    $("#demo1").jstree(true).search($("#searchtest").val());
                });
                $(document).on('click', "#bTest", function () {
                    $("#hiddenSelected").val($("#demo1").jstree(true).get_selected());
                });
            }
        });



    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hiddenTest" runat="server" />
        <asp:HiddenField ID="hiddenSelected" runat="server" />
        <div>
            <asp:TextBox runat="server" ID="searchtest"></asp:TextBox>
            <asp:Button ID="bTest" runat="server" OnClick="bTest_Click" />

        </div>

        <div id="demo1">
        </div>
    </form>
</body>
</html>
