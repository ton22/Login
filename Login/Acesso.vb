Public Class Acesso
    Public ObjConexao As SqlClient.SqlConnection
    'Private ObjConexaoFire As FirebirdSql.Data.FirebirdClient

    Public Sub Conectar()
        'vk = ("187.111.3.134,1500")
        'cb = ("187.111.3.134,1500")
        'md = ("187.111.3.134,1500")

        Try
            ObjConexao = New SqlClient.SqlConnection("Data Source = 'TON-PC\BASETESTE02'; INITIAL CATALOG = recepcao; USER ID = hmsc ; PASSWORD = sbschmsc ")
            ObjConexao.Open()

        Catch ex As Exception



            If Me.ObjConexao.State = ConnectionState.Closed Then
                MsgBox("Sem conexão com o banco!" + vbCrLf + "Escolha outra conexão ou verifique sua rede")
                FecharErro()
            End If
        Finally
            'Me.Fechar()

        End Try
        Exit Sub


    End Sub

    'Public Sub Conectar2()
    '    Try
    '        ObjConexao = New SqlClient.SqlConnection("Data Source = '192.168.1.251\iabas'; INITIAL CATALOG = recepcao; USER ID = hmsc ; PASSWORD = sbschmsc ")
    '        ObjConexao.Open()

    '    Catch ex As Exception

    '        If Me.ObjConexao.State = ConnectionState.Closed Then
    '            MsgBox("Sem conexão com o banco!" + vbCrLf + "Escolha outra conexão ou verifique sua rede")
    '            FecharErro()
    '        End If
    '    Finally
    '        'Me.Fechar()

    '    End Try
    '    Exit Sub
    'End Sub
    Public Sub Fechar()
        Try
            If Not IsNothing(ObjConexao) Then
                If ObjConexao.State = ConnectionState.Open Then
                    ObjConexao.Close()
                End If
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Function ExecuteQuerry(ByVal Command As String) As DataSet
        Dim ds As New DataSet
        Dim ObjDataAdapter As New SqlClient.SqlDataAdapter
        Dim ObjCommand As New SqlClient.SqlCommand
        Try
            ObjCommand = ObjConexao.CreateCommand
            ObjCommand.CommandText = Command

            ObjDataAdapter = New SqlClient.SqlDataAdapter(ObjCommand)
            ObjDataAdapter.Fill(ds)
        Catch ex As Exception
            If Me.ObjConexao.State = ConnectionState.Closed Then
                FecharErro()
            End If

        End Try
        Return ds
    End Function

    Public Sub FecharErro()
        End

        'Try
        '    'If ObjConexao Then

        '    '    If  Then


        '    '    End If
        '    'End If
        'Catch ex As Exception
        '    Throw ex

        'End Try
    End Sub
    'Public Sub ConectarVK()
    '    'vk = ("187.111.3.134,1500")
    '    'cb = ("187.111.3.134,1500")
    '    'md = ("187.111.3.134,1500")

    '    Try
    '        ObjConexao = New SqlClient.SqlConnection("Data Source = '187.111.3.134,1500'; INITIAL CATALOG = recepcao; USER ID = hmsc ; PASSWORD = sbschmsc ")
    '        ObjConexao.Open()

    '    Catch ex As Exception



    '        If Me.ObjConexao.State = ConnectionState.Closed Then
    '            MsgBox("Sem conexão com o banco!" + vbCrLf + "Escolha outra conexão ou verifique sua rede")
    '            FecharErro()
    '        End If
    '    Finally
    '        'Me.Fechar()

    '    End Try
    '    Exit Sub


    'End Sub
    'Public Sub ConectarMD()
    '    'vk = ("187.111.3.134,1500")
    '    'cb = ("187.111.3.134,1500")
    '    'md = ("187.111.3.134,1500")

    '    Try
    '        ObjConexao = New SqlClient.SqlConnection("Data Source = '187.111.3.134,1500'; INITIAL CATALOG = recepcao; USER ID = hmsc ; PASSWORD = sbschmsc ")
    '        ObjConexao.Open()

    '    Catch ex As Exception



    '        If Me.ObjConexao.State = ConnectionState.Closed Then
    '            MsgBox("Sem conexão com o banco!" + vbCrLf + "Escolha outra conexão ou verifique sua rede")
    '            FecharErro()
    '        End If
    '    Finally
    '        'Me.Fechar()

    '    End Try
    '    Exit Sub


    'End Sub
    'Public Sub ConectarCB()
    '    'vk = ("187.111.3.134,1500")
    '    'cb = ("187.111.3.134,1500")
    '    'md = ("187.111.3.134,1500")

    '    Try
    '        ObjConexao = New SqlClient.SqlConnection("Data Source = '187.111.3.134,1500'; INITIAL CATALOG = recepcao; USER ID = hmsc ; PASSWORD = sbschmsc ")
    '        ObjConexao.Open()

    '    Catch ex As Exception



    '        If Me.ObjConexao.State = ConnectionState.Closed Then
    '            MsgBox("Sem conexão com o banco!" + vbCrLf + "Escolha outra conexão ou verifique sua rede")
    '            FecharErro()
    '        End If
    '    Finally
    '        'Me.Fechar()

    '    End Try
    '    Exit Sub


    'End Sub

End Class


