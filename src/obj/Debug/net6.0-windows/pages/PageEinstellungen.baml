   M S B A M L   `   `   `  ����G  Cahif_academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ahif_academy.pagesahif_academy.pages  5      *    $ahif_academy.pages.PageEinstellungen   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ahif_academy.pages     5        N� Title$  PageEinstellungen��5	      .��5      �    FrameBackground#���   6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��3.5* �6   .+�5   
   ��   borderBackground#���  6    �� CornerRadius$ 25��6A   $��5,5,5,30q�6S   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $
��left=�6M   .+�5      A� $��80��6   $��80��6%   $��10,0,0,0q�61   ��5      �� 5       �� ImageSource 6%   ��  �� Path$ 	ImagePath�5      �� 5      -   5         ��Name$ benutzername��5      $�� ��62   $��25(�6:   $��5,25,0,0q�6H   5      5      �� 5   
   $��1��6   $ 
Horizontal=�6#   .+�5      �� $	��180��6   $��	5,5,5,315q�6!   #���  64   $ 25��6d   ._�5      �� $��15q�6   .+�5       �� $
��Mode��6    $��Center=�6,   $��20(�6I   $
��Bold"�6W   $��0,0,0,5q�6i   d� 5!      -   5         d�Name$ ThemeToggleButton��5!   $   $��1��6?   $	��Top=�6L   $��Center=�6d   $��5q�6�   $	��120��6�   $��60��6�    � Cursor$
 Hand��6�     ThemeToggleButtonStyle#���  6�   5"      5#      5$      �� 5%      $��
77,5,5,315q�6   $	��180��6)   #���  65   $ 25��6e   ._�5&      �� $��15q�6   .+�5'      �� $��Benutzername��6    $��Center=�64   $��20(�6Q   $
��Bold"�6_   $��0,0,0, 5q�6q   �� 5(      -   5        	 ��Name$	 changeBenutzername��5(      $	��100��6:   $��40��6F   $��Center=�6R   $��20(�6o   $
��Bold"�6}   $��14q�6�   �� 5)      -   5        $��60��5)      $��60��6)   $��Bottom=�6I   .��5*      �� $��../pictures/speichern.png��6    $��30��6C   $��30��6O   5+      5,      5-      �� 5.      $��1��6   $ 
Horizontal=�6&   $��
77,0,0,310q�6?   .+�5/      �� $��5q�6   $	��180��6$   #���  60   $ 25��6`   ._�50      �� $��15q�6!   .+�51      �� $��
Profilbild��6$   $��Center=�66   $��20(�6S   $
��Bold"�6a   $��0,0,0,5q�6s   �� 52      -   5        
 ��Name$
 
Profilbild��52   F   $	��100��6#   $��50��6/   $��8q�6;   $��20(�6�   $��Center=�6�   $��Center=�6�   .@�53      �� $��Katze��6+   �� 54      $��	Spiderman��6+   �� 55      $
��Cool��6+   �� 56      $
��ToΣ��6+   57      59      5:      5;      �� 5<      $��
79,5,5,315q�6   $	��180��6)   #���  66   $ 25��6f   ._�5=      �� $��15q�6   .+�5>      �� $��Abmelden��6    $��Center=�60   $��20(�6M   $
��Bold"�6[   $��0,0,0, 5q�6m   �� 5@      -   5         ��Name$ Abmelden��5@      $��0,70,0,0q�6/   $��60��6A   $	��100��6M   $��Abmelden��6Y   $��Bottom=�6�   5B      5C      5D      5F      5J      5K      