   M S B A M L   `   `   `  ����F  BWPFKnjizara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Knjizara.FormeKnjizara.Forme  5   	       Knjizara.Forme.FrmRacun   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Knjizara.Forme     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ FrmRacun��5   	   $	��250��6   $	��400��6'   
���� ��$��7q�5
   	   ��5      �� 5   
    �� ImageSource$+ %C:\Users\HP\Desktop\WPFKnjizara\3.jpg��6    j� Stretch$
 Fill=�6I   6Z   .��5      � .+�5   
   �� $��	Korisnik:��6   $��DemiBold"�6$   $��14(�6:   $
��Left=�6H   $��	80,20,0,0q�6c   $	��Top=�6v   �� 5   
   $��Kupac:��6   $��DemiBold"�6!   $��14(�67   $
��Left=�6E   $��	80,50,0,0q�6`   $	��Top=�6s   �� 5   
   $��Datum prodaje:��6   $��DemiBold"�6)   $��14(�6?   $
��Left=�6M   $��	80,80,0,0q�6h   $	��Top=�6{   �� 5   
   $��Cena prodaje:��6   $��DemiBold"�6(   $��14(�6>   $
��Left=�6L   $��
80,110,0,0q�6g   $	��Top=�6{   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��190, 20,0,0q�6B   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ ImeKorisnika��6{    �� SelectedValuePath$ 
KorisnikID��6�   �� 5   
   -   5        $ cbKupac��5      $
��Left=�6$   $��
190,50,0,0q�6?   $	��Top=�6S   $	��120��6k   $ ImeKupca��6w   $ KupacID��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumProdaje��5      $
��Left=�6+   $��
190,80,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5         ��Name$ txtCenaProdaje��5      $
��Left=�6*   $��23��6E   $��190,110,0,0q�6Q   	 �� TextWrapping$
	 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        
 ��Name$
 
btnSacuvaj��5      
���ؿ��$��Sačuvaj��6:   $��Italic$�6L   $��14(�6_   $
��Left=�6m   $��
85,170,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        $
 	btnOtkazi��5      
���ؿ��$��Otkaži��69   $��Italic$�6J   $��14(�6]   $
��Left=�6k   $��235,170,0,0q�6�   $	��Top=�6�   $��75��6�   6�   5      5      