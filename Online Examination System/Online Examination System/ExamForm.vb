Imports System.Windows.Forms

Public Class Form1
    ' Define the list of tuples for section names and number of questions
    Private sectionData As List(Of Tuple(Of String, Integer)) = New List(Of Tuple(Of String, Integer)) From {
        Tuple.Create("Section 1", 4),
        Tuple.Create("Section 2", 8),
        Tuple.Create("Section 3", 4)
    }

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadSections()
    End Sub

    Private Sub LoadSections()
        ' Iterate through the list of tuples in reverse order and create labels for sections and question buttons
        For i As Integer = sectionData.Count - 1 To 0 Step -1
            Dim sectionLabel As New Label()
            sectionLabel.Text = sectionData(i).Item1 ' Item1 is the section name
            sectionLabel.AutoSize = True
            sectionLabel.Dock = DockStyle.Top
            sectionLabel.Margin = New Padding(5)
            SplitContainer1.Panel1.Controls.Add(sectionLabel)

            Dim questionCount As Integer = sectionData(i).Item2 ' Item2 is the number of questions

            ' Add question buttons for each section
            Dim rowCount As Integer = Math.Ceiling(questionCount / 4)
            Dim questionPanel As New TableLayoutPanel()
            questionPanel.Dock = DockStyle.Top
            questionPanel.AutoSize = True
            questionPanel.ColumnCount = 4
            questionPanel.RowCount = rowCount

            For j As Integer = 1 To questionCount
                Dim questionButton As New Button()
                questionButton.Text = "S " & (i + 1) & ", Q " & j
                questionButton.AutoSize = True
                questionButton.Margin = New Padding(5)
                AddHandler questionButton.Click, AddressOf QuestionButton_Click

                Dim rowIndex As Integer = (j - 1) \ 4
                Dim columnIndex As Integer = (j - 1) Mod 4
                questionPanel.Controls.Add(questionButton, columnIndex, rowIndex)
            Next

            ' Add question panel to the SplitContainer1.Panel1.Controls
            SplitContainer1.Panel1.Controls.Add(questionPanel)
        Next
    End Sub

    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Handle click event of question buttons
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim questionInfo As String = questionButton.Text
        MessageBox.Show("You clicked on: " & questionInfo)

        ' Here you can change the question in the right panel
        ' For now, let's just change the text in a textbox
        TextBox1.Text = "You clicked on: " & questionInfo & ". Question details will be displayed here."
    End Sub

    ' Add other button click event handlers for previous, clear, save_next, submit
    ' For example:
    Private Sub PreviousButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Handle click event of the previous button
        ' Add your logic here
    End Sub
End Class
