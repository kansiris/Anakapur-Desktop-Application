   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          Anakapur.OrdersUpdate   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  Orders Update��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � 
�������.+�5   
   ]� ��. $��10,10,10,10q�6)   .+�5      �� -   5        $��stkTop��5   .   $	��Top=�6   $��Center=�6<    �� Orientation$ 
Horizontal=�6Y   .+�5      �� $ Vertical=�6   
�������.+�5      �� 
�������6/   �� 5      $��Orders Update��6   $��Center=�64   $��20(�6Q   $��	ExtraBold"�6_   6x   �� 5      6"   5      5      �� 5      -   5        $��	stkBottom��5   2   $��Bottom=�6   $��Center=�6C   $ 
Horizontal=�6`   $��50��6y   .+�5       �� -   5         ��Name$ btnAssignDriver��5       $	��Pay��62   $��0,0,20,0q�6@   $��20(�6R      AccentedSquareButtonStyle#��[  6`   $��Black"�6�   6�   �� 5!      -   5        $ btnMap��5!      $��	Delivered��6)   $��0,0,20,0q�6=   $��20(�6O   $��Black"�6]   #��[  6p   6�   �� 5"      -   5        $ btnPd��5"      $��Paid and Delivered��6(   $��0,0,20,0q�6E   $��20(�6W   $��3��6e   $��Black"�6r   #��[  6�   6�   �� 5#      -   5        $ 	btncancel��5#      $��Cancel Order��6,   $��0,0,20,0q�6C   $��20(�6U   $��Black"�6c   #��[  6v   6�   5&      �� 5'      $
��Auto=�6   $
��Left=�6?   .��5,      &   System.Windows.Controls.DataGrid  -   5        $��dgOrders��5,         AutoGenerateColumns .     CanUserAddRows .  $��1��6^   $	��500��6k   $��15(�6w   $   HorizontalScrollBarVisibility$ Visible=�6�   "	   VerticalScrollBarVisibility$	 Visible=�6�     AzureDataGrid#��[ 6�   
   
IsReadOnly
 . $	��400��5-   2   $��5,5,5,5q�6n   $��1q�6   $��2q�6�      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  50   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��65      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *	OrderId+6c     51   "   $ Status��65    6E   �� *StatusDescription+  52   "   $ Phone��65    6D   �� *CustPhoneNumber+  53   "   $ 
First Name��65      
FontWeight$ DemiBold"�6k    6I   �� *CustomerFName+6k     54   "   $ 	Last Name��65    6H   �� *CustomerLName+  55      $ Remarks��6-    6>   �� *	Remarks+59      5A      �� 5B      -   5        $��stkRight��5B      $��Center=�6+   $ 
Horizontal=�6H   .+�5D      �� $ Vertical=�6   $	��Top=�65   $��Center=�6M   $��0,0,20,0q�6j   .+�5E      � -	   5        $��custName��5E       � ColumnDefinitions 5F      �� 5G      $
��Auto �6/   �� 5H      $��* �6/    � RowDefinitions 5J      �� 5K      $
��Auto �6,   �� 5L      $
��Auto �6,   �� 5M      $
��Auto �6,   �� 5N      $
��Auto �6,   �� 5O      $
��Auto �6,   �� 5P      $
��Auto �6,   �� 5Q      $
��Auto �6,   �� 5R      $
��Auto �6,   �� 5S      $
��Auto �6,   �� 5T      $��* �6,   .+�5V      �� $��0��6    $��0��60   $��Remarks:��6=   $��15(�6P   �� 5W      -
   5         ��Name$ 
txtremarks��5W   N   $��1��6"   $��0��62   $��15(�6@   $	��200��6b   $��30��6n   $��	0,0,150,0q�6z   �� 5X      -   5        $��txtdelchrge��5X   $   $y�	Collapsed=�67   �� 5Y      -   5        $��txtcgst��5Y   $   $y�	Collapsed=�63   �� 5Z      -   5        $��txtsgst��5Z   $   $y�	Collapsed=�63   �� 5[      $��0��6    $��1��60   $��Name:��6=   $��15(�6M   �� 5\      -   5         ��Name$ lblCustomerName��5\   [   $��1��6    $��1��60   $��Name:��6=   $��15(�6M   6[   �� 5]      $��0��6    $��2��60   $��Address:��6=   $��15(�6P   �� 5^      -   5         ��Name$ 
lblAddress��5^   $   $��2��69   $��1��6F   $��15(�6V   $��Address:��6d   �� 5_      -   5        $ lbldiscount��5_       $��0��65   $��3��6E   $��Discount Rs��6R   $
��Left=�6h   $	��Top=�6�   �� 5a      -   5        $ txtdiscount��5a   k   $��1��6$   $��3��64   $
��Left=�6A    �� 	MaxLength$ 10��6\   $��1��6�   $	��Top=�6�   $��76��6�   6�   �� 5d      -   5        $ lbltip��5d       $��0��62   $��4��6B   $��Tip Rs��6O   $
��Left=�6`   $	��Top=�6}   �� 5e      -   5        $ txttip��5e   g   $��20��6"   $��1��6/   $��4��6?   $
��Left=�6L   $��2��6w   $ 10��6�   $	��Top=�6�   $��76��6�   6�     5g      -   5          Name$ 	dgDetails��5g   \   $��5��6$   $��2��61    .  $��Visible=�6q   $	��430��6�    .  $	��170��6�   $
 Auto=�6�   
 . $��10,10,10,10q�6  $��1q�6(  $��2q�6<  #��[ 6H   5j        5k   "   $ Dish ID��65   $
 auto 6d    6F   �� *	ProductID+6d     5l   "   $ 	Dish Name��65   $
 auto 6h    6H   �� *ProductName+6h     5m   "   $	 Qty��65   $
 auto 6_    6B   �� *
Quantity+6_     5n   "   $ Price��65   $
 auto 6_    6D   �� *Price+6_     5o   "   $ Total��65   $
 Bold"�6_   $
 auto 6q    6D   �� *Total+6q   5s      �� 5u      -   5        $ lbltotprice��5u       $��0��65   $��6��6E   $��Total Price Rs:��6R   $
��Left=�6l   $	��Top=�6�   �� 5w      -   5        $ txttotprice��5w   \   $��6��6#   $��1��61   $
��Left=�6A   $
��Bold"�6q   $ 30��6�   $��76��6�   {�.  $��26��6�   $	��Top=�6�   �� 5z      $��2��6$   $��8��68   $��5��6E   6R   �� 5|      -   5        $ lbltotalbill��5|       $��0��67   $��9��6G   $��20(�6T   $
��Bold"�6b   $��
Total Bill��6t   $
��Left=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 	0.019,0.5&�6�   �� 5}      -   5        $ 
txttotbill��5}   {   $��1��6#   $��9��63   $��20(�6@   $
��Bold"�6N   $
��Left=�6`   $ 5��6�   $	��Top=�6�   $	��144��6�   {�.  6�   5      5�      5�      5�      5�      5�      