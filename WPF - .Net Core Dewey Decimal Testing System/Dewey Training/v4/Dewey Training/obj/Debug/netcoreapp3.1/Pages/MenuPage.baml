   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      /clr-namespace:Dewey_TrainingDewey_Training  5      #    Dewey_Training.Pages.MenuPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      7Dewey_Trainingclr-namespace:Dewey_Training     5        N� Title$  MenuPage��5
      .��5      � .+�5   
   �� $��Dewy Training��6   
�������$��Rockwell)�6;   $��45(�6Q   $��Center=�6_   $��Center=�6�   $	��Top=�6�   $��65��6�   $	��344��6�   $��	0,-18,0,0q�6�   �� 5   
   -   5         ��Name$ LoginBtn��5      $��Login��6#   $
��Left=�63   $��	30,64,0,0q�6N   $	��Top=�6a   $	��180��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ ReplaceBooks��5      $��Replace Books��6'   $
��Left=�6?   $��
30,159,0,0q�6Z   $	��Top=�6n   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ IdentifyingAreas��5      $��Identify Areas��6+   $
��Left=�6D   $��
30,254,0,0q�6_   $	��Top=�6s   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   ${�False��6  �� 5   
   -   5        $ FindCallNumbers��5      $��Find Call Numbers��6*   $
��Left=�6F   $��
30,349,0,0q�6a   $	��Top=�6u   $	��180��6�   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   ${�False��6�   �� 5   
   -   5         ��Name$ 
Difficulty��5      $
��Left=�6V   $��
30,649,0,0q�6q   $	��Top=�6�   $	��180��6�   $��48��6�    �� SelectedIndex$ 0��6�   $��16(�6�   $��Rockwell)�6�   .@�5      �� .��6   Easy6!   �� 5      .��6   Medium6#   �� 5      .��6   Hard6!   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5        CanUserSortColumns$ False��6      CanUserReorderColumns$ False��6.      CanUserResizeColumns$ False��6L      RowHeaderWidth$ 0Q�6i   	   CanUserAddRows$	 False��6|   
   CanUserDeleteRows$
 False��6�      RowBackground �#fcf0bf   CanUserResizeRows$ False��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��16(�6�   $��Rockwell)�6�   
������ $
��Left=�5      $	��Top=�6M   $	��794��6e   $��Center=�6�   $��Center=�6�   
������    SelectionMode$ Single=�6�      
IsReadOnly$
 True��6  $��
246,60,0,0q�5      ${�False��6'      AutoGenerateColumns$ False��69   $	��637��6U   ��5   .   �� *Scores+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
Username+6R     5      $ Score / Time��6%    6;   �� *	UserScore+6[     5      $ 
Time Taken��6%    69   �� *
DateTime+6X    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value �� Color��%v  '        7 (��     5(   "   * SystemColors.HighlightBrushKey+)�� 5       8   "  6Q   .�5!      ��  � �� �#24242463   �� 5"       � ��
 �����63   �� 5#       � ��$ 0q�60   �� 5$       � ��$ Center=�6A   �� 5%       � ��$ Center=�6C   �� 5&       � ��$ 35(�61   5'      �� 5(      $ #ca3e47��6T   5)         	CellStyle 5*      �� 5+      *  $System.Windows.Controls.DataGridCell"  6   .�5,      ��  � �� 5-      �� 5.       �� 
TargetType"  6.   .R�5/   "   � #��z��6'   .+�50   &   �� $��Center=�67   51   #   52      54      �� 55       � ��$ 0q�68   �� 56       �@�FocusVisualStyle 69   Z� �� 57       � ��$ 22(�61   �� 58       � ��$ Stretch=�6<   �� 59       � ��$ Stretch=�6:   �� 5:       � ��$ Stretch=�6A   �� 5;       �@��TextAlignment$ Center=�6@   �� 5<       � ��$
 60px��6/   5=      5?      �� 5@   
   $��Set Difficulty��6   
�������$
��Bold"�6<   $��Rockwell)�6N   $��16(�6d   $��Center=�6r   $
��Left=�6�   $	��Top=�6�   $��25��6�   $	��180��6�   $��
30,619,0,0q�6�   5A      5B      