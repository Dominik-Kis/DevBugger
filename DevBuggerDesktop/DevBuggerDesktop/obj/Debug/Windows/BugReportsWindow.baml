   M S B A M L   `   `   `  ����K  GDevBuggerDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DevBuggerDesktop.WindowsDevBuggerDesktop.Windows  5   	   /    )DevBuggerDesktop.Windows.BugReportsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DevBuggerDesktop.Windows     5   	     � Title$  Bug Report Detail��5   	   $	��450��6#   $
��1050��60   ���#292929$y�Visible=�6R   
�������.��5	      � -   5         �Name$ GridContainter��5	       � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��20 �6   .+�5%   
   �� $��1��5&      $��1��5'      $��IDBugReport:��5(      $
��Left=�5)      $��Center=�5*      ���	#FFF6F9FE5+      �� 5-   
   -   5         ��Name$ TbIDBugReport��51      $��1��5.      $��3��5/      $��2��50      $
��Left=�52      $��23��53       �� TextWrapping$
 Wrap=�54      
����������#545d6a$��Center=�57      $	��200��6(    �� 
IsReadOnly . ��55      �� *IDBugReport+57   4   �� 59   
   $��2��5:      $��1��5;      $��BugCategoryID:��5<      $
��Left=�5=      $��Center=�5>      ���	#FFF6F9FE5?      �� 5A   
   -   5        $ TbBugCategoryID��5E      $��2��5B      $��3��5C      $��1��5D      $
��Left=�5F      $��23��5G      $
 Wrap=�5H      
����������#545d6a$��Center=�5K      $	��150��6(    . ��5I      �� *BugCategoryID+5K   4   �� 5M   
   -   5         ��Name$ btnOpenBugCategory��5R      $��2��5N      $��4��5O      $��25��5P      $��Center=�5Q      ���#545d6a
�������$
��Open��5T      6   �� 5V   
   $��3��5W      $��1��5X      $��GamePageID:��5Y      $
��Left=�5Z      $��Center=�5[      ���	#FFF6F9FE5\      �� 5^   
   -   5        $ TbGamePageID��5b      $��3��5_      $��3��5`      $��1��5a      $
��Left=�5c      $��23��5d      $
 Wrap=�5e      
����������#545d6a$��Center=�5h      $	��150��6(    . ��5f      �� *
GamePageID+5h   4   �� 5j   
   -   5        $ btnOpenGame��5o      $��3��5k      $��4��5l      $��25��5m      $��Center=�5n      ���#545d6a
�������$
��Open��5q      6   �� 5s   
   $��4��5t      $��1��5u      $��
AccountID:��5v      $
��Left=�5w      $��Center=�5x      ���	#FFF6F9FE5y      �� 5{   
   -   5        $ TbAccountID��5      $��4��5|      $��3��5}      $��1��5~      $
��Left=�5�      $��23��5�      $
 Wrap=�5�      
����������#545d6a$��Center=�5�      $	��150��6(    . ��5�      �� *	AccountID+5�   4   �� 5�   
   -   5        $ btnOpenAccount��5�      $��4��5�      $��4��5�      $��25��5�      $��Center=�5�      ���#545d6a
�������$
��Open��5�      6   �� 5�   
   $��5��5�      $��1��5�      $��Title:��5�      $
��Left=�5�      $��Center=�5�      ���	#FFF6F9FE5�      �� 5�   
   -	   5        $ TbTitle��5�      $��5��5�      $��3��5�      $��2��5�      $
��Left=�5�      $��23��5�      $
 Wrap=�5�      
����������#545d6a$��Center=�5�      $	��200��5�      ��5�      �� *Title+5�      �� 5�   
   $��10��5�      $��1��5�      $��Created:��5�      $
��Left=�5�      $��Center=�5�      ���	#FFF6F9FE5�      �� 5�   
   -
   5        $ 	TbCreated��5�      $��10��5�      $��3��5�      $��2��5�      $
��Left=�5�      $��23��5�      $
 Wrap=�5�      
����������#545d6a$��Center=�5�      $	��200��5�       . ��5�      �� *	Created+5�      �� 5�   
   $��6��5�      $��1��5�      $��Description:��5�      $
��Left=�5�      $��Center=�5�      ���	#FFF6F9FE5�      �� 5�   
   -   5        $ TbDescription��5�      $��6��5�      $��3��5�      $��2��5�      $��4��5�      $
��Left=�5�      $	��160��5�      $
 Wrap=�5�      
����������#545d6a$��Center=�5�      $	��200��5�      ��5�      �� *Description+5�       � 5�   
   -   5          �Name$ frameDashboard��5�      $��6��6(   $��3��68   $��1��6L   $��8��6Y   	  � NavigationUIVisibility$	 Hidden=�6j   �� 5�   
   -   5        $ btnComments��5�      $��Comments��6&   $��6��69   $��9��6I   $��25��6V   $��	10,0,10,0q�6b   ���#545d6a
�������6�   �� 5�   
   -   5        $ 	btnUpdate��5�      $��Update��6$   $��6��65   $��10��6E   $��25��6S   $��	10,0,10,0q�6_   ���	#FF87AFEA
�������6�   �� 5�   
   -   5        $ 	btnDelete��5�      $��Delete��6$   $��7��65   $��10��6E   $��25��6S   $��	10,0,10,0q�6_   
���  ��
�������6�   5�      5�      