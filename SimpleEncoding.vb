Class SimpleEncoding

    ''  SSS   III  M   M  PPPP   L     EEEE      EEEE  N   N   CCC   OOO   DDD   III  N   N   GGG  
    '' S       I   MM MM  P   P  L     E         E     NN  N  C     O   O  D  D   I   NN  N  G     
    ''  SSS    I   M M M  PPPP   L     EEE       EEE   N N N  C     O   O  D  D   I   N N N  G  GG 
    ''     S   I   M   M  P      L     E         E     N  NN  C     O   O  D  D   I   N  NN  G   G 
    '' SSSS   III  M   M  P      LLLL  EEEE      EEEE  N   N   CCC   OOO   DDD   III  N   N   GGG  

    ''' <summary></summary>
    ''' <param name="input">Input String</param>
    ''' <param name="multiplier">Multiplier (For Encoding)</param>
    ''' <returns>Encoded String</returns>
    Public Shared Function EncodeString(input As String, Optional multiplier As Integer = 8) As String
        Dim enc As New Text.StringBuilder
        For Each c As Char In input
            enc.Append(ChrW((multiplier * AscW(c))))
        Next
        Return Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(enc.ToString))
    End Function

    ''' <summary></summary>
    ''' <param name="input">Input String</param>
    ''' <param name="multiplier">Multiplier (For Decoding)</param>
    ''' <returns>Decoded String</returns>
    Public Shared Function DecodeString(input As String, Optional multiplier As Integer = 8) As String
        Dim dec As New Text.StringBuilder
        For Each c As Char In Text.Encoding.UTF8.GetString(Convert.FromBase64String(input))
            Try
                dec.Append(ChrW((AscW(c) / multiplier)))
            Catch ex As Exception
                Throw New Exception("Wrong Multiplier!")
            End Try
        Next
        Return dec.ToString
    End Function

    ''' <summary></summary>
    ''' <param name="input">Input Bytes</param>
    ''' <param name="multiplier">Multiplier (For Encoding)</param>
    ''' <returns>Encoded Bytes</returns>
    Public Shared Function EncodeBytes(input As Byte(), Optional multiplier As Integer = 8) As Byte()
        Try
            Return Convert.FromBase64String(EncodeString(Convert.ToBase64String(input), multiplier))
        Catch ex As Exception
            Throw New Exception("Cannot encode bytes!")
            Return Nothing
        End Try
    End Function

    ''' <summary></summary>
    ''' <param name="input">Input Bytes</param>
    ''' <param name="multiplier">Multiplier (For Decoding)</param>
    ''' <returns>Decoded Bytes</returns>
    Public Shared Function DecodeBytes(input As Byte(), Optional multiplier As Integer = 8) As Byte()
        Try
            Return Convert.FromBase64String(DecodeString(Convert.ToBase64String(input), multiplier))
        Catch ex As Exception
            Throw New Exception("Cannot decode bytes!")
            Return Nothing
        End Try
    End Function
End Class