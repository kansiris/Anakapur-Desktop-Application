   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5          Anakapur.UCTickets   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5      .��5	      � .+�5
   
   ��   �� CornerRadius$  5��6   $��1q�6"   $��2,2,2,2q�66   
���   �._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��auto��62   $	��750��6?   $	��Top=�6L   .+�5      �� $ Vertical=�6   $	��270��64   .+�5      �� -   5        $��stkmn��5   %   .+�5      �� -   5        $��stktktdtls1��5   B   $ 
Horizontal=�6)   .+�5   "   �� -   5        $��
lblOrderID��5   (   $��Order Id��6:   $��15(�6M   $
��Bold"�6[   $��0,0,20,0q�6m   5   #   �� 5   "   -   5        $��lblItemsCount��5   (   $��10 Items��6=   $��15(�6P   $
��Bold"�6^   6r   5      �� 5      -   5        $��stktktdtls2��5   S   $��Center=�6)   $
��auto��6F   .+�5   "   �� -   5        $��lblOrderTime��5   (   $��
Order Time��6<   $��15(�6Q   $
��Bold"�6_   $��0,0,15,0q�6q   6�   �� 5   "   -   5        $��txtDeliveryTime��5   ,   $
��Wrap=�6C   $��15(�6W   $
��Bold"�6e   $
��auto��6x   $
��auto��6�   6�   �� 5   "   -   5        $��lblElapsedTime��5   (   $��Elapsed Time��6>   $��15(�6U   $
��Bold"�6c   $��Center=�6u   6�   �� 5   "   -	   5        $��lblcustomername��5   (   $��15(�6@   $
��Bold"�6N   $
��Left=�6`   
����  �6�   �� 5   "   -
   5        $��lblcustphone��5   (   $��15(�6=   $
��Bold"�6K   $
��Left=�6]   
����  �6�   �� 5   "   $ 
Horizontal=�6-   $��Center=�6F   $
��auto��6c   .+�5   &   �� -   5        $��
imgmobicon��5   C   $��25��6,   $��25��67   $��Images/mobicon2.png��6U   $y�Hidden=�6r   �� 5   &   -   5        $��lblordertype��5   ,   $��15(�6A   $
��Bold"�6O   $��Center=�6a   
���  ��5    '   �� 5!   &   -   5        $��lblosts��5!   ,   $��15(�6<   $
��Bold"�6J   $��Center=�6\   
��� d �6y   5"   #   �� 5#   "   6.   �� 5$   "   -   5        $��txtUserRequests��5$   ,   $
��auto��6C   $
��Auto��6P   $��15(�6^   $
��Wrap=�6l   6�   5%      5&      �� 5'      6&   �� 5(      -   5        $��lvOrders��5(   +   $��10q�6   $	��700��6;   $
��auto��6H   $��Visible=�6U   $
��Auto=�6�    �� View 5)      �� 5*      .P�5,   "   �� $
��Code��61    �� CellTemplate 5-   &   �� 5.   *   .R�5/   .   �� $��2,2,2,2q�69   .+�50   2   �� $��15(�6W   $
��Bold"�6e   ��68   �� *	ProductID+6e   51   /   52   +   54   #   �� 55   "   $
��Dish��61    �� Width$	 100��6?    56   &   �� 57   *   .R�58   .   �� $��2,2,2,2q�69   .+�59   2   �� $��15(�6Z   $
��Bold"�6h   $
��Wrap=�6z   ��6<   �� *ProductName+6z   5:   /   5;   +   5=   #   �� 5?   "   $	��Qty��61    5@   &   �� 5A   *   .R�5B   .   �� $��2,2,2,2q�69   .+�5C   2   �� $��15(�6V   $
��Bold"�6d   ��68   �� *
Quantity+6d   5D   /   5E   +   5G   #   5J      5L      �� 5M      6&   5O      5Q      5S      5T      5U      5V      