   M S B A M L   `   `   `  ����H  DQuanLiKhoHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLiKhoHangQuanLiKhoHang  5   	   W0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl"QuanLiKhoHang.QuanLiKhoUserControl  5   
        QuanLiKhoHang.OutputWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLiKhoHang     5   	   ?uc0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl     5   
   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5        $��OutputWindoww��5   	     � Title$  OutputWindow��5	   	   $	��450��6   $	��860��6+    � WindowStartupLocation$ CenterScreen=�5   
      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � 
ResizeMode$ NoResize=�5   
    � WindowStyle$
 None=�5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      5   /QuanLiKhoHang.QuanLiKhoUserControl.UserControl1  
 � Tag 6   �� *Title+ �� ElementName$ OutputWindoww��6Q   5      � 5    
   $��1��6    5!      �� 5"      $
��auto �6    60   �� 5#      $
��auto �6    60   �� 5$      6"   .+�5(      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5)      � $��0 0 0 10q�6   .+�5*      �� -   5        $��cbxObjectItem��5*   Z   $��0��6   $��0��6)   $y�Hidden=�64   	 �� 
IsReadOnly$
	 True��6H   
 �� SelectedValue$
 Id��6o    �� DisplayMemberPath$ DisplayName��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên vật tư��6�   $��	5 25 15 5q�6�   6�   �� 5+      -   5         ��Name$ txbObjectName��5+      $��	0,15,10,5q�65    �� 
IsReadOnly$
 True��6H   $	��140��6[   $ Tên vật tư��6g   6�   �� 5,      -   5        $��cbxIdInputInfo��5,      $
 Id��65   $	��140��6H   $ Mã đơn nhập��6T   $��	5 25 15 5q�6�   ��5-      �� 5.      .R�5/   "   ��  �� Orientation$ 
Horizontal=�6-   .+�50   &   �� ��60   �� *Id+6F   �� 51   &   $��-��60   6;   �� 52   &   ��60   �� * IdObjectNavigation.DisplayName+6b   53   #   54      56      (  "System.Windows.Controls.DatePicker  57      -   5        $��dpOutputDate��57   !   $��Center=�65   $	��100��6s   $��	5 5 15 -7q�6   $ Ngày xuất��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6P   �� *	DateOnput+6�   �� 58      -   5        $ txbQuantity��58      $��80��63   $��5 5 15 5q�6z   $ Số lượng��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6>   �� *Count+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 59      -   5        $ txbOutPrice��59   0   $
 True��6   $	��100��6E   $��5 5 15 5q�6�   $ Giá xuất��6�   #��[ 6�   ��6Q   �� *PriceOutput+$ PropertyChanged=�6�   �� 5:      -   5        $��cbxCustomer��5:   ?   $	��130��6    $��	5 18 15 5q�6,   $ DisplayName��6R   $ Khách hàng��6s    �� 
IsEditable$
 True��6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   6�   �� 5<      -	   5        $ 	txbStatus��5<      $��5 5 15 5q�6n   $ Trạng thái xuất��6�   #��[ 6�   ��61   �� *Status+$ PropertyChanged=�6�   5=      5>        5@      $��1��6"   $��5q�6/   .��5A      � .+�5B      �� -
   5         ��Name$ btnAdd��5B      $��Thêm��6a   $��5q�6p   $	��100��6{   ��6B   �� *
AddCommand+6�   �� 5C      -   5        $ btnEdit��5C      $��Sửa��6d   $��5q�6s   $	��100��6~   ��6D   �� *EditCommand+6�   �� 5D      -   5        $ btnDel��5D      $��Xóa��6d   $��5q�6s   $	��100��6~   ��6B   �� *DeleteCommand+6�   5E      5F        5H      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5I      �� $
��Auto=�6   .��5J      �� -   5        $��	lsvOutput��5J       �� View 5K      �� 5L      .P�5M   "   �� $��
Vật tư��61    �� DisplayMemberBinding 6B   �� * IdObjectNavigation.DisplayName+6�   �� 5N   "   $��Ngày xuất��61    5O   &   �� 5P   *    �� Path$# IdOutputNavigation.DateOutput�62    �� StringFormat$ {0:dd/MM/yyyy}��6W   5R   #   �� 5S   "   $��Số lượng��61    6E   �� *Count+6n   �� 5T   "   $��Giá xuất��61    6E   �� *#!IdInputInfoNavigation.OutputPrice+6�   �� 5U   "   $��Khách hàng��61    6G   �� *" IdCustomerNavigation.DisplayName+6�   �� 5V   "   $��Trạng thái xuất��61    6M   �� *Status+6w   �� 5W   "   $��Thực hiện��61    6D   �� *User.DisplayName+6x   5X      5Z      5[      5\      5]      5^      5_      