   M S B A M L   `   `   `  ����J  FSportStatViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SportStatViewerSportStatViewer  5   	        SportStatViewer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SportStatViewer     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $
��Plik��6   .@�5      m� -   5        $��Wczytaj��5      6,   5      m� 5      $��
Statystyki��6   .@�5      m� -   5        $��Podstawowe miary��5      65   m� 5      -   5        $��Współczynnik korelacji��5      6;   5      m� 5      $��Legenda��6   .@�5      m� -   5        $��Pokaż��5      6*   5      5      �� 5   
   $��Bottom=�6   .@�5      �� -   5        $��-��5      $��30��5      5      �� 5       -   5        $��+��5!      $��30��5"      5#      5$      ]� 5&   
   .+�5'      �� $
��Auto=�5(      $
��Auto=�5)      $	��600��5*      .��5+      R� -   5        $��dataTreeView��5,      $
��Left=�5-      $	��180��5.      5/      �� 51      -   5        $��mapScrollViewer��52      $��10,10,10,10q�53      $
��Left=�54      $	��Top=�55      $��Visible=�56      .��58      �� -	   5        $��	mapCanvas��59      z�5=      �� 5>      -
   5        mapCanvasScaleTransform��5>   )   5@      5B      � 5D      -   5        $��previewPopup��5E      ��.  $��Relative=�5G      $��Slide=�5I       � AllowsTransparency .  � PlacementTarget 5H      ��  �� ElementName$ 	mapCanvas��.��5M      �� $	��210��6   $	��215��6%   .+�5N      F� 
�������$��2��6)   ��5O      �� 5P       �� Color$ #bdbdbd��6.    �� Opacity$	 0.9Q�6>   ��5R      B� 5S      .��5T   "   E�  E� 
StartPoint$	 0,0&�6-   .��5U   &   �� 	 �� Point$	 150,20&�62   �� 5V   &   
 �� Size$
 100,100��5W   )    �� RotationAngle$ 45Q�5X   )    �� 
IsLargeArc .  �� SweepDirection$ 	Clockwise=�5Z   )    �� Point$ 30,40&�5[   )   �� 5\   &   $		 0,0&�62   5]   #   5^      5`      �� 5b      -   5        $��	prevLabel��5c      $��13(�5d      ���#004c00$��Center=�5f      $	��140��5g      
 �� Top$ 15��5h       �� Left$ 20��5i      �� 5l      -   5        $��previewCanvas��5m      $	��150��5n      $	��150��5o      $ 40��5p      $ 30��5q      5r      5s      5u      5v      5w      