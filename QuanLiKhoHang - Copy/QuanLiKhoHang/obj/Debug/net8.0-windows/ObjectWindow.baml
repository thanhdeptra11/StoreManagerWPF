   M S B A M L   `   `   `  ����H  DQuanLiKhoHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLiKhoHangQuanLiKhoHang  5   	   W0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl"QuanLiKhoHang.QuanLiKhoUserControl  5   
        QuanLiKhoHang.ObjectWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLiKhoHang     5   	   ?uc0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl     5   
   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     � Title$  CustomerWindow��5   	   $	��550��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�5
   
      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � 
ResizeMode$ NoResize=�5   
    � WindowStyle$
 None=�5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      5   /QuanLiKhoHang.QuanLiKhoUserControl.UserControl1  
 � Tag 6   �� *Title+ �� ElementName$# Storagemanagement_application��6a   5      � 5   
   $��1��6    5       �� 5!      $
��auto �6    60   �� 5"      $
��auto �6    60   �� 5#      6"   .+�5%      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��0,0,0,15q�6/   .��5&      � .+�5'      �� -   5        $��txbObjectItem��5)      $��Center=�5'      $��7,5,20,7q�69   $	��120��5(      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Tên vật phẩm��5+       % !MaterialDesignFloatingHintTextBox#��[ 5,      �� 5.      -   5        $��cbxUnit��5/      $	 
Đơn vị��5.      
 �� DisplayMemberPath$
 DisplayName��50      $	��130��51      $��	7,11,20,7q�52      53      �� 54      -   5        $��cbxSupplier��55      $	 Nhà cung cấp��54      $
 DisplayName��56      $	��130��57      $��	7,11,20,7q�58      59      5:      5;        5=      $��1��6"   $��5q�6/   .��5>      � .+�5?      �� -   5         ��Name$ btnAdd��5?      $��Thêm��6a   $��7q�6p   $	��100��6{   ��6B   �� *
AddCommand+6�   �� 5@      -   5        $ btnEdit��5@      $��Sửa��6d   $��7q�6r   $	��100��6}   ��6D   �� *EditCommand+6�   �� 5A      -   5        $ btnDel��5A      $
��Xóa��6d   $��7q�6r   $	��100��6}   ��6B   �� *DeleteCommand+6�   5B      5C        5F      $��2��6"   $��5q�6/   $��Stretch=�6:   $��Stretch=�6V   .��5G      � .+�5H      �� -   5         ��Name$ lsvObjectItem��5H       �� View 5I      �� 5J      .P�5K   "   �� $��Id��61    �� Width$ 80��5L   *    �� DisplayMemberBinding 5K   =   �� *Id+5M   #   �� 5N   "   $
��Tên��61   $	 130��5O   *    5N   >   �� *DisplayName+5P   #   �� 5Q   "   $��Đơn vị đo��61   $	 130��5R       5Q   D   �� *IdUnitNavigation.DisplayName+5S   #   �� 5T   "   $��Nhà cung cấp��61   $	 160��5U       5T   G   �� *" IdSupplierNavigation.DisplayName+5V   #   5W      5Y      5Z      5[      5\      5]      5^      