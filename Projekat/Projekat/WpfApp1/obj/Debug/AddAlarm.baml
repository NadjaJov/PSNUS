   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.AddAlarm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  AddAlarm��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      .+�5   
   �� $��Alarm name (id) :��6   $
��Left=�6,   $��140,100,0,0q�6G   $	��Top=�6\   $��2��6t   �� 5   
   -   5        $��NameBoxAlarm��5      $
��Left=�6I   $��23��6d   $��250,100,0,0q�6p    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   ��6'   ��  �� Path$ IdNameAlarm�6�   �� 5   
   $��Limit value��6   $
��Left=�6&   $��140,150,0,0q�6A   $	��Top=�6V   $��2��6n   �� 5   
   -   5        $��limitvalueBoxAlarm��5      $
��Left=�6I   $��23��6d   $��250,150,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   ��6-   �� $ Limit�6�   �� 5   
   $&�� Alarm is activated when value is��6   $
��Left=�6;   $��
68,200,0,0q�6V   $	��Top=�6j   $��2��6�   �� 5   
   -   5        $��BorderAlarm��5      $��1q�6$   $
��Left=�68   $	��Top=�6S   $��248,198,0,0q�6k   $	��124��6�   $��26��6�   �� 5   
   -   5        $��overunderBoxAlarm��5      $
��Left=�6T   $��250,200,0,0q�6o   $	��Top=�6�   $	��120��6�   $��2��6�    �� SelectedItem 6,   �� $ 	OverUnder�6�   �� 5   
   $��	the limit��6   $
��Left=�6$   $��380,200,0,0q�6?   $	��Top=�6T   $��2��6l   �� 5   
   $��Alarm message��6   $
��Left=�6(   $��130,250,0,0q�6C   $	��Top=�6X   $��2��6p   �� 5   
   -   5        $��messageBoxAlarm��5      $
��Left=�6G   $��23��6b   $��250,250,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   ��6)   �� $ Message�6�   �� 5   
   -   5        $
��Save��5      $
��Left=�62   $��210,320,0,0q�6M   $	��Top=�6b   $	��100��6z   $��20��6�   $��2��6�   5      5      