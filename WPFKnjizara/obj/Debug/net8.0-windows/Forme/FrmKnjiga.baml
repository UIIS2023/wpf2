   M S B A M L   `   `   `  ����F  BWPFKnjizara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Knjizara.FormeKnjizara.Forme  5   	       Knjizara.Forme.FrmKnjiga   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Knjizara.Forme     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ 	FrmKnjiga��5   	   $	��320��6   $	��470��6(   
���� ��$��7q�5
   	   ��5      �� 5   
    �� ImageSource$+ %C:\Users\HP\Desktop\WPFKnjizara\3.jpg��6    j� Stretch$
 Fill=�6I   6Z   .��5      � .+�5   
   �� $��Naslov:��6   $��DemiBold"�6"   $��14(�68   $
��Left=�6F   $��
120,45,0,0q�6a   $	��Top=�6u   �� 5   
   $��Pisac:��6   $��DemiBold"�6!   $��14(�67   $
��Left=�6E   $��
120,75,0,0q�6`   $	��Top=�6t   �� 5   
   $��Zanr:��6   $��DemiBold"�6    $��14(�66   $
��Left=�6D   $��120,105,0,0q�6_   $	��Top=�6t   �� 5   
   $��Izdavac:��6   $��DemiBold"�6#   $��14(�69   $
��Left=�6G   $��120,135,0,0q�6b   $	��Top=�6w   �� 5   
   $��Racun:��6   $��DemiBold"�6!   $��14(�67   $
��Left=�6E   $��120,165,0,0q�6`   $	��Top=�6u   �� 5   
   $��Nabavka:��6   $��DemiBold"�6#   $��14(�69   $
��Left=�6G   $��120,195,0,0q�6b   $	��Top=�6w   �� 5   
   -   5         ��Name$ 	txtNaslov��5      $
��Left=�6%   $��23��6@   $��
200,50,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5         ��Name$ cbPisac��5      $
��Left=�6$   $��
200,80,0,0q�6?   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$ Pisac��6w   	 �� SelectedValuePath$	 PisacID��6�   �� 5   
   -   5        $ cbZanr��5      $
��Left=�6#   $��200,110,0,0q�6>   $	��Top=�6S   $	��120��6k   $ 
NazivZanra��6w   $	 ZanrID��6�   �� 5   
   -   5        $ 	cbIzdavac��5      $
��Left=�6&   $��200,140,0,0q�6A   $	��Top=�6V   $	��120��6n   $ NazivIzdavaca��6z   $	 	IzdavacID��6�   �� 5   
   -   5        $ cbRacun��5      $
��Left=�6$   $��200,170,0,0q�6?   $	��Top=�6T   $	��120��6l   $ CenaProdaje��6x   $	 RacunID��6�   �� 5   
   -   5        $ 	cbNabavka��5      $
��Left=�6&   $��200,200,0,0q�6A   $	��Top=�6V   $	��120��6n   $ CenaNabavke��6z   $	 	NabavkaID��6�   �� 5   
   -   5        
 ��Name$
 
btnSacuvaj��5      
���ؿ��$��Sačuvaj��6:   $��Italic$�6L   $��14(�6_   $
��Left=�6m   $��120,250,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        $
 	btnOtkazi��5      
���ؿ��$��Otkaži��69   $��Italic$�6J   $��14(�6]   $
��Left=�6k   $��250,250,0,0q�6�   $	��Top=�6�   $��75��6�   6�   5       5!      