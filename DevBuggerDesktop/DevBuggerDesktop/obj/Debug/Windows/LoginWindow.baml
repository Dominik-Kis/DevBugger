   M S B A M L   `   `   `  ����K  GDevBuggerDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DevBuggerDesktop.WindowsDevBuggerDesktop.Windows  5   	   *    $DevBuggerDesktop.Windows.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DevBuggerDesktop.Windows     5   	     � Title$  Login��5   	   $	��300��6   $	��400��6$   $��18(�60   ���#292929 � 
ResizeMode$ NoResize=�6S   
�������.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��2��6   $
��Left=�6$   $��Center=�6?   $��1��6Z   $��Email:��6g   $	��120��6u   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtEmail��5   �   $��2��6   $
��Left=�6"   $��Center=�6=   $��2��6X    �� TextWrapping$
 Wrap=�6e   $	��260��6y    �� 	MaxLength$	 100��6�   
����������#545d6a6�   �� 5   
   $��2��6   $
��Left=�6$   $��Center=�6?   $��3��6Z   $��	Password:��6g   $	��120��6x   $
��Bold"�6�   G� 5   
   -   5         G�Name$ txtPassword��5   �   $��2��6   $
��Left=�6&   $	��260��6A   $��4��6M   $��Center=�6Z    G� 	MaxLength$ 20��6u   ���#545d6a6�   �� 5    
   -   5        	 ��Name$	 btnLogin��5       $��2��6#   $��5��63   $��Login��6@   $
��Bold"�6P   $��30��6b   $��80��6n   $��Center=�6y   $��Center=�6�   ���#545d6a
�������6�   5"      5#      