   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      /clr-namespace:Dewey_TrainingDewey_Training  5      '    !Dewey_Training.Pages.ReplaceBooks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      3
deweyTrainclr-namespace:Dewey_Training     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  ReplaceBooks��5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   7      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��6.      CanUserResizeColumns$ False��6L      RowHeaderWidth$ 0Q�6i      CanUserAddRows$ False��6|      CanUserDeleteRows$ False��6�      RowBackground �#fcf0bf	   CanUserResizeRows$	 False��6�   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   $��16(�5      $��Rockwell)�6!   
������ $
��Left=�6b   $	��880��6�   $	��Top=�6�   $	��692��6�   $��Center=�5   @   
������    SelectionMode$ Single=�6~      
IsReadOnly$
 True��6�   $��	162,8,0,0q�6�   !   Dewey_Training.VisualHelper   EnableRowsMove$
 True��5      ${�False��6A      AutoGenerateColumns$ False��6S   ��5   }   �� *DeweyDecimal+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Angle �� ScaleX �� ScaleY �� Triggers P� Property P� Value �� Color��%  '        7 (�� �    5.   "   * SystemColors.HighlightBrushKey+)�� 5      8   "  6Q   .�5      ��  � �� �#24242463   �� 5       � ��
 �����63   �� 5       � ��$ 3q�60   �� 5       � ��$ Center=�6A   �� 5       � ��$ Center=�6C   �� 5       � ��$ 16(�61   �� 5       � ��$
 Bold"�63   �� 5       �@�LayoutTransform 5      V� 5      .~�5    "   �� $	 -90Q�62   �� 5!   "   $ 1Q�61   $ -1Q�6<   5"      5$       5%      P� 5&       �@J�IsMouseOver$
 True��69   . �5'      ��  � ��
 �����6;   5(      P� 5)       � {�$ False��67   . �5*      ��  � ��
 �����6;   5+      5-      �� 5.      $ #ca3e47��6T   5/         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Decimal��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Decimal+  52      $ Author��6%    65   �� *Author+   	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � �� 57      �� 58       �� 
TargetType"  6.   .R�59   "   � #��z��6'   .+�5:   &   �� $��Center=�67   5;   #   5<      5>      �� 5?       � ��$ 0q�68   �� 5@       �@�FocusVisualStyle 69   Z� �� 5A       � ��$
 17.5(�61   �� 5B       � ��$ Stretch=�6<   �� 5C       � ��$ Stretch=�6:   �� 5D       � ��$ Center=�6A   �� 5E       � ��$ Center=�6C   �� 5F       �@��TextAlignment$ Center=�6@   �� 5G       � ��$
 Bold"�63   �� 5H       � ��$
 79.9��6.   �� 5I       �@�LayoutTransform 5J      V� 5K      .~�5L   "   �� $	 -90Q�62   �� 5M   "   $ 1Q�61   $ -1Q�6<   5N      5P      5Q        � LayoutTransform  5S      V� 5T      .~�5U      �� $ 90Q�6&   u� 5V      ! u� Matrix$! -1, 0, 0, 1, 0, 0x�6&   5W      5Y      �� 5Z   
   -   5        " ��Name$" Start��5Z      $��Start��6    $
��Left=�60   $��
10,649,0,0q�6K   $	��Top=�6_   $	��141��6w   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5[   
   $��Elapsed Time��6   $
��Left=�6'   $��
10,245,0,0q�6B   $	��Top=�6V   
�������$	��141��6�   # J� RenderTransformOrigin$# 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��20(�6�   �� 5\   
   -   5        $ ��Name$$ 
TimerLabel��5\      $��00��6$   $
��Left=�61   $��
10,288,0,0q�6L   $	��Top=�6`   
�������$	��141��6�   $# 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��25(�6�   �� 5]   
   -   5        $" Return��5]      $��Return��6!   $
��Left=�62   $��
10,586,0,0q�6M   $	��Top=�6a   $	��141��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   5^      5_      