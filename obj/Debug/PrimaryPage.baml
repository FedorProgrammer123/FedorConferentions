   M S B A M L   `   `   `  ����S  OOrganisationConferention, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:OrganisationConferentionOrganisationConferention  5      *    $OrganisationConferention.PrimaryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:OrganisationConferention     5        N� Title$  PrimaryPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��50 �6   6*   .+�5   
   �  � Orientation$ 
Horizontal=�6   $��Center=�6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $:��4Введите название для поиска:��6   $	��175��6@    �� TextAlignment$ Right=�6L   6d   �� 5      -   5        $��
TBoxSearch��5   &   $	��225��6   6_   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Выберите тип:��6   $	��175��61   $ Right=�6=   6U   �� 5      -   5        $��	ComboType��5   '   $	��225��6    �� DisplayMemberPath$ Event��68   6�   5      5      �� 5   
   -   5        $��LViewEvents��5       $��1��6   $��Disabled=�63   $��Center=�6i   ��5      �� 5      .R�5      � $ 
Horizontal=�6    $��Center=�69   6X   5      ��5!      �� 5"      .R�5#      � $��20q�6   $	��400��6'    5$      �� 5%      $��70 �6,   6:   �� 5&      $	��310 �6,   6;   �� 5'      $
��auto �6,   6<   �� 5(      $
��auto �6,   6<   .+�5*      �� $��1��6!   $��Uniform=�6.   $��Center=�6@   $��5q�6]   ��5+      �� 5,   "    �� Path$ 
ImagePhoto�6*    �� TargetNullValue 5-   &   �� 5.   *    �� 	UriSource$ /Resources/Logo.png?�66   6X   50   #   52      �� 53      $��1��6%   $��Center=�54      $
��Left=�55      .+�56      �� $
��Wrap=�57   ;   $
��Bold"�58      ��56   (   �� *Event+	 �� StringFormat$	 Событие: {0}��58   1   �� 59      $
��Wrap=�5;      ��59   (   �� *Date+$	 Дата: {0:dd/MM/yyyy}��5;   3   5<      5=      5>      5@      �� 5A   
   $��2��6   .+�5B      �� -   5        $��1��5B      $��Авторизация��6"   $	��100��68   $
��Left=�6D   $��Comic Sans MS)�6_   6�   5C      5D      5E      