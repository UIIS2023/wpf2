   M S B A M L   `   `   `  ����F  BWPFKnjizara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:KnjizaraKnjizara  5   	       Knjizara.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Knjizara     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Knjizara��5   	   $	��450��6   $	��760��6'   
���� ��$��7q�5
   	   ��5      �� 5   
    �� ImageSource$+ %C:\Users\HP\Desktop\WPFKnjizara\3.jpg��6    j� Stretch$
 Fill=�6I   6Z   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly$
 True��6      CanUserAddRows$ False��5         SelectionUnit$ FullRow=�6*      SelectionMode$ Single=�6B   �� 5   
   $	��Top=�6    � Cursor$
 Hand��6-   	 �� Orientation$	 
Horizontal=�6;   .+�5      �� -   5        
 ��Name$
 	btnKnjiga��5      
���ؿ��$��
10,0, 0, 0q�6=   $��Knjiga��6Q   $��40��6b   $	��Top=�6n   $��50��6�   6�   �� 5      -   5        $
 btnZanr��5      
���ؿ��$��40,0,0,0q�6;   $
��Zanr��6M   $��40��6\   $	��Top=�6h   $��50��6�   6�   �� 5      -   5        $
 btnPisac��5      
���ؿ��$��40,0,0,0q�6<   $��Pisac��6N   $��40��6^   $	��Top=�6j   $��50��6�   6�   �� 5      -   5        $
 
btnIzdavac��5      
���ؿ��$��40,0,0,0q�6>   $��Izdavac��6Q   $��40��6c   $	��Top=�6o   $��50��6�   6�   �� 5      -   5        $
 btnKorisnik��5      
���ؿ��$��40,0,0,0q�6?   $��Korisnik��6Q   $��40��6d   $	��Top=�6p   $��50��6�   6�   �� 5      -   5        $
 btnKupac��5      
���ؿ��$��40,0,0,0q�6<   $��Kupac��6O   $��40��6_   $��50��6k   6v   �� 5      -   5        $
 
btnNabavka��5      
���ؿ��$��40,0,0,0q�6>   $��Nabavka��6P   $��40��6b   $	��Top=�6n   $��50��6�   6�   �� 5      -	   5        $
 btnRacun��5      
���ؿ��$��40,0,0,0q�6<   $��Racun��6O   $��50��6_   6j   5      �� 5   
   $	 
Horizontal=�6   $��Bottom=�6.   $
 Hand��6I   .+�5      �� -
   5        $
 btnDodaj��5      
���ؿ��$��Dodaj��6<   $	��120��6L   $��40��6X   $��100, 0, 0, 0q�6d   6z   �� 5      -   5        $
 	btnIzmeni��5      
���ؿ��$��Izmeni��6>   $	��120��6O   $��40��6[   $��70, 0, 0, 0q�6g   6|   �� 5       -   5        $
 	btnObrisi��5       
���ؿ��$��Obriši��6=   $	��120��6N   $��40��6Z   $��70, 0, 0, 0q�6f   6{   5!      5"      5#      