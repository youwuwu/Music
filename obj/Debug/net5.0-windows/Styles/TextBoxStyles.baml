   M S B A M L   `   `   `  ����W  SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fR NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   SearchingTextBoxStyle �� Property & "MahApps.Brushes.Control.Background �� Value " MahApps.Brushes.TextBox.Border # MahApps.Brushes.ThemeForeground  MahApps.TextBox.ContextMenu   MahApps.Fonts.Family.Control  MahApps.Font.Size.Content  MahApps.Brushes.Text  MahApps.Brushes.Highlight �� 
TargetType ��Name ��Name+   %MahApps.Metro.Controls.ControlsHelper    CornerRadius �� CornerRadius +	 'MahApps.DropShadowEffect.WaitingForData J� Effect	 J� SnapsToDevicePixels
 �Name � ColumnDefinitions ��Name � RowDefinitions ��Name ��Name ��Name �� Orientation �� Stretch ��Name &
 "MahApps.Styles.TextBlock.Watermark*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark   WatermarkAlignment �� TextAlignment   WatermarkTrimming   WatermarkWrapping $  MahApps.Brushes.Control.Disabled J� IsHitTestVisible J� Opacity �� RelativeSource �� Path �� Mode �� Triggers �� Value  �� Binding! �� 
TargetName" ^� 
Conditions# �� Binding$ �� Value% N� EnterActions * &MahApps.Storyboard.ShowFloatingMessage& N� ExitActions * &MahApps.Storyboard.HideFloatingMessage' P� Property( P� Value) ]� 
Conditions* �� Property $  MahApps.Storyboard.EnterGotFocus # MahApps.Storyboard.ExitGotFocus # MahApps.Storyboard.EnterHasText " MahApps.Storyboard.ExitHasText % !MahApps.Storyboard.WaitingForData % !MahApps.Templates.ValidationError ( $MahApps.Brushes.TextBox.Border.Focus , (MahApps.Brushes.TextBox.Border.MouseOver & "MahApps.Font.Size.Button.ClearText�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      6mah,http://metro.mahapps.com/winfx/xaml/controls  5      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        7  7  7  7  7  7  7  �� 5      "  ��6   .�5   
   ��  � ��# �  6'   �� 5	   
    � ��# �  6(   �� 5
   
    � ��$ 1q�6,   �� 5   
    �@��
CaretBrush# �  6'   �� 5   
    �@�ContextMenu# �  6(   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    � ��$ 26��6&   �� 5   
    � ��$ 	20,4,20,4q�6$   �� 5   
    �@��SelectionBrush# �  6+   �� 5   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � .+�5      �� $/ )PART_WaitingForDataEffectAdornerDecorator��6B   $y�	Collapsed=�6+   .u�5      �� $# PART_WaitingForDataEffectGrid��5    !   #��z��5   !   
������ #��z��5   !   # z 5   !   # � 	 5   !   #	 z	 5   !   5    !   5!      �� 5#      $
 Base��5)      #��z��5$      #��z��5%      #��z��5&      # z 5'      #	 z	 5(      5)      � 5+      $
 PART_InnerGrid��6J   #��z��6    5,      �� 5-   "   $ 
TextColumn��6=   $��* �63   6=   �� 5.   "   $ ButtonColumn��6@   $
��Auto �63   6@    50      �� 51   "   $
��Auto �60   �� 52   "   $ 	ButtonRow��6;   $��* �60   6;   .+�55      �� $ PART_ContentHost��5?   !   $��0q�57   !   $��0��58   !   $��1��59   !   $��False��5:   !   $��0q�5;   !   #��z��5<   !   #	 z	 5=   !   $��Stretch=�5>   !   ��56   !   Z� 5?   !   �� 5B      $ PART_Message��5H   !   $��0��5C   !   $��1��5D   !   $��	20,0,20,0q�5E   !   $ 
Horizontal=�5F   !   $y�	Collapsed=�5G   !   .+�5J   "   F� �����p�r ������! `Z� ��o ��o �    �fn� ��o ��o �0= ���� h�o h�o �h�� xB�� ��o ��o �rh��|'@�]�� �* �* ��G�z0@�s �p��0�� �* �* �`�� ���� z� xU�� �* �* ���n�@-@xjn� ��o ��o ���v��@���� h�o h�o ph�o i��|?u/��`�� �fn���g^ �g^ ׀�o p�����g^ �g^ ׈* �fn���g^ �g^ ׀�o �����g^ �g^ 	#��z��5L   %   $��12��5M   %   #��z��5N   %   $��0,0,0,0q�5O   %   $ Uniform=�5P   %   #��z��5Q   %   $��12��5R   %   �� 5T   "   $ PART_MessageTextBlock��5_   %   $��13(�5U   %   #��z��5V   %   #��z��5W   %   $	��4,0q�5X   %   #��� 
 5Y   %   #��z 5Z   %   # z 5[   %   #��z 5\   %   #��z 5]   %   #��z��5^   %   5_   %   5`      5a      �� 5c      $ DisabledVisualElement��5l      #���  5d      #���  5e      #��z��5f      # z 5g      $ False��5h      $ 0Q�5i      #	 z	 5j      y�5k      ��  �� *TemplatedParent+$: 4(mah:ControlsHelper.DisabledVisualElementVisibility)�$ OneWay=�5l      5m       5n      �� 5o      $
 Left��6�     6&   ��  �� *Self+$* $(mah:TextBoxHelper.ButtonsAlignment)�.a�5p      �� $! ButtonColumn��66    � ��$ * �6P   �� 5q      $! PART_ContentHost��6<    � ��$ 1��6Z   �� 5s      $! PART_Message��6<    � ��$ 1��6V   �� 5t      $! 
