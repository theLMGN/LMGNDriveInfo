Module Module1
    Sub wl(text)
        Console.WriteLine(text)
    End Sub
    Function ip(text)
        Console.WriteLine(text)
        Return Console.ReadLine
    End Function
    Sub wpb(curVal, maxVal)
        Dim wbpprog
        Dim wpbprog = ""
        Dim wdpprog = 100
        wbpprog = curVal / maxVal
        wbpprog = wbpprog * 100
        While wbpprog >= 1.0
            wpbprog = wpbprog & "#"
            wbpprog = wbpprog - 1
            wdpprog = wdpprog - 1
        End While
        While wdpprog >= 1
            wpbprog = wpbprog & "-"
            wdpprog = wdpprog - 1
        End While
        wl(wpbprog)
    End Sub
    Sub Main()
        Console.Title = "LMGNDriveInfo"
        Dim dl = ip("Drive Letter:")
        If My.Computer.FileSystem.DirectoryExists(dl & ":\") Then
            If My.Computer.FileSystem.FileExists(dl & ":\" & "di.ldi") Then
                Dim size As System.IO.DriveInfo
                size = My.Computer.FileSystem.GetDriveInfo(dl & ":\")
                Dim fileReader As System.IO.StreamReader
                fileReader =
                My.Computer.FileSystem.OpenTextFileReader(dl & ":\di.ldi")
                wl("Drive ID:     " & fileReader.ReadLine())
                wl("Drive format: " & fileReader.ReadLine())
                wl("Drive info:   " & fileReader.ReadLine())
                wl("Drive FS:     " & size.DriveFormat)
                wl("Drive label:  " & size.VolumeLabel)

                wl("Drive name:   " & size.Name)
                If size.DriveType = "0" Then
                    wl("Drive type:   Unknown")
                End If
                If size.DriveType = "1" Then
                    wl("Drive type:   No root path.")
                End If
                If size.DriveType = "2" Then
                    wl("Drive type:   Removable Drive")
                End If
                If size.DriveType = "3" Then
                    wl("Drive type:   Fixed")
                End If
                If size.DriveType = "4" Then
                    wl("Drive type:   Network share")
                End If
                If size.DriveType = "5" Then
                    wl("Drive type:   CD-ROM")
                End If
                If size.DriveType = "6" Then
                    wl("Drive type:   RAM Disk")
                End If
                wl("Used space:   " & size.TotalSize / 1024 / 1024 & "MB")
                wl("Free space:   " & size.TotalFreeSpace / 1024 / 1024 & "MB")
                wpb(size.TotalSize - size.TotalFreeSpace, size.TotalSize)
                wl("Drive notes:  " & fileReader.ReadLine())
                Else
                wl("Info file not found.")
                Dim cf = ip("Create one now? (lowercase y to create, anything else, don't create.)")
                If cf = "y" Then
                    Try
                        My.Computer.FileSystem.WriteAllText(dl & ":\di.ldi", ip("ID:") & Chr(13), True)
                        My.Computer.FileSystem.WriteAllText(dl & ":\di.ldi", ip("Format (eg USB Stick, SDCard etc...):") & Chr(13), True)
                        My.Computer.FileSystem.WriteAllText(dl & ":\di.ldi", ip("Info (EG Sondask Facay 8GB Purple):") & Chr(13), True)
                        My.Computer.FileSystem.WriteAllText(dl & ":\di.ldi", ip("Notes:") & Chr(13), True)
                    Catch errrororororor As Exception
                        wl("ERROR: " & errrororororor.Message & " in " & errrororororor.Source & " Go to " & errrororororor.HelpLink & " for more info")
                    End Try

                Else
                    Dim size As System.IO.DriveInfo
                    size = My.Computer.FileSystem.GetDriveInfo(dl & ":\")
                    wl("Running with out creating a info file, some features are not available.")
                    wl("Drive FS:     " & size.DriveFormat)
                    wl("Drive label:  " & size.VolumeLabel)
                    wl("Drive name:   " & size.Name)
                    If size.DriveType = "0" Then
                        wl("Drive type:   Unknown")
                    End If
                    If size.DriveType = "1" Then
                        wl("Drive type:   No root path.")
                    End If
                    If size.DriveType = "2" Then
                        wl("Drive type:   Removable Drive")
                    End If
                    If size.DriveType = "3" Then
                        wl("Drive type:   Fixed")
                    End If
                    If size.DriveType = "4" Then
                        wl("Drive type:   Network share")
                    End If
                    If size.DriveType = "5" Then
                        wl("Drive type:   CD-ROM")
                    End If
                    If size.DriveType = "6" Then
                        wl("Drive type:   RAM Disk")
                    End If
                    wl("Used space:   " & size.TotalSize / 1024 / 1024 & "MB")
                    wl("Free space:   " & size.TotalFreeSpace / 1024 / 1024 & "MB")
                    wpb(size.TotalSize - size.TotalFreeSpace, size.TotalSize)
                End If
            End If
        Else
            wl("Drive not found.")
            wl("Listing all drives...")
            For Each Drive As System.IO.DriveInfo In My.Computer.FileSystem.Drives
                Try
                    wl("== " & Drive.Name.Replace(":\", "") & " (" & Drive.VolumeLabel & ") ==")
                Catch Erroor As Exception
                    wl("== " & Drive.Name.Replace(":\", "") & " (Error:" & Erroor.Message.Replace(Chr(13), "") & " Most likely unmounted or an empty CD/DVD drive.) ==")
                End Try
            Next
        End If
        Main()
    End Sub

End Module
