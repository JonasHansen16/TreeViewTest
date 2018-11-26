Imports System.Web.Script.Services
Imports System.Web.Services

Public Class Treeview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <System.Web.Services.WebMethod()>
    <ScriptMethod(ResponseFormat:= ResponseFormat.Json)>
    Public Shared Function GetAllNodes(id As String) As List(Of G_JsTree)
        dim JsTreeArray = New List(Of G_JsTree)

        Dim JsTree = New G_JsTree()
        JsTree.data = "x1"
        JsTree.text = "x1"
        JsTree.state = "closed"
        JsTree.IdServerUse = 10
        JsTree.children = Nothing
        JsTree.attr = New G_JsTreeAttribute With { .id= 10, .selected = False}
        
       JsTreeArray.Add(JsTree)

        Dim jsTree2 = New G_JsTree()
        Dim children() as G_JsTree = {
            New G_JsTree With{ .text = "x1-11", .attr = New G_JsTreeAttribute With { .id = "201"}},
            New G_JsTree With{ .text = "x1-12", .attr = New G_JsTreeAttribute With { .id = "202"}},
            New G_JsTree With{ .text = "x1-13", .attr = New G_JsTreeAttribute With { .id = "203"}},
            New G_JsTree With{ .text = "x1-14", .attr = New G_JsTreeAttribute With { .id = "204"}}
        }
        jsTree2.data = "x2"
        jsTree2.text = "x2"
        jsTree2.IdServerUse = 20
        JsTree.state = "closed"
        jsTree2.children = children
        jsTree2.attr = New G_JsTreeAttribute With { .id = "20", .selected = True}
        JsTreeArray.Add(jsTree2)

        Dim children2() as G_JsTree = {
            New G_JsTree With{ .text = "x2-11", .attr = New G_JsTreeAttribute With { .id = "301"}},
            New G_JsTree With{ .text = "x2-12", .attr = New G_JsTreeAttribute With { .id = "302"}, .children = { New G_JsTree With { .data = "x2-21" , .text = "x2-21", .attr = New G_JsTreeAttribute With{.id="3011"}}}},
            New G_JsTree With{ .text = "x2-13", .attr = New G_JsTreeAttribute With { .id = "303"}},
            New G_JsTree With{ .text = "x2-14", .attr = New G_JsTreeAttribute With { .id = "304"}}
        }

        Dim jsTree3 = New G_JsTree()
        jsTree3.data = "x3"
        jsTree3.text = "x3"
        jsTree3.state = "closed"
        jsTree3.IdServerUse = 30
        jsTree3.children = children2
        jsTree3.attr = New G_JsTreeAttribute With { .id = "30", .selected = True}
        JsTreeArray.Add(jsTree3)
        
        Return JsTreeArray
                
    End Function
End Class