   M S B A M L   `   `   `  ����G  Cahif_academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ahif_academy.pagesahif_academy.pages  5      $    ahif_academy.pages.PageProfile   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ahif_academy.pages     5        N� Title$  	PageLogin��5	         
Background N� 
Background# �   6   .��5      �   FrameBackground#���  6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��3.5* �6   .+�5   
   ��   borderBackground#���  6    �� CornerRadius$ 25��6A   $��5,5,5,30q�6S   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $
��left=�6M   .+�5      A� $��80��6   $��80��6%   $��10,0,0,0q�61   ��5      �� 5       �� ImageSource 6%   ��  �� Path$ 	ImagePath�5      �� 5      -   5         ��Name$ benutzername��5   $   $�� ��6   $��25(�6:   $��5,25,0,0q�6H   5      5      � 5   
   $��1��6    5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $ 
Horizontal=�6&   $��Center=�6?   .+�5       �� -   5         ��Name$ AllgemeinButton��5       
������ 
���   �$��	Allgemein��6^   $��30(�6r   $	��200��6�   $��60��6�   $��10q�6�   6�   �� 5!      -   5        $ DeutschButton��5!      
������ 
���   �$��Deutsch��6]   $��30(�6o   $	��200��6}   $��60��6�   $��10q�6�   6�   �� 5"      -   5        $ MatheButton��5"      
������ 
���   �$��Mathe��6Z   $��30(�6j   $	��200��6x   $��60��6�   $��10q�6�   6�   5#      �� 5$      -   5        	 ��Name$	 canvas��5$      $��1��6%   $��Stretch=�62   $��5q�6N   5&      5'      5)      5*      