   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5	          Anakapur.SearchCustomer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	    5      @d2http://schemas.microsoft.com/expression/blend/2008 	    5      (localclr-namespace:Anakapur 	    5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF 	    5	        N� Title$  SearchCustomer��5       N� 	KeepAlive . .��5      � -   5        $��gridCustomerSearch��5      $
��Auto��6%   $
��1000��63   $y�Visible=�6@   $��Center=�6U   .+�5   
   �� $
��Auto=�6   $
��Auto=�6:   .��5      ]� $
��Left=�6   $
��Auto��63   ��. $	��Top=�6W   $
��auto��6o   .+�5      ��  �� Orientation$ Vertical=�6   $	��Top=�64   $
��Left=�6L   .+�5      �� $ 
Horizontal=�6!   $
��auto��6:   .+�5      �� -   5        $��lblCustomerCaption��5       $�� ��6:   �� 5      -   5        $��lblCustomerName��5       $�� ��67   $
��Bold"�6B   $��15(�6T   6d   5      �� 5      $ 
Horizontal=�6!   $	��Top=�6:   .+�5      �� -   5        $��lblCustomerSearchCaption��5       $��Search Customer : ��6@   $��15(�6]   $��80,0,0,0q�6k   �� 5      -   5        $��txtCustomerName��5   "   $�� ��69   $	��115��6B    �� 	MaxLength$ 12��6N   $��DemiBold"�6]   |�. $��15(�6�   $��24��6�   6  �� 5      -   5         ��Name$ btnCustomerSearch��5   !   $��28��6<   $��15(�6H   $��10,0,0,0q�6V   $��DemiBold"�6h   $��Search��6~      AccentedSquareButtonStyle#��[  6�   $��80��6�   6�   5      9� 5      -   5        $��	expandRes��5   5   $��More Results��6   .��5      �� -   5        $��stkListView��5   %   $y�Visible=�68   .+�5      �� .��5    "   �� -	   5        $��lstCustomerResult��5    +   $��15(�6D   $	��200��6R   $��1q�6`   $��2q�6t   $
��0,20q�6�   $	��892��6�    �� View 5!   &   �� 5"   *   -
   5        CustomerGrid��.P�5#   .   �� $��Phone��6=    �� Width$	 120��6L    �� CellTemplate 5$   2   �� 5%   6   .R�5&   :   �� $��6,2,6,2q�6E   .+�5'   >   �� ��6D   �� *CustPhoneNumber+5(   ;   5)   7   5+   /   �� 5,   .   $��
First Name��6=   $	 130��6Q    5-   2   �� 5.   6   .R�5/   :   �� $��6,2,6,2q�6E   .+�50   >   �� ��6D   �� *CustomerFName+51   ;   52   7   54   /   �� 55   .   $��	Last Name��6=   $	 120��6P    56   2   �� 57   6   .R�58   :   �� $��6,2,6,2q�6E   .+�59   >   �� ��6D   �� *CustomerLName+5:   ;   5;   7   5=   /   �� 5>   .   $��Delivery Address��6=   $	 300��6W    5?   2   �� 5@   6   .R�5A   :   �� $��6,2,6,2q�6E   .+�5B   >   �� ��6D   �� *Delivery_Addresss+5C   ;   5D   7   5F   /   �� 5G   .   $��	Land Mark��6=   $	 300��6P    5H   2   �� 5I   6   .R�5J   :   �� $��6,2,6,2q�6E   .+�5K   >   �� ��6D   �� *	Land_mark+5L   ;   5M   7   5O   /   5Q   +    �� 
GroupStyle 5S   &   (  "System.Windows.Controls.GroupStyle  5T   *   	   ContainerStyle	 5U   .   �� 5V   2   
 �� 
TargetType"
 ��68   .�5W   6   ��  �� Property � �� �� Value 5X   :   �� 5Y   >   .R�5Z   B   9�  9� 
IsExpanded . ��6K   �� *CustPhoneNumber+.��5[   F   �� 5\   C   5]   ?   5_   7   5`   3   5c   +   5e   #   5f      5g      5h      �� 5i      $ 
Horizontal=�6!   .+�5k      �� -   5        $��stkNewCustomer��5k   :   $��10,10,10,10q�6%   $ Vertical=�6P   $
��left=�6g   $	��Top=�6�   .+�5l      �� $
��Auto=�6+   .��5m   "   � $��10q�6'    � ColumnDefinitions 5n   &   �� 5o   *   $
��Auto �6;   �� 5p   *   $��* �6;    � RowDefinitions 5r   &   �� 5s   *   $
��Auto �68   �� 5t   *   $
��Auto �68   �� 5u   *   $
��Auto �68   �� 5v   *   $
��Auto �68   �� 5w   *   $
��Auto �68   �� 5x   *   $
��Auto �68   �� 5y   *   $
��Auto �68   �� 5z   *   $
��Auto �68   �� 5{   *   $
��Auto �68   �� 5|   *   $
��Auto �68   �� 5}   *   $
��Auto �68   �� 5~   *   $��* �68   .+�5�   &   �� $��15(�6,   .��6:   Phone:6B   �� 5�   &   -   5        $��txtPhone��5�   >   $��1��6.   $��15(�6N   $ 10��6\   $��SemiBold"�6�   6�   �� 5�   &   $��15(�6,   $��1��6:   .��6G   First Name :6U   �� 5�   &   -   5        $��txtFname��5�   K   $��1��6.   $��1��6;   $ 15��6[   $��15(�6j   $��SemiBold"�6x   6�   �� 5�   &   $��15(�6-   $��2��6;   .��6H   
Last Name:6T   �� 5�   &   -   5        $��txtLname��5�   o   $��2��6.   $��1��6;    �� AcceptsReturn . $ 15��6`   $��15(�6   $��SemiBold"�6�   6�   �� 5�   &   $��15(�6,   $��3��6:   .��6G   Mobile1 +91:6U   �� 5�   &   -   5        $��
txtMobile1��5�   �   $��3��6.   $��1��6;    . $ 10��6`   $��15(�6�   $��SemiBold"�6�   �� 5�   &   $��15(�6,   $��4��6:   .��6G   Mobile2 +91:6U   �� 5�   &   -   5        $��
txtMobile2��5�   o   $��4��6.   $��1��6;    . $ 10��6`   $��15(�6�   $��SemiBold"�6�   �� 5�   &   -   5        $��lblLat��5�   I   $��8��6,   $��0��69   6Y   �� 5�   &   -   5        $��lblLong��5�   ,   $��8��6;   $��1��6H   6[   �� 5�   &   $��Customer Type : ��6,   $��9��6H   $��0��6U   $��15(�6e   6u   �� 5�   &   -   5        $��cboCustType��5�   /   $��9��6B   $��1��6O   $��30��6_   $��15(�6k   $��DemiBold"�6y   .@�5�   *   �� .��67   	Corporate6B   �� 5�   *    �� 
IsSelected . .��6I   
Individual6U   �� 5�   *   .��67   Family6?   �� 5�   *   .��67   	Friends6@   �� 5�   *   .��67   Staff6>   5�   '   5�   #   5�      �� 5�      6*   �� 5�      $��10,10,10,10q�6)   $ 
Horizontal=�6>   $	��Top=�6W   .+�5�   "   �� -   5        $��btnSaveNewCustomer��5�   )   $��30��6C   $��15(�6O   #��[  6]   $��DemiBold"�6�   $��Save New Customer��6�   $��0,0,10,0q�6�   6�   �� 5�   "   -   5        $��btnEditCustomer��5�   )   $��30��6@   $��15(�6L   #��[  6Z   $��DemiBold"�6�   $��Update Customer��6�   $��0,0,10,0q�6�   6�   �� 5�   "   -   5        $��btnPlaceNewOrder��5�   )   $��30��6A   $��15(�6M   #��[  6[   $��DemiBold"�6�   $��Place NewOrder��6�   $��0,0,10,0q�6�   6�   5�      5�      �� 5�      .+�5�      � $	��600��6#   
�������.+�5�   "   �� -   5        $��	lbldeladd��5�   �   $��15(�6(   $	��125��66   $��40��6B   $��10,24,465,636q�6N   $��Delivery Address:��6e   6�   �� 5�   "   -   5        $��txtDeliverAddress��5�   *   $��80��6C   $	��200��6P   $ �� HorizontalScrollBarVisibility$
 Auto=�6^    . $��15(�6�   $��SemiBold"�6�   $
��Left=�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $��140,24,0,596q�6N  �� 5�   "   -   5        $��lbllandmark��5�   �   $��15(�6(   $	��125��67   $��40��6C    J� RenderTransformOrigin$ 0.168,-1.45&�6O   $��10,109,465,551q�6s   $��
Land Mark:��6�   6�   �� 5�   "   -   5        $��txtLandMark��5�   *   $��80��6>    . $	��200��6_   $��15(�6l   $��SemiBold"�6z   $
��Left=�6�   $��140,109,0,511q�6�   '  !Microsoft.Maps.MapControl.WPF.Map  5�   "   -   5        $��myMap��5�   (   +  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$s m3mrcDN85gFcdksMCctBl ~Npoo2wRVtC6h1tQTxvhnmg~Ap17BfInLNVFV6LDJv18zWNHetTtlyDPu2Un9yLYY9mpGL2fUP-FY_BMMIon7ACj 65      Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 17.3850, 78.4867 6�      	ZoomLevel$ 12Q�6�   $	��500��6�   $	��800��6�   $��	0,200,0,0q�6/  5�      5�      5�      5�      5�      5�      5�      5�      