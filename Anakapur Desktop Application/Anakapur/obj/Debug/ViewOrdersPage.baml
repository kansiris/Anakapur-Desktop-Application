   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      C ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur 5         Anakapur.ViewOrdersPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5        N� Title$  ViewOrdersPage��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��7q�6I   .+�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��lblhead��5      $��View Orders��6'   $
��Bold"�6=   $��20(�6O   5      �� 5      -   5        $��stkRadioBtn��5      $��Center=�6-   $ 
Horizontal=�6J   �� 5      6   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5   
   �� .+�5      �� -   5        $��cboOrderStatus��5      $	��120��63   $��0,0,10,0q�6@   .@�5      �� $��
New orders��6'    �� 
IsSelected . 
 � Tag$ 1��6N   �� 5"      $��
Prepared  ��6'   $ 2��6=   �� 5#      $��Payment Due  ��6'   $ 3��6@   �� 5$      $��Payment Complete��6'   $ 4��6C   �� 5%      $��Driver Assigned��6'   $ 5��6B   �� 5&      $��
Delivered ��6'   $ 6��6=   �� 5'      $��	Complete ��6'   $ 11��6<   �� 5(      $��All Orders ��6'   $ 0��6>   5)      5*      �� 5+      .+�5,      (  "System.Windows.Controls.DatePicker  -   5        $��dtpicker��5,   !   $��0,0,10,0q�62   $
��Bold"�6D   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� -   5        $��	btnSearch��5/         AccentedSquareButtonStyle#��[  6H   $	��100��6}   $��5,5,5,5q�6�   .��50      �� $ 
Horizontal=�6%   .+�51      �� $��30��6(   $��25��52      ��53      ��  �� RelativeSource ��  �� AncestorType$ ButtonL�	 �� Path$	 
Foreground�
 J� OpacityMask
 54   "   !� 55   &    j� Stretch$
 Fill=�62     appbar_page_search !� Visual# [ 6A   57      �� 58      $��4 0 0 0q�6(   $��Center=�59      $��Search��5:      5;      5<      5>      5?      �� 5@      $ 
Horizontal=�6   .+�5A      �� -   5        $��txtcount��5A      $
��auto��6,   $��15(�69   $��DemiBold"�6G   $��10,10,10,10q�6]   �� 5B      -   5        $��	txtamount��5B      $
��auto��6-   $��15(�6:   $��DemiBold"�6H   $��150,10,10,10q�6^   5C      �� 5D      �� 5E      $ Vertical=�6   .+�5F      &   System.Windows.Controls.DataGrid  -   5        $��dgOrdersData��5F      $
��auto��6/   $	��300��6<      CanUserAddRows .  $��13(�6`   "   VerticalScrollBarVisibility$ Visible=�6n      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Visible=�6�   $��1q�6�   $��2q�6�      Columns 5L      4  .System.Windows.Controls.DataGridTemplateColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��61      CellTemplate 5N      �� 5O   "   .R�5Q   &   �� -	   5        #��[" �5Q   f   ��6I   �� *	orderid+ 6�   �� *	orderid+6�   5R   #   5T        5U      $ 
Order date��61    5V      �� 5W   "   .R�5X   &   �� ��6,   �� *	OrderDate+6M   5Y   )   5[        5\      $ Status��61    5]      �� 5^   "   .R�5_   &   �� ��6,   �� *statusdiscription+6U   5`   #   5b        5c      $ Phone��61    5d      �� 5e   "   .R�5f   &   �� ��6,   �� *customerphone+6Q   5g   #   5i        5j      $ Customer FName��61    5k      �� 5l   "   .R�5m   &   �� ��6,   �� *customerfname+6Q   5n   #   5p        5q      $ Customer LName��61    5r      �� 5s   "   .R�5t   &   �� ��6,   �� *customerlname+6Q   5u   #   5w        5x      $
 Rest��61    5y      �� 5z   "   .R�5{   &   �� ��6,   �� *
restcode+6L   5|   #   5~        5      $ Quantity��61    5�      �� 5�   "   .R�5�   &   �� ��6,   �� *
Quantity+6L   5�   #   5�        5�      $ Total Price��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *
TotalPrice+6`   5�   #   5�        5�      $ Delivery charge��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *Deliverycharges+6e   5�   #   5�        5�      $
 CGST��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *cgstcharges+6a   5�   #   5�        5�      $
 SGST��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *sgstcharges+6a   5�   #   5�        5�      $ Amount Paid��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *
amountPaid+6`   5�   #   5�        5�      $ 
Order Time��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *	ordertime+6_   5�   #   5�        5�      $ Deliver Time��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *tobedeliver+6a   5�   #   5�        5�      $ Remarks��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *	Remarks+6a   5�   #   5�        5�      $ 	OrderType��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *	OrderType+6c   5�   #   5�        5�      $ TransactionId��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *TransactionId+6g   5�   #   5�        5�      $ Transaction Status��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *TransactionStatus+6k   5�   #   5�      5�      5�      �� 5�      -
   5         ��Name$ picImage��5�      $	��100��6&   $	��100��63   �� 5�      -   5        $ image2��5�      $	��100��6$   $	��100��61   5�      5�      5�      