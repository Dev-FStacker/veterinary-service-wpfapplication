   M S B A M L   `   `   `  ����I  EWPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFApplication.customerWPFApplication.customer  5   	   2    ,WPFApplication.customer.BookingDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WPFApplication.customer     5   	     � Title$  Booking Details��5   	   $	��500��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ CanResizeWithGrip=�6_    � 	Resources 5
         PayButtonStyle �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow �� Triggers �� Binding	 �� Value��%�  &	        '      '      �� 5   
   " ��6'   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � �� �#388E3C6,   �� 5       � ��$ 2q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 150��6&   �� 5       � ��$ 45��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�64   �� 5       � ��$ Bottom=�62   5      �� 5   
   "  6   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5        � ��$
 Bold"�6+   �� 5!       � ��$ 40��6'   �� 5"       � ��$ Center=�6;   5#      �� 5&   
   "  6   .�5'      ��  � �� �#FFFFFF6+    5(      �� 5*       6   �� *
IsSelected+	 True6=   .a�5+      ��  � �� �#C8E6C963   5,      5.      5/      .��51      � .+�53   
   � $��50��6   $	��Top=�6   .+�54      �� $��Booking Details��6   $��20(�6/   $
��Bold"�6=   $��Center=�6O   $��Center=�6j   55      � 58   
   $��10,60,10,10q�6   .+�5:      &   System.Windows.Controls.DataGrid  -   5        $��BookingDataGrid��5:      
   AutoGenerateColumns$

 True��6.   $��Stretch=�5;      $��Stretch=�65   $��0,0,0,60q�5<      �� 5?      -   5        $��PaymentButton��5?      $	��Pay��6*   #��[  68   $��Right=�5@   1   $��	0,0,10,10q�6M   5A      5B      5C      