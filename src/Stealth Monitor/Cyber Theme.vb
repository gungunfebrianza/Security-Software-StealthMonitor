Imports System.Drawing.Drawing2D
''' <summary>
''' Credits
''' </summary>
''' <remarks>
''' Conversion Functions - Tedd
''' Rounded Rectangle - Tedd
''' Graphite Button - Tedd
''' Graphite Toggle Button - Programming by Tedd, idea from Ubuntu OS
''' Graphite Frame - Tedd
''' Graphite Progress Bar - Tedd
''' Graphite Radio - Tedd
''' Graphite Tab Control - Design by Tedd, OwnerDraw method by xZ3R0xPR0J3CTx (Mentor / Friend)
''' Graphite Theme - Tedd
''' Graphite Trackbar - Tedd, idea from Carbon Theme by AeonHack and GREENEXXX
''' Graphite Seperator - Tedd
''' Graphite ComboBox - Design by Tedd, OwnerDraw method by xZ3R0xPR0J3CTx (Mentor / Friend)
'''
''' Contact:
''' Tedd           - HackForums.net Forum  or  Tedd.Zublansky@blackhax.com
''' xZ3R0xPR0J3CTx - HackForums.net Forum
''' AeonHack       - HackForums.net Forum
''' GREENEXXX      - HackForums.net Forum</remarks>

Module ConversionFunctions
    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return New SolidBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return New SolidBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, R, G, B)))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(R, G, B)))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, C)))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return New Pen(New SolidBrush(Color))
    End Function
End Module
Module RRM
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
End Module

Class GraphiteButton
    Inherits Control

    Enum MouseState
        None = 0
        Over = 1
        Down = 2
    End Enum

    Private State As MouseState = 0

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.FillRectangle(ToBrush(Color.FromArgb(232, 232, 232)), ClientRectangle)
        G.FillRectangle(ToBrush(120, Color.White), New Rectangle(0, 0, Width, CInt(Height / 2)))
        Select Case Enabled
            Case True
                Select Case State
                    Case MouseState.Over
                        Dim Whit As New GraphicsPath
                        Whit.AddEllipse(New Rectangle(0, 0, Width, Height * 2))

                        Dim Whity As New PathGradientBrush(Whit)
                        Whity.CenterColor = Color.FromArgb(120, Color.White)

                        Whity.SurroundColors = New Color() {Color.Transparent}

                        G.FillEllipse(Whity, New Rectangle(0, 0, Width, Height * 2))
                    Case MouseState.Down
                        Dim Whit As New GraphicsPath
                        Whit.AddEllipse(New Rectangle(0, 0, Width, Height * 2))

                        Dim Whity As New PathGradientBrush(Whit)
                        Whity.CenterColor = Color.FromArgb(120, Color.White)

                        Whity.SurroundColors = New Color() {Color.Transparent}

                        G.FillEllipse(Whity, New Rectangle(0, 0, Width, Height * 2))
                        G.FillRectangle(ToBrush(20, Color.Black), ClientRectangle)
                End Select

                G.DrawString(Text, Font, Brushes.Black, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)), CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2))))
            Case False
                G.DrawString(Text, Font, Brushes.White, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)) + 1, CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2)) + 1))
                G.DrawString(Text, Font, Brushes.Gray, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)), CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2))))
        End Select


        G.SmoothingMode = SmoothingMode.HighQuality
        G.DrawPath(ToPen(157, 157, 157), RoundRect(0, 0, Width - 1, Height - 1, 2))
        G.DrawRectangle(ToPen(40, Color.White), New Rectangle(1, 1, Width - 3, Height - 3))
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e) : State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e) : State = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : State = MouseState.Over : Invalidate()
    End Sub
End Class

