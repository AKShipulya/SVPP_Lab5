   M S B A M L   `   `   `  ����?  ;Lab5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab5Lab5  5   	       Lab5.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab5     5   	     � Title$  Shape Paint��5   	   $	��450��6   $	��800��6*   .��5	      ]� ��. .+�5
   
   o� $	��Top=�6   $��25��6$   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ menuItemLoad��5      $
��Load��61    m� Command$
 Open��6?   m� 5      -   5        $ menuItemSave��5      $
��Save��61   $
 Save��6?   5      m� 5      -   5        $��Shape��5      6&   m� 5      -   5        $ menuItemHelp��5      $
��Help��6-   $
 Help��6;   m� 5      -   5        $ menuItemExit��5      $
��Exit��6-   $ Close��6;   5      �� 5   
   $��Bottom=�6   $��25��6,   .@�5      �� .��5      �� -   5         ��Name$ textBlockCursorPosition��5      5      5      c� 5   
   $��35��6   $	��Top=�6   .@�5      �� -   5         ��Name$ buttonItemOpen��5      $
��Open��6-   .��5      �� $��Resources/Open-icon.png��6   5      �� 5      -   5        $ buttonItemSave��5      $
��Save��6-   .��5      �� $��Resources/Save-icon.png��6   5      5      �� 5    
   -	   5         ��Name$ canvas��5       
�������6Q   5!      5"      