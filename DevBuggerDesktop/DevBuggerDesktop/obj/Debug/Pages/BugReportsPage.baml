   M S B A M L   `   `   `  ����K  GDevBuggerDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DevBuggerDesktop.UtilDevBuggerDesktop.Util  5      ?$clr-namespace:DevBuggerDesktop.PagesDevBuggerDesktop.Pages  5      +    %DevBuggerDesktop.Pages.BugReportsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4util#clr-namespace:DevBuggerDesktop.Util     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:DevBuggerDesktop.Pages     5        N� Title$  BugReportsPage��5
       N� 
Background �#292929.��5      � .+�5   
   �� -   5         ��Name$ LvBugReports��5       �� AlternationCount$ 2��5      $
��auto��6"   $��0q�60   $
��auto��6;   ���#292929(   "DevBuggerDesktop.Util.GridViewSort   AutoSort . ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 �����63   �� 5       � ��
 �   �63    �� Triggers 5      ]� 5      	 ]� 
Conditions	 5      �� 5   "   
 �� Property
 �@��
IsSelected �� Value . 6B   ./�5      ��  � �� �#545d6a6;   �� 5       � ��
 �����6;   5       5#       �� View 5%      �� 5&      .P�5'      �� $��IDBugReport��5(         PropertyName$ IDBugReport��5*       �� DisplayMemberBinding 5)      �� *IDBugReport+5*      �� 5+      $��BugCategoryID��5,      $ BugCategoryID��5.       5-      �� *BugCategoryID+5.      �� 5/      $��
GamePageID��50      $ 
GamePageID��52       51      �� *
GamePageID+52      �� 53      $��	AccountID��54      $ 	AccountID��56       55      �� *	AccountID+56      �� 57      $��Title��58      $ Title��5:       59      �� *Title+5:      �� 5;      $��Created��5<      $ Created��5>       5=      �� *	Created+5>      �� 5?      $��Description��5@      $ Description��5B       5A      �� *Description+5B      5C      5F      5G      5H      