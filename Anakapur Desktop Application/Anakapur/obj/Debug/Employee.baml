   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          Anakapur.Employee   5      ` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35Imy@http://schemas.microsoft.com/winfx/2006/xaml/presentation/ribbon  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Anakapur     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        � Title$  Ankapur Main Window��5
   	   $
��auto��6%   $
��auto��63    � WindowState$ 	Maximized=�6@    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      (  "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5         ��Name$ 
lblempname��5      $�� ��6,   5      �� 5      -   5        .��5      �� $ 
Horizontal=�6   .+�5      �� $��20��6    $��20��5      ��5      ��  �� RelativeSource �� 	 �� AncestorType$	 ButtonL�
 �� Path$
 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*      appbar_window_closed !� Visual# [  69   5       �� 5!      $��4 0 0 0q�6    $��Center=�5"      $��Logout��5#      5$      5%      �� 5&      -   5        .��5'      �� $ 
Horizontal=�6   .+�5(      �� $��20��6    $��20��5)      ��5*      ��  �� $	 ButtonL�$
 
Foreground� 5+      !� 5,      $
 Fill=�6*     appbar_people_profile# [ 69   5.      �� 5/      $��4 0 0 0q�6    $��Center=�50      $��
My Profile��51      52      53      54      .��56      �  � RowDefinitions 57   
   �� 58      $
��Auto �6   �� 59      .+�5;   
   9� -   5        $��expMenu��5;      $��Collapse��6"   .��5<      +  %System.Windows.Controls.Ribbon.Ribbon  -   5          Name$ 	RibbonWin��5<       �� SelectedIndex$ 0��6)   $	��Top=�6;   .@�5>      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6      KeyTip$ H��6&   $
��Left=�61   $
��auto��6L   .@�5?      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ rbnAdmin��5?   "   .@�5@      5  /System.Windows.Controls.Ribbon.RibbonMenuButton     LargeImageSource$ Images\admin1.jpg��6+   $
��auto��6P   $
��auto��6^      Label$ Admin��6k      KeyTip$ V��6y   .@�5A      3  -System.Windows.Controls.Ribbon.RibbonMenuItem  -   5        $��	Employees��5A   .      KeyTip$ T��6A   6L     5B      -   5        $��Products��5B   .   $ S��6@   6K     5C      -	   5        $��Edit_Orders��5C   .   $ S��6C   6N   5H      5K        5L      -
   5        $ rbncustomer��5L   "   .@�5M      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5           LargeImageSource$ Images\customer1.jpg��5M   '   $
��auto��6O   $
��auto��6]      Label$ Customer��6j      KeyTip$ V��6�   5P      5S        5T      -   5        $ rbnNewOrder��5T      .@�5U        -   5        $ Images\neworder1.jpg��5U   '   $
��auto��6O   $
��auto��6]   $ 	New_Order��6j   $ V��6�   5X      5Z        5\      -   5        $ 
rbntickets��5\      .@�5]        -   5        $ Images\tickets1.jpg��5]   '   $
��auto��6N   $
��auto��6\   $ Tickets��6i   $ V��6�   5`      5c        5e      -   5        $ rbnvieworder��5e      .@�5f        -   5        $ Images\vieworder1.jpg��5f   '   $
��auto��6P   $
��auto��6^   $ 
View_Order��6�   $ V��6�   5k      5n        5w      -   5        $ rbnOrderUpdate��5w   "   .@�5x        -   5        $ Images\orderupdate1.jpg��5x   '   $
��auto��6R   $
��auto��6`   $ Order_Update��6�   $ V��6�   5{      5~        5      -   5        $ rbnproductavail��5   "   .@�5�        -   5        $$ Images\productavailablity1.jpg��5�   '   $
��auto��6Y   $
��auto��6g   $ Product_Availability��6�   $ V��6�   5�      5�        5�      -   5        $ 
rbnreports��5�   "   .@�5�        -   5        $ Images\Reports.jpg��5�   '   $
��auto��6M   $
��auto��6[   $ Reports��6�   $ V��6�   5�      5�        5�      -   5        $ rbnankreport��5�   "   .@�5�        -   5        $ Images\Reports.jpg��5�   '   $
��auto��6M   $
��auto��6[   $ Revenue_Report��6�   $ V��6�   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   .��5�       � -   5        $��frmMain��5�      $��Visible=�5�      ��. $�� ��5�        � NavigationUIVisibility$ Hidden=�5�      5�      �� 5�   
   -   5        $��stkMain��5�      6&   5�      5�      