   M S B A M L   `   `   `  ����H  DQuanLiKhoHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl"QuanLiKhoHang.QuanLiKhoUserControl  5   	   -clr-namespace:QuanLiKhoHangQuanLiKhoHang  5   	       QuanLiKhoHang.Register   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ?uc0clr-namespace:QuanLiKhoHang.QuanLiKhoUserControl     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   'localclr-namespace:QuanLiKhoHang  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��Register_Window��5
   	     � Title$  Register_Window��5	      $	��520��6$   $	��550��61    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5!   
   � $��0��6   .+�5"      5   /QuanLiKhoHang.QuanLiKhoUserControl.UserControl1  
 � Tag 6   �� *Title+ �� ElementName$ Register_Window��6S   5#      #  MaterialDesignThemes.Wpf.Card  5%   
   $��Center=�6   $��Center=�69   $	��450��5&      $	��360��6#   $��1��60   .��5'      �  5(      �� 5)      6&   �� 5*      6&   �� 5+      6&   �� 5,      6&   �� 5-      6&   �� 5.      6&   	 � 	Resources	 50      
 �� 
TargetType �� Property �� Value��%]   '�       �� 51      "
 �6   .�52      ��  � ��$ 6,7,5,10q�63   6F   53      54      .+�55      �� -   5        $��txbUsername��56      $��0��55      $��Center=�58      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��59       % !MaterialDesignFloatingHintTextBox#��[ 5:      G� 5<      -   5         G�Name$ txbPassword��5?      $��1��5<         
Foreground
 � � �$ Password��5A      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 � � � ) %MaterialDesignFloatingHintPasswordBox#��[ 5C      5E      G� 5F      -   5        $ txbPasswordReEnter��5H      $��2��5F      
 � � �$ Re enter password��5J      
 � � �#��[ 5L      5N      � 5O      $��3��6    � ColumnDefinitions 5P      �� 5Q      $
��auto �6+   6:   �� 5R      $��* �6+   67   .+�5T      �� -   5        $��txbEmail��5U      $��0��5T      $��Center=�5W      $
��Left=�5X      $	��200��5Y      $ Email��5Z      #��[ 5[      �� 5]      -   5         ��Name$ 
btnSendOTP��5]      $��Right=�6L   $��1��6h   $	��100��6x   .��6�   
Send OTP6�   5^      �� 5`      -   5        $��txbOTP��5a      $��4��5`      $
��Left=�5c      $	��200��5d      $	 OTP��5e      #��[ 5f      � 5i      $��5��6    5j      �� 5k      6-   �� 5l      6-   �� 5m      6-   .+�5o      �� -   5        $��btnLogin��5s      $��0��5o      $	��130��5p      $��Register��5q       # MaterialDesignRaisedLightButton#��[ 5t       � ToolTip$4 .Resource name: MaterialDesignRaisedLightButton��5u      �� 5w      -	   5        $��btnExit��5z      $��1��5w      $	��130��5x      $
��Exit��5y      
��� E��#��[ 5|      $4 .Resource name: MaterialDesignRaisedLightButton��5}      �� 5      -
   5        $��btnReturnLogin��5�      $��2��5      $	��130��5�      $��Return Login��5�      #��[ 5�      $4 .Resource name: MaterialDesignRaisedLightButton��5�      5�      5�      5�      5�      5�      