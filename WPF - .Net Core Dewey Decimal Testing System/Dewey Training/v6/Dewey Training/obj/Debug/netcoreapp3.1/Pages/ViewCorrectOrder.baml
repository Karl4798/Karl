   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      /clr-namespace:Dewey_TrainingDewey_Training  5      +    %Dewey_Training.Pages.ViewCorrectOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      3
deweyTrainclr-namespace:Dewey_Training     5        N� Title$  ViewCorrectOrder��5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   7      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��6.      CanUserResizeColumns$ False��6L      RowHeaderWidth$ 0Q�6i      CanUserAddRows$ False��6|      CanUserDeleteRows$ False��6�      RowBackground �#fcf0bf	   CanUserResizeRows$	 False��6�   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   $��16(�5      $��Rockwell)�6!   
������ $
��Left=�6b   $	��880��6�   $	��Top=�6�   $	��692��6�   $��Center=�5   @   
������    SelectionMode$ Single=�6~      
IsReadOnly$
 True��6�   $��10,8,0,0q�6�   !   Dewey_Training.VisualHelper   EnableRowsMove$
 True��5      ${�False��6A      AutoGenerateColumns$ False��6S   ��5   }   �� *DeweyDecimal+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Angle �� ScaleX �� ScaleY �� Triggers P� Property P� Value �� Color��%  '        7 (�� �    5+   "   * SystemColors.HighlightBrushKey+)�� 5      8   "  6Q   .�5      ��  � �� �#24242463   �� 5       � ��
 �����63   �� 5       � ��$ 3q�60   �� 5       � ��$ Center=�6A   �� 5       � ��$ Center=�6C   �� 5       � ��$ 16(�61   �� 5       � ��$
 Bold"�63   �� 5       �@�LayoutTransform 5      V� 5      .~�5   "   �� $	 -90Q�62   �� 5   "   $ 1Q�61   $ -1Q�6<   5      5!       5"      P� 5#       �@J�IsMouseOver$
 True��69   . �5$      ��  � ��
 �����6;   5%      P� 5&       � {�$ False��67   . �5'      ��  � ��
 �����6;   5(      5*      �� 5+      $ #ca3e47��6T   5,         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Decimal��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Decimal+  5/      $ Author��6%    65   �� *Author+   	CellStyle 51      �� 52      *  $System.Windows.Controls.DataGridCell"  6   .�53      ��  � �� 54      �� 55       �� 
TargetType"  6.   .R�56   "   � #��z��6'   .+�57   &   �� $��Center=�67   58   #   59      5;      �� 5<       � ��$ 0q�68   �� 5=       �@�FocusVisualStyle 69   Z� �� 5>       � ��$
 17.5(�61   �� 5?       � ��$ Stretch=�6<   �� 5@       � ��$ Stretch=�6:   �� 5A       � ��$ Center=�6A   �� 5B       � ��$ Center=�6C   �� 5C       �@��TextAlignment$ Center=�6@   �� 5D       � ��$
 Bold"�63   �� 5E       � ��$
 78.5��6.   �� 5F       �@�LayoutTransform 5G      V� 5H      .~�5I   "   �� $	 -90Q�62   �� 5J   "   $ 1Q�61   $ -1Q�6<   5K      5M      5N        � LayoutTransform  5P      V� 5Q      .~�5R      �� $ 90Q�6&   u� 5S      ! u� Matrix$! -1, 0, 0, 1, 0, 0x�6&   5T      5V      �� 5W   
   -   5        " ��Name$" Finish��5W      $��Finish��6!   $
��Left=�62   $��893,652,0,0q�6M   $	��Top=�6b   $	��141��6z   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   5X      5Y      