   M S B A M L   `   `   `  ����I  EWPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFApplication.vetWPFApplication.vet  5      /    )WPFApplication.vet.ScheduleManagementPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      g cSyncfusion.SfBusyIndicator.WPF, Version=27.1.58.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.SfInput.Wpf, Version=27.1.58.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89c _Syncfusion.SfScheduler.WPF, Version=27.1.58.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e	 aSyncfusion.SfSkinManager.WPF, Version=27.1.58.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89^
 ZSyncfusion.Shared.WPF, Version=27.1.58.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89:
syncfusion!http://schemas.syncfusion.com/wpf    	 
 5      4local clr-namespace:WPFApplication.vet    	 
 5        N� Title$  ScheduleManagementPage��5
       N� 
Background
 �����.��5      � .+�5   
   .  (Syncfusion.UI.Xaml.Scheduler.SfScheduler  -   5          Name$ Schedule��5   !      ViewType$
 Week=�63      AppointmentMapping 5      5  /Syncfusion.UI.Xaml.Scheduler.AppointmentMapping  5         Subject$ Title��5         	StartTime$
 From��5         EndTime$ To��5         AppointmentBackground$ BackgroundColor��5      	   
Foreground$	 ForegroundColor��5      5      �� 5   
   -   5        
 ��Name$
 DetailsPanel��5      $y�	Collapsed=�6+   
�������$��10q�6Y   $	��Top=�5      $��Right=�6%   $	��300��6A   $	��600��6M   .+�5      �� $��Booking Details��6   $��16(�6/   $
��Bold"�6=   $��10q�6O   $��Center=�6[   ���#3333336x   �� 5      $
��Auto=�6   $��Disabled=�6>   $
��10,0q�6g   $	��400��6u   .��5      �� -   5        $
 BookingDetailsStackPanel��5      $
��10,0q�6?   5      5       �� 5"      -   5        $��Close��5"      $��10q�6%   $��Right=�61   $��Center=�6M   $
��10,5q�5#      $��14(�66   $
��Bold"�6D   ���#4CAF50
�������6k   5$      5&      5'      