   M S B A M L   `   `   `  ����K  GDevBuggerDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DevBuggerDesktop.WindowsDevBuggerDesktop.Windows  5   	   3    -DevBuggerDesktop.Windows.BugCategoryAddWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DevBuggerDesktop.Windows     5   	     � Title$  Add bug category��5   	   $	��450��6"   $	��325��6/   ���#292929$y�Visible=�6P   
�������.��5	      � -   5         �Name$ GridContainter��5	       � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��5      $��1��5      $��Name:��5      $
��Left=�5       $��Center=�5!      ���	#FFF6F9FE5"      �� 5$   
   -   5         ��Name$ TbName��5(      $��1��5%      $��3��5&      $��1��5'      $
��Left=�5)      $��23��5*       �� TextWrapping$
 Wrap=�5+      
����������#545d6a$��Center=�5.      $	��200��6(   ��5,      �� *Name+5.   (   �� 50   
   $��2��51      $��1��52      $��Description:��53      $
��Left=�54      $��Center=�55      ���	#FFF6F9FE56      �� 58   
   -   5        $ TbDescription��5=      $��2��59      $��3��5:      $��1��5;      $��4��5<      $
��Left=�5>      $	��220��5?      $
 Wrap=�5@      
����������#545d6a$��Center=�5C      $	��200��5D      ��5A      �� *Description+5D      �� 5F   
   -   5         ��Name$ btnAdd��5F      $	��Add��6!   $��3��6/   $��1��6?   $��6��6S   $��25��6`   $��0,0,0,0q�6l   ���	#FF87AFEA
�������6�   5I      5J      