   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5   	       Anakapur.test   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Anakapur     5   	     � Title$
  test��5   	   $	��500��6   $	��500��6#   .��5	      � .+�5
   
   �� $��20,20,20,20q�6    �� Orientation$ Vertical=�6*   .+�5      �� $��5,5,5,5q�6   $ 
Horizontal=�6*   .+�5      �� -   5        $��Order Id : ��5   .   $��0,0,0,0q�6D      AccentedSquareButtonStyle#��[  6U   6�   �� 5      -   5        $��
lblOrderID��5      $��Order Id��6*   $��0,0,0,0q�6=   $
��Bold"�6N   6b   �� 5      $��
Order Date��6   $��0,0,0,0q�6-   6@   �� 5      -   5        $��lblOrderDate��5      $��Order Id��6,   $��0,0,0,0q�6?   $
��Bold"�6P   6d   �� 5      $��
Order Time��6   $��0,0,0,0q�6-   6@   �� 5      -   5        $��lblOrderTime��5      $��Order Id��6,   $��0,0,0,0q�6?   $
��Bold"�6P   6d   5      �� 5      6   �� 5      $ 
Horizontal=�6   .+�5      �� $��Customer Name : ��6   $��0,0,15,0q�63   6G   �� 5      -   5        $��lblCustName��5      $
��Name��6+   $��0,0,0,0q�6:   $
��Bold"�6K   6_   5      �� 5      $��5,5,5,5q�6   $ 
Horizontal=�6*   .+�5      �� $��Phone : ��6   $��0,0,0,0q�6+   6>   �� 5      -   5        $��lblCustPhone��5      $��Order Id��6,   $��0,0,0,0q�6?   $
��Bold"�6P   6d   �� 5      $��Address  : ��6   $��0,0,0,0q�6.   6A   �� 5      -   5        $��
lblAddress��5      $��Order Id��6*   $��0,0,0,0q�6=   $
��Bold"�6N   6b   5       �� 5!      6   �� 5"      $ 
Horizontal=�6   $��Center=�62   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��Total Items : ��6   $��0,0,15,0q�61   6E   �� 5'      -   5        $��lblItems��5'      $��Total Items : ��6(   $��0,0,15,0q�6A   $
��Bold"�6S   6g   �� 5(      $��Grand Total Rs: ��6   $��0,0,15,0q�63   6G   �� 5)      -	   5        $��lblGrandTotal��5)      $��Grand total : ��6-   $��0,0,15,0q�6F   $
��Bold"�6X   6l   �� 5*      -
   5        $��	lblStatus��5*      $��Order Status : ��6)   $��0,0,15,0q�6C   $
��Bold"�6U   6i   5+      �� 5,      -   5        $��lvOrders��5,   #   $��10q�6   $	��297��63   $��1q�6@   $��2q�6T   $��Visible=�6`    �� View 5-      �� 5.      .P�50      �� $
��Code��6)    �� CellTemplate 51      �� 52   "   .R�53   &   �� $��6,2,6,2q�61   .+�54   *   �� ��60   �� *	ProductID+55   '   56   #   58      �� 59      $
��Dish��6)    �� Width$	 150��67    5:      �� 5;   "   .R�5<   &   �� $��6,2,6,2q�61   .+�5=   *   �� ��60   �� *ProductName+5>   '   5?   #   5A      �� 5B      $��Price��6)    5C      �� 5D   "   .R�5E   &   �� $��6,2,6,2q�61   .+�5F   *   �� ��60   �� *Price+5G   '   5H   #   5J      �� 5K      $	��Qty��6)    5L      �� 5M   "   .R�5N   &   �� $��6,2,6,2q�61   .+�5O   *   �� ��60   �� *
Quantity+5P   '   5Q   #   5S      �� 5T      $��Total��6)    5U      �� 5V   "   .R�5W   &   �� $��6,2,6,2q�61   .+�5X   *   �� ��60   �� *Total+5Y   '   5Z   #   5\      5^      5`      5d      5e      5f      