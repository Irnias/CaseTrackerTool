Public Class ThisAddIn
    Dim outlookNameSpace As Outlook.NameSpace
    Dim inbox As Outlook.MAPIFolder
    Dim WithEvents items As Outlook.Items

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        outlookNameSpace = Me.Application.GetNamespace("MAPI")
        inbox = outlookNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
        items = inbox.Items
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Private Sub NewEmail_Receive(ByVal item As Object) Handles items.ItemAdd
        'Check if we receive a new email
        If TypeOf (item) Is Outlook.MailItem Then

            Dim mail As Outlook.MailItem = item
            If mail.MessageClass = "IPM.Note" Then
                'Parse new email and insert it
                'MsgBox(mail.szSubject)
            End If
        End If
    End Sub

    Private Sub NewEmail_Receive() Handles Application.ItemLoad
        Dim retrieveObject As Object
        Dim email As Outlook.MailItem

        ' returns reference to current item, either the one selected (Explorer), or the one currently open (Inspector)
        Select Case True
            Case TypeName(Application.ActiveWindow) = "Explorer"
                retrieveObject = Application.ActiveExplorer.Selection.Item(1)
                Exit Select
            Case TypeName(Application.ActiveWindow) = "Inspector"
                retrieveObject = Application.ActiveInspector.CurrentItem
                Exit Select
            Case Else
                retrieveObject = vbObject
        End Select

        If TypeName(retrieveObject) = "MailItem" Then
            email = retrieveObject
            'MsgBox(msg.ConversationID)
        End If

    End Sub
End Class
