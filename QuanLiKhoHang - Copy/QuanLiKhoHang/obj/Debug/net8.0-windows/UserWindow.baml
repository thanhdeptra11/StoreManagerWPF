   M S B A M L   `   `   `  ����H  DQuanLiKhoHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLiKhoHangQuanLiKhoHang  5   	   W0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl"QuanLiKhoHang.QuanLiKhoUserControl  5   	       QuanLiKhoHang.UserWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLiKhoHang     5   	   ?uc0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��Userrr��5	   	     � Title$  CustomerWindow��5      $	��550��6   $
��1000��6,    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      5   /QuanLiKhoHang.QuanLiKhoUserControl.UserControl1  
 � Tag 6   �� *Title+ �� ElementName$ Userrr��6J   5      � 5   
   $��1��6    5      �� 5       $
��auto �6    60   �� 5!      $
��auto �6    60   �� 5"      6"   .+�5$      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��0,0,0,15q�6/   .��5%      � .+�5&      �� -   5        	 ��Name$	 txbUsername��5&      $��5 5 15 5q�63   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Tên đăng nhập��6E    % !MaterialDesignFloatingHintTextBox#��[ 6u   �� 5'      -   5        $��cbxRole��5'      $	��100��6.   $��5 5 15 5q�6:    �� DisplayMemberPath$ DisplayName��6M    & "MaterialDesignFloatingHintComboBox#��[ 6m   6�   �� 5(      -   5        $	 txbDisplayname��5(      $��5 5 15 5q�66   $
 Tên hiển thị��6H   #��[ 6x   �� 5)      -   5        $��
cbxRequest��5+      $	��101��5)      $��	5 13 15 5q�5*      $
 
Yêu cầu��5,       5/      50      51        53      $��1��6"   $��5q�6/   .��54      � .+�55      �� -   5         ��Name$ btnAdd��55      $��Thêm��6a   $��7q�6p   $	��100��6{   ��6B   �� *
AddCommand+6�   �� 56      -   5        $ btnEdit��56      $��Sửa��6d   $��7q�6r   $	��100��6}   ��6D   �� *EditCommand+6�   �� 57      -   5        $ btnDel��57      $
��Xóa��6d   $��7q�6r   $	��100��6}   ��6B   �� *DeleteCommand+6�   58      59        5<      $��2��6"   $��5q�6/   $��Stretch=�6:   $��Stretch=�6V   .��5=      � .+�5>      �� -	   5         ��Name$ lsvUser��5>       �� View 5?      �� 5@      .P�5A   "   �� $��Id��61    �� DisplayMemberBinding 6=   �� *Id+6c   �� 5B   "   $��Tên đăng nhập��61    6I   �� *
UserName+6u   �� 5C   "   $��Chức vụ��61    6D   �� *IdRoleNavigation.DisplayName+6�   �� 5D   "   $��Tên hiển thị��61    6I   �� *DisplayName+6x   �� 5E   "   $��
Yêu cầu��61    6B   �� *	Request+6m   5F      5H      5I      5J      5K      5L      5M      