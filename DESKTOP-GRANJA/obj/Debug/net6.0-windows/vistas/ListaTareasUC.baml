   M S B A M L   `   `   `  ����I  EDESKTOP-GRANJA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DESKTOP_GRANJA.vistasDESKTOP_GRANJA.vistas  5      )    #DESKTOP_GRANJA.vistas.ListaTareasUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:DESKTOP_GRANJA.vistas     5      ] YSyncfusion.SfGrid.WPF, Version=25.2.4.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfTextInputLayout.WPF, Version=25.2.4.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89] YSyncfusion.Shared.WPF, Version=25.2.4.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c896
syncfusion!http://schemas.syncfusion.com/wpf    5        � 	Resources  5
         RoundedButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  &	        �� 5   
   " ��6&   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 7��5      ._�5      �� $��Center=�6/   $��Center=�5   +   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��2* �6   .+�5!   
   ]� $
��True��6   $��0��6)   .+�5"      �� $��50��6   $	��Top=�6%    �� Orientation$ 
Horizontal=�6:   .+�5#      �� $��20��6   $��	10,0,10,0q�6(   	Tamaño6D   �� 6P   $��60��6X   $��20��6c   ��6o   �� *
PageSize+6�   �� 5%      -   5        $��25��5%      $��60��6%   $��15,0,5,0q�60   .��6d   Atras6k   �� 5&      -   5        $��25��5&      $��60��6%   .��6Q   	Siguiente6\   5'      �� 5(      
������$��50��61   $��Bottom=�6=   $ 
Horizontal=�6U   .+�5)      �� $��25��6   .��6%   VER6*   5*      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  5+      -   5           ColumnSizer$
 Star=�5.      	   AllowFiltering$
	 True��5/      (  "Syncfusion.UI.Xaml.Grid.SfGridBase
   AutoGenerateColumns$
 False��50         ItemsSource 5,      ��  �� Path$ ListaTareas�   SelectedItem 5-      �� $ TareaActual�   Columns 53      ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   MappingName$ Id��60     54      $ Nombre��60     55      $ Importancia��60     56      $ Fechainicio��60     57      $ Departamento��60     58      $ Importancia��60   5:      5;      *   $DESKTOP_GRANJA.vistas.DetalleTareaUC  5<   
   $��1��6   5=      5>      