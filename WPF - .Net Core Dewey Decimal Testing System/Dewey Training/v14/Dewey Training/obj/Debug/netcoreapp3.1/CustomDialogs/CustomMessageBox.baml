   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dewey_Training.CustomDialogsDewey_Training.CustomDialogs  5   	   3    -Dewey_Training.CustomDialogs.CustomMessageBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Dewey_Training.CustomDialogs     5   	     � Title$  CustomMessageBox��5   	   $	��250��6"   $	��500��6/   
������  � 
ResizeMode$ NoResize=�6T    � WindowStyle$
 None=�6j    � AllowsTransparency$
 True��6}    � WindowStartupLocation$ CenterScreen=�6�   .��5	      ��  �� CornerRadius$ 10��6   ���#474747$��0q�65   ���#242424._�5
   
   � .+�5      �� -   5         ��Name$ exitBtn��5      $��X��6&   $��Arial)�62   $��46(�6E   $
��Left=�6S   $��	459,0,0,0q�6n   $	��Top=�6�   $��42��6�    J� RenderTransformOrigin$ -1.633,2.27&�6�   $��41��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value

 ���� 67   �� 5      	 � ��

 �����67   �� 5      	 � ��$	
 Top=�6E   �� 5      	 � ��
 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� #��z��6-    �� Padding$ 0,0,0,1q�6W   ._�5   *   �� $��Stretch=�6;   $��Stretch=�6Y   5   '   5   #   5       �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5   "   �� 	 � ��
 �#db000f6?   5      5      5!      �� 5"      -   5         ��Name$ titleBar��5"   @   $y�Visible=�6   
������ $
��Left=�6R   $��42��6m   $	��Top=�6y   $	��459��6�   6�   �� 5#      -   5        $ OkBtn��5#      $��OK��6$   $
��Left=�61   $��330,200,0,0q�6L   $	��Top=�6a   $	��160��6y   $��40��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5$      -   5         ��Name$ Message��5$      $��Center=�6%   $��Message Content��6B   $��Center=�6\   $	��480��6w   
������ $	��150��6�   $��Center=�6�   $��Center=�5%      $��20(�6:   
�������
������ 6[   �� 5&      -   5        $ MessageHeader��5&      $
��Left=�6+   $��Message Header��6F   $	��Top=�6_   $	��157��6w   
������ $��42��6�   $��Center=�6�   $
��Left=�5'      $��16(�68   ���#FE5F55$��10,0,0,0q�6[   
������ 6m   5(      5)      5*      