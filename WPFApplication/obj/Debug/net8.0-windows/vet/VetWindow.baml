   M S B A M L   `   `   `  ����I  EWPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFApplicationWPFApplication  5   	       WPFApplication.VetWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFApplication     5   	     � Title$  	VetWindow��5   	   $	��600��6   $
��1200��6(    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5
         SidebarGradient �� 
StartPoint �� EndPoint � Color � Offset  NavButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%�  &	        &	 �     �� 5   
   $	 0,0&�66   $	 1,0&�6G   .��5      � $ 	#FF4B6E8C��6   $	 0.0Q�6-   � 5      $ 	#FF2A3D4B��6   $	 1.0Q�6-   5      �� 5   
   " ��6'   .�5      ��  � ��	 �	#FF2A3D4B6+   �� 5       � ��
	 �����6+   �� 5       � ��$	 16(�6)   �� 5       � ��$	 Medium"�6+   �� 5       � ��$	 40��6'   �� 5       � ��$
	 0,10q�6'   �� 5       � ��$	 10q�6(   �� 5       � ��$	 Stretch=�64   �� 5       � ��
	 ���� 6,   �� 5       � ��$	 1q�60   �� 5       � ��$	 Segoe UI)�6+   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5       �� #��z��6!   #��z��5!      $��1q�5"      $ 20��5#      ._�5$      �� $��Center=�6/   $��Center=�6L   5%      5&      5(       5*      P� 5+       �@J�IsMouseOver$
 True��61   . �5,      ��  � ��	 5-      �� 5.      $	 0,0&�62   $	 1,0&�6C   .��5/   "   � $ 	#FF60788B��6/   $ 0Q�6A   � 50   "   $ 	#FF4B6E8C��6/   $ 1Q�6A   51      53      54      56      57      .��59      � .+�5:   
   �� #��[  6   $	��220��6?   $
��Left=�6K    �� Padding$ 20,40,20,20q�6f   ._�5;      �� $	��Top=�6   $��Stretch=�61   .+�5<      �� $��Veterinary Panel��6   $��22(�64   
�������$
��Bold"�6U   $��Center=�6g   $��0,0,0,30q�6�   �� 5>      -   5        $��Schedule��5>      #��[ 6C   �� 5?      -   5        $��Profile��5?      #��[ 6A   �� 5@      -   5        $��Logout��5@      #��[ 6?   �� 5B      $��1��6   
�������$��10,20q�64   �� 5D      $��Coming Soon!��6   $��14(�60   
�������$��Center=�6Q   $��10,20q�6n   5F      5G       � 5I   
   -   5        $��	MainFrame��5I        � NavigationUIVisibility$ Hidden=�6!   $��	220,0,0,0q�6A   ���#F4F4F4$��0q�6i   ��5J      � 5K      $��Stretch=�6   $��Stretch=�63   .+�5L      �� $��file:///E:/vet-image.webp��6   $��Stretch=�6?   $��Stretch=�6]   $��UniformToFill=�6y   5M      5O      5P      5Q      