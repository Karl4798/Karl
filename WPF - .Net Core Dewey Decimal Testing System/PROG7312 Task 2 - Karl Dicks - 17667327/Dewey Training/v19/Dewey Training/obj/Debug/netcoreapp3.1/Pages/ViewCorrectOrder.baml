   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      A%clr-namespace:Dewey_Training.ServicesDewey_Training.Services  5      +    %Dewey_Training.Pages.ViewCorrectOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      <
deweyTrain%clr-namespace:Dewey_Training.Services     5        N� Title$  ViewCorrectOrder��5
      .��5      � .+�5   
   �� -   5         ��Name$ Finish��5      $��Finish��6!   $
��Left=�62   $��836,637,0,0q�6M   $	��Top=�6b   $	��180��6z   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   ���#242424   DataGridTwo#��[  6'   $��0q�6Q    �� CornerRadius$ 10��6e   $	��791��6w   $	��645��6�   $��
9,53,250,9q�6�   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   5      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��62      CanUserResizeColumns$ False��6P      RowHeaderWidth$ 0Q�6m      CanUserAddRows$ False��6�   	   CanUserDeleteRows$	 False��6�   
   RowBackground
 �#fcf0bf   CanUserResizeRows$ False��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��16(�5      $��Rockwell)�6   
������ $
��Left=�6`   $	��791��6�   $	��Top=�6�   $	��645��6�   $��Center=�5   >      SelectionMode$ Single=�6b      
IsReadOnly$
 True��6y   $��0,0,0,0q�6�   *   $Dewey_Training.Services.VisualHelper   EnableRowsMove$
 True��5      ${�False��6?      AutoGenerateColumns$ False��6Q      GridLinesVisibility$ Vertical=�6m      VerticalGridLinesBrush
 �   �"   VerticalScrollBarVisibility$ Hidden=�6�   ��5   {   �� *DeweyDecimal+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Angle �� ScaleX �� ScaleY �� Triggers P� Property P� Value �� Color��%�  '        7 (�� r    5,   &   * SystemColors.HighlightBrushKey+)�� 5      8   "  6U   .�5      ��  � ��
 �����67   �� 5       � ��$ 3q�64   �� 5       � ��$ Center=�6E   �� 5       � ��$ Center=�6G   �� 5       � ��$ 16(�65   �� 5       � ��$
 Bold"�67   �� 5       �@�LayoutTransform 5      V� 5   "   .~�5   &   �� $	 -90Q�66   �� 5   &   $ 1Q�65   $ -1Q�6@   5    #   5"       5#      P� 5$       �@J�IsMouseOver$
 True��6=   . �5%   "   ��  � ��
 �����6?   5&      P� 5'       � {�$ False��6;   . �5(   "   ��  � ��
 �����6?   5)      5+      �� 5,      $ #ca3e47��6X   5-          Columns  5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn!   Header$! Decimal��6)   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6:   �� *	Decimal+  50      $! Author��6)   " 69   �� *Author+#   	CellStyle# 52      �� 53      *  $System.Windows.Controls.DataGridCell"  6   .�54      ��  � �� 55      �� 56   "   $ �� 
TargetType"$  62   .R�57   &   � #��z��6+   .+�58   *   �� $��Center=�6;   59   '   5:   #   5<      �� 5=       � ��$ 0q�6<   �� 5>       �@�FocusVisualStyle 6=   Z� �� 5?       � ��$
 15.5(�65   �� 5@       � ��$ Stretch=�6@   �� 5A       � ��$ Stretch=�6>   �� 5B       � ��$ Center=�6E   �� 5C       � ��$ Center=�6G   �� 5D       �@��TextAlignment$ Center=�6D   �� 5E       � ��$
 Bold"�67   �� 5F       � ��$
 70.4��62   �� 5G       �@�LayoutTransform 5H      V� 5I   "   .~�5J   &   �� $	 -90Q�66   �� 5K   &   $ 1Q�65   $ -1Q�6@   5L   #   5N      5O      % � LayoutTransform% 5Q      V� 5R      .~�5S      �� $ 90Q�6*   u� 5T      & u� Matrix$& -1, 0, 0, 1, 0, 0x�6*   5U      5W      5X      �� 5Y   
   $��Correct Book Order��6   
�������$��Rockwell)�6@   $��45(�6V   $��Center=�6d   $��Center=�6�   $	��Top=�6�   $��65��6�   $	��440��6�   $��	0,-28,0,0q�6�   5Z      5[      