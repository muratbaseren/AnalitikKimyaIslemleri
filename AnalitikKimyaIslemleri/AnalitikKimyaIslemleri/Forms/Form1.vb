Public Class Form1

#Region "Görünüm"

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical)
    End Sub
#End Region

#Region "işlemler"
    Private Sub AnalizSonucDegToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalizSonucDegToolStripMenuItem.Click
        Dim frm As Form2 = New Form2
        frm.MdiParent = Me
        frm.Show()
        CType(sender, ToolStripMenuItem).Enabled = False
    End Sub

    Private Sub TitrasyonHesapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitrasyonHesapToolStripMenuItem.Click
        Dim frm As Form4 = New Form4
        frm.MdiParent = Me
        frm.Show()
        CType(sender, ToolStripMenuItem).Enabled = False
    End Sub
#End Region

#Region "Makaleler"
    'Tüm makaleler'in Click işlemi tek sub 'a toplanarak "Tag" 'ları içindeki açılacak konum bilgisi okunur.
    Private Sub Makale_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MakAmadeoAvogadroToolStripMenuItem.Click, MakAsitBazTanımlarıToolStripMenuItem.Click, MakBeyazBeyazSarıToolStripMenuItem.Click, MakBuckminsterFullerToolStripMenuItem.Click, MakCâbirBinHayânToolStripMenuItem.Click, MakCarlDjerassiToolStripMenuItem.Click, MakDNAdanSonraToolStripMenuItem.Click, MakDoğrulukKesinlikToolStripMenuItem.Click, MakEkzotermikAlevliDumanliDeneyToolStripMenuItem.Click, MakEnzimlerinİnhibisyonuToolStripMenuItem.Click, MakFrederickSangerToolStripMenuItem.Click, MakHardalGazıToolStripMenuItem.Click, MakHidronyumİyonununBenzenİçindekiYapısıToolStripMenuItem.Click, MakİlaçlardaStereokimyanınÖnemiToolStripMenuItem.Click, MakİmkansızHayallerToolStripMenuItem.Click, MakKimyanınHalaBüyükSorularıVarMıToolStripMenuItem.Click, MakLinusPaulingToolStripMenuItem.Click, MakLouisPasteurVe150YılSonrasıToolStripMenuItem.Click, MakManyetizmaİçgüdüToolStripMenuItem.Click, MakMarieCurieToolStripMenuItem.Click, MakMaviŞişeToolStripMenuItem.Click, MakMaxFPerutzToolStripMenuItem.Click, MakNicelVeNitelAnalizToolStripMenuItem.Click, MakÖlçümKimyasıToolStripMenuItem.Click, MakPaulinginSolElliΑSarmalıToolStripMenuItem.Click, MakSarinGazıİçinYeniBirSensörToolStripMenuItem.Click, MakSarinToolStripMenuItem.Click, MakSesBombasiToolStripMenuItem.Click, MakSimetrininBozulduğuAnToolStripMenuItem.Click, MakSuylaBaşlayanYanmaTepkimesiToolStripMenuItem.Click, MakTuruncuRenginDansıToolStripMenuItem.Click, MakVanDerWaalsToolStripMenuItem.Click, MakVictorGrignardToolStripMenuItem.Click

        Dim frm As Form6 = New Form6
        Dim itm As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        frm.MdiParent = Me

        frm.Loading(itm.Tag.ToString, itm.Text)
        frm.Show()

    End Sub
#End Region

#Region "Menü"
    Private Sub ÇıkışToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇıkışToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next

        End
    End Sub

    Private Sub EkleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEkle.Click
        Dim frm As Form7 = New Form7
        AddHandler frm.FormClosing, AddressOf WebYenile
        frm.ShowDialog()
    End Sub

    Public Sub WebYenile(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        Me.AdreslerToolStripMenuItem.DropDownItems.Clear()
        Dim itm As ToolStripMenuItem

        For Each dr As DataRow In CType(sender, Form7).Liste.Rows
            itm = New ToolStripMenuItem(dr(0).ToString)
            itm.Tag = dr(1).ToString
            AddHandler itm.Click, AddressOf AdreseGit
            Me.AdreslerToolStripMenuItem.DropDownItems.Add(itm)
        Next
    End Sub

    Private Sub AdreseGit(ByVal sender As Object, ByVal e As EventArgs)
        Shell("explorer.exe " & CType(sender, ToolStripMenuItem).Tag.ToString, AppWinStyle.MaximizedFocus)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable = New DataTable
        Dim itm As ToolStripMenuItem
        Dim dll As DLL_FileReaderWriter.XML = New DLL_FileReaderWriter.XML
        dt = dll.ReadXMLFile(Application.StartupPath & "\" & "WbAdrs.xml")

        For Each dr As DataRow In dt.Rows
            itm = New ToolStripMenuItem(dr(0).ToString)
            itm.Tag = dr(1).ToString
            AddHandler itm.Click, AddressOf AdreseGit
            Me.AdreslerToolStripMenuItem.DropDownItems.Add(itm)
        Next
    End Sub
#End Region

End Class