TextColumn��66    � ��$
 Auto �6N   5u      �� 5w      $  ��6j     6&   ��  �� *Self+$
 Text�.a�5x      �� $! PART_Message��6;    � y�$ Visible=�6U   5y      ^� 5{      " 5|      �� 5}   "   # 6,   �� $ 	IsVisible� �� *Self+$ True6u   �� 5~   "   # 6,   �� $. ((mah:TextBoxHelper.UseFloatingWatermark)� �� *Self+$ True6�   �� 5   "   # 6,   �� $! (mah:TextBoxHelper.HasText)� �� *Self+$ True6�   % 5�      �� 5�   "   8��  62   & 5�      �� 5�   "   8�� 62   5�      ^� 5�      " 5�      �� 5�   "   # 6,   ��  �� *Self+$* $(mah:TextBoxHelper.ButtonsAlignment)�	$ Right6�   �� 5�   "   # 6,   ��  �� *Self+$) #(mah:TextBoxHelper.ClearTextButton)�	$ False6�   .0�5�      �� $! PART_ContentHost��6@    � ��$ 2��6^   �� 5�      $! PART_Message��6@    � ��$ 2��6Z   5�      P� 5�      ' �@J�IsMouseOver$
( True��69   . �5�      �� $
! Base��6<    6N   ��  �� *TemplatedParent+$/ )(mah:ControlsHelper.MouseOverBorderBrush)� � ��5�      P� 5�      ' � {�$( False��67   . �5�      �� $! DisabledVisualElement��68    �@J�Opacity$	 0.6Q�6[   5�      P� 5�      ' �@J�	IsFocused$
( True��67   . �5�      �� $
! Base��6<    6N   ��  �� *TemplatedParent+$+ %(mah:ControlsHelper.FocusBorderBrush)� � ��5�      ]� 5�      ) 5�      �� 5�   "   * �@ HasText$$ False��6Q   �� 5�   "   * �@J�	IsFocused$
$ True��6A   % 5�      �� 5�   "   8�� 62   & 5�      �� 5�   "   8�� 62   5�      P� 5�      ' �@ HasText$
( True��6G   % 5�      �� 5�   "   8�� 62   & 5�      �� 5�   "   8�� 62   5�      ]� 5�      ) 5�      �� 5�   "   * �@J�	IsVisible$
$ True��6A   �� 5�   "   * �@ IsWaitingForData$
$ True��6Z   ./�5�      �� $/! )PART_WaitingForDataEffectAdornerDecorator��6;    � y�$ Visible=�6r   % 5�      �� 5�   "   8�� 62   5�      P� 5�      ' �@ IsWaitingForData$( False��6P   . �5�      �� $/! )PART_WaitingForDataEffectAdornerDecorator��6;    � y�$ 	Collapsed=�6r   5�      5�      5�      �� 5�   
    �@=�ErrorTemplate# �  65   �� 5�   
    �@  FocusBorderBrush# �  6@   �� 5�   
    �@  MouseOverBorderBrush# �  6D   �� 5�   
    �@ ButtonFontSize# �  6=   �� 5�   
    �@ ButtonWidth$ 22Q�6:   �� 5�   
    �@ IsMonitoring$
 True��6;   �� 5�   
   & �@ IsSpellCheckContextMenuEnabled 6M   ��  �� *Self+$ (SpellCheck.IsEnabled)��� 5�   
    �@ WatermarkWrapping 6@   ��  �� *Self+$ TextWrapping�$ OneWay=�5�      5�      