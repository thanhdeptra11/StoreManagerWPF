   M S B A M L   `   `   `  ����H  DQuanLiKhoHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLiKhoHangQuanLiKhoHang  5   	   W0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl"QuanLiKhoHang.QuanLiKhoUserControl  5   
       QuanLiKhoHang.InputWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLiKhoHang     5   	   ?uc0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl     5   
   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5        $��InputWindoww��5   	     � Title$  InputWindow��5	   	   $	��450��6   $	��860��6*    � WindowStartupLocation$ CenterScreen=�5   
      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � 
ResizeMode$ NoResize=�5   
    � WindowStyle$
 None=�5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      5   /QuanLiKhoHang.QuanLiKhoUserControl.UserControl1  
 � Tag 6   �� *Title+ �� ElementName$ InputWindoww��6P   5      � 5!   
   $��1��6    5"      �� 5#      $
��auto �6    60   �� 5$      $
��auto �6    60   �� 5%      6"   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5*      � $��0 0 0 10q�6   .+�5+      �� -   5        $��cbxObjectItem��5+      	 �� SelectedValue$	 Id��64   
 �� DisplayMemberPath$
 DisplayName��6G   $	��140��6g   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên vật tư��6s   $��	5 25 15 5q�6�   6�   (  "System.Windows.Controls.DatePicker  5,      -   5        $��dpDateInput��5,   !   $��Center=�64   $	��100��6r   $��	5 5 15 -7q�6~   $ Ngày nhập��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6O   �� *	DateInput+6�   �� 5-      -   5         ��Name$ txbQuantity��5-   f   $��5 5 15 5q�6�   $ Số lượng��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6{   �� *Count+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5.      -   5        $ txbInputPrice��5.   B   $��5 5 15 5q�6�   $ Giá nhập��6�   #��[ 6�   ��6Y   �� *
PriceInput+$ PropertyChanged=�6�   �� 5/      -   5        $ txbOutputPrice��5/   C   $��5 5 15 5q�6�   $ Giá xuất��6�   #��[ 6�   ��6[   �� *PriceOutput+$ PropertyChanged=�6�   �� 51      -   5        $ 	txbStatus��51   0    �� 
IsReadOnly$
 True��6   $��5 5 15 5q�6�   $ Trạng thái nhập��6�   #��[ 6�   ��6C   �� *Status+$ PropertyChanged=�6�   52      53        55      $��1��6"   $��5q�6/   .��56      � .+�57      �� -   5        $��btnAdd��57   <   $��Thêm��6_   $��5q�6n   $	��100��6y   ��6   �� *
AddCommand+6�   �� 58      -	   5        $��btnEdit��58   =   $��Sửa��6b   $��5q�6q   $	��100��6|   ��6   �� *EditCommand+6�   �� 59      -
   5        $��	btnDelete��59   ?   $��Xóa��6h   $��5q�6w   $	��100��6�   ��6   �� *DeleteCommand+6�   5:      5;        5=      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5>      �� $
��Auto=�6   .��5?      �� -   5         ��Name$ lsvInput��5?       �� View 5@      �� 5A      .P�5B   "   �� $��
Vật tư��62    �� DisplayMemberBinding 6C   �� * IdObjectNavigation.DisplayName+6�   �� 5C   "   $��Ngày nhập��61    5D   &   �� 5E   *    �� Path$! IdInputNavigation.DateInput�62    �� StringFormat$ {0:dd/MM/yyyy}��6U   5G   #   �� 5H   "   $��Số lượng��61    6E   �� *Count+6n   �� 5I   "   $��Giá nhập��61    6E   �� *
InputPrice+6s   �� 5J   "   $��Giá xuất��61    6E   �� *OutputPrice+6t   �� 5K   "   $��Trạng thái nhập��61    6M   �� *Status+6w   �� 5L   "   $��Thực hiện��61    6D   �� *User.UserName+6u   5M      5O      5P      5Q      5R      5S      5T      