   M S B A M L   `   `   `  ����I  EDESKTOP-GRANJA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DESKTOP_GRANJA.vistasDESKTOP_GRANJA.vistas  5      ] YSyncfusion.SfGrid.WPF, Version=25.2.4.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`Dclr-namespace:Syncfusion.UI.Xaml.Grid;assembly=Syncfusion.SfGrid.WPFSyncfusion.UI.Xaml.Grid 5      ,    &DESKTOP_GRANJA.vistas.ListaEmpleadosUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:DESKTOP_GRANJA.vistas     5      [
syncfusionDclr-namespace:Syncfusion.UI.Xaml.Grid;assembly=Syncfusion.SfGrid.WPF     5        � 	Resources  5
       �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Path �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'    5      �� 5       6   �� $ EmpleadoSelect� 6F   Z� .a�5      ��  � {�$ False��62   5      5      5      .��5      ]� .+�5   
   �� 
������$��50��6-   $��Bottom=�69    �� Orientation$ 
Horizontal=�6Q   .+�5      �� $��25��6   ��6!   �� $ Command�.��6B   VER6G   5      �� 5   
   $��Right=�6   $��2,0,0,0q�6)   $	��302��6a   ��6:   �� *TareasEmpleado+��5      �� 5      .R�5      �� $ Vertical=�6!   	 �� CanHorizontallyScroll$	 False��68   5      ��5!      �� 5"      .R�5#      ]� $
��True��6    .+�5$      �� $��20��6$   $	��266��60   $	��Top=�6<   $��5,10,0,0q�6Q   $
��Bold"�6{   $��CharacterEllipsis=�6�   ��6c   �� *Nombre+6�   �� 5%      $	��Top=�6%   $ 
Horizontal=�6;   $��5,5,0,0q�6T   .+�5&      (  "System.Windows.Controls.DatePicker  $	��155��6)   ${�False��6Z   
   SelectedDate
 65   �� *Fechainicio+6Z   5'      �� 5(      $��Bottom=�6%   $ 
Horizontal=�6=   $��0,5,0,5q�6V   .+�5)      �� -   5        $��80��5)   >   $��	10,3,10,3q�6I   .��6]   
Ver mas...6i   5*      �� 5+      $��Bottom=�6%   $ 
Horizontal=�6=   $��
5,10,10,10q�6V   .+�5,      �� $��70��6)   $	��250��65   $��5,5,0,0q�6A   $
��Wrap=�6R   $��Italic$�6�   $��CharacterEllipsis=�6�   ��6f   �� *Descripcion+6�   5.      5/      50      53      ]� 54   
   $��Right=�6   .+�55      �� $��50��6   $	��Top=�6%   $ 
Horizontal=�6:   .+�56      �� $��20��6   $��	10,0,10,0q�6(   	Tamaño6D   �� 57      $��60��6   $��20��6%   ��61   �� *
PageSize+6M   �� 59      -   5        $��25��59      $��60��6%   $��15,0,5,0q�60   $
{�True��6d   .��6u   Atras6|   �� 5:      -   5        $��25��5:      $��60��6%   $
{�True��6P   .��6a   	Siguiente6l   5;      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  5<      -   5           ColumnSizer$
 Star=�5?         AllowFiltering$
 True��5@      (  "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False��5A         ItemsSource 5=      �� $ ListaEmpleados�   SelectedItem 5>      �� $ EmpleadoActual�   Columns 5D      ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   MappingName$ Nombre��60     5E      $ 	Apellidos��60     5F      $ Email��60     5G      $ Telefono��60     5H      $	 Rol��60     5I      $ CentroTrabajo��60   0  *Syncfusion.UI.Xaml.Grid.GridComboBoxColumn  5J      $	 Rol��64   5L      5M      5N      5O      