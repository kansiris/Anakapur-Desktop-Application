   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Anakapur.PagesAnakapur.Pages  5          Anakapur.Pages.New_Order   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Anakapur.Pages     5        N� Title$  	New_Order��5      $��402.74��6   $��708.904��6)   .��5      � -   5        $��grdData��5       � ColumnDefinitions 5   
   �� 5      $	��49* �6   �� 5      $	��15* �6   �� 5      $
��236* �6   .+�5   
   ]� $��3��6   .+�5      �� 
����� �$	��Top=�6'   ._�5      �� $��Customer Name��6   5      �� 5      
���  ��$��Bottom=�6&   ._�5      �� $��Dock:Bottom��6   5      �� 5      
��� ���$
��Left=�6)   ._�5      �� $��Center=�6   $��Center=�69   $��	Dock:Left��5      5      �� 5      
���P��$��Right=�6(   ._�5      �� -   5         ��Name$ lstElements��5       %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�5      $��Center=�6T   $��Center=�6q   ��6;   �� .@�6�   
Items List5    !   5#      �� 5$      
�������$
��Left=�6+   ._�5%      � $��0,22,0,0q�6   $	��241��6*    � RowDefinitions 5-      �� 5.      $	��50* �6(   �� 5/      $	��50* �6(   �� 50      $	��46* �6(   �� 51      $	��54* �6(   �� 52      $	��49* �6(   .+�57      9� -   5        $��	BreakFast��57      $��-10,-33,10,0q�6P   $��2��6f    J� RenderTransformOrigin$ 0.536,0.234&�6w   �� 59      -   5        $��spdata��59   !   $
��Auto��6/    �� Orientation$ 
Horizontal=�6<   �� 5h      -   5         ��Name$ btnLunch��5h      $��Lunch/Dinner��60   $��
0,31,10,22q�6G   $��2��6[   $��2��6h   �� 5i      -   5        $ btnCombo��5i      $��Combo��60   $��
0,31,10,15q�6@   $��1��6T   $��2��6a   �� 5j      -   5        $ btnFamilyPack��5j      $��Family Pack��65   $��
0,22,10,26q�6g   $��3��6{   $��2��6�   5      5�      5�      5�      5�      