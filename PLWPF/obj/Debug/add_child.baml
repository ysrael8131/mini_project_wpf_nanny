   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.add_child   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          � Title$  	add_child��5	   	   $	��606��6   $	��600��6(   $��Segoe UI Semibold)�6L    � 	Resources 5
         childViewSource  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder  BackgroundGrid   BooleanToVisibilityConverter  textblock_style �� 
TargetType �� Property �� Value  textbox_style �� Triggers P� Property P� Value  triger_to_textbox��%-  &	        &	      &	 2     &	 Z     &	 z     &	 �     &	 �     7  7  &	 �    7  7  &	 A    �� 5   
   6   �� 5   
   $ White��6;   �� 5   
   $ LightSteelBlue��6;   �� 5   
   $ Indigo��67   �� 5   
   $ Beige��61   �� 5   
   6'   �� 5   
   " ��6(   .�5      ��  � ��$ 10q�6'   �� 5       � ��$ Center=�62   �� 5       �@��TextAlignment$
 Left=�6.   �� 5       � ��$ 15(�6)   �� 5       � ��8   6+   �� 5       � ��8  6+   �� 5       � ��$ 25��6'   5      �� 5!   
   " ��6&   .�5"      ��  � ��$ 10q�6'   �� 5#       � ��$ Center=�62   �� 5$       �@��TextAlignment$
 Left=�6.   �� 5%       � ��8   6+   �� 5&       � ��8  6,   �� 5'       � ��$ 25��6'    5+      P� 5,       � ��$  ��6*   . �5-      ��  � ��
 ���� 63   5.      50      �� 52   
   " ��6*    53      P� 54       � ��$  ��6*   . �55      ��  � ��
 ���� 63   56      5;      5<      .��5B      � 
�������	 � ColumnDefinitions	 5C   
   �� 5D      $
��2.6* �6   �� 5E      $
��1.5* �6   .+�5G   
   � -   5        
 �Name$
 
child_grid��5G      #��[ 6#   $��15q�6P    � RowDefinitions 5H      �� 5I      $��* �6    �� 5J      $��* �6    �� 5K      $��* �6    �� 5L      $��* �6    �� 5M      $��* �6    �� 5N      $��* �6    �� 5O      $��* �6    �� 5P      $��* �6    .+�5R      �� $��10,10,9,9.2q�6   $��Personal Information��6.    �� TextAlignment$ Center=�6J   $��20(�6a   �� 5T      $	�� ID��6   $��1��6&   #��[ 63   y�5U   
   ��  �� ElementName$ 	idTextBox�� �� Path$ Text.IsEmpty� �� 	Converter# [ �� 5V      -   5         ��Name$ 	idTextBox��5V      $��1��6)   $��10q�66   #��[ 6B   ��5W   
   �� *id+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6e   �� 5X      -   5         ��Name$ errorMesseg1��5X      $%�� This field is for numbers only��6.   $��1��6U    	 textblock_style_error#��[	 6b   �� 5Y      -   5        $ errorMesseg2��5Y      $"��Number ID should be 9 digits��6.   $��1��6R   #��[	 6_   �� 5Z      -   5        $ errorMesseg3��5Z      $#��Number ID can not be negative��6.   $��1��6S   #��[	 6`   �� 5]      $��	Mother ID��6   $��2��6,   #��[ 69   y�5^   
   �� $ idTextBoxMother��$ Text.IsEmpty�# [ �� 5_      -   5        $ idTextBoxMother��5_      $��2��6/   #��[ 6<   $��10q�5`   k   ��6
   �� *
MotherID+$ TwoWay=� .  . 6w   �� 5b      -   5        $ errorMesseg4��5b      $%�� This field is for numbers only��6.   $��2��6U   #��[	 6b   �� 5c      -	   5        $ errorMesseg5��5c      $"��Number ID should be 9 digits��6.   $��2��6R   #��[	 6_   �� 5d      -
   5        $ errorMesseg6��5d      $#��Number ID can not be negative��6.   $��2��6S   #��[	 6`   �� 5f      $��
First Name��6   $��4��6-   #��[ 6:   y�5g      �� $ firstNameTextBox��$ Text.IsEmpty�# [ �� 5h      -   5        $ firstNameTextBox��5h      $��4��60   #��[ 6=   $��10q�5i   d   ��6   �� *	FirstName+$ TwoWay=� .  . 6d   �� 5m      $��	Birth day��6   $��3��6,   #��[ 69   y�5n      �� $ birthDayDatePicker��$ Text.IsEmpty�# [ (  "System.Windows.Controls.DatePicker  5o      -   5          Name$ birthDayDatePicker��5o      $��3��66   $��Center=�5q      #��[ 61   $��15q�6e      SelectedDate 5p      �� *
birthDay+$ TwoWay=� .  . 5q   e   �� 5s      $��Special Needs:��6   $��0��6-   $
��Left=�6=   $��3q�6X   $��5��6c   $��Center=�6p   �� 5t      -   5         ��Name$ specialNeedsCheckBox��5t      $�� ��65   $��0��6@   $��Center=�5u      $��5��6/   $��Center=�6<    d� 	IsChecked 5t   P   �� *specialNeeds+$ TwoWay=� .  . 5u   <   �� 5x      $��details Special Needs:��6   $��6��69   #��[ 6F   y�5y   
   �� $  detailsSpecialNeedsTextBox��$ Text.IsEmpty�# [ �� 5z      -   5        $  detailsSpecialNeedsTextBox��5z      $��6��6:   #��[ 6G   $��10q�5|   X   ��5{   
   �� *detailsSpecialNeeds+$ TwoWay=� .  . {�5|      �� $ specialNeedsCheckBox��$ 	IsChecked�6X   �� 5}      -   5        $��Creat��5}      $��7��6'   $��20q�64   #��[ 6B   ��5~      �� 5       5�      �� 5�       �� Binding 6*   �� $ 	idTextBox��$
 Text� �� Value  6^   .a�5�   "   ��  � {� .  6E   5�      �� 5�       6*   �� $ firstNameTextBox��$
 Text�  6e   .a�5�   "   ��  � {� .  6E   5�      �� 5�       6*   �� $ birthDayDatePicker��$
 Text�  6g   .a�5�   "   ��  � {� .  6E   5�      �� 5�       6*   �� $ idTextBoxMother��$
 Text�  6d   .a�5�   "   ��  � {� .  6E   5�      5�      5�      5�      �� 5�   
   $��1��6   $��Center=�6$   $��10q�6B   $
��Wrap=�6N   $��create a new child��6b   $��72(�6}   $	��Top=�6�   $��Tango BT)�6�   $
��Bold"�6�   $ Center=�6�   $y�Visible=�6�   �� 5�   
   $��0.2,246,-0.4,-0.2q�6   $��
123321.png��6+   $
��Fill=�6?   $��1��6N   5�      5�      