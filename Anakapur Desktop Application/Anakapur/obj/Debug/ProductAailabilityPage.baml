   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   C ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur 5      %   Anakapur.ProductAailabilityPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5        N� Title$  ProductAailabilityPage��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��7q�6I   .+�5      �� -   5        $��stkRadio��5      $��Center=�6*   $ 
Horizontal=�6G   �� 5      5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $ 
Horizontal=�6   .+�5      �� -   5        $��	btnsearch��5         AccentedSquareButtonStyle#��[  6I   $	��150��6~   $��35��6�   $��5,5,5,5q�6�   .��5      �� $ 
Horizontal=�6%   .+�5      �� $��30��6(   $��25��5      ��5      ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5   "   !� 5    &   	 j� Stretch$
	 Fill=�62     appbar_page_search
 !� Visual#
 [ 6A   5"      �� 5#      $��4 0 0 0q�6(   $��Center=�5$      $��Search��5%      5&      5'      5)      �� 5*      .+�5+      �� -   5        $��lblheadr��5+      $��Product Availability��6,   $��25(�6K   $��DemiBold"�6Y   $��10,10,10,10q�6o   5,      5-      �� 5.      �� 5/      $ Vertical=�6   .+�50      &   System.Windows.Controls.DataGrid  -   5        $��GridProducts��51         
IsReadOnly .     CanUserAddRows .     AutoGenerateColumns .  $��1q�50   a   $��2q�6u   $
��auto��6�   $��15(�6�   $	��300��51   !   $   HorizontalScrollBarVisibility$ Visible=�6/   "   VerticalScrollBarVisibility$ Visible=�6W     AzureDataGrid#��[ 6}      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	ProductID+6_     54      $ Product Name��6-    6C   �� *ProductName+  55      $ Short Description��6-    6H   �� *ShortDescription+  56      $ Price��6-      
FontWeight$ DemiBold"�6g    6<   �� *Price+ �� StringFormat$ 0#��6g   4  .System.Windows.Controls.DataGridCheckBoxColumn  57      $ 	Available��61    6D   �� *	Available+  58      $ Remarks��6-    6>   �� *	Remarks+5;      5<      �� 5=      $ 
Horizontal=�6   $
��Left=�62   .+�5>      �� .+�5?      �� -   5        $
��Edit��5?   t   #��[  63   $	��150��6h   $��5,5,5,5q�6�   .��5@      �� $ 
Horizontal=�6%   .+�5A      �� $��35��6(   $��25��5B      ��5C      ��  �� $ ButtonL�$ 
Foreground� 5D   "   !� 5E   &   $
	 Fill=�62     appbar_clipboard_edit#
 [ 6A   5G      �� 5H      $��4 0 0 0q�6(   $��Center=�5I      $
��Edit��5J      5K      5L      5N      5O      5P      5Q      5f      