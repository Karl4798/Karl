   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      *    $Dewey_Training.Pages.FindCallNumbers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5        N� Title$  FindCallNumbers��5	      .��5      � .+�5   
   �� $��Find Call Numbers��6   
�������$��Rockwell)�6?   $��45(�6U   $��Center=�6c   $��Center=�6�   $	��Top=�6�   $��65��6�   $	��400��6�   $��	0,-28,0,0q�6�   �� 5   
   $��Description:��6   
�������$��Rockwell)�6:   $��30(�6P   $��Center=�6^   $
��Left=�6�   $	��Top=�6�   $��45��6�   $	��175��6�   $��
25,156,0,0q�6�   �� 5   
   $��205,151,25,448q�6    �� Padding$ 5q�6)   $��1q�65   ���#fcf0bf���#fcf0bf �� CornerRadius$ 10��6t   ._�5      �� -   5         ��Name$ lblQuestion��5       �� Padding$ 10q�6-   
���   �$��Rockwell)�6M   $��30(�6c   $
��Wrap=�6q   $��Center=�6�   $��Center=�6�   $	��100��6�   $	��812��6�   5      �� 5   
   -   5         ��Name$ lblQuestionLvl��5      $9��3Which decimal does the below description belong to?��6(   
�������$��Rockwell)�6y   $��30(�6�   $��Center=�6�   $��Center=�6�   $	��Top=�6�   $��50��6�   $
��1000��6  $��0,96,0,0q�6  �� 5   
   -   5         ��Name$ listBoxLevels��5   6   $��25(�6   $��Rockwell)�6    $��Center=�6M   $	��374��6�   $	��Top=�6�   $
��1000��6�   $��Center=�5   B    �� SelectionMode$ Single=�6f   $��	0,267,0,0q�6}   $��Disabled=�6�   $��Disabled=�5      ��5   j   �� *Levels+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%_   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 10��65   5      5      5      �� 5   
   -   5         ��Name$
 Next��5      $
��Next��6   $
��Left=�6.   $��884,649,0,0q�6I   $	��Top=�6^   $	��141��6v   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $
��Left=�62   $��
25,649,0,0q�6M   $	��Top=�6a   $	��141��6y   $��48��6�   $��16(�6�   $��1��6�   $��Rockwell)�6�   $
��Bold"�6�   6�   �� 5   
   $��Time Remaining��6   $
��Left=�6)   $��
404,40,0,0q�6D   $	��Top=�6X   
�������$	��222��6�    J� RenderTransformOrigin$ 
1.004,0.55&�6�   $��50��6�   $��Center=�6�   $��30(�6�   �� 5   
   $��648,45,357,612q�6   $ 0q�6)   $��1q�65   ���#fcf0bf���#fcf0bf$ 10��6t   $��50��6�   $��45��6�   ._�5      �� -   5        $ 
TimerLabel��5      $��00��6(   $��Center=�65   $��Center=�6R   
���   �$��45��6�   $ 
0.62,0.634&�6�   $��50��6�   $��Center=�6�   $��30(�6�   5       5"      5#      