   M S B A M L   `   `   `  ����  WPFApplication/    )WPFApplication.customer.BookingFormWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Booking Service��5   	   $	��750��6!   $	��600��6.   ���#f5f5f5 � WindowStartupLocation$ CenterScreen=�6O   .��5      � $��20q�6   .+�5   
   �� ���#0078D7$��2q�6'    �� CornerRadius$ 10��6;    �� Padding$ 10q�6M   ._�5      �� .+�5      �� $��Book a Service��6   $��28(�62   $
��Bold"�6@   ���#0078D7$��Center=�5	      $��0,0,0,20q�69   �� 5
       �� Orientation$ Vertical=�6   $	��Top=�64   $��10q�6L   .+�5      �� $��Booking Date:��6    $
��Bold"�65   ���#333$��0,5,0,0q�6Y   (  "System.Windows.Controls.DatePicker  5      -   5        $��BookingDatePicker��5   !   $	��250��6:   $��0,5,0,10q�6F   �� 5      $��Slot: ��6    $
��Bold"�6.   ���#333$��0,10,0,0q�6R   �� 5      -   5        $��SlotComboBox��5      $	��250��63   $��0,5,0,20q�6?   .@�5      �� $��Slot1: 7:00 - 9:15��6'   �� 5      $��Slot2: 9:30 - 11:45��6'   �� 5      $��Slot3: 12:30 - 14:45��6'   �� 5      $��Slot4: 15:00 - 17:15��6'   5      �� 5      $��Service Type:��6    $
��Bold"�65   ���#333$��0,10,0,0q�6Y   �� 5      -   5        $��ServiceTypeComboBox��5      $	��250��6:   $��0,5,0,10q�6F   6X   �� 5      $��Number of Pools:��6    $
��Bold"�68   ���#333$��0,10,0,0q�6\   �� 5      -   5        $��NumberOfPoolsTextBox��5      $	��250��6:   $��0,5,0,10q�6F   �� 5      $��Additional Notes:��6    $
��Bold"�69   ���#333$��0,10,0,0q�6]   �� 5      -   5        $��AdditionalNotesTextBox��5      $	��250��6<   $��80��6H    �� TextWrapping$
 Wrap=�6T    �� AcceptsReturn$
 True��5      " �� VerticalScrollBarVisibility$
 Auto=�63   $��0,5,0,10q�6V   �� 5      $��Deposit Amount:��6    $
��Bold"�67   ���#333$��0,10,0,0q�6[   �� 5       -   5        $��DepositAmountTextBox��5       $	��250��6:   $��0,5,0,10q�6F   �� 5"      $��Payment Method:��6    $
��Bold"�67   ���#333$��0,10,0,0q�6[   �� 5#      -   5        $��PaymentMethodComboBox��5#      $	��250��6<   $��0,5,0,20q�6H   .@�5$      �� $��Credit Card��6'   �� 5%      $
��Cash��6'   �� 5&      $��Bank Transfer��6'   5'      �� 5(      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5)      �� -   5        $��Confirm Booking��5)   !   $	��140��6;   $��40��6G   ���#0078D7
�������$
��Bold"�5*      $��0,0,10,0q�6   61   �� 5+      -	   5        $��Cancel��5+   !   $	��100��62   $��40��6>   ���#e0e0e0���#333$
��Bold"�5,      6   5-      5.      5/      50      51      52      