Class GraphiteButtonToggle
    Inherits Control

    Private _toggled As Boolean
    Public Property Toggled() As Boolean
        Get
            Return _toggled
        End Get
        Set(ByVal value As Boolean)
            _toggled = value
            Invalidate()
        End Set
    End Property

    Enum MouseState
        None = 0
        Over = 1
        Down = 2
    End Enum

    Private State As MouseState = 0

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.FillRectangle(ToBrush(Color.FromArgb(232, 232, 232)), ClientRectangle)
        G.FillRectangle(ToBrush(120, Color.White), New Rectangle(0, 0, Width, CInt(Height / 2)))
        Select Case Enabled
            Case True
                If Not Toggled Then
                    Select Case State
                        Case MouseState.Over
                            Dim Whit As New GraphicsPath
                            Whit.AddEllipse(New Rectangle(0, 0, Width, Height * 2))

                            Dim Whity As New PathGradientBrush(Whit)
                            Whity.CenterColor = Color.FromArgb(120, Color.White)

                            Whity.SurroundColors = New Color() {Color.Transparent}

                            G.FillEllipse(Whity, New Rectangle(0, 0, Width, Height * 2))
                        Case MouseState.Down
                            Dim Whit As New GraphicsPath
                            Whit.AddEllipse(New Rectangle(0, 0, Width, Height * 2))

                            Dim Whity As New PathGradientBrush(Whit)
                            Whity.CenterColor = Color.FromArgb(120, Color.White)

                            Whity.SurroundColors = New Color() {Color.Transparent}

                            G.FillEllipse(Whity, New Rectangle(0, 0, Width, Height * 2))
                            G.FillRectangle(ToBrush(20, Color.Black), ClientRectangle)
                    End Select
                Else
                    Dim Whit As New GraphicsPath
                    Whit.AddEllipse(New Rectangle(0, 0, Width, Height * 2))

                    Dim Whity As New PathGradientBrush(Whit)
                    Whity.CenterColor = Color.FromArgb(120, Color.White)

                    Whity.SurroundColors = New Color() {Color.Transparent}

                    G.FillEllipse(Whity, New Rectangle(0, 0, Width, Height * 2))
                    G.FillRectangle(ToBrush(20, Color.Black), ClientRectangle)
                End If

                G.DrawString(Text, Font, Brushes.Black, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)), CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2))))
            Case False
                G.DrawString(Text, Font, Brushes.White, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)) + 1, CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2)) + 1))
                G.DrawString(Text, Font, Brushes.Gray, New Point(CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2)), CInt((Height / 2) - (G.MeasureString(Text, Font).Height / 2))))
        End Select


        G.SmoothingMode = SmoothingMode.HighQuality
        G.DrawPath(ToPen(157, 157, 157), RoundRect(0, 0, Width - 1, Height - 1, 2))
        G.DrawRectangle(ToPen(40, Color.White), New Rectangle(1, 1, Width - 3, Height - 3))
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e) : State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e) : State = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e) : Toggled = Not Toggled : Invalidate()
    End Sub
End Class

Class GraphiteFrame
    Inherits ContainerControl
    Enum TAlign
        Left = 0
        Center = 1
        Right = 2
    End Enum

    Private TA As TAlign
    Public Property TextAlignment() As TAlign
        Get
            Return TA
        End Get
        Set(ByVal value As TAlign)
            TA = value
            Invalidate()
        End Set
    End Property

    Sub New()
        Size = New Size(275, 75)
        TA = TAlign.Left
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics

        G.Clear(Color.FromArgb(236, 237, 239))

        G.DrawRectangle(ToPen(165, 166, 168), New Rectangle(0, CInt(G.MeasureString(Text, Font).Height / 2), Width - 1, Height - 1 - CInt(G.MeasureString(Text, Font).Height / 2)))

        Dim TOff As Integer = 0
        Select Case TA
            Case TAlign.Left
                TOff = 6
            Case TAlign.Right
                TOff = Width - 6 - G.MeasureString(Text, Font).Width
            Case TAlign.Center
                TOff = CInt((Width / 2) - (G.MeasureString(Text, Font).Width / 2))
        End Select

        G.FillRectangle(ToBrush(236, 237, 239), New Rectangle(New Point(TOff, 0), G.MeasureString(Text, Font).ToSize))

        G.DrawString(Text, Font, Brushes.Black, TOff, 0)
    End Sub
