   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      C ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur 5         Anakapur.ProductsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5      MCustom@http://schemas.microsoft.com/winfx/2006/xaml/presentation/ribbon  5        N� Title$  ProductsPage��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � .+�5      �� -   5        $��txtName��5      $��Product Details��6-   $��5q�6D   $��Center=�6O   $��20(�6l   $
��Bold"�6z   $��Center=�6�   5      �� 5      
���   �$��2q�6*   $	��746��6>   ._�5      �� $ 
Horizontal=�6   $��Center=�66   $
��auto��6S   $
��auto��6`   $��20,20,20,20q�6n   .+�5      �� $	��Top=�6!   $
��Left=�69   $	��800��6T   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��GridProducts��5      $	��300��5   #      CanUserAddRows .  $
��Left=�6G   $��1q�6b   $��2q�6v      
IsReadOnly .    AzureDataGrid#��[  6�   $	��Top=�5      $
��auto��67      CanUserResizeRows .    AutoGenerateColumns .  $��15(�6}   "	   VerticalScrollBarVisibility$	 Visible=�5!   4   $
   HorizontalScrollBarVisibility$
 Visible=�6Z      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��65      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *	ProductID+6g     5$   "   $ Product Name��65      
FontWeight$ DemiBold"�6k    6K   �� *ProductName+6k     5%   "   $ Short Description��65    6P   �� *ShortDescription+  5&   "   $ Price��65   $ DemiBold"�6^    6D   �� *Price+6^     5'   "   $ 	Available��65    6H   �� *	Available+  5(   "   $ Remarks��65    6F   �� *	Remarks+  5)   "   $ Quantity��65    6G   �� *	Quanity+  5*   "   $ kitchen Description��65    6R   �� *Kitchen Description+5,      5-      �� 5.      $
��Auto��6!   $��20,20,20,20q�6.   $	��650��6C   $	��Top=�6P   $ Vertical=�6h   .+�51      �  � ColumnDefinitions 52      �� 53   "   $
��Auto �63   �� 55   "   $��* �63    � RowDefinitions 57      �� 58   "   $
��Auto �60   �� 59   "   $
��Auto �60   �� 5:   "   $
��Auto �60   �� 5;   "   $
��Auto �60   �� 5<   "   $
��Auto �60   �� 5=   "   $
��Auto �60   �� 5>   "   $
��Auto �60   �� 5?   "   $
��Auto �60   �� 5@   "   $
��Auto �60   �� 5A   "   $
��Auto �60   �� 5B   "   $
��Auto �60   �� 5C   "   $
��Auto �60   �� 5D   "   $
��Auto �60   �� 5E   "   $
��Auto �60   �� 5F   "   $
��Auto �60   �� 5G   "   $
��Auto �60   �� 5H   "   $
��Auto �60   �� 5I   "   $��* �60   .+�5L      �� -   5        $��txtProdName��5L   6   $��1��6&   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Product Name��6I   $��15(�6y    �� 	MaxLength$ 50��6�   $��1��6�   $��SemiBold"�6�   �� 5N      -   5        $��txtPrice��5N   C   $��1��6&   $��1��63   $ Price��6|   $ 10��6�   $��2��6�   $��15(�6�   $��SemiBold"�6�   �� 5P      -   5        $��txtshortdesc��5P   X   $��3��6&   $��1��63    �� AcceptsReturn . $ Short Description��6l   $��15(�6�   $ 50��6�   $��4��6�   $��SemiBold"�6�   �� 5R      -   5        $��txtlongdesc��5R   Y   $��4��6&   $��1��63    . $ Long Description��6l   $	 100��6�   $��5��6�   $��15(�6�   $��SemiBold"�6�   �� 5T      -   5        $��txtQuantity��5T   X   $��5��6&   $��1��63    . $ Quantity��6k   $ 4��6�   $��6��6�   $��15(�6�   $��SemiBold"�6�   �� 5V      -   5        $��txtdiscount��5V   X   $��8��6&   $��1��63    . $ Discount��6k   $��15(�6�   $ 4��6�   $��9��6�   $��SemiBold"�6�   �� 5Y      -	   5        $��txtFileName��5Y   &   $��7��6:   $��1��6G   $	��250��6W   $ Upload File��6c   $��7��6�   $��Right=�6�   6�   �� 5Z      -
   5        $��BTN_BROWSE_FILE��5Z   %   $��7��6[   $��1��6h     AccentedSquareButtonStyle#��[ 6x   $	��100��6�   $��	130,5,5,5q�6�   .��5[   "   �� $ 
Horizontal=�6-   .+�5\   &   �� $��30��60   $��25��5]      ��5^      ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5_   *   !� 5`   .    j� Stretch$
 Fill=�6:     appbar_skydrive_upload !� Visual# [ 6I   5b   '   �� 5c   &   $��4 0 0 0q�60   $��Center=�5d      $��Browse��5e      5f   #   5g      �� 5k      -   5        $��cmbDishType��5k   E   $��2��6'   $��1��64   $��15(�6q   $��3��6�   $��SemiBold"�6�   ��6X   �� 6�   �� 5m      -   5        $��
txtRemarks��5m   X   $��9��6&   $��1��63    . $��15(�6j   $ Remarks��6x   $ 50��6�   $��10��6�   $��SemiBold"�6�   �� 5o      -   5        $��
cmbcatType��5o   (   $��15(�6:   $��DemiBold"�6H   $��10��6^   $��1��6�   $��11��6�   ��6l   �� 6�   �� 5q      -   5        $��cmbitemcode��5q   (   $��15(�6;   $��DemiBold"�6I   $��11��6_   $��1��6�   $��12��6�   ��6m   �� 5w      �� 5y      -   5        $��
txtprodcod��5y   Y   $��12��6&   $��1��64    . $ Product code��6k   {�.  $��15(�6�   $��SemiBold"�6�   �� 5{      -   5        $��txtTax��5{   Y   $��13��6&   $��1��64    . $��15(�6g   $	 Tax��6u   $��SemiBold"�6�   �� 5}      -   5        $��	cmbactive��5}   (   $��14��6:   $��1��6I   $��12��6Y   $��15(�6g   $��DemiBold"�6u   .@�5~   "   ��  �� 
IsSelected . 
 � Tag$ 1��6A   $
��True��6I   �� 5   "   $��False��6/   $ 0��6?   5�      �� 5�      -   5        $��txtsih��5�   Y   $��15��6&   $��1��64    . $��15(�6g   $ 4��6u   $ Stock in hand��6�   $��SemiBold"�6�   �� 5�      -   5        $��	txtktdesc��5�   Y   $��16��6&   $��1��64    . $��15(�6j   $ 20��6x   $ Kitchen Description��6�   $��SemiBold"�6�   �� 5�      $ 
Horizontal=�6)   $��17��6B   $��2��6Q   $
��auto��6e   .+�5�   "   �� -   5        $��Submit��5�   �   #��[ 6C   $	��150��6x   $��5,5,5,5q�6�   .��5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��30��64   $��25��5�      ��5�      ��  �� $ ButtonL�$ 
Foreground� 5�   .   !� 5�   2   $
 Fill=�6>     appbar_save# [ 6M   5�   +   �� 5�   *   $��4 0 0 0q�64   $��Center=�5�      $
��Save��5�      5�   '   5�   #   �� 5�   "   -   5        $��btnEdit��5�   �   #��[ 6A   $	��150��6v   $��5,5,5,5q�6�   .��5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��30��64   $��25��5�      ��5�      ��  �� $ ButtonL�$ 
Foreground� 5�   .   !� 5�   2   $
 Fill=�6>     appbar_clipboard_edit# [ 6M   5�   +   �� 5�   *   $��4 0 0 0q�64   $��Center=�5�      $
��Edit��5�      5�   '   5�   #   5�      �� 5�      -   5        $��stkImage��5�   )   $��Center=�69   $��5,5,5,5q�6V   $	��Top=�6g   $��0��6   $��0��6�   $��10��6�   $	��200��6�   $	��200��6�   .+�5�   "   �� 
�������
���   �$��2q�6U   $��5,5,5,5q�6i   ._�5�   &   ��  �� CornerRadius$ 4��6-   
���   �$��1q�6R   $��5,5,5,5q�6f   ._�5�   *   �� -   5        $��imgPhoto��5�   W    �� BitmapScalingMode$
 Fant=�60   $��Uniform=�5�      $
��auto��5�      $
��auto��5�      $	��Top=�5�      $��5,5,5,5q�5�      $��Center=�5�      5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5Y     