   M S B A M L   `   `   `  ����F  BDeanOffice1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DeanOffice1DeanOffice1  5   	       DeanOffice1.StudentEditor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DeanOffice1     5   	     � Title$  StudentEditor��5   	   $	��450��6   $	��400��6,   $	��300��68   $	��450��5	   	   $��16(�5
   	   .��5      �� $��Center=�6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%  '��       '�� O     '�� �     �� 5      " ��6   .�5      ��  � ��$ 	10,0,10,0q�63   5      �� 5      " ��6   .�5      ��  � ��$ 	10,0,10,0q�63   5      �� 5      " ��6   .�5      ��  � ��$ 	10,0,10,0q�63   5      5      .+�5   
   �� $��Фамилия, имя:��6   �� 5   
   -   5         ��Name$ StudentName��5      �� 5   
   $ ��Дата рождения:��6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ StudentBirth��5      $��	10,0,10,0q�6+   �� 5"   
   $��Телефон:��6   �� 5#   
   -   5        $ StudentPhone��5#      �� 5&   
   $��Email:��6   �� 5'   
   -   5        $ StudentEmail��5'      �� 5*   
   $��Факультет:��6   �� 5+   
   -   5         ��Name$ FacultiesList��5+       �� DisplayMemberPath$
 Name��6*   	 �� SelectedIndex$	 0��6C   5,      �� 5/   
   $��Группа:��6   �� 50   
   -   5        $ 
GroupsList��50      $
 Name��6'   $	 0��6@   �� 59   
   -   5        
 ��Name$
 
SaveButton��59      $��40��6%   $��10,20,10,10q�61   .��6_   Сохранить6j   5;      5<      