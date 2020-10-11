﻿Public Class ObjectBase
    Public coord As Point
    Public spr As SpriteSheet
    Public spr_index As Int16
    Public random As Random

    Sub New()
        random = New Random(gameTick)
        coord = GetCoordCircle(S_WIDTH \ 2, S_HEIGHT \ 2, random.Next(0, 360) * 180 / Math.PI, S_WIDTH)
    End Sub

    Sub Draw(ByVal g As Graphics)
        If -spr.width \ 2 < coord.X < S_WIDTH + spr.width \ 2 And -spr.height \ 2 < coord.Y < S_HEIGHT + spr.height \ 2 Then
            DrawSprite(g, spr, spr_index, coord.X, coord.Y)
        End If
    End Sub

    Sub DefaultEvent()
        coord.X += player_hspeed
        coord.Y += player_vspeed

        If GetDistanceTwoPoint(coord.X, coord.Y, S_WIDTH \ 2, S_HEIGHT \ 2) > S_WIDTH * 2 Then
            Die()
        End If
    End Sub

    Sub Die()
        obj_list.Remove(MyBase.ToString)
        enemy_list.Remove(MyBase.ToString)
        Finalize()
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
        Debug.WriteLine("객체 소멸")
    End Sub
End Class
