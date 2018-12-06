Imports TreeviewTest

Public Class TreeState
    Implements ITreeState

    Public Property opened() As Boolean Implements ITreeState.opened
    Public Property disabled() As Boolean Implements ITreeState.disabled
    Public Property selected() As Boolean Implements ITreeState.selected

End Class
