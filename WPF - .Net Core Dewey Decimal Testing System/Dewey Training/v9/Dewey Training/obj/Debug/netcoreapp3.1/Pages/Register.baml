   M S B A M L   `   `   `  ����I  EDewey Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dewey_Training.PagesDewey_Training.Pages  5      #    Dewey_Training.Pages.Register   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Dewey_Training.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Register��5
      .��5      � .+�5   
   �� $��Register��6   $��Center=�6#   $	��Top=�6@   $��83��6X   $	��240��6d   $��60(�6p   $��Rockwell)�6~   $��0,53,0,0q�6�   
�������6�   �� 5   
   -   5         ��Name$ registerBtn��5      $��Register Account��6&   $��Center=�6A   $��	0,472,0,0q�6^   $	��Top=�6q   $	��255��6�   $��48��6�   $��16(�6�   $��3��6�   $��Rockwell)�6�   $
��Bold"�6�   G� 5   
   -   5         G�Name$ confirmPassword��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Confirm Password��6   
�������$
��Bold"�6\      HintOpacity$
 0.85Q�6n   
�������$
��Left=�6�   $��35��6�   $��325,385,0,0q�6�   $	��Top=�6  $	��440��6  $��22(�6'  $��2��65  $��Rockwell)�6B  �� 5   
   -   5        $ backBtn��5      $
��🡄��6"   $
��Left=�6/   $��
25,-10,0,0q�6J   $	��Top=�6^   $��80��6v   $��80��6�   $��75(�6�   $��4��6�   $��Rockwell)�6�   $
��Bold"�6�   
������ ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 63   �� 5       � ��
 �����63   �� 5       � ��$	 Top=�6A   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� #��z��6)   	 �� Padding$	 0,0,0,1q�6S   ._�5   &   �� $��Stretch=�67   $��Stretch=�6U   5   #   5      5      
 �� Triggers
 5      P� 5        P� Property �@J�IsMouseOver P� Value$
 True��69   . �5!      ��  � �� �#e84f466;   5"      5$      5&      '  !MaterialDesignThemes.Wpf.PackIcon  5'   
      Kind$ 	LockCheck=�6"   
�������$��39��6F   $��35��6Q   $��281,385,0,0q�6]     5(   
   $
 Lock=�6"   
�������$��39��6A   $��35��6L   $��281,325,0,0q�6X   G� 5)   
   -   5        $ password��5)   �   $ Password��6   
�������$
��Bold"�6T   $
 0.85Q�6f   
�������$
��Left=�6�   $��35��6�   $��325,325,0,0q�6�   $	��Top=�6�   $	��440��6  $��22(�6  $��1��6&  $��Rockwell)�63    5*   
   $ Person=�6"   
�������$��39��6C   $��35��6N   $��281,265,0,0q�6Z   �� 5+   
   -   5         ��Name$ username��5+   �   $ Username��6   
�������$
��Bold"�6P   $
 0.85Q�6b   
�������$
��Left=�6�   $��35��6�   $��325,265,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6  $	��440��6  $��22(�6)  $��0��67  $��Rockwell)�6D  5,      5-      