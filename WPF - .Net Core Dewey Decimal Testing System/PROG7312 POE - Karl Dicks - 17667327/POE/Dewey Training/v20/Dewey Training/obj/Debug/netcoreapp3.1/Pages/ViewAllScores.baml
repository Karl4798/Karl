   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      (    "Dewey_Training.Pages.ViewAllScores   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5        N� Title$  ViewAllScores��5	      .��5      � .+�5   
   �� ���#242424   DataGridOne#��[  6'   $��0q�6Q    �� CornerRadius$ 10��6e   $	��791��6w   $	��645��6�   $��
252,57,6,5q�6�   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   e      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��62      CanUserResizeColumns$ False��6P      RowHeaderWidth$ 0Q�6m      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�   	   RowBackground	 �#fcf0bf
   CanUserResizeRows$
 False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 61   $��16(�6A   $��Rockwell)�6O   
������ $��Center=�6�   $��Center=�5      $	��791��62   $��Center=�6k   $��Center=�6�      SelectionMode$ Single=�5         
IsReadOnly$
 True��6.      AutoGenerateColumns$ False��6@      GridLinesVisibility$ 
Horizontal=�6\      HorizontalGridLinesBrush
 �   �$	��637��6�   ��5   �   �� *Scores+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User��6)   -   5        username��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   7   �� *
Username+6h     5      $ Score��6)   -   5        	userScore�� 5   8   �� *	UserScore+6k     5      $ Time (S)��6)   -   5        userTime�� 5   ;   �� *
UserTime+6l     5      $ 
Test Taken��6)    6=   �� *
DateTime+6\    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Color��%L  '        7 (�� �     5   &   * SystemColors.HighlightBrushKey+)�� 5      8   "  6U   .�5      ��  � ��
 �����67   �� 5       � ��$ 0q�64   �� 5       � ��$ Center=�6E   �� 5       � ��$ Center=�6G   �� 5       � ��$ 35(�65   5      �� 5      $ #ca3e47��6X   5          	CellStyle 5!      �� 5"      *  $System.Windows.Controls.DataGridCell"  6   .�5#      ��  � �� 5$      �� 5%   "    �� 
TargetType"  62   .R�5&   &   � #��z��6+   .+�5'   *   �� $��Center=�6;   5(   '   5)   #   5+      �� 5,       � ��$ 0q�6<   �� 5-       �@�FocusVisualStyle 6=   Z� �� 5.       � ��$ 22(�65   �� 5/       � ��$ Stretch=�6@   �� 50       � ��$ Stretch=�6>   �� 51       � ��$ Stretch=�6E   �� 52       �@��TextAlignment$ Center=�6D   �� 53       � ��$
 59px��63   54      56      57      �� 58   
   -   5         ��Name$ Return��58      $��Return��6!   $
��Left=�62   $��
34,637,0,0q�6M   $	��Top=�6a   $	��180��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 59   
   -   5         ��Name$ ScoreSelection��59      $
��Left=�6^   $��
34,562,0,0q�6y   $	��Top=�6�   $	��180��6�   $��48��6�    �� SelectedIndex$ 0��6�   $��16(�6�   $��Rockwell)�6�   .@�5:      �� $��Replace Books��6   �� 5;      $��Identify Areas��6   �� 5<      $��Find Call Numbers��6   5=      �� 5>   
   $��Set Score View��6   
�������$
��Bold"�6<   $��Rockwell)�6N   $��18(�6d   $��Center=�6r   $
��Left=�6�   $	��Top=�6�   $��25��6�   $	��180��6�   $��
34,532,0,0q�6�   �� 5?   
   $��View Personal Scores��6   
�������$��Rockwell)�6B   $��45(�6X   $��Center=�6f   $��Center=�6�   $	��Top=�6�   $��65��6�   $	��460��6�   $��	0,-28,0,0q�6�   5@      5A      