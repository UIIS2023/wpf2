   M S B A M L   `   `   `  ����F  BWPFKnjizara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Knjizara.FormeKnjizara.Forme  5   	       Knjizara.Forme.FrmNabavka   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Knjizara.Forme     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ 
FrmNabavka��5   	   $	��220��6   $	��350��6)   
���� ��$��7q�5
   	   ��5      �� 5   
    �� ImageSource$+ %C:\Users\HP\Desktop\WPFKnjizara\3.jpg��6    j� Stretch$
 Fill=�6I   6Z   .��5      � .+�5   
   �� $��Datum nabavke:��6   $��DemiBold"�6)   $��14(�6?   $
��Left=�6M   $��	40,15,0,0q�6h   $	��Top=�6{   �� 5   
   $��Cena nabavke:��6   $��DemiBold"�6(   $��14(�6>   $
��Left=�6L   $��	40,45,0,0q�6g   $	��Top=�6z   �� 5   
   $��	Korisnik:��6   $��DemiBold"�6$   $��14(�6:   $
��Left=�6H   $��
40,75, 0,0q�6c   $	��Top=�6w   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumNabavke��5      $
��Left=�6+   $��
150,20,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5         ��Name$ txtCenaNabavke��5      $
��Left=�6*   $��23��6E   $��
150,50,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��
150,80,0,0q�6B   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$ ImeKorisnika��6z   	 �� SelectedValuePath$	 
KorisnikID��6�   �� 5   
   -   5        
 ��Name$
 
btnSacuvaj��5      
���ؿ��$��Sačuvaj��6:   $��Italic$�6L   $��14(�6_   $
��Left=�6m   $��
45,150,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        $
 	btnOtkazi��5      
���ؿ��$��Otkaži��69   $��Italic$�6J   $��14(�6]   $
��Left=�6k   $��195,150,0,0q�6�   $	��Top=�6�   $��75��6�   6�   5      5      