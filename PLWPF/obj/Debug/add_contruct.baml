   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.add_contruct   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          � Title$  add_contruct��5	   	   $	��480��6   $��398.6��6+   $��Segoe UI Semibold)�6P    � 	Resources 5
         contractViewSource��%   &	        �� 5   
   6   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $	��41* �6   �� 5      $	��16* �6   .+�5   
   �   BackgroundGrid#��[ 6   $��15q�6<   .+�5      �� -   5         ��Name$ mom_child_nan_stackpanel��5      $y�Visible=�6;   .+�5      �� -   5        $ mother_stackpanel��5      $y�Visible=�69    �� Orientation$ 
Horizontal=�6N   .+�5      �� -   5         ��Name$ select_mother��5       $��Select mother��67   $��15q�6L   $��Impact)�6X   
���**��6l   �� 5      -   5         ��Name$ select_mother_conbobox��5       �� DisplayMemberPath$ id��6?   $��90��6V   $��15q�6a   $��3q�6�   $��Impact)�6�   5      �� 5      -   5        $ child_stackpanel��5      $y�Visible=�68   $ 
Horizontal=�6M   .+�5      �� -   5        $ select_child��5       $��Select child��66   $��15q�6J   $��Impact)�6V   
���**��6j   �� 5      -   5        $ select_child_conbobox��5       $ id��5       $��90��5    6   $��15q�6A   $��3q�6�   $��Impact)�6�   {�5   7   ��  �� ElementName$ select_mother_conbobox��	 �� Path$	 SelectedItem�5    �   5!      �� 5"      -	   5        $ nanny_stackpanel��5"      $y�Visible=�67   $ 
Horizontal=�6L   .+�5#      �� -
   5        $ select_nannys��5#       $��Select nanny��67   $��15q�6K   $��Impact)�6W   
���**��6k   �� 5$      -   5        $ select_nanny_conbobox��5$      $ id��6>   $��90��6U   $��15q�6`   
����  �$��3q�6�   $��Impact)�6�   5%      �� 5&      -   5        
 ��Name$
 select_button��5&      $��Center=�60   $��build your contract��6M   $��25��6k   $y�Visible=�6w   ��5(      �� 5)       �� Triggers 5*      �� 5+   "    �� Binding 6.   �� $ select_mother_conbobox��$
	 Text� �� Value  6p   .a�5,   "   ��  �� Property � {� �� Value .  6E   5-      �� 5.   "    6.   �� $ select_child_conbobox��$
	 Text�  6q   .a�5/   "   ��  � {� .  6E   50      �� 51   "    6.   �� $ select_nanny_conbobox��$
	 Text�  6o   .a�52   "   ��  � {� .  6E   53      57      59      5=      � 5>      -   5         �Name$ contract_grid��5>      $y�	Collapsed=�6*   $��0q�6A    5?      �� 5@      $��1* �6'   �� 5A      $��1* �6'    � RowDefinitions 5C      �� 5D      $
��auto �6$   �� 5E      $
��auto �6$   �� 5F      $
��auto �6$   �� 5G      $
��auto �6$   �� 5H      $
��auto �6$   �� 5I      $
��auto �6$   �� 5J      $
��auto �6$   �� 5K      $
��auto �6$   �� 5L      $��1* �6$   .+�5O      �� $��2��6   $��your contract��61   $��Center=�6F   $��Center=�6c   $��20(�6~   �� 5P      $��	Nanny ID:��6   $��0��6,   $
��Left=�6<   $��3q�6W   $��1��6b   $��Center=�6o   �� 5Q      -   5        $ nannyIDTextBlock��5Q      $��1��66   $
��Left=�6F   $��3q�6a   $��1��6l   $��Center=�6�   ��6z   �� *	NannyID+6�   �� 5R      $��
Mother ID:��6   $��0��6-   $
��Left=�6=   $��3q�6X   $��2��6c   $��Center=�6p   �� 5S      -   5        $ motherIDTextBlock��5S      $��1��67   $
��Left=�6G   $��3q�6b   $��2��6m   $��Center=�6�   ��6z   �� *
MotherID+6�   �� 5U      $��	child ID:��6   $��0��6,   $
��Left=�6<   $��3q�6W   $��3��6b   $��Center=�6o   �� 5V      -   5        $ childIDTextBlock��5V      $��1��66   $
��Left=�6F   $��3q�6a   $��3��6l   $��Center=�6�   ��6y   �� *	childID+6�   �� 5X      $��per hour able:��6   $��0��61   $
��Left=�6A   $��3q�6\   $��4��6g   $��Center=�6t   �� 5Y      -   5         ��Name$ contracPerCheckBox��5Y      $�� ��67   $��1��6B   $
��Left=�6R   {�.  $��3q�6�   $��4��6�   $��Center=�6�    d� 	IsChecked 6   �� *
ContracPer+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5\      $��salary Per Hour:��6   $��0��63   $
��Left=�6C   $��3q�6^   $��5��6i   $��Center=�6v   �� 5]      -   5        $ salaryPerHourTextBlock��5]      $��1��6<   $
��Left=�6L   $��3q�6g   $��5��6r   $��Center=�6�   ��6   �� *salaryPerHour+6�   �� 5^      $��salary Per Month:��6   $��0��64   $
��Left=�6D   $��3q�6_   $��6��6j   $��Center=�6w   �� 5_      -   5        $ salaryPerMonthTextBlock��5_      $
��Left=�6=   $��Center=�6x   $��6��6�   $��1��6�   ��6X   �� *salaryPerMonth+6�   � 5a      $��7��6   $��Center=�6$   $��Center=�6?   
�������$��2��6w    5b      �� 5c      $
��auto �6+   �� 5d      $
��auto �6+    5f      �� 5g      $
��auto �6(   �� 5h      $
��auto �6(   �� 5i      $
��auto �6(   �� 5j      $
��auto �6(   �� 5k      $
��auto �6&   .+�5n      �� $��enter the folowing��6    $��Center=�6:   $��Center=�6W   $��59,7,58,11.6q�6r   $��0��6�   $��2��6�   �� 5o      $��start:��6   $��0��6+   $
��Left=�6;   $��Center=�6W   $��1��6r   (  "System.Windows.Controls.DatePicker  5p      -   5          Name$ startDatePicker��5p      $
��Left=�68   $��Center=�5r      $��1��6;   $��1��6H      SelectedDate 5q      �� *start+$ TwoWay=� .  . 5r   H   �� 5t      $
��end:��6   $��0��6)   $
��Left=�69   $��Center=�6U   $��2��6p     5u      -   5        $ endDatePicker��5u      $
��Left=�66   $��Center=�5w      $��2��6;   $��1��6H    5v      �� *end+$ TwoWay=� .  . 5w   H   �� 5y      $��knowlage Meet:��6   $��0��63   $
��Left=�6C   $��Center=�5z      $��3��65   �� 5{      -   5        $ knowlageMeetCheckBox��5{      $�� ��6;   $
��Left=�6F   $��Center=�5}      $��3��69   $��1��6F    5|      �� *knowlageMeet+$ TwoWay=� .  . 5}   F   �� 5      $��contract Signe:��6   $��0��66   $��4��6F   $
��Left=�6S   $��Center=�5�      �� 5�      -   5        $ contractSigneCheckBox��5�      $�� ��6>   $
��Left=�6I   $��Center=�5�      $��4��6:   $��1��6G    5�      �� *contractSigne+$ TwoWay=� .  . 5�   G   5�      �� 5�      -   5        $
 add_contract_button��5�      $��8��66   
����·�$��Add Contract��6^   $��50��6u   $	��100��6�   $��Center=�6�   $��Center=�6�   6�   �� 5�      -   5        $
 payment��5�      $��8��6*   $��1��67   
����·�$��Calculate Payment��6b   $��50��6~   $	��100��6�   $��Center=�6�   $��Center=�6�   6�   5�      5�      5�      5�      