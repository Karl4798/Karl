   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      /clr-namespace:Dewey_TrainingDewey_Training  5      '    !Dewey_Training.Pages.ReplaceBooks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      3
deweyTrainclr-namespace:Dewey_Training     5        N� Title$  ReplaceBooks��5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5        CanUserSortColumns$ False��6      CanUserReorderColumns$ False��6.      CanUserResizeColumns$ False��6L      RowHeaderWidth$ 0Q�6i      CanUserAddRows$ False��6|      CanUserDeleteRows$ False��6�      RowBackground �#fcf0bf	   CanUserResizeRows$	 False��6�   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   $��16(�6�   $��Rockwell)�6�   ���#fcf0bf$
��Left=�5      $	��488��6M   $��Center=�6Z   $	��628��6u   $��Center=�6�   $��Center=�6�   
������    SelectionMode$ Single=�6     
IsReadOnly$
 True��6%  $��	162,0,0,0q�67  !   Dewey_Training.VisualHelper   EnableRowsMove$
 True��6J  ${�False��6x  ��6(   �� *DeweyDecimal+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Color��%v  '        7 (��     5   "   * SystemColors.HighlightBrushKey+)�� 5      8   "  6Q   .�5      ��  � �� �#24242463   �� 5       � ��
 �����63   �� 5       � ��$ 5q�60   �� 5       � ��$ Center=�6A   �� 5       � ��$ Center=�6C   �� 5       � ��$ 25(�61   5      �� 5      $ #ca3e47��6T   5         	CellStyle 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6   .�5      ��  � ��$ 0q�68   �� 5       �@�FocusVisualStyle 69   Z� �� 5       � ��$ 37(�61   �� 5        � ��$ Stretch=�6<   �� 5!       � ��$ Stretch=�6:   �� 5"       � ��$ Stretch=�6A   �� 5#       �@��TextAlignment$ Center=�6@   5$      5&      �� 5'   
   -   5         ��Name$ Start��5'      $��Start��6    $
��Left=�60   $��
10,445,0,0q�6K   $	��Top=�6_   $	��141��6w   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5(   
   $��Elapsed Time��6   $
��Left=�6'   $��
10,200,0,0q�6B   $	��Top=�6V   
�������$	��141��6�    J� RenderTransformOrigin$ 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��20(�6�   �� 5)   
   -   5         ��Name$ 
TimerLabel��5)      $��00:00:00��6$   $
��Left=�67   $��
10,243,0,0q�6R   $	��Top=�6f   
�������$	��141��6�   $ 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��18(�6�   �� 5*   
   -   5        $ Return��5*      $��Return��6!   $
��Left=�62   $��
10,382,0,0q�6M   $	��Top=�6a   $	��141��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   5+      5,      