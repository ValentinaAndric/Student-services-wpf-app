   M S B A M L   `   `   `  ����M  IStudentska služba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Studentska_služba.FormeStudentska_služba.Forme  5   	   &     Studentska_služba.Forme.frmExam   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Studentska_služba.Forme     5   	   -   5          �Name$  frmExam1��5   	    � Title$ Add/Edit exam��5   	   $	��450��6   $	��800��6,   ���	#FF9DBBF1.��5
      �  � ColumnDefinitions 5   
   �� 5      $
��110* �6   �� 5      $
��578* �6   �� 5      $
��105* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Student��6   $
��Left=�61   $��24��6L   $��1,39,0,0q�6X   $	��Top=�6j   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5        $ 
label_Copy��5      $��Subject��6$   $
��Left=�66   $��26��6Q   $��1,90,0,0q�6]   $	��Top=�6o   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5        $ label_Copy1��5      $��	Classroom��6%   $
��Left=�69   $��24��6T   $��	1,147,0,0q�6`   $	��Top=�6s   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5        $ label_Copy2��5      $
��Date��6%   $
��Left=�64   $��24��6O   $��	1,200,0,0q�6[   $	��Top=�6n   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5        $ label_Copy3��5      $
��Time��6%   $
��Left=�64   $��24��6O   $��	1,251,0,0q�6[   $	��Top=�6n   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5        $ label_Copy4��5      $��Employee��6%   $
��Left=�68   $��26��6S   $��	1,302,0,0q�6_   $	��Top=�6r   $	��190��6�   $��1��6�   $
��Bold"�6�   ���	#FF786FCF6�   �� 5   
   -   5         ��Name$ 
cbxStudent��5       �� DisplayMemberPath$ Student��6'    �� SelectedValuePath$ 	StudentID��6C   $
��Left=�6a   $��24��6|   $��
273,39,0,0q�6�   $	��Top=�6�   $	��230��6�   $��1��6�   �� 5   
   -	   5        $ 
cbxSubject��5      $ NameOfSubject��6'   $ 	SubjectID��6I   $
��Left=�6g   $��24��6�   $��
273,90,0,0q�6�   $	��Top=�6�   $	��230��6�   $��1��6�   �� 5   
   -
   5        $ cbxClassroom��5      $ NumberOfClassroom��6)   $ ClassroomID��6O   $
��Left=�6p   $��24��6�   $��273,147,0,0q�6�   $	��Top=�6�   $	��230��6�   $��1��6�   �� 5   
   -   5        $ cbxEmployee��5      $ Employee��6(   $ 
EmployeeID��6E   $
��Left=�6d   $��24��6   $��273,302,0,0q�6�   $	��Top=�6�   $	��230��6�   $��1��6�   6�   �� 5   
   -   5         ��Name$ txtTime��5      $
��Left=�6#   $��23��6>   $��275,252,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��228��6�   $��1��6�   �� 5   
   -   5        	 ��Name$	 btnSave��5      $
��Save��6"   $
��Left=�61   $��27��6L   $��	1,353,0,0q�6X   $	��Top=�6k   $	��150��6�   $��1��6�   $��5q�6�   ���	#FF786FCF6�   �� 5   
   -   5        $	 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��27��6P   $��353,353,0,0q�6\   $	��Top=�6q   $	��150��6�   $��1��6�   $��5q�6�   ���	#FF786FCF6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dpDate��5      $
��Left=�6%   $��24��6@   $��273,200,0,0q�6L   $	��Top=�6a   $	��230��6y   $��1��6�   5       5!      