   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5          Anakapur.Dispatch   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5        N� Title$  Dispatch��5	      .��5      � $��Center=�6   .+�5   
   ]� ��. $��10,10,10,10q�6)   $
��auto��6>   .+�5      �� -   5        $��stkTop��5   .   $	��Top=�6   $��Center=�6<    �� Orientation$ 
Horizontal=�6Y   .+�5      �� $ Vertical=�6   .+�5      �� $��Driver Dispatch list��6   $��Center=�67   $��20(�6T   $��	ExtraBold"�6b   6{   �� 5      $��10,10,10,10q�6    67   5      5      �� 5      -   5        $��stkRight��5   0   $��Right=�6   $
��Left=�6@   $ 
Horizontal=�6[   $
��auto��6t   .+�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5      �� $��Riders��6    $��15(�61   $
��Bold"�6?   $��Center=�6Q   5      �� 5      $��/Images/db.png��6    $��30��68   $��5,5,5,5q�6D   5      � 5      .+�5      �� -   5        $��lvInDrivers��5   /   $��10q�6#   $	��297��6B   $��15(�6O   $
��Auto=�6�   $��1q�6�   $��2q�6�    �� View 5      �� 5   "   .P�5!   &   �� $��Select��65    �� CellTemplate 5"   *   �� 5#   .   .R�5$   2   �� $��6,2,6,2q�6=   .+�5%   6   �� $��chkdispatch��6?   -   5        ��5%   R   �� *	EmpCode+6�   5'   3   5(   /   5*   '   �� 5+   &   $��
First Name��65    5,   *   �� 5-   .   .R�5.   2   �� $��6,2,6,2q�6=   .+�5/   6   �� ��6<   �� *
First_Name+50   3   51   /   53   '   �� 54   &   $��	Last Name��65    �� Width$	 100��6H    55   *   �� 56   .   .R�57   2   �� $��6,2,6,2q�6=   .+�58   6   �� ��6<   �� *	Last_Name+59   3   5:   /   5<   '   �� 5=   &   $��Orders in hand��65    5>   *   �� 5?   .   .R�5@   2   �� $��6,2,6,2q�6=   .+�5B   6   �� -   5        #��[" �5B   �   ��6=   �� *NumberOfOrders+
 � Tag 6u   �� *	EmpCode+6�   5C   3   5D   /   5F   '   5Q   #   5S      5U      5V      5Y      �� 5Z      -   5        $��	stkBottom��5Z   1   $��Bottom=�6   $��Center=�6B   $ 
Horizontal=�6_   $��50��6x   $
��10,0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5[      V� 5\      5^      .+�5a      �� -   5        $��
btnRefresh��5a      $��Refresh��6+      AccentedSquareButtonStyle#��[  6=   $��0,0,20,0q�6p   $��20(�6�   $��Black"�6�   6�   �� 5c      -   5        $��btnMap��5c      $	��Map��6'   #��[  65   $��0,0,20,0q�6h   $��20(�6z   $��Black"�6�   6�   5e      �� 5f      6   �� 5g      $ Vertical=�6   .+�5h      �� -	   5        $��lblOrderheader��5h   K   $��Orders��6   $
��Bold"�6*   $��15(�6<   $��Center=�6a   6�   �� 5i      -
   5        $��stkGrd��5i      $ Vertical=�6+   6D   �� 5j      $
��Auto=�6   $
��auto��6?   .��5l      � $
��auto��6   $��Center=�6,   $��10,10,10,10q�6I   .+�5n      &   System.Windows.Controls.DataGrid  -   5        $��dgOrders��5n   #      
IsReadOnly .    CanUserAddRows .  	   AutoGenerateColumns	 .  $	��300��6x   $
��auto��6�   $��15(�6�   $
��Auto=�6�   $��1q�6�   $��2q�6  
 �� SelectedItem
 6�   �� *	OrderId+   Columns 5p      4  .System.Windows.Controls.DataGridTemplateColumn  5q   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��69      CellTemplate 5r   &   �� 5s   *   .R�5u   .   �� -   5        #��[" �5u   n   ��6Q   �� *	OrderId+ 6�   �� *	OrderId+6�   5v   +   5x   #   0  *System.Windows.Controls.DataGridTextColumn  5z   "   $ 
Order Time��65      FontSize$ 15Q�6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *OTime+6c     5{   "   $ 
First Name��65   $ 15Q�6k    6I   �� *CustomerFName+6k     5|   "   $ 	Last Name��65   $ 15Q�6j    6H   �� *CustomerLName+6j     5}   "   $ Order Status��65   $ 15Q�6q    6K   �� *StatusDescription+6q     5   "   $ Delivery Address��65   $ 15Q�6u    6O   �� *Delivery_Addresss+6u   5�      5�      5�      5�      5�      5�      5�      