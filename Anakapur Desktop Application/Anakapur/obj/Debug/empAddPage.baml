   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          Anakapur.empAddPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Anakapur     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  
empAddPage��5	      $��Visible=�6D   $��Visible=�6x    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/icons.xaml?�6%   %    5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � .+�5      �� -   5        $��txtName��5      $��Employee Details��6-   $��5q�6E   $��Center=�6P   $��20(�6m   $
��Bold"�6{   $��Center=�6�   5      �� 5      
���   �$��2q�6*   $	��746��6>   ._�5      �� $ 
Horizontal=�6   $��Center=�66   $
��auto��6S   $
��auto��6`   $��20,20,20,20q�6n   .+�5      �� $	��Top=�6!   $
��Left=�69   $	��800��6T   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ GridEmployee��5      $	��300��5   #      CanUserAddRows .  $
��Left=�6G      
IsReadOnly . $	��Top=�5   !   $
��auto��69   $��1q�6F   $��2q�6Z      CanUserResizeRows . 	   AutoGenerateColumns	 .  $��15(�6�   "
   VerticalScrollBarVisibility$
 Visible=�5   4   $��10,10,10,10q�6Z   $   HorizontalScrollBarVisibility$ Visible=�6o      AzureDataGrid#��[  6�      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Emp Code��65      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *	EmpCode+6c     5"   "   $ 
First Name��65      
FontWeight$ DemiBold"�6h    6I   �� *
First_Name+6h     5#   "   $ Address1��65    6G   �� *
Address1+  5$   "   $ Mobile1��65   $ DemiBold"�6b    6F   �� *	Mobile1+6b     5%   "   $ Active��65    6E   �� *Active+  5&   "   $ Password��65    6G   �� *
Password+  5'   "   $ Email Id��65    6G   �� *	EmailId+5)      5*      �� 5+      $
��auto��6!   $��20,20,20,20q�6.   $	��650��6C   $	��Top=�6P   $ Vertical=�6h   .+�5.      �  � ColumnDefinitions 5/      �� 50   "   $
��Auto �63   �� 52   "   $��* �63    � RowDefinitions 54      �� 55   "   $
��Auto �60   �� 56   "   $
��Auto �60   �� 57   "   $
��Auto �60   �� 58   "   $
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
��Auto �60   �� 5D   "   $��* �60   .+�5G      �� -   5        $��txtFirstName��5G   6   $��1��6&   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 
First Name��6J   $��15(�6x    �� 	MaxLength$ 10��6�   $��1��6�   $��SemiBold"�6�   �� 5I      -   5        $��txtLastName��5I   C   $��1��6&   $��1��63   $ 	Last Name��6V   $ 10��6�   $��2��6�   $��15(�6�   $��SemiBold"�6�   �� 5K      -   5        $��
txtMobile2��5K   X   $��3��6&   $��1��63    �� AcceptsReturn . $ Mobile2��6j   $��15(�6�   $ 10��6�   $��4��6�   $��SemiBold"�6�   �� 5M      -   5        $��txtAddress1��5M   Y   $��4��6&   $��1��63    . $ Address1��6l   $	 100��6�   $��5��6�   $��15(�6�   $��SemiBold"�6�   �� 5O      -   5        $��txtAddress2��5O   X   $��5��6&   $��1��63    . $ Address2��6k   $	 100��6�   $��6��6�   $��15(�6�   $��SemiBold"�6�   �� 5Q      -   5        $��
txtEmailId��5Q   X   $��8��6&   $��1��63    . $ EmailId��6j   $��15(�6�   $ 30��6�   $��9��6�   $��SemiBold"�6�   �� 5T      -	   5        $��txtFileName��5T   &   $��7��6:   $��1��6G   $	��250��6W   $ Upload File��6c   $��7��6�   $��Right=�6�   6�   �� 5U      -
   5        $��BTN_BROWSE_FILE��5U   %   $��7��6[   $��1��6h     AccentedSquareButtonStyle#��[ 6x   $	��100��6�   $��	130,5,5,5q�6�   .��5V   "   �� $ 
Horizontal=�6-   .+�5W   &   �� $��30��60   $��25��5X      ��5Y      ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5Z   *   !� 5[   .    j� Stretch$
 Fill=�6:     appbar_skydrive_upload !� Visual# [ 6I   5]   '   �� 5^   &   $��4 0 0 0q�60   $��Center=�5_      $��Browse��5`      5a   #   5b      �� 5f      -   5        $��
txtMobile1��5f   X   $��2��6&   $��1��63    . $ Mobile1��6j   $��15(�6�   $ 10��6�   $��3��6�   $��SemiBold"�6�   �� 5h      -   5        $��
txtRemarks��5h   X   $��9��6&   $��1��63    . $��15(�6j   $ Remarks��6x   $ 50��6�   $��10��6�   $��SemiBold"�6�   �� 5j      -   5        $��cmbusercode��5j   (   $��15(�6;   $��DemiBold"�6I   $��10��6_   $��1��6�   $��11��6�   ��6m   �� 6�   �� 5m      -   5        $��cmbrestcode��5m   (   $��15(�6;   $��DemiBold"�6I   $��11��6_   $��1��6�   $��12��6�   ��6m   �� 6�   �� 5o      -   5        $��	txtEmpcod��5o   Y   $��12��6&   $��1��64    . {�.  $��15(�6|   $��SemiBold"�6�   �� 5q      -   5        $��txtEmpPW��5q   Y   $��13��6&   $��1��64    . $��15(�6i   {�.  $��SemiBold"�6�   �� 5s      -   5        $��	cmbactive��5s   (   $��14��6:   $��1��6I   $��12��6Y   $��15(�6g   $��DemiBold"�6u   .@�5t   "   ��  �� 
IsSelected . 
 � Tag$ 1��6A   $
��True��6I   �� 5u   "   $��False��6/   $ 0��6?   5v      �� 5y      $ 
Horizontal=�6)   $��15��6B   $��2��6Q   $
��auto��6e   .+�5z      �� -   5        $��Submit��5z   |   #��[ 6;   $	��150��6p   $��5,5,5,5q�6�   .��5{   "   �� $ 
Horizontal=�6-   .+�5|   &   �� $��30��60   $��25��5}      ��5~      ��  �� $ ButtonL�$ 
Foreground� 5   *   !� 5�   .   $
 Fill=�6:     appbar_save# [ 6I   5�   '   �� 5�   &   $��4 0 0 0q�60   $��Center=�5�      $
��Save��5�      5�   #   5�      �� 5�   "   -   5        $
��Edit��5�   �   #��[ 6?   $	��150��6t   $��5,5,5,5q�6�   .��5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��30��64   $��25��5�      ��5�      ��  �� $ ButtonL�$ 
Foreground� 5�   .   !� 5�   2   $
 Fill=�6>     appbar_clipboard_edit# [ 6M   5�   +   �� 5�   *   $��4 0 0 0q�64   $��Center=�5�      $
��Edit��5�      5�   '   5�   #   �� 5�   "   -   5        $��Changepw��5�   �   #��[ 6D   $	��150��6y   $��5,5,5,5q�6�   .��5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��30��64   $��25��5�      ��5�      ��  �� $ ButtonL�$ 
Foreground� 5�   .   !� 5�   2   $
 Fill=�6>     appbar_interface_password# [ 6M   5�   +   �� 5�   *   $��4 0 0 0q�64   $��Center=�5�      $��Change password��5�      5�   '   5�   #   5�      �� 5�      -   5        $��stkImage��5�   )   $��Center=�69   $��5,5,5,5q�6V   $	��Top=�6g   $��0��6   $��0��6�   $��10��6�   $	��200��6�   $	��200��6�   .+�5�   "   �� 
�������
���   �$��2q�6U   $��5,5,5,5q�6i   ._�5�   &   ��  �� CornerRadius$ 4��6-   
���   �$��1q�6R   $��5,5,5,5q�6f   ._�5�   *   �� -   5        $��imgPhoto��5�   W    �� BitmapScalingMode$
 Fant=�60   $��Uniform=�5�      $
��auto��5�      $
��auto��5�      $	��Top=�5�      $��5,5,5,5q�5�      $��Center=�5�      5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      