End Class

Class GraphiteProgress
    Inherits Control

    Private Max As Integer
    Public Property Maximum() As Integer
        Get
            Return Max
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then Max = value
            If Max < Val Then Val = Max
            Invalidate()
        End Set
    End Property

    Private Val As Integer
    Public Property Value() As Integer
        Get
            Return Val
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then Val = 0 Else If value > Max Then Val = Max Else Val = value
            Invalidate()
        End Set
    End Property

    Sub New()
        Max = 100
    End Sub

    Protected Overrides Sub CreateHandle()
        DoubleBuffered = True
        MyBase.CreateHandle()
        Dim Animation As New Timer With {.Interval = 50}
        AddHandler Animation.Tick, AddressOf AnimationHandle
        Animation.Start()
    End Sub

    Dim Offset As Integer = 0

    Sub AnimationHandle()
        If Offset < 7 Then Offset += 1 Else Offset = 0
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality

        G.Clear(Color.FromArgb(225, 226, 228))

        Dim Fill As Rectangle = New Rectangle(2, 2, CInt((Width - 5) * (Val / Max)), Height - 5)
        G.FillRectangle(ToBrush(180, Color.Black), Fill)

        G.RenderingOrigin = New Point(Offset, 0)
        Dim KP As New HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(40, Color.Black), Color.Empty)
        G.FillRectangle(KP, Fill)

        'If Value > 2 Then
        '    For x = 0 To Math.Floor(Fill.Width / 10)
        '        Dim points As Point() = {New Point(x * 10, 3), New Point((x * 10) - 5, Height - 3), New Point((x * 10) - 10, Height - 3), New Point((x * 10) - 5, 3)}
        '        G.FillPolygon(ToBrush(40, Color.Black), points)
        '    Next
        'End If

        G.DrawRectangle(ToPen(40, Color.Black), Fill)
        G.FillRectangle(ToBrush(40, Color.White), New Rectangle(0, 0, Width, CInt(Height / 2)))
        G.DrawPath(ToPen(50, Color.Black), RoundRect(0, 0, Width - 1, Height - 1, 2))
    End Sub
End Class

Class GraphiteRadio
    Inherits Control

    Private [Check] As Boolean
    Public Property Checked() As Boolean
        Get
            Return [Check]
        End Get
        Set(ByVal value As Boolean)
            [Check] = value
            Invalidate()
        End Set
    End Property

    Private aZ As Boolean
    Public Overrides Property Autosize() As Boolean
        Get
            Return aZ
        End Get
        Set(ByVal value As Boolean)
            aZ = value
            Invalidate()
        End Set
    End Property


    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        Autosize = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim Ell As Rectangle = New Rectangle(0, 0, 12, 12)
        Dim G As Graphics = e.Graphics

        If Autosize Then
            Size = New Size(Ell.Width + 5 + G.MeasureString(Text, Font).Width, _
                                  Ell.Height + 1)
        End If

        G.Clear(Parent.FindForm.BackColor)
        G.SmoothingMode = SmoothingMode.HighQuality

        If Enabled Then
            G.FillEllipse(Brushes.White, Ell)
            G.DrawEllipse(ToPen(40, Color.Black), Ell)

            If Checked Then
                G.FillEllipse(ToBrush(180, Color.Black), New Rectangle(New Point(Ell.X + 3, Ell.Y + 3), New Size(Ell.Width - 6, Ell.Height - 6)))
            End If

            G.DrawString(Text, Font, Brushes.Black, New Point(5 + Ell.X + Ell.Width, CInt(((Ell.Y + Ell.Width) / 2) - (G.MeasureString(Text, Font).Height / 2))))
        Else
            G.DrawEllipse(ToPen(40, Color.Black), Ell)

            If Checked Then
                G.FillEllipse(ToBrush(80, Color.Black), New Rectangle(New Point(Ell.X + 3, Ell.Y + 3), New Size(Ell.Width - 6, Ell.Height - 6)))
            End If

            G.DrawString(Text, Font, Brushes.DimGray, New Point(5 + Ell.X + Ell.Width, CInt(((Ell.Y + Ell.Width) / 2) - (G.MeasureString(Text, Font).Height / 2))))
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        If Enabled Then
            If Not Checked Then Checked = True

            For Each ctl As Control In Parent.Controls
                If TypeOf ctl Is GraphiteRadio Then
                    If ctl.Handle = Me.Handle Then Continue For
                    If ctl.Enabled Then DirectCast(ctl, GraphiteRadio).Checked = False
                End If
            Next
        End If
    End Sub
End Class

Class GraphiteTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or _
        ControlStyles.UserPaint Or _
        ControlStyles.DoubleBuffer, True)
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Select Case Alignment
            Case TabAlignment.Left
                SizeMode = TabSizeMode.Fixed
                ItemSize = New Size(20, 75)
            Case TabAlignment.Right
                SizeMode = TabSizeMode.Fixed
                ItemSize = New Size(20, 75)
            Case Else
                SizeMode = TabSizeMode.Normal
                ItemSize = New Size(77, 21)
        End Select
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim ItemBounds As Rectangle
        Dim TextBrush As New SolidBrush(Color.Empty)
        Dim SOFF As Integer = 0
        G.Clear(Color.FromArgb(236, 237, 239))



        For TabItemIndex As Integer = 0 To Me.TabCount - 1
            ItemBounds = Me.GetTabRect(TabItemIndex)

            If Not TabItemIndex = SelectedIndex Then
                SOFF = 2

                Select Case Alignment
                    Case TabAlignment.Left
                        G.FillPath(ToBrush(216, 217, 219), RoundRect(New Rectangle(New Point(ItemBounds.X + SOFF, ItemBounds.Y), New Size(ItemBounds.Width, ItemBounds.Height)), 2))
                        G.DrawPath(ToPen(90, Color.Black), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y), New Size(ItemBounds.Width, ItemBounds.Height)), 2))

                        Dim sf As New StringFormat
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                        TextBrush.Color = Color.FromArgb(80, 80, 80)
                        Try
                            G.DrawString(TabPages(TabItemIndex).Text, New Font(Font.Name, Font.Size - 1), TextBrush, New Rectangle(GetTabRect(TabItemIndex).Location, GetTabRect(TabItemIndex).Size), sf)
                            TabPages(TabItemIndex).BackColor = Color.FromArgb(236, 237, 239)
                        Catch : End Try
                    Case TabAlignment.Right
                        G.FillPath(ToBrush(216, 217, 219), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))
                        G.DrawPath(ToPen(90, Color.Black), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))

                        Dim sf As New StringFormat
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                        TextBrush.Color = Color.FromArgb(80, 80, 80)
                        Try
                            G.DrawString(TabPages(TabItemIndex).Text, New Font(Font.Name, Font.Size - 1), TextBrush, New Rectangle(GetTabRect(TabItemIndex).Location, GetTabRect(TabItemIndex).Size), sf)
                            TabPages(TabItemIndex).BackColor = Color.FromArgb(236, 237, 239)
                        Catch : End Try
                    Case TabAlignment.Top
                        G.FillPath(ToBrush(216, 217, 219), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))
                        G.DrawPath(ToPen(90, Color.Black), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))

                        Dim sf As New StringFormat
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                        TextBrush.Color = Color.FromArgb(80, 80, 80)
                        Try
                            G.DrawString(TabPages(TabItemIndex).Text, New Font(Font.Name, Font.Size - 1), TextBrush, New Rectangle(GetTabRect(TabItemIndex).Location, GetTabRect(TabItemIndex).Size), sf)
                            TabPages(TabItemIndex).BackColor = Color.FromArgb(236, 237, 239)
                        Catch : End Try
                    Case TabAlignment.Bottom
                        G.FillPath(ToBrush(216, 217, 219), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y - 6 + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))
                        G.DrawPath(ToPen(90, Color.Black), RoundRect(New Rectangle(New Point(ItemBounds.X, ItemBounds.Y - 6 + SOFF), New Size(ItemBounds.Width, ItemBounds.Height)), 2))

                        Dim sf As New StringFormat
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                        TextBrush.Color = Color.FromArgb(80, 80, 80)
                        Try
                            G.DrawString(TabPages(TabItemIndex).Text, New Font(Font.Name, Font.Size - 1), TextBrush, New Rectangle(GetTabRect(TabItemIndex).Location - New Point(0, 2), GetTabRect(TabItemIndex).Size), sf)
                            TabPages(TabItemIndex).BackColor = Color.FromArgb(236, 237, 239)
                        Catch : End Try
                End Select

            End If
        Next
        Select Case Alignment
            Case TabAlignment.Top
                G.FillPath(ToBrush(236, 237, 239), RoundRect(0, 20, Width - 1, Height - 21, 2))
                G.DrawPath(ToPen(150, 151, 153), RoundRect(0, 20, Width - 1, Height - 21, 2))
            Case TabAlignment.Bottom
                G.DrawPath(ToPen(150, 151, 153), RoundRect(0, 0, Width - 1, Height - 22, 2))
                G.FillPath(ToBrush(236, 237, 239), RoundRect(1, 1, Width - 3, Height - 23, 2))
            Case TabAlignment.Right
                G.FillPath(ToBrush(236, 237, 239), RoundRect(0, 2, Width - 76, Height - 3, 2))
                G.DrawPath(ToPen(150, 151, 153), RoundRect(0, 2, Width - 76, Height - 3, 2))
            Case TabAlignment.Left
                G.FillPath(ToBrush(236, 237, 239), RoundRect(75, 2, Width - 76, Height - 3, 2))
                G.DrawPath(ToPen(150, 151, 153), RoundRect(75, 2, Width - 76, Height - 3, 2))
        End Select

        For TabItemIndex As Integer = 0 To Me.TabCount - 1
            ItemBounds = Me.GetTabRect(TabItemIndex)

            If TabItemIndex = SelectedIndex Then

                Select Case Alignment
                    Case TabAlignment.Top
                        G.FillPath(ToBrush(236, 237, 239), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 3, ItemBounds.Height - 2)), 2))
                        G.DrawPath(ToPen(150, 151, 153), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 2, ItemBounds.Height - 2)), 2))

                        G.FillRectangle(ToBrush(236, 237, 239), New Rectangle(New Point(ItemBounds.X - 1, ItemBounds.Y + 1), New Size(ItemBounds.Width + 1, ItemBounds.Height)))
                    Case TabAlignment.Bottom
                        G.FillPath(ToBrush(236, 237, 239), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 3, ItemBounds.Height - 2)), 2))
                        G.DrawPath(ToPen(150, 151, 153), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 2, ItemBounds.Height - 2)), 2))

                        G.FillRectangle(ToBrush(236, 237, 239), New Rectangle(New Point(ItemBounds.X - 1, ItemBounds.Y - 2), New Size(ItemBounds.Width + 1, ItemBounds.Height)))
                    Case TabAlignment.Left
                        G.FillPath(ToBrush(236, 237, 239), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 3, ItemBounds.Height + 2)), 2))
                        G.DrawPath(ToPen(150, 151, 153), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 2, ItemBounds.Height + 1)), 2))

                        G.FillRectangle(ToBrush(236, 237, 239), New Rectangle(New Point(ItemBounds.X + 1, ItemBounds.Y + 1), New Size(ItemBounds.Width + 6, ItemBounds.Height)))
                    Case TabAlignment.Right
                        G.FillPath(ToBrush(236, 237, 239), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 3, ItemBounds.Height + 1)), 2))
                        G.DrawPath(ToPen(150, 151, 153), RoundRect(New Rectangle(New Point(ItemBounds.X - 2, ItemBounds.Y), New Size(ItemBounds.Width + 2, ItemBounds.Height + 2)), 2))

                        G.FillRectangle(ToBrush(236, 237, 239), New Rectangle(New Point(ItemBounds.X - 7, ItemBounds.Y + 1), New Size(ItemBounds.Width + 6, ItemBounds.Height + 1)))
                End Select
                SOFF = 0

                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Center
                TextBrush.Color = Color.FromArgb(80, 80, 80)
                Try
                    G.DrawString(TabPages(TabItemIndex).Text, Font, TextBrush, New Rectangle(GetTabRect(TabItemIndex).Location + New Point(0, SOFF), GetTabRect(TabItemIndex).Size), sf)
                    TabPages(TabItemIndex).BackColor = Color.FromArgb(236, 237, 239)
                Catch : End Try

            End If
        Next
    End Sub

End Class

Class GraphiteTheme
    Inherits ContainerControl

    Sub New()
        Dock = DockStyle.Fill
        BackColor = Color.FromArgb(235, 235, 235)
        ForeColor = Color.FromArgb(235, 235, 235)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle() : SendToBack()
        Parent.FindForm.TransparencyKey = Color.Fuchsia
        Parent.FindForm.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private _ico As Icon
    Public Property Icon() As Icon
        Get
            Return _ico
        End Get
        Set(ByVal value As Icon)
            _ico = value
            Invalidate()
        End Set
    End Property

#Region " Movement and Control Buttons"
    Private Cap As Boolean = False
    Private CapL As Point = Nothing

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If New Rectangle(0, 0, Width, 25).Contains(e.Location) Then
            Cap = True : CapL = e.Location : End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e) : If Cap Then Parent.Location = MousePosition - CapL
    End Sub
#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e) : Dim G As Graphics = e.Graphics
        G.Clear(BackColor)
        'Title
        G.FillRectangle(ToBrush(78, 78, 78), New Rectangle(0, 0, Width, 19))
        G.FillRectangle(ToBrush(73, Color.White), New Rectangle(0, 0, Width, 10))

        'Title Icon
        Try
            G.DrawIcon(_ico, New Rectangle(3, 3, 16, 16))
        Catch : End Try

        'Title Text
        G.DrawString(Text, Font, ToBrush(120, Color.Black), New Point((Width / 2) - (G.MeasureString(Text, Font).Width / 2), 4))
        G.DrawString(Text, Font, ToBrush(ForeColor), New Point((Width / 2) - (G.MeasureString(Text, Font).Width / 2) + 1, 2))

        'Border
        G.DrawRectangle(Pens.DimGray, New Rectangle(1, 1, Width - 3, Height - 3))
        G.DrawPath(Pens.Black, RoundRect(0, 0, Width - 1, Height - 1, 2))

        Try
            G.DrawRectangle(ToPen(Parent.FindForm.TransparencyKey), New Rectangle(0, 0, 1, 1))
            G.DrawRectangle(ToPen(Parent.FindForm.TransparencyKey), New Rectangle(Width - 1, 0, 1, 1))
            G.DrawRectangle(ToPen(Parent.FindForm.TransparencyKey), New Rectangle(0, Height - 1, 1, 1))
            G.DrawRectangle(ToPen(Parent.FindForm.TransparencyKey), New Rectangle(Width - 1, Height - 1, 1, 1))
        Catch : End Try

    End Sub

End Class

Class GraphiteTrackBar
    Inherits Control

#Region "Properties"
    Dim _Maximum As Integer = 10
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _Maximum = value
            If value < _Value Then _Value = value
            Invalidate()
        End Set
    End Property

    Event ValueChanged()
    Dim _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)

            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < 0
                    _Value = 0
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select

            Invalidate()
            RaiseEvent ValueChanged()
        End Set
    End Property
#End Region

    Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Dim CaptureM As Boolean = False
    Dim Bar As Rectangle = New Rectangle(0, 10, Width - 1, Height - 21)
    Dim Track As Size = New Size(20, 10)

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        Bar = New Rectangle(15, 10, Width - 31, Height - 21)
        G.Clear(Parent.FindForm.BackColor)

        G.FillRectangle(ToBrush(20, Color.Black), New Rectangle(0, CInt((Height / 2) - 2), Width - 1, 4))
        G.DrawRectangle(ToPen(20, Color.Black), New Rectangle(0, CInt((Height / 2) - 2), Width - 1, 4))

        G.FillRectangle(ToBrush(180, Color.Black), New Rectangle(1, CInt((Height / 2) - 2), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 4))

        G.FillRectangle(ToBrush(Parent.FindForm.BackColor), New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Size(Track.Width, Track.Height)))
        G.DrawRectangle(ToPen(50, Color.Black), New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Size(Track.Width, Track.Height)))
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        Me.BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim mp = New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), 0), New Size(Track.Width, Height)).IntersectsWith(mp) Then
            CaptureM = True
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureM = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureM Then
            Dim mp As Point = New Point(e.X, e.Y)
            Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((mp.X - Bar.X) / Bar.Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : CaptureM = False
    End Sub

End Class

Class GraphiteSeperator
    Inherits Control

    Enum POrientation
        Horizonal = 0
        Vertical = 1
    End Enum

    Private ori As POrientation
    Public Property Orientation() As POrientation
        Get
            Return ori
        End Get
        Set(ByVal value As POrientation)
            ori = value
            If ori = POrientation.Horizonal Then If Height > Width Then Size = New Size(Height, Width)
            If ori = POrientation.Vertical Then If Width > Height Then Size = New Size(Height, Width)
            Invalidate()
        End Set
    End Property

    Sub New()
        Size = New Size(100, 10)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.Clear(Parent.BackColor)

        Select Case ori
            Case POrientation.Horizonal
                G.DrawLine(ToPen(40, Color.Black), New Point(0, CInt(Height / 2) - 1), New Point(Width, CInt(Height / 2) - 1))
                G.DrawLine(ToPen(20, Color.White), New Point(0, CInt(Height / 2)), New Point(Width, CInt(Height / 2)))
            Case POrientation.Vertical
                G.DrawLine(ToPen(40, Color.Black), New Point(CInt(Width / 2) - 1, 0), New Point(CInt(Width / 2) - 1, Height))
                G.DrawLine(ToPen(20, Color.White), New Point(CInt(Width / 2), 0), New Point(CInt(Width / 2), Height))
        End Select
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        Select Case ori
            Case POrientation.Horizonal
                Size = New Size(Width, 10)
            Case POrientation.Vertical
                Size = New Size(10, Height)
        End Select
    End Sub
End Class

Class GraphiteComboBox
    Inherits ComboBox
    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or _
        ControlStyles.UserPaint Or _
        ControlStyles.DoubleBuffer, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(235, 235, 235)
        ForeColor = Color.FromArgb(31, 31, 31)
        DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private _StartIndex As Integer = 0
    Public Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not DropDownStyle = ComboBoxStyle.DropDownList Then DropDownStyle = ComboBoxStyle.DropDownList
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        Dim T As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(0, Color.Black), Color.FromArgb(22, Color.Black), 90S)
        Dim DrawCornersBrush As SolidBrush
        DrawCornersBrush = ToBrush(235, 235, 235)
        Try
            With G
                G.SmoothingMode = SmoothingMode.HighQuality
                .Clear(Color.FromArgb(235, 235, 235))
                .FillRectangle(T, New Rectangle(0, 0, Width, Height))
                .DrawLine(ToPen(235, 235, 235), 0, 0, 0, 0)
                .DrawRectangle(ToPen(235, 235, 235), New Rectangle(1, 1, Width - 3, Height - 3))

                .DrawLine(ToPen(80, Color.Black), New Point(Width - 22, 4), New Point(Width - 22, Height - 5))

                Dim K As New GraphicsPath
                K.AddEllipse(-Width \ 2, -Height, Width * 2, CInt(Height * 1.55))

                Dim kK As New PathGradientBrush(K)
                kK.CenterColor = Color.Transparent
                kK.SurroundColors = New Color() {Color.FromArgb(100, Color.White)}
                .FillPath(kK, K)

                Try
                    If .MeasureString(Text, Font).Width > Width - 29 Then
                        .DrawString(Items(SelectedIndex).ToString, Font, ToBrush(71, 71, 71), New RectangleF(3, 3, Width - 35, Height - 7))
                        .DrawString("...", Font, ToBrush(71, 71, 71), New Point(Width - 38, 3))
                    Else
                        .DrawString(Items(SelectedIndex).ToString, Font, ToBrush(71, 71, 71), New RectangleF(3, 3, Width - 35, Height - 7))
                    End If
                Catch
                    .DrawString("...", Font, ToBrush(71, 71, 71), New Point(3, 3))
                End Try

                DrawTriangle(Color.FromArgb(71, 71, 71), New Point(Width - 15, Height - 10), New Point(Width - 12, Height - 7), New Point(Width - 9, Height - 10), G)
                DrawTriangle(Color.FromArgb(235, 235, 235), New Point(Width - 15, Height - 12), New Point(Width - 12, Height - 8), New Point(Width - 9, Height - 12), G)
                DrawTriangle(Color.FromArgb(71, 71, 71), New Point(Width - 15, 9), New Point(Width - 12, 6), New Point(Width - 9, 9), G)
                DrawTriangle(Color.FromArgb(235, 235, 235), New Point(Width - 15, 11), New Point(Width - 12, 7), New Point(Width - 9, 11), G)

                .DrawPath(ToPen(120, Color.Black), RoundRect(0, 0, Width - 1, Height - 1, 2))
            End With
        Catch
        End Try
    End Sub
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(ToBrush(200, 200, 200), e.Bounds)
            End If
            e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, ToBrush(71, 71, 71), e.Bounds)
        Catch : End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray)
    End Sub
End Class

Class GraphiteCheck
    Inherits Control

    Sub New()
        Check = False
        Az = True
    End Sub

    Private [Check] As Boolean
    Public Property Checked() As Boolean
        Get
            Return [Check]
        End Get
        Set(ByVal value As Boolean)
            [Check] = value
            Invalidate()
        End Set
    End Property

    Private [Az] As Boolean
    Public Property AutoResize() As Boolean
        Get
            Return [Az]
        End Get
        Set(ByVal value As Boolean)
            [Az] = value
            OnResize(EventArgs.Empty)
        End Set
    End Property

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If Az Then Size = New Size(15 + CreateGraphics().MeasureString(Text, Font).Width, 13)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e) : Checked = Not Checked : Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G.Clear(BackColor)

        G.FillPath(Brushes.White, RoundRect(0, 0, Height - 1, Height - 1, 2))
        G.DrawPath(ToPen(120, Color.Black), RoundRect(0, 0, Height - 1, Height - 1, 2))

        Dim ChkSize As Integer = Height - 1

        If Checked Then
            Dim WWidth As Integer = Height
            G.SmoothingMode = SmoothingMode.HighQuality
            Dim OFS As Integer = -2
            Dim CP As Point() = {New Point(ChkSize / 4, ChkSize / 2), New Point(ChkSize / 2, ChkSize - (ChkSize / 4)), New Point(ChkSize - (ChkSize / 5), ChkSize / 4), New Point(ChkSize - (ChkSize / 4), (ChkSize / 4) + OFS), New Point(ChkSize / 2, ChkSize - (ChkSize / 4) + OFS), New Point(ChkSize / 4, (ChkSize / 2) + OFS)}
            G.FillPolygon(Brushes.Black, CP)
        End If

        G.DrawString(Text, Font, ToBrush(ForeColor), New Point(ChkSize + 3, CInt(Height / 2) - CInt(G.MeasureString(Text, Font).Height / 2)))

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e) : OnResize(EventArgs.Empty) : Invalidate()
    End Sub
End Class