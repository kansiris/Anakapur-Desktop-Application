   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur 5         Anakapur.ReportsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   (localclr-namespace:Anakapur     5        N� Title$  ReportsPage��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��7q�6I   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�5      �� -   5        $��lblhead��5      $��Reports��6'   $
��Bold"�69   $��20(�6K   5      �� 5      -   5        $��stkRadioBtn��5      $��Center=�6-   $ 
Horizontal=�6J   �� 5      5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� .+�5      �� -   5        $��
cboreports��5       $	��120��63   $��0,0,10,0q�6@   .@�5      �� $��Daily��6'    �� 
IsSelected . 
 � Tag$ 1��6I   �� 5      $��Weekly��6'   $ 2��69   �� 5      $��Monthly��6'   $ 3��6:   5       5!      �� 5"      .+�5#      (  "System.Windows.Controls.DatePicker  -   5        $��dtpicker��5#   !   $
��Bold"�61   $��0,0,10,0q�6D   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� -   5        $��	btnSearch��5&         AccentedSquareButtonStyle#��[  6H   $	��100��6}   $��5,5,5,5q�6�   .��5'      �� $ 
Horizontal=�6%   .+�5(      �� $��30��6(   $��25��5)      ��5*      ��  �� RelativeSource ��  �� AncestorType$ ButtonL�	 �� Path$	 
Foreground�
 J� OpacityMask
 5+   "   !� 5,   &    j� Stretch$
 Fill=�62     appbar_page_search !� Visual# [ 6A   5.      �� 5/      $��4 0 0 0q�6(   $��Center=�50      $��Search��51      52      53      55      �� 56      .+�57      �� -   5        $��	btnexport��57      $��Export to Excel��6.   $��0,0,10,0q�6a   58      �� 59      .+�5:      �� -   5        $��
txtrevenue��5:       $��15(�62   $
��Bold"�6@   $��0,0,10,0q�6S   �� 5;      -   5        $��txtamountpaid��5;       $��15(�65   $
��Bold"�6C   $��0,0,10,0q�6V   5<      5=      �� 5>      �� 5?      $ Vertical=�6   .+�5@      &   System.Windows.Controls.DataGrid  -	   5        $��dgreportsData��5@      $��13(�60      CanUserAddRows .  $
��auto��6U   $	��300��6b   $��1q�6o   $��2q�6�   "   VerticalScrollBarVisibility$ Visible=�6�      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Visible=�6�     AzureDataGrid#��[ 6�      Columns 5A      4  .System.Windows.Controls.DataGridTemplateColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��61      CellTemplate 5C      �� 5D   "   .R�5F   &   �� -
   5        #��[" �5F   f   ��6I   �� *	orderid+ 6�   �� *	orderid+6�   5G   #   5I        5J      $ 
Order date��61    5K      �� 5L   "   .R�5M   &   �� ��6,   �� *	OrderDate+6M   5N   #   5P        5Q      $ Status��61    5R      �� 5S   "   .R�5T   &   �� ��6,   �� *statusdiscription+6U   5U   #   5W        5X      $ Phone��61    5Y      �� 5Z   "   .R�5[   &   �� ��6,   �� *customerphone+6Q   5\   #   5^        5_      $ Customer FName��61    5`      �� 5a   "   .R�5b   &   �� ��6,   �� *customerfname+6Q   5c   #   5e        5f      $ Customer LName��61    5g      �� 5h   "   .R�5i   &   �� ��6,   �� *customerlname+6Q   5j   #   5l        5m      $
 Rest��61    5n      �� 5o   "   .R�5p   &   �� ��6,   �� *
restcode+6L   5q   #   5s        5t      $ Quantity��61    5u      �� 5v   "   .R�5w   &   �� ��6,   �� *
Quantity+6L   5x   #   5z        5{      $ Total Price��61    5|      �� 5}   "   .R�5~   &   �� $
��Bold"�6,   ��6>   �� *
TotalPrice+6`   5   #   5�        5�      $ Delivery charge��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *Deliverycharges+6e   5�   #   5�        5�      $
 CGST��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *cgstcharges+6a   5�   #   5�        5�      $
 SGST��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *sgstcharges+6a   5�   #   5�        5�      $ Amount Paid��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *
amountPaid+6`   5�   #   5�        5�      $ Remarks��61    5�      �� 5�   "   .R�5�   &   �� $
��Bold"�6,   ��6>   �� *	Remarks+6]   5�   #   5�        5�      $ 	OrderType��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *	OrderType+6c   5�   #   5�        5�      $ TransactionId��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *TransactionId+6g   5�   #   5�        5�      $ Transaction Status��61    5�      �� 5�   "   .R�5�   &   �� $��DemiBold"�6,   ��6B   �� *TransactionStatus+6k   5�   #   5�      5�      5�      �� 5�      -   5         ��Name$ picImage��5�      $	��100��6&   $	��100��63   �� 5�      -   5        $ image2��5�      $	��100��6$   $	��100��61   5�      5�      5�      