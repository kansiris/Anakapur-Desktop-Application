   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AnakapurAnakapur  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       Anakapur.EditOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Anakapur     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     N� Title$  	EditOrder��5	   	   $	��450��6   $	��500��6(   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��30,60,20,20q�6   $��1q�6&   
������� �� CornerRadius$ 5��6M   ._�5   
   ]� .+�5       �� $
��Left=�6   .+�5!      �� $��/Images/ankapurlogo.png��6   $	��200��69   $	��200��6E   6T   5#      �� 5%      $��Right=�6   $��Center=�60   $��Center=�6K   .+�5(      �� $��20(�6   $��1��6"   .��6/   
Order Id69   �� 5)      -   5        $��
txtorderid��5)   3   $��1��6   $��1��6#   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Order Id��6E    �� 	MaxLength$ 20��6q   $	��200��6�   $��40��6�   $��2��6�   $��15(�6�   $��SemiBold"�6�   
���   �$��1q�6�   �� 5*      $��20(�6   $��Discount��6+   �� 5+      -   5        $��txtdiscount��5+   P   $��3��6   $��1��6+    �� AcceptsReturn . $ Discount��6e   $��40��6�   $	��200��6�   $��15(�6�   $ 10��6�   $��4��6�   $��SemiBold"�6�   
���   �$��1q�6�   �� 5,      $��20(�6   $��3��6+   .��68   Amount Paid6E   �� 5-      -   5        $��txtamountpaid��5-   P   $��4��6   $��1��6+    . $ 
AmountPaid��6f   $��40��6�   $	��200��6�   $��15(�6�   $ 10��6�   $��4��6�   $��SemiBold"�6�   
���   �$��1q�6  �� 5.      $��20(�6   $��3��6+   .��68   	Remarks6A   �� 5/      -   5        $��
txtremarks��5/   P   $��5��6   $��1��6+    . $ Remarks��6b   $	��200��6�   $��80��6�   $��15(�6�   $ 10��6�   $��4��6�   $��SemiBold"�6�   
���   �$��1q�6�   �� 50      -   5         ��Name$ btnsave��50      $	��180��6/   $��6��6;   $��UPDATE��6H   
����� �$��15(�6l   
����·�6�   51      54      55      56      57      