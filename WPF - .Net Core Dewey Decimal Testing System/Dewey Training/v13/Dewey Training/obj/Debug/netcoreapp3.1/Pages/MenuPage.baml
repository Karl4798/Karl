   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      /clr-namespace:Dewey_TrainingDewey_Training  5      #    Dewey_Training.Pages.MenuPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      7Dewey_Trainingclr-namespace:Dewey_Training     5        N� Title$  MenuPage��5
      .��5      � .+�5   
   �� $��Dewy Training��6   
�������$��Rockwell)�6;   $��45(�6Q   $��Center=�6_   $��Center=�6�   $	��Top=�6�   $��65��6�   $	��344��6�   $��	0,-23,0,0q�6�   �� 5   
   -   5         ��Name$ LoginBtn��5      $��Login��6#   $
��Left=�63   $��	30,67,0,0q�6N   $	��Top=�6a   $	��180��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ ReplaceBooks��5      $��Replace Books��6'   $
��Left=�6?   $��
30,162,0,0q�6Z   $	��Top=�6n   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ IdentifyingAreas��5      $��Identify Areas��6+   $
��Left=�6D   $��
30,257,0,0q�6_   $	��Top=�6s   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ FindCallNumbers��5      $��Find Call Numbers��6*   $
��Left=�6F   $��
30,352,0,0q�6a   $	��Top=�6u   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   ${�False��6�   �� 5   
   -   5         ��Name$ 
Difficulty��5      $
��Left=�6V   $��
30,643,0,0q�6q   $	��Top=�6�   $	��180��6�   $��48��6�    �� SelectedIndex$ 0��6�   $��16(�6�   $��Rockwell)�6�   .@�5      �� .��6   Easy6!   �� 5      .��6   Medium6#   �� 5      .��6   Hard6!   5      �� 5   
   ���#242424   DataGridOne#��[  6'   $��0q�6Q    �� CornerRadius$ 10��6e   $	��791��6w   $	��645��6�   $��
252,57,6,5q�6�   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   e      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��62      CanUserResizeColumns$ False��6P   	   RowHeaderWidth$	 0Q�6m   
   CanUserAddRows$
 False��6�      CanUserDeleteRows$ False��6�      RowBackground �#fcf0bf   CanUserResizeRows$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 61   $��16(�6A   $��Rockwell)�6O   
������ $��Center=�6�   $��Center=�5      $	��791��62   $��Center=�6k   $��Center=�6�      SelectionMode$ Single=�5         
IsReadOnly$
 True��6.   ${�False��6@      AutoGenerateColumns$ False��6R      GridLinesVisibility$ 
Horizontal=�6n      HorizontalGridLinesBrush
 �   �$	��637��6�   "   VerticalScrollBarVisibility$ Hidden=�6�   ��5   �   �� *Scores+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Username+6V     5      $ Score / Time (S)��6)    6C   �� *	UserScore+6c     5      $ 
Time Taken��6)    6=   �� *
DateTime+6\    � 	Resources 5!      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Color��%L  '        7 (�� �     5)   &   * SystemColors.HighlightBrushKey+)�� 5"      8   "  6U   .�5#      ��  � ��
 �����67   �� 5$       � ��$ 0q�64   �� 5%       � ��$ Center=�6E   �� 5&       � ��$ Center=�6G   �� 5'       � ��$ 35(�65   5(      �� 5)      $ #ca3e47��6X   5*         	CellStyle 5+      �� 5,      *  $System.Windows.Controls.DataGridCell"  6   .�5-      ��  � �� 5.      �� 5/   "    �� 
TargetType"  62   .R�50   &   � #��z��6+   .+�51   *   �� $��Center=�6;   52   '   53   #   55      �� 56       � ��$ 0q�6<   �� 57       �@�FocusVisualStyle 6=   Z� �� 58       � ��$ 22(�65   �� 59       � ��$ Stretch=�6@   �� 5:       � ��$ Stretch=�6>   �� 5;       � ��$ Stretch=�6E   �� 5<       �@��TextAlignment$ Center=�6D   �� 5=       � ��$
 59px��63   5>      5@      5A      �� 5B   
   $��Set Difficulty��6   
�������$
��Bold"�6<   $��Rockwell)�6N   $��16(�6d   $��Center=�6r   $
��Left=�6�   $	��Top=�6�   $��25��6�   $	��180��6�   $��
30,613,0,0q�6�   �� 5C   
   -   5        $ ScoreSelection��5C      $
��Left=�6^   $��
30,541,0,0q�6y   $	��Top=�6�   $	��180��6�   $��48��6�   $ 0��6�   $��16(�6�   $��Rockwell)�6�   .@�5D      �� $��Replace Books��6   �� 5E      $��Identify Areas��6   �� 5F      $��Find Call Numbers��6   ${�False��67   5G      �� 5H   
   $��Set Score View��6   
�������$
��Bold"�6<   $��Rockwell)�6N   $��16(�6d   $��Center=�6r   $
��Left=�6�   $	��Top=�6�   $��25��6�   $	��180��6�   $��
30,511,0,0q�6�   5I      5J      