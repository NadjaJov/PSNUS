   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.AddAI   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   !localclr-namespace:WpfApp1  5   	     � Title$  AddAI��5	   	   $	��450��6   $	��800��6$   .��5
      � .+�5   
   �� $��Tag name (id) :��6   $
��Left=�6*   $��160,100,0,0q�6E   $	��Top=�6Z   $��2��6r   �� 5   
   -   5        $��	NameBoxAI��5   1   $
��Left=�6B   $��23��6]   $��250,100,0,0q�6i    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   $	��120��6�   $��2��6�   ��6   ��  �� Path$ IdNameAI�6�   �� 5   
   $��Description :��6   $
��Left=�6(   $��160,150,0,0q�6C   $	��Top=�6X   $��2��6p   �� 5   
   -   5        $��DescriptionBoxAI��5      $
��Left=�6N   $��23��6i   $��250,150,0,0q�6u   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   ��6*   �� $ DescriptionAI�6�   �� 5   
   $��I/O address :��6   $
��Left=�6(   $��160,200,0,0q�6C   $	��Top=�6X   $��2��6p   �� 5   
   -   5        $��BorderAI��5      $��1q�6!   $
��Left=�65   $	��Top=�6P   $��249,199,0,0q�6h   $	��122��6}   $��24��6�   �� 5   
   -   5        $��AddressComboAI��5      $
��Left=�6Q   $��250,200,0,0q�6l   $	��Top=�6�   $	��120��6�   $��2��6�    �� SelectedItem 6)   �� $ 	AddressAI�6�   �� 5   
   $��Scan time :��6   $
��Left=�6&   $��160,250,0,0q�6A   $	��Top=�6V   $��2��6n   �� 5   
   $��miliseconds��6   $
��Left=�6&   $��380,250,0,0q�6A   $	��Top=�6V   $��2��6n   �� 5   
   -   5        $��	TimeBoxAI��5      $
��Left=�6D   $��23��6_   $��250,250,0,0q�6k   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   ��6#   �� $ 
ScanTimeAI�6�   �� 5   
   $��Units :��6   $
��Left=�6"   $��175,300,0,0q�6=   $	��Top=�6R   $��2��6j   �� 5   
   -   5        $��
UnitsBoxAI��5      $
��Left=�6C   $��23��6^   $��250,300,0,0q�6j   $
 Wrap=�6   $	��Top=�6�   $	��120��6�   $��2��6�   ��6%   �� $ UnitsAI�6�   �� 5   
   -   5        $��	listboxAI��5       �� SelectionMode$ Multiple=�6#   $
��Left=�6<   $	��Top=�6W   $��500,110,0,0q�6o   $	��200��6�   $	��150��6�   ��5      �� 5      .R�5      � $	��0,2q�6    � ColumnDefinitions 5      �� 5      $��* �6/   �� 5      $	��100 �6/   .+�5      �� ��6$   �� $ IdNameAlarm�5       5!      5#      �� 5%   
   -   5        $
��Save��5%       $
��Left=�6/   $��670,200,0,0q�6J   $	��Top=�6_   $	��100��6w   $��20��6�   $��2��6�   �� 5&   
   $��Alarms��6   $
��Left=�6!   $��
550,78,0,0q�6<   $	��Top=�6P   5'      5(      