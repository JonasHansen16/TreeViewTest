Public Interface ITreeNode

    Property id As String
    Property text As String
    Property icon As String
    Property children As IEnumerable(Of ITreeNode)
    Property state As ITreeState
End Interface
