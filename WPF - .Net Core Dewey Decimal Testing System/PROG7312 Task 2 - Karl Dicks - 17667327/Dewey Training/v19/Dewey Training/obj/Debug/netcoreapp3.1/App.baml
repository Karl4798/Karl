   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Dewey_TrainingDewey_Training  5          Dewey_Training.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:Dewey_Training     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        �� 	Resources  5         MyImageBrush �� ImageSource  DataGridOne  DataGridTwo �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value  ComboBoxTextBoxStyle
 ��Name  ComboBoxToggleButton � ColumnDefinitions ��Name F�Name �� Triggers �� 
TargetName  ComboBoxTextBox �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" P� 
SourceName# �� Padding$ �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme%   	BaseTheme&   PrimaryColor'   SecondaryColor( �� Source�� 5   
   $ 5�        5�      	% Light6.   & Red6@   ' Blue6S   �� 5�      $h( bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   %�  &	        &	 3     &	 c     '�� �     &	 �    &	 �    &	 =    '�� �    7  7  '��     �� 5
      $ Images/bookbackground.jpg��6.   �� 5      $ Images/datagridone.png��6-   �� 5      $ Images/datagridtwo.png��6-   �� 5      " ��6   .�5      ��  � �� �#FE5F556/   �� 5       � ��
 �����6/   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� #��z��6%   $ 5��6O   ._�5   "   �� $��Center=�63   $��Center=�6P   5      5      5       5      P� 5       �@J�IsMouseOver$
	 True��65   . �5      ��  � �� �#e84f4667   5      P� 5       � {�$	 False��63   . �5       ��  � �� �#ff807867   5!      5#      �� 5&      " ��61   .�5'      ��  � �� 5(      �� 5)      " ��6*   .R�5*      � .+�5+   "   �� $ 5,0,0,5��6)   $��1q�5,      #��z��5-      
���   �._�5/   &   �� $
 PART_ContentHost��63   50   #   51      52      54      55      �� 58      " d�6;   .R�59      �  5:      �� 5;      �� 5<      $��20 �6+   .+�5>      �� $ Border��5?      $��2��5@      $ 5��5A      ���#FE5F55���	#FF97A0A5$��0q�5D      �� 5E      $��0��5F      $ 0��5G      $��1q�5H      ���	#FF97A0A5$��0,0,1,0q�5J      F� 5K      $ Arrow��5L      $��1��5M      
�������$��Center=�5O      $��Center=�5P      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5Q      5S       5T      P� 5U       �@J�IsMouseOver$
	 true��6B   . �5V      �� $ Border��6!    � �� �#e84f466K   5W      P� 5X       � {�$	 False��63   . �5Y      �� $ Border��6!    � �� �#ff80786K   �� 5Z      $ Border��6!    � �� �#ff80786L   �� 5[       � �� �#88888867   �� 5\      $ Arrow��6!    � �� �#8888886D   5]      5_      �� 5a      " ��66   .R�5b      �� $ PART_ContentHost��6   $|�False��63   #��z��6E   5c      �� 5f      " ��6.   .�5g      ��  �@J�SnapsToDevicePixels$
 true��68   �� 5h       �@�OverridesDefaultStyle$
 true��6:   �� 5i       � ��$
 Auto=�6O   �� 5j       � ��$
 Auto=�6M   �� 5k       � ��$
 true��6B   �� 5l       � ��$	 120��6-   �� 5m       � ��$ 20��6.   �� 5n       � ��
 �����6/   �� 5o       � ��$ Rockwell)�6/   �� 5p       � ��$
 Bold"�6/   �� 5q       � �� 5r      �� 5s      " ��6*   .R�5t      � .+�5u   "   d� $��ToggleButton��5v      8��  $��2��5x      $|�false��5y      $ Press=�5{       5z      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5|   #   �� 5}   "   $��ContentSite��63   $ False��6F   #��z 6`   #��z 5~      #��z��5      $��3,3,23,3q�5�      $��Center=�5�      $��Center=�5�      �� 5�   "   $ PART_EditableTextBox��6*   8�� $
��Left=�5�      $��Center=�5�      $��3,3,23,3q�5�      $
|�True��5�      ���#ff7169
��� � �$y�Hidden=�5�      # z 5�      ��5�      Z� 5�      � 5�   "   $��Popup��5�      $��Bottom=�5�      #��z 5�      $
 True��5�      $|�False��5�      $��Slide=�5�      .��5�   &   � $��DropDown��6+   $
 True��5�      #��z 5�      #��z 5�      .+�5�   *   �� $ DropDownBorder��5�   !   ���#ff7169$��1q�5�   !   ���#8888885�   !   �� 5�   *   $��4,6,4,6q�67   $
 True��6H   .��5�   .   �� $
  True��69   $! 	Contained=�6L   5�   +   5�   '   5�   #   5�       5�      P� 5�   "    �@��HasItems$	 false��6>   . �5�   &   �� $ DropDownBorder��6-    � ��$ 95��6^   5�   #   P� 5�   "    � {�$	 false��6?   . �5�   &   ��  � ��
 �����6C   5�   #   P� 5�   "    �@��
IsGrouping$
	 true��6@   . �5�   &   ��  � ��$ false��6V   5�   #   P� 5�   "   $" Popup��6*    �@�AllowsTransparency$
	 true��6a   . �5�   &   �� $ DropDownBorder��6-    �@��CornerRadius$ 0��6a   �� 5�   &   $ DropDownBorder��6-    � ��$ 0,2,0,0q�6[   5�   #   P� 5�   "    �@��
IsEditable$
	 true��6A   . �5�   &   ��  � ��$ false��6B   �� 5�   &   $ PART_EditableTextBox��6-    � y�$ Visible=�6e   �� 5�   &   $ ContentSite��6-    � y�$ Hidden=�6\   5�   #   5�      5�       5�      5�      �� 5�      " ��62   .�5�      ��  �@J�SnapsToDevicePixels$
 true��68   �� 5�       � ��
 �����6/   �� 5�       �@�OverridesDefaultStyle$
 true��6:   �� 5�       � �� 5�      �� 5�      " ��6*   .R�5�      �� $��Border��6%   $# 2q�5�      $
 true��5�      ._�5�   "   �� 5�       5�      P� 5�   "    �@��IsHighlighted$
	 true��6C   . �5�   &   �� $ Border��6-    � �� �#e84f466W   5�   #   P� 5�   "    � {�$	 false��6?   . �5�   &   ��  � �� �#2424246C   5�   #   5�      5�      5�      5�      5�      