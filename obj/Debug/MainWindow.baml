   M S B A M L   `   `   `  ����M  IStudentska služba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Studentska_službaStudentska_služba  5   	   #    Studentska_služba.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Studentska_služba     5   	     � Title$  Exam registration��5   	   $	��450��6#   $	��800��60   ��5	      �� 5
   
    �� ImageSource$ Image/Slika.jpg��6   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentral��5      $��Center=�6,   $
��auto��6I   $��Center=�6X   $
��auto��6s      AlternatingRowBackground
 ��ح�   
IsReadOnly .    CanUserAddRows .     SelectionUnit$ FullRow=�6�      SelectionMode$ Single=�6�   ���	#FF9DBBF16�   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6>   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   .+�5      �� -   5        	 ��Name$	 btnStudyPrograms��5      $��Study programs��6/   $
��Left=�6H   $��30��6c   $	��Top=�6p   $��75��6�   ���	#FF9DBBF16�   �� 5      -   5        $	 btnStudents��5      $��Students��6*   $
��Left=�6=   $��75��6X   $��30��6c   $	��Top=�6o   ���	#FF9DBBF16�   �� 5      -   5        $	 btnEmployees��5      $��	Employees��6+   $
��Left=�6?   $��75��6Z   ���	#FF9DBBF16�   �� 5      -   5        $	 btnPaymentSlips��5      $��Payment slips��6.   $
��Left=�6F   $��75��6a   ���	#FF9DBBF16�   �� 5      -   5        $	 btnExams��5      $��Exams��6'   $
��Left=�67   $��75��6R   ���	#FF9DBBF16t   �� 5      -   5        $	 btnSubjects��5      $��Subjects��6*   $
��Left=�6=   $��30��6X   $	��Top=�6e   $��75��6}   ���	#FF9DBBF16�   �� 5      -   5        $	 btnClassrooms��5      $��
Classrooms��6,   $
��Left=�6A   $��30��6\   $	��Top=�6i   $��75��6�   ���	#FF9DBBF16�   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   $��188,0,244,0q�6   .+�5      �� -	   5        $	 btnAdd��5      $	��Add��6%   $	��120��63   
����d�6T   �� 5      -
   5        $	 btnEdit��5      $
��Edit��6&   $	��120��65   
����d�6W   �� 5      -   5        $	 	btnDelete��5      $��Delete��6(   $��30��69   $	��Top=�6F   $	��120��6^   
����d�6�   5      5      5       