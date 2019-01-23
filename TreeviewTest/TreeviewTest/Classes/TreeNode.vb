Imports TreeviewTest

Public Class TreeNode
    Implements ITreeNode

    Public Property id() As String Implements ITreeNode.id

    Public Property icon() As String Implements ITreeNode.icon

    Public Property text() As String Implements ITreeNode.text

    Public Property children() As IEnumerable(Of ITreeNode) Implements ITreeNode.children
    Public Property hasChildren As Boolean

    Public Property state() As ITreeState Implements ITreeNode.state
End Class
