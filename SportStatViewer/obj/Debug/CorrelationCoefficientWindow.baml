   M S B A M L   `   `   `  ����m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  5   	   J FSportStatViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SportStatViewerSportStatViewer 5   	   2   ,SportStatViewer.CorrelationCoefficientWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �chartingmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5   	   /localclr-namespace:SportStatViewer     5   	   -   5          � Title$  Współczynnik korelacji��5	   	   $	��530��5
   	   $	��500��5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Województwo:��5      $��Center=�5       �� 5#   
   $��1��5$      $��Sport:��5%      $��Center=�5&      �� 5)   
   $��2��5*      $��Oś X:��5+      $��Center=�5,      �� 5/   
   $��3��50      $��Oś Y:��51      $��Center=�52      �� 55   
   $��4��56      $(��"Współczynnik korelacji Pearsona:��57      $��Center=�58      �� 5;   
   -   5        $��voivodeshipComboBox��5=      $��1��5<      $��5q�5>      �� 5A   
   -   5        $��sportComboBox��5D      $��1��5B      $��1��5C      $��5q�5E      �� 5H   
   -   5        $��axisXComboBox��5K      $��2��5I      $��1��5J      $��5q�5L      �� 5O   
   -   5        $��axisYComboBox��5R      $��3��5P      $��1��5Q      $��5q�5S      �� 5V   
   -   5        $��pearsonCoefficientLabel��5Y      $��4��5W      $��1��5X      $��Center=�5Z      �� 5]   
   $��5��5^      $��2��5_      .+�5a      7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5          Name$
 host��5a         Child. 5b      ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        	chart��   Series 5c      <   6System.Windows.Forms.DataVisualization.Charting.Series  5d         Name$ series��5e         	ChartType$ Column=�5f      	   
ChartAreas	 5j      ?   9System.Windows.Forms.DataVisualization.Charting.ChartArea  5k      
   Name$
 	chartArea��5l      5o      5p      5q      5r      5s      