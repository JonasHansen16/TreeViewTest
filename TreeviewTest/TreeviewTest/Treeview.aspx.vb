Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services

Public Class Treeview
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function GetAllNodes(id As String) As List(Of TreeNode)

        If id <> "#" Then

                Return CreateChildren(id, 3, "xxxx")

        End If
        Dim JsTreeArray = New List(Of TreeNode)

        JsTreeArray.AddRange(CreateChildren(0, 5, ""))
        JsTreeArray(0).hasChildren = True

        Return JsTreeArray
    End Function

    Private Shared Function CreateChildren(_ParentID As Integer, NumOfChildren As Integer, ParentName As String) As List(Of TreeNode)
        Dim G_JSTreeArray = New List(Of TreeNode)()
        Dim n = 10
        For index = 0 To NumOfChildren
            Dim CurrChildId = If(_ParentID = 0, n, ((_ParentID * 10) + index))
            Dim _G_JSTree = New TreeNode()
            _G_JSTree.id = CurrChildId
            _G_JSTree.text = If(_ParentID = 0, "root" + "-Child" + index.ToString(), ParentName + CurrChildId.ToString() + index.ToString())
            _G_JSTree.children = Nothing
            G_JSTreeArray.Add(_G_JSTree)
            n = n + 10
        Next



        Return G_JSTreeArray
    End Function
End Class