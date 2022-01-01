
''' <summary>
''' Implements the IDropDownDisplayAdapter by using the ComboBoxDisplay
''' as the adaptedControl control.
''' </summary>
Public NotInheritable Class ComboBoxDisplayAdapter
    Implements IDropDownDisplayAdapter

#Region " Private Members "

    ' The ComboBoxDisplay control - our adaptedControl.
    Private WithEvents _Display As ComboBoxDisplay

#End Region

#Region " Constructor "

    Public Sub New(ByVal display As ComboBoxDisplay)
        If display Is Nothing Then
            Throw New ArgumentNullException("display")
        End If
        Me._Display = display
    End Sub

#End Region

#Region " Public Events "

    Public Event DropDownAppearanceChanged As EventHandler Implements IDropDownDisplayAdapter.DropDownAppearanceChanged

#End Region

#Region " Public Properties "

    Public ReadOnly Property AdaptedControl() As System.Windows.Forms.Control Implements IDropDownDisplayAdapter.AdaptedControl
        Get
            Return Me._Display
        End Get
    End Property

    Public Property Color() As System.Drawing.Color Implements IDropDownDisplayAdapter.Color
        Get
            Return Me._Display.Color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            Me._Display.Color = Value
        End Set
    End Property

    Public Property HasDropDownAppearance() As Boolean Implements IDropDownDisplayAdapter.HasDropDownAppearance
        Get
            Return Me._Display.HasDropDownAppearance
        End Get
        Set(ByVal Value As Boolean)
            Me._Display.HasDropDownAppearance = Value
        End Set
    End Property

    Public Property Text() As String Implements IDropDownDisplayAdapter.Text
        Get
            Return Me._Display.Text
        End Get
        Set(ByVal Value As String)
            Me._Display.Text = Value
        End Set
    End Property

#End Region

#Region " Private Event Handlers "

    Private Sub _Display_DropDownAppearanceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Display.DropDownAppearanceChanged
        RaiseEvent DropDownAppearanceChanged(Me, e)
    End Sub

#End Region

End Class
