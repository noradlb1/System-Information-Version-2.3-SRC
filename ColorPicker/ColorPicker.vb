Imports System.Drawing
Imports System.Windows.Forms.Design
Imports System.ComponentModel

''' <summary>
''' Defines the appearance of the control.
''' </summary>
Public Enum ColorPickerAppearance
    Button = 0
    ComboBox = 1
    EditableComboBox = 2
    Custom = 3
End Enum

<DefaultProperty("Color"), DefaultEvent("ColorChanged")> _
Public Class ColorPicker
    Inherits Control

#Region " Private Members "

    ' The IDropDownDisplayAdapter implementation used to render the required appearance
    ' of the control.
    Private WithEvents _DisplayAdapter As IDropDownDisplayAdapter

    ' Should the control display the color's name?
    Private _TextDisplayed As Boolean = True

    ' The IWindowsFormsEditorService implementation used to display the drop-down window.
    Private _EditorService As WindowsFormsEditorService

    ' The event is raised when the Color property changes.
    Public Event ColorChanged As EventHandler

    Private Const DefaultColorName As String = "Black"
    Private Const DefaultWidth As Integer = 121

#End Region

#Region " Contructor "

    Public Sub New(ByVal clr As Color)
        MyBase.New()

        ' Init the display adapter.
        Me.DisplayAdapter = New ComboBoxDisplayAdapter(New EditableComboBoxDisplay)
        Me.SetColor(clr)

        _EditorService = New WindowsFormsEditorService(Me)
        MyBase.TabStop = False
    End Sub

    Public Sub New()
        Me.New(System.Drawing.Color.FromName(DefaultColorName))
    End Sub

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' The currently selected color.
    ''' </summary>
    <Description("The currently selected color."), Category("Appearance"), _
    DefaultValue(GetType(Color), DefaultColorName)> _
    Public Property Color() As Color
        Get
            Return Me._DisplayAdapter.Color
        End Get
        Set(ByVal Value As Color)
            Me.SetColor(Value)
            RaiseEvent ColorChanged(Me, EventArgs.Empty)
        End Set
    End Property

    ''' <summary>
    ''' True means the control displays the currently selected color's name, False otherwise.
    ''' </summary>
    <Description("True means the control displays the currently selected color's name, False otherwise."), _
    Category("Appearance"), DefaultValue(True)> _
    Public Property TextDisplayed() As Boolean
        Get
            Return _TextDisplayed
        End Get
        Set(ByVal Value As Boolean)
            _TextDisplayed = Value
            Me.SetColor(Me.Color)
        End Set
    End Property

    ''' <summary>
    ''' Sets or returns the appearance of the control.
    ''' </summary>
    <Description("Sets or returns the appearance of the control."), _
    Category("Appearance"), DefaultValue(ColorPickerAppearance.Button)> _
    Public Property Appearance() As ColorPickerAppearance
        Get
            ' Return the appropriate enum constant according to the type of the control
            ' used for rendering.
            ' Note: We must check the EditableComboBoxDisplay type BEFORE the ComboBoxDisplay
            ' type, because the EditableComboBoxDisplay control derives from ComboBoxDisplay.
            ' If we'd have checked the ComboBoxDisplay type first, even the EditableComboBoxDisplay
            ' would satisfy the test.
            If TypeOf Me._DisplayAdapter.AdaptedControl Is CheckBox Then
                Return ColorPickerAppearance.Button
            ElseIf TypeOf Me._DisplayAdapter.AdaptedControl Is EditableComboBoxDisplay Then
                Return ColorPickerAppearance.EditableComboBox
            ElseIf TypeOf Me._DisplayAdapter.AdaptedControl Is ComboBoxDisplay Then
                Return ColorPickerAppearance.ComboBox
            Else
                Return ColorPickerAppearance.Custom
            End If
        End Get
        Set(ByVal Value As ColorPickerAppearance)
            ' NOOP if the appearance wouldn't change.
            If Value = Me.Appearance Then
                Return
            End If

            ' Instantiate and set the appropriate IDropDownDisplayAdapter implementation.
            If Value = ColorPickerAppearance.Button Then
                Me.DisplayAdapter = New CheckBoxDisplayAdapter(New CheckBox)
            ElseIf Value = ColorPickerAppearance.ComboBox Then
                Me.DisplayAdapter = New ComboBoxDisplayAdapter(New ComboBoxDisplay)
            ElseIf Value = ColorPickerAppearance.EditableComboBox Then
                Me.DisplayAdapter = New ComboBoxDisplayAdapter(New EditableComboBoxDisplay)
            Else
                Throw New InvalidOperationException( _
                 "To set custom appearance, set the ColorPicker.DisplayAdapter property at runtime.")
            End If

        End Set
    End Property

    ''' <summary>
    ''' Associates the IDropDownDisplayAdapter implementation with the control.
    ''' </summary>
    <Browsable(False)> _
    Public Property DisplayAdapter() As IDropDownDisplayAdapter
        Get
            Return Me._DisplayAdapter
        End Get
        Set(ByVal Value As IDropDownDisplayAdapter)
            If Value Is Nothing Then
                Throw New ArgumentNullException("Value")
            End If

            ' To centralize control, this method is called from the constructor as well as from
            ' user code. In the call from user code, we have to preserve the current color selection
            ' so it doesn't change to default color after the adapter is set up.
            Dim SavedColor As Color = Color.Black
            If Not Me._DisplayAdapter Is Nothing Then
                SavedColor = Me._DisplayAdapter.Color
            End If
            Me.Controls.Clear()
            Me._DisplayAdapter = Value
            Me._DisplayAdapter.AdaptedControl.Dock = DockStyle.Fill
            Me.Controls.Add(Me._DisplayAdapter.AdaptedControl)
            Me.SetColor(SavedColor)
        End Set
    End Property

    ''' <summary>
    ''' We've shadowed the TabStop property, because we don't want the control to be tabbed to directly.
    ''' Instead, the adaptedControl control is used to interact with the user, so we delegate to it.
    ''' </summary>
    Public Shadows Property TabStop() As Boolean
        Get
            Return Me._DisplayAdapter.AdaptedControl.TabStop
        End Get
        Set(ByVal Value As Boolean)
            Me._DisplayAdapter.AdaptedControl.TabStop = Value
        End Set
    End Property

    ''' <summary>
    ''' No need to display ForeColor and BackColor and Text in the property browser.
    ''' </summary>
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            MyBase.ForeColor = Value
        End Set
    End Property

    ''' <summary>
    ''' No need to display ForeColor and BackColor and Text in the property browser.
    ''' </summary>
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            MyBase.BackColor = Value
        End Set
    End Property

    ''' <summary>
    ''' No need to display ForeColor and BackColor and Text in the property browser.
    ''' </summary>
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
        End Set
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Primitive color inversion.
    ''' </summary>
    Public Shared Function GetInvertedColor(ByVal clr As Color) As Color
        If (CInt(clr.R) + CInt(clr.G) + CInt(clr.B)) > ((255I * 3I) \ 2I) Then
            Return System.Drawing.Color.Black
        Else
            Return System.Drawing.Color.White
        End If
    End Function

    ''' <summary>
    ''' Shortcut to the system-provided Color type converter.
    ''' </summary>
    Public Shared ReadOnly Property ColorTypeConverter() As TypeConverter
        Get
            Static _Converter As TypeConverter
            If _Converter Is Nothing Then
                _Converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(Color))
                Debug.Assert(Not _Converter Is Nothing)
            End If
            Return _Converter
        End Get
    End Property

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Sets the associated CheckBox color and Text according to the TextDisplayed property value.
    ''' </summary>
    Private Sub SetColor(ByVal c As Color)
        Me._DisplayAdapter.Color = c
        If _TextDisplayed Then
            Me._DisplayAdapter.Text = ColorPicker.ColorTypeConverter.ConvertToString(c)
        Else
            Me._DisplayAdapter.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' If the associated display is dropped down, we'll display the drop-down UI. Otherwise we'll close it.
    ''' </summary>
    Private Sub OnDropDownAppearanceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _DisplayAdapter.DropDownAppearanceChanged
        If Me._DisplayAdapter.HasDropDownAppearance Then
            Me.ShowDropDown()
        Else
            Me.CloseDropDown()
        End If
    End Sub

    Private Sub ShowDropDown()
        Try
            ' This is the Color type editor - it displays the drop-down UI calling
            ' our IWindowsFormsEditorService implementation.
            Dim Editor As New System.Drawing.Design.ColorEditor

            ' Display the UI.
            Dim C As Color = Me.Color
            Dim NewValue As Object = Editor.EditValue(_EditorService, C)

            ' If the user didn't cancel the selection, remember the new color.
            If (Not NewValue Is Nothing) AndAlso (Not _EditorService.Canceled) Then
                Me.Color = CType(NewValue, Color)
            End If

            ' Finally, "pop-up" the associated dropdow display.
            Me._DisplayAdapter.HasDropDownAppearance = False

        Catch ex As Exception
            Trace.WriteLine(ex.ToString())
        End Try

    End Sub

    Private Sub CloseDropDown()
        _EditorService.CloseDropDown()
    End Sub

#End Region

#Region " Protected Methods "

    ''' <summary>
    ''' Invalidate the display so it shows the focus rectangle.
    ''' </summary>
    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        MyBase.OnEnter(e)
        Me._DisplayAdapter.AdaptedControl.Invalidate()
    End Sub

    ''' <summary>
    ''' Invalidate the display so it doesn't show the focus rectangle.
    ''' </summary>
    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e)
        Me._DisplayAdapter.AdaptedControl.Invalidate()
    End Sub

#End Region

#Region " Protected Properties "

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(ColorPicker.DefaultWidth, SystemInformation.CaptionHeight + 1)
        End Get
    End Property

#End Region

End Class



