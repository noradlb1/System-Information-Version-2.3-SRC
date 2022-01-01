
Imports System.Drawing

''' <summary>
''' Implements the IDropDownDisplayAdapter by using the standard CheckBox
''' as the adaptedControl control.
''' </summary>
Friend NotInheritable Class CheckBoxDisplayAdapter
	Implements IDropDownDisplayAdapter

#Region " Private Members "

    Private WithEvents _CheckBox As CheckBox    ' the adaptedControl

#End Region

#Region " Constructor "

    Public Sub New(ByVal checkBox As CheckBox)
        Debug.Assert(Not checkBox Is Nothing)
        Me._CheckBox = checkBox
        checkBox.Appearance = Appearance.Button
        checkBox.TextAlign = ContentAlignment.MiddleCenter
    End Sub

#End Region

#Region " Public Events "

    Public Event DropDownAppearanceChanged As EventHandler Implements IDropDownDisplayAdapter.DropDownAppearanceChanged

#End Region

#Region " Public Properties "

    Public Property Color() As System.Drawing.Color Implements IDropDownDisplayAdapter.Color
        Get
            Return Me._CheckBox.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            ' Store the color in the BackColor property and set the ForeColor
            ' to a value that will make the displayed text readable.
            Me._CheckBox.BackColor = Value
            Me._CheckBox.ForeColor = ColorPicker.GetInvertedColor(Value)
        End Set
    End Property

    Public Property HasDropDownAppearance() As Boolean Implements IDropDownDisplayAdapter.HasDropDownAppearance
        Get
            Return Me._CheckBox.Checked
        End Get
        Set(ByVal Value As Boolean)
            Me._CheckBox.Checked = Value
        End Set
    End Property

    Public Property Text() As String Implements IDropDownDisplayAdapter.Text
        Get
            Return Me._CheckBox.Text
        End Get
        Set(ByVal Value As String)
            Me._CheckBox.Text = Value
        End Set
    End Property

    Public ReadOnly Property AdaptedControl() As System.Windows.Forms.Control Implements IDropDownDisplayAdapter.AdaptedControl
        Get
            Return Me._CheckBox
        End Get
    End Property

#End Region

#Region " Private Event Handlers "

    Private Sub _CheckBox_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _CheckBox.CheckStateChanged
        RaiseEvent DropDownAppearanceChanged(Me, EventArgs.Empty)
    End Sub

#End Region

End Class
