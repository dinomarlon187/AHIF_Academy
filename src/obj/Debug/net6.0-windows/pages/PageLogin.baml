   M S B A M L   `   `   `  ����G  Cahif_academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ahif_academy.pagesahif_academy.pages  5      "    ahif_academy.pages.PageLogin   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ahif_academy.pages     5        N� Title$  	PageLogin��5	         
Background N� 
Background# �   6   .��5      �   FrameBackground#���  6   $��270,50,270,50q�6:    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      
BlurRadius$ 10Q�6,      ShadowDepth$ 7Q�6<      	Direction$	 320Q�6L      Opacity$	 0.5Q�6\    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   	 �� Orientation$	 
Horizontal=�60   $��8,0,0,0q�6I   .+�5      �� $��Hallo ��6   $��40(�6&   $
��Bold"�64   $��Calibri)�6F   
 �� TextAlignment$
 Center=�6[   �� 5      $��	Benutzer!��6   ���	#FF00A5D8$��40(�6@   $
��Bold"�6N   $��Calibri)�6`   $
 Center=�6u   5      �� 5   
   -   5         ��Name$ UsernameBox��5      $��1��6'   $��20(�64   $��Center=�6B   $��	5,30,5,30q�6d   6�   �� 5   
   -   5        $ placeholderPassword��5      $��20(�6/   $��Center=�6=   $y�Visible=�6_   $��2��6t   $��	5,30,5,30q�6�   6�   �� 5   
   -   5         ��Name$ zurueck��5      $��15(�6"   $��zurück��60   $��2��6A   
������ 
������ $
��left=�6�   $��Bottom=�6�   $��5,0,0,0q�6�   5      G� 5   
   -   5         G�Name$ PasswordBox��5      $��20(�6+   $��Center=�69   $y�	Collapsed=�6[   $��2��6r   $��	5,30,5,30q�6   6�   �� 5    
   -   5        $��3��5       $��Anmelden��6   $��	5,30,5,30q�62   6E   5"      5#      