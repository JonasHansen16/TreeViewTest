Imports System.ComponentModel
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.UI
Imports System.Web.UI.WebControls
<DefaultProperty("Text"), ToolboxData("&lt;{0}:TreeControl runat=""server"" />")>
Public Class TreeControl
    Inherits WebControl
    Implements INamingContainer

    Private _plugins As New List(Of String)

    Dim ltrl As New Literal
    Dim NodesHiddenField As HiddenField
    Dim SelectedNodesHiddenField As HiddenField


    ''' <summary>
    ''' Nodes waarmee de treecontrol wordt opgebouwd
    ''' Verwacht een json-string van objecten die de interface ITreeNode implementeert
    ''' </summary>
    ''' <returns></returns>
    Public Property TreeNodes() As String
        Get
            Return NodesHiddenField.Value
        End Get
        Set(ByVal value As String)
            NodesHiddenField.Value = value
        End Set
    End Property

    ''' <summary>
    ''' Geeft alle ids van de nodes met een gecheckt checkbox
    ''' comma-seperated string
    ''' </summary>
    ''' <returns></returns>
    Public Property CheckedNodes() As String
        Get
            Return SelectedNodesHiddenField.Value
        End Get
        Private Set(value As String)
            SelectedNodesHiddenField.Value = value
        End Set
    End Property


    <Bindable(True), Category("Appearance"), DefaultValue("false"), Description("Determines if nodes have an accompanying checkbox for multiple selection. defaults to false")>
    Public Property CheckBox() As Boolean
        Get
            Return ViewState("enableCheckBox")
        End Get
        Set(ByVal value As Boolean)
            ViewState("enableCheckBox") = value
            _plugins.Add("'checkbox'")
        End Set
    End Property

    <Bindable(True), Category("Misc"), DefaultValue(""), Description("Id of the textbox used to search the TreeControl")>
    Public Property SearchTextBoxId() As String
        Get
            Dim s As String = ViewState("SearchTextBoxId")
            Return If(s = Nothing, "", s)
        End Get
        Set(ByVal value As String)
            ViewState("SearchTextBoxId") = value
            _plugins.Add("'search'")
        End Set
    End Property

    Public Sub New()
        Controls.Clear()

        _plugins.Add("'themes'")
        _plugins.Add("'json_data'")
        _plugins.Add("'wholerow'")
        _plugins.Add("'state'")

        NodesHiddenField = New HiddenField
        With NodesHiddenField
            .ID = "hfNodes"
        End With
        Controls.Add(NodesHiddenField)

        SelectedNodesHiddenField = New HiddenField
        With SelectedNodesHiddenField
            .ID = "hfSelectedNodes"
        End With
        Controls.Add(SelectedNodesHiddenField)
    End Sub

    Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

        ltrl.Text = GenerateLiteral()
        ltrl.RenderControl(writer)
        NodesHiddenField.RenderControl(writer)
        SelectedNodesHiddenField.RenderControl(writer)
    End Sub

    Protected Overrides Sub CreateChildControls()

        With ltrl
            .ID = "ltrlJavascript"
            .Text = ""
        End With
    End Sub

    Private Function GenerateLiteral() As String
        Dim sb As New System.Text.StringBuilder()

        sb.AppendLine("<script src='https://code.jquery.com/jquery-3.3.1.js' ")
        sb.AppendLine("integrity ='sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=' ")
        sb.AppendLine("crossorigin='anonymous'></script>")
        sb.AppendLine("<link rel='stylesheet' href='//cdnjs.cloudflare.com/ajax/libs/jstree/3.3.5/themes/default/style.min.css' />")
        sb.AppendLine("<script src='//cdnjs.cloudflare.com/ajax/libs/jstree/3.3.5/jstree.min.js'></script>")

        sb.AppendLine("    <script type='text/javascript'>")
        sb.AppendLine("        $(document).ready(function () {")
        sb.AppendLine("            var state = $('#" & Me.ClientID.Replace("$", "_") & "_hfNodes" & "');")
        sb.AppendLine("            if (state.val() !== '') {")
        sb.AppendLine("            $('#" & Me.ClientID.Replace("$", "_") & "_treeview" & "').jstree({")
        sb.AppendLine("                'core': {")
        sb.AppendLine("                    'data': function (node, cb) {")
        sb.AppendLine("                        var thisVar = this;")
        sb.AppendLine("                        cb.call(thisVar, { d: JSON.parse(state.val()) });")
        sb.AppendLine("                    },")
        sb.AppendLine("                },")
        sb.AppendLine("                'search': {")
        sb.AppendLine("                    'case_insensitive': true,")
        sb.AppendLine("                    'show_only_matches': true")
        sb.AppendLine("                },")

        If _plugins.Contains("'checkbox'") Then
            sb.AppendLine("                'checkbox': { cascade: '', three_state: false, tie_selection : false, whole_node : false },")
        End If

        sb.AppendLine("                'state': { 'key': '" & Me.ClientID.Replace("$", "_") & "_treeview' },")
        sb.AppendLine("                'plugins': [" & String.Join(",", _plugins) & "]")
        sb.AppendLine("            })")

        If _plugins.Contains("'checkbox'") Then
            sb.AppendLine("                    .on('check_node.jstree uncheck_node.jstree', function (e, data) {")
            sb.AppendLine("                        $('#" & Me.ClientID.Replace("$", "_") & "_hfSelectedNodes" & "').val($('#" & Me.ClientID.Replace("$", "_") & "_treeview" & "').jstree(true).get_checked());")
            sb.AppendLine("                    })")
        End If

        If _plugins.Contains("'search'") Then
            sb.AppendLine("            $(document).on('input propertychange paste', '#" & SearchTextBoxId & "', function () {")
            sb.AppendLine("                $('#" & Me.ClientID.Replace("$", "_") & "_treeview" & "').jstree(true).search($('#" & SearchTextBoxId & "').val());")
            sb.AppendLine("            });")
        End If

        sb.AppendLine("        }")
        sb.AppendLine("        });")
        sb.AppendLine("    </script>")
        sb.AppendLine("<div id=""" & Me.ClientID.Replace("$", "_") & "_treeview" & """></div>")
        sb.AppendLine("")
        sb.AppendLine("")
        sb.AppendLine("")
        sb.AppendLine("")
        Return sb.ToString()
    End Function
End Class
