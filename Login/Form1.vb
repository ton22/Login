Imports iTextSharp.text ' import namespaces .net pdf library
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports itextsharp.text.pdf.PdfPage
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.ConsoleColor
Imports System.Threading.Thread
Imports System.Data.Odbc

Public Class Form1

    Private t1, t2, t3 As Thread
    Private ObjBanco As New Acesso
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hwnd As System.IntPtr, ByVal wmsg As Integer, ByVal wparam As Integer, ByVal lparam As Integer)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Width = 46

        '        Dim Sql As String
        '        Dim MiConexion As New SqlConnection("Data Source ='TON-PC\BASETESTE02'; INITIAL CATALOG = recepcao; USER ID =hmsc ; PASSWORD =sbschmsc")
        '        Dim Rs As SqlDataReader
        '            Dim Com As New SqlCommand
        '            Com.Connection = MiConexion
        '            MiConexion.Open()
        '        Sql = ("select nome from Acesso.dbo.setores 
        'where nome in ('CLINICA','PEDIATRIA','ENFERMEIRO(a)','TEC.ENFERMAGEM','EQUIPE MULTI','RECEPCAO','OUTROS')
        'order by nome")
        '        Com = New SqlCommand(Sql, MiConexion)
        '            Rs = Com.ExecuteReader()
        '            'Rs.Read()
        '            'ComboBoxEx1.Text = Rs(0)  
        '            While Rs.Read
        '            ComboBox1.Items.Add(Rs.Item("NOME"))

        '        End While

        '            Rs.Close()
    End Sub

    ' 1
    Private Sub TextBox1_Validating(sender As Object, e As CancelEventArgs) Handles TextBox1.Validating
        PesquisarNome()
    End Sub
    '2
    Private Sub PesquisarNome()
        Dim nome As String
        nome = ""
        Try
            nome = TextBox1.Text
            'WebBrowser1.Document.GetElementById("pesquisaValue").SetAttribute("value", nome)
            WebBrowser1.Document.GetElementById("pesquisaValue").Focus()
            'SendKeys.Send(nome)
            SendKeys.SendWait(nome)
            ChamarClick()
        Catch
            MsgBox("Não é possivel pesquisar o CNS, verifique a internet ou desative a pesquisa.")
            Foc()
        End Try
    End Sub
    '3
    Private Sub ChamarClick()
        For Each Element As HtmlElement In WebBrowser1.Document.GetElementsByTagName("button")
            If Element.OuterHtml.Contains("6") And Element.OuterHtml.Contains("Pesquisar") Then
                Element.InvokeMember("click")
                Timer2.Enabled = True
                Return
            End If
            'If Element.OuterHtml.Contains("#vinculomodal") Then
            '    Element.InvokeMember("click")
            '    'Timer2.Enabled = True
            '    Return
            'End If

            Foc()
        Next Element
    End Sub
    '4
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        DgvDados.Rows.Clear() 'LIMPA O DATA GRID

        For Each Element As HtmlElement In WebBrowser1.Document.GetElementsByTagName("td")
            If Element.OuterHtml.Contains("NOME PROFISSIONAL") Then
                DgvDados.Rows.Add(Element.InnerText)
                DgvDados.Rows.Add()
            End If
            If Element.OuterHtml.Contains("DETALHES") And Element.OuterHtml.Contains("Vínculos ativos") Then
                Element.InvokeMember("click")
                DgvDados.Rows.Add(Element.InnerText)

            End If
            If Element.OuterHtml.Contains("'cns'") Then
                TextBox5.Text = (Element).InnerText
                DgvDados.Rows.Add(Element.InnerText)
            End If



        Next Element
        Timer2.Enabled = False
    End Sub
    '5
    Public Sub Foc()
        MaskedTextBox3.Focus()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ''select nome from Acesso.dbo.setores order by nome
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ''SELECT CONSELHO_ID, CONSELHO_SIGLA, CONSELHO_TRATAMENTO_PROFISSIONAL TRATAMENTO, CONSELHO_TITULO_PROFISSIONAL TITULO FROM RECEPCAO.DBO.CONSELHOS  WHERE  CONSELHO_SIGLA = 'CRM'   ORDER BY CONSELHO_SIGLA 
        ''CRIAR USUARIO CADMED, PROFISSIONAL MEDICO
        ''VERIFICAR SE O CPF JA ESTA CADASTRADO E VALIDA O DIGITO
        ''SELECT CIC from Recepcao.dbo.medicos where cic = @P1 AND codigo <> @P2
        ',N'@P1 varchar(12),@P2 int','999999999990',0
        '' N'SELECT CIC from Recepcao.dbo.medicosadt where cic = @P1 AND codigo <> @P2
        ',N'@P1 varchar(12),@P2 int','999999999990',0
        ''VERIFICA SE O CRM ESTA CADASTRADO
        ''select crm, nome, ext, count (*) qtde from Recepcao.dbo.medicos where crm = @P1
        ''group by crm, nome, ext
        ',N'@P1 varchar(4)','1357'

    End Sub
    Private Sub MaskedTextBox3_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox3.MaskInputRejected
        ''select crm, nome, ext, count (*) qtde from Recepcao.dbo.medicos where crm = @P1
        ''group by crm, nome, ext
        ',N'@P1 varchar(6)','098765'
    End Sub
    Private Sub MaskedTextBox2_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox2.MaskInputRejected

        ''SELECT CIC from Recepcao.dbo.medicos where cic = @P1 AND codigo <> @P2
        ',N'@P1 varchar(14),@P2 int','00000000000000',0

        ''SELECT CIC from Recepcao.dbo.medicosadt where cic = @P1 AND codigo <> @P2
        ',N'@P1 varchar(14),@P2 int','00000000000000',0
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ComboBox2.Text = "MEDICO" Then
            Label8.Text = "CRM"
        Else
            If ComboBox2.Text = "ENFERMEIRO(a)" Or ComboBox2.Text = "TEC.ENFERMAGEM" Then
                Label8.Text = "COREN"
            Else
                If ComboBox2.Text = "FISIOTERAPEUTA" Then
                    Label8.Text = "CREFITO"
                Else
                    If ComboBox2.Text = "NUTRIÇÃO" Then
                        Label8.Text = "CRN"
                    Else
                        If ComboBox2.Text = "PSICOLOGIA" Then
                            Label8.Text = "CRP"
                        Else
                            If ComboBox2.Text = "RECEPCAO" Then
                                Label8.Text = "OUT"
                            End If
                        End If
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DgvDados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDados.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    End Sub
    Private Sub MaskedTextBox3_Validating(sender As Object, e As CancelEventArgs) Handles MaskedTextBox3.Validating
        'ChamarClick()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click

        Try
            WebBrowser1.Document.GetElementById("pesquisaValue").SetAttribute("value", "")
            TextBox1.SelectAll()
        Catch
            TextBox5.Text = ""
            TextBox1.SelectAll()
        End Try


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (Panel2.Width = 46) Then
            Panel2.Width = 721

        Else
            Panel2.Width = 46
        End If
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Hide()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If ComboBox1.Text.Trim().Length = 0 Then
            If ComboBox2.Text.Trim().Length = 0 Then
                If MaskedTextBox3.MaskCompleted Then
                    If MaskedTextBox2.MaskCompleted Then
                        If MaskedTextBox1.MaskCompleted Then
                            If TextBox1.Text.Trim().Length = 0 Then
                                Button2.Enabled = True
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Button2.Enabled = False

    End Sub

    Public Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Body.Style = "zoom: 95%"
        'If e.Url = WebBrowser1.Url Then
        '    Timer2.Enabled = True
        '    'Verifica se a url é a de um Frame ou a url da página.
        '    'Aqui o código que você quer executar quando a página estiver totalmente carregada
        'End If
    End Sub




End Class
