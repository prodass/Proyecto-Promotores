   M S B A M L   `   `   `  ����J  FTrabajo Gestion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Trabajo_GestionTrabajo_Gestion  5   	       Trabajo_Gestion.Promotor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Trabajo_Gestion     5   	     � Title$  Alta de Promotor��5   	   $	��330��6"   $	��585��6/   $	��585��6;   $	��330��6J   $	��585��6Z   $	��330��6i    � WindowStartupLocation$ CenterScreen=�6y    � Icon$ /descarga.png��6�    � 
ResizeMode$ NoResize=�6�    � SizeToContent$ WidthAndHeight=�6�    � WindowStyle$ SingleBorderWindow=�6�   ���	#FFFFE2E2.��5	      � $��	-1,1,0,-1q�6   .+�5
   
   �� $
��Left=�6   $	��244��6/   $��
274,11,0,0q�6<   
���   �$	��Top=�6_   $	��272��6w   ���	#FFF3EAEA6�   �� 5   
   $
��Left=�6   $	��244��6/   
���   �$	��Top=�6K   $	��234��6c   $��	25,11,0,0q�6o   ���	#FFF3EAEA6�   �� 5   
   -   5         ��Name$ lbl_id��5      $��Promotor ID:
��6    $
��Left=�6<   $��	31,25,0,0q�6W   $	��Top=�6j   $��26��6�   $
��Bold"�6�   $��Normal$�6�   �� 5   
   -   5         ��Name$ tbox_idPromotor��5      $
��Left=�6+   $��
127,29,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ lbl_id_Copy��5      $��Nombre:
��6%   $
��Left=�6<   $��	31,56,0,0q�6W   $	��Top=�6j   $��26��6�   $
��Bold"�6�   $��Normal$�6�   �� 5   
   -   5        $ tbox_nombrePromotor��5      $
��Left=�6/   $��
127,60,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   $��Promotores:��6   $
��Left=�6&   $��
282,14,0,0q�6A   $	��Top=�6U   $��Normal"�6m   �� 5   
   $��	Detalles:��6   $
��Left=�6$   $��
410,14,0,0q�6?   $	��Top=�6S   $��Normal"�6k   �� 5   
   -   5        $��lbox_promotores��5      $��282,40,176,73q�6)   6@   �� 5   
   -   5        $��lbox_promotoresDetalles��5      $��409,40,34,73q�61   �� 5   
   -   5        	 ��Name$	 btn_agregarPromotor��5      $��Agregar��6.   $
��Left=�6@   $��
36,226,0,0q�6[   $	��Top=�6o   $��62��6�   ���	#FFDDDDDD$��22��6�   6�   �� 5   
   $
��Left=�6   $��1��6/   $��
36,219,0,0q�6:   
���   �$	��Top=�6]   $	��211��6u   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   �� 5   
   -   5        $	 btn_actualizarPromotor��5      $��
Actualizar��61   $
��Left=�6F   $��185,226,0,0q�6a   $	��Top=�6v   $��62��6�   ���	#FFDDDDDD$��22��6�   6�   �� 5   
   -	   5        $	 btn_siguientePromotor��5      $��	Siguiente��60   $
��Left=�6D   $��501,262,0,0q�6_   $	��Top=�6t   $��64��6�   6�   �� 5   
   -
   5        $	 btn_menuPromotor��5      $
��Menu��6+   $
��Left=�6:   $��432,262,0,0q�6U   $	��Top=�6j   $��64��6�    � UseLayoutRounding .  6�   �� 5   
   -   5        $	 btn_atrasPromotor��5      $��Volver��6,   $
��Left=�6=   $��363,262,0,0q�6X   $	��Top=�6m   $��64��6�    .  6�   �� 5   
   -   5        $	 btn_borrarPromotor��5      $��Borrar��6-   $
��Left=�6>   $��111,226,0,0q�6Y   $	��Top=�6n   $��62��6�   ���	#FFDDDDDD$��22��6�   6�   �� 5   
   -   5        $ lbl_descripcion��5      $��Descripcion:
��6)   $
��Left=�6E   $��	31,86,0,0q�6`   $	��Top=�6s   $��26��6�   $
��Bold"�6�   $��Normal$�6�   �� 5   
   -   5        $ tbox_descripcion��5      $
��Left=�6,   $��
127,90,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   -   5        $	 btn_consultasPromotor��5      $��Mas consultas��60   $
��Left=�6H   $��450,226,0,0q�6c   $	��Top=�6x   $��86��6�    .  6�   �� 5   
   $
��Left=�6   $	��177��6/   $��
401,40,0,0q�6<   
���   �$	��Top=�6_   $��1��6w   5!      5"      