Imports System.Web.Script.Serialization

Public Class TreeControlTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         If Not Page.IsPostBack Then
            tcTest.TreeNodes = GetAllNodes()
        End If
    End Sub

    Public Shared Function GetAllNodes() As String
        Dim JsTreeArray = New List(Of TreeNode)

        Dim JsTree = New TreeNode()
        JsTree.text = "x1"
        JsTree.id = 10

        JsTreeArray.Add(JsTree)

        Dim jsTree2 = New TreeNode()
        Dim children As List(Of TreeNode) = {
            New TreeNode With {.text = "x1-11", .id = "201"},
            New TreeNode With {.text = "x1-12", .id = "202"},
            New TreeNode With {.text = "x1-13", .id = "203"},
            New TreeNode With {.text = "x1-14", .id = "204"}
        }.ToList()
        jsTree2.text = "x2"
        jsTree2.id = 20
        jsTree2.children = children
        jsTree2.state = New TreeState With {.selected = True}
        JsTreeArray.Add(jsTree2)

        Dim children2() As TreeNode = {
            New TreeNode With {.text = "x2-11", .id = "301"},
            New TreeNode With {.text = "x2-12", .id = "302", .children = {New TreeNode With {.text = "x2-21", .id = "3011"}}},
            New TreeNode With {.text = "x2-13", .id = "303"},
            New TreeNode With {.text = "x2-14", .id = "304"}
        }

        Dim jsTree3 = New TreeNode()
        jsTree3.text = "x3"
        jsTree3.id = 30
        jsTree3.children = children2
        jsTree3.state = New TreeState With {.selected = True, .opened = False}
        JsTreeArray.Add(jsTree3)

        Dim serializer = New JavaScriptSerializer()
        Return serializer.Serialize(JsTreeArray)

    End Function

    Protected Sub bTest_Click(sender As Object, e As EventArgs)
    End Sub
End Class