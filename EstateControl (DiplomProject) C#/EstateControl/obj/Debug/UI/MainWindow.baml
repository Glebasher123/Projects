   M S B A M L   `   `   `  ����H  DEstateControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EstateControlEstateControl  5   	       EstateControl.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EstateControl     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�66   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ table��5
   E   $
��Left=�6T   $	��550��6o   $��	10,10,0,0q�6|   $	��Top=�6�   $	��900��6�   �� 5   
   -   5        $��estate��5      $'��!Выбрать имущество��6   $
��Left=�6;   $��
914,10,0,0q�6V   $	��Top=�6j   $	��150��6�   6�   �� 5   
   -   5        $��client��5      $#��Выбрать клиента��6   $
��Left=�69   $��
915,35,0,0q�6T   $	��Top=�6h   $	��149��6�   6�   �� 5   
   -   5        $��docType��5      $
��Left=�6"   $��
915,60,0,0q�6=   $	��Top=�6Q   $	��149��6i   6u   �� 5   
   -   5        $
��type��5      $��Документ��6   $
��Left=�6/   $��1069,60,0,0q�6J   $	��Top=�6_   $	��113��6w   �� 5   
   -   5         ��Name$ print��5      $��Распечатать��6    $
��Left=�66   $��915,514,0,0q�6Q   $	��Top=�6f   $	��267��6~   6�   �� 5   
   -   5        $ 
registrate��5      $&�� Зарегестрировать��6%   $
��Left=�6@   $��915,489,0,0q�6[   $	��Top=�6p   $	��267��6�   6�   �� 5   
   -   5        $��search��5   q   $
��Left=�6   $��23��6�   $��
915,87,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��
Поиск��6�   $	��Top=�6�   $	��149��6�   �� 5   
   -	   5        $ delete��5      $��Удалить��6!   $
��Left=�63   $��915,539,0,0q�6N   $	��Top=�6c   $	��267��6{   6�   �� 5   
   -
   5        $��	statistic��5   &   $��Статистика��6   $
��Left=�67   $��915,464,0,0q�6R   $	��Top=�6g   $	��267��6   6�   5      5      