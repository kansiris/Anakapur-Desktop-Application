   M S B A M L   `   `   `  ����C  ?Anakapur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Anakapur.PagesAnakapur.Pages  5          Anakapur.Pages.MyOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Anakapur.Pages     5        N� Title$  MyOrder��5      $��312.857��6   $��535.714��6(   .��5
      � -   5         �Name$	 Grd��5
   !   
������� � ColumnDefinitions 5   
   �� 5      $��8* �6   �� 5      $	��69* �6   �� 5      $	��23* �6   .+�5   
   �� -   5         ��Name$ StkPnl��5       �� Orientation$ 
Horizontal=�6%   $��3��6>    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� ElementName��%�   ' �       �� 5      "  �6   .�5      ��  � ��$ 0,50,0,0q�6/   �� 5       � �� 6.   �� *ActualWidth+$		 Grd���� 5       �@ �NavigationUIVisibility$ Hidden=�6?   5      5      .+�5       � -   5        
  �Name$
 
FramePage1��5        � Source$ 
Combo.xaml?�6(   5      �� 5   
   -   5        $��	BreakFast��5      $
��Left=�6%   $��	10,23,0,0q�6@   $	��Top=�6S   $��75��6k   $��2��6�    � Triggers 5      :� 5       :� RoutedEvent$ ButtonBase.Click��6   .[�5      �� .��5      ��  �� 
TargetName$ 
FramePage1��6%    �� TargetProperty$ Margin�6H   .��5       t� 	 t� To$ -2000 , 50 , 0, 0X�61    g� Duration$ 0:0:5D�6H   5!      5"      5#      5%      5&      5'      