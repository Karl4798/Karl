   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      A%clr-namespace:Dewey_Training.ServicesDewey_Training.Services  5      '    !Dewey_Training.Pages.ReplaceBooks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      <
deweyTrain%clr-namespace:Dewey_Training.Services     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  ReplaceBooks��5      .��5      � .+�5   
   �� ���#242424   DataGridTwo#��[  6'   $��0q�6Q    �� CornerRadius$ 10��6e   $	��890��6w   $	��692��6�   $��	153,7,7,8q�6�   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   7      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��62      CanUserResizeColumns$ False��6P      RowHeaderWidth$ 0Q�6m      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�   	   RowBackground	 �#fcf0bf
   CanUserResizeRows$
 False��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��16(�5      $��Rockwell)�6!   
������ $
��Left=�6b   $	��885��6�   $	��Top=�6�   $	��692��6�   $��Center=�5   @      SelectionMode$ Single=�6d      
IsReadOnly$
 True��6{   $��0,0,0,0q�6�   *   $Dewey_Training.Services.VisualHelper   EnableRowsMove$
 True��5      ${�False��6A      AutoGenerateColumns$ False��6S      GridLinesVisibility$ Vertical=�6o      VerticalGridLinesBrush
 �   �"   VerticalScrollBarVisibility$ Hidden=�6�   ��5   }   �� *DeweyDecimal+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Angle �� ScaleX �� ScaleY �� Triggers P� Property P� Value �� Color��%�  '        7 (�� r    5.   &   * SystemColors.HighlightBrushKey+)�� 5      8   "  6U   .�5      ��  � ��
 �����67   �� 5       � ��$ 3q�64   �� 5       � ��$ Center=�6E   �� 5       � ��$ Center=�6G   �� 5       � ��$ 16(�65   �� 5       � ��$
 Bold"�67   �� 5       �@�LayoutTransform 5      V� 5   "   .~�5    &   �� $	 -90Q�66   �� 5!   &   $ 1Q�65   $ -1Q�6@   5"   #   5$       5%      P� 5&       �@J�IsMouseOver$
 True��6=   . �5'   "   ��  � ��
 �����6?   5(      P� 5)       � {�$ False��6;   . �5*   "   ��  � ��
 �����6?   5+      5-      �� 5.      $ #ca3e47��6X   5/         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn    Header$  Decimal��6)   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6:   �� *	Decimal+  52      $  Author��6)   ! 69   �� *Author+"   	CellStyle" 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � �� 57      �� 58   "   # �� 
TargetType"#  62   .R�59   &   � #��z��6+   .+�5:   *   �� $��Center=�6;   5;   '   5<   #   5>      �� 5?       � ��$ 0q�6<   �� 5@       �@�FocusVisualStyle 6=   Z� �� 5A       � ��$
 17.5(�65   �� 5B       � ��$ Stretch=�6@   �� 5C       � ��$ Stretch=�6>   �� 5D       � ��$ Center=�6E   �� 5E       � ��$ Center=�6G   �� 5F       �@��TextAlignment$ Center=�6D   �� 5G       � ��$
 Bold"�67   �� 5H       � ��$ 80��62   �� 5I       �@�LayoutTransform 5J      V� 5K   "   .~�5L   &   �� $	 -90Q�66   �� 5M   &   $ 1Q�65   $ -1Q�6@   5N   #   5P      5Q      $ � LayoutTransform$ 5S      V� 5T      .~�5U      �� $ 90Q�6*   u� 5V      % u� Matrix$% -1, 0, 0, 1, 0, 0x�6*   5W      5Y      5Z      �� 5[   
   -   5        & ��Name$& Start��5[      $��Start��6    $
��Left=�60   $��	6,649,0,0q�6K   $	��Top=�6^   $	��141��6v   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5\   
   $��Elapsed Time��6   $
��Left=�6'   $��
10,245,0,0q�6B   $	��Top=�6V   
�������$	��141��6�   ' J� RenderTransformOrigin$' 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��20(�6�   �� 5]   
   -   5        ( ��Name$( 
TimerLabel��5]      $��00��6$   $
��Left=�61   $��
10,288,0,0q�6L   $	��Top=�6`   
�������$	��141��6�   $' 
1.004,0.55&�6�   $��40��6�   $��Center=�6�   $��25(�6�   �� 5^   
   -   5        $& Return��5^      $��Return��6!   $
��Left=�62   $��	6,588,0,0q�6M   $	��Top=�6`   $	��141��6x   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   5_      5`      