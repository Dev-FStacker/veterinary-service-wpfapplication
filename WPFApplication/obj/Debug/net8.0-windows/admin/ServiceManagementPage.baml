   M S B A M L   `   `   `  ����I  EWPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFApplication.adminWPFApplication.admin  5      0    *WPFApplication.admin.ServiceManagementPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFApplication.admin     5        N� Title$  Service Management Page��5	       N� 
Background
 �����.��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Service Management��6   $��24(�6.   $
��Bold"�6<   $��10q�6N   $��0��6Z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ServicesDataGrid��5         AutoGenerateColumns$ False��6-   $��1��6I   $
��0,10q�6V      SelectionMode$ Single=�5         CanUserAddRows$ False��6*      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Service ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *	ServiceId+6W     5      $
 Name��6%   $	 * 6L   
 63   �� *Name+6L     5      $ Service Delivery��6%   $	 * 6n   
 6?   �� *ServiceDeliveryMethod.Name+6n     5      $ Price��6%   $
	 Auto 6N   
 64   �� *Price+6N     5      $ Description��6%   $	 * 6Z   
 6:   �� *Description+6Z     5      $ Status��6%   $
	 Auto 6[   
 65   �� *StatusDescription+6[   5      �� 5!   
    �� Orientation$ Vertical=�6   $��2��6,   $
��0,10q�69   .+�5"      �� $��Service Details��6   $��18(�6/   $��SemiBold"�6=   $
��0,10q�6S   �� 5$      $ 
Horizontal=�6   $	��0,5q�62   .+�5%      �� $��Service ID:��6   $	��100��6/   �� 5&      -   5         ��Name$ ServiceIdTextBox��5&      $	��200��64   5'      �� 5)      $ 
Horizontal=�6   $	��0,5q�62   .+�5*      �� $��Name:��6   $	��100��6)   �� 5+      -   5        $ ServiceNameTextBox��5+      $	��200��66   5,      �� 5.      $ 
Horizontal=�6   $	��0,5q�62   .+�5/      �� $��Price:��6   $	��100��6*   �� 50      -   5        $ ServicePriceTextBox��50      $	��200��67   51      �� 53      $ 
Horizontal=�6   $	��0,5q�62   .+�54      �� $��Description:��6   $	��100��60   �� 55      -   5        $ ServiceDescriptionTextBox��55      $	��200��6=   56      �� 58      $ 
Horizontal=�6   $	��0,5q�62   .+�59      �� $��Status:��6   $	��100��6+   �� 5:      -   5        $ ServiceStatusTextBox��5:      $	��200��68   5;      �� 5>      $ 
Horizontal=�6   $��Center=�62   $
��0,15q�6O   .+�5?      �� -   5        $	��Add��5?      $��80��6'   $��5q�62   6=   �� 5@      -   5        $��Update��5@      $��80��6*   $��5q�65   6@   �� 5A      -	   5        $��Delete��5A      $��80��6*   $��5q�65   6@   �� 5B      -
   5        $��Clear��5B      $��80��6)   $��5q�64   6?   5C      5D      5E      5F      