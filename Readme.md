# Overview

This project shows the implementation of a custom message box service that is driven by a
service locator interface. It inlcudes a notification component that can be used to implement
positioned pop-up messages in the vicinity of related controls. All implementation is in WPF
and follows MVVM without compromises.

See http://www.msgbox.codeplex.com for more details.

## Change History:

- 2015-07-29
  There are breaking changes in the way a Window Chrome is themed in WPF between .Net Version 4.0
  and .Net Version 4.5. Namely:
  - The System.Windows.Shell.DLL is integrated into the PresentationFramework assembly
    (see code changes in this branch for more details).

- Extracted service locator into separate ServiceLocator project and re-designed interface
  (small breaking change that should be easy to repair see difference in demo programs)

- Extended Notification project with new controls (see class files and Wiki documentation for details):
  UserNotification.View.SimpleNotificationWindow
  UserNotification.View.NotifyableContentControl

- Bugfix Italian typo Non should be No
  http://www.codeproject.com/Tips/682283/WPF-MessageBox-Service?msg=4707211#xx4707211xx

- Small bugfix in Dialog - View focus handling

- Correction in 2 Hindi translation strings

## Fixed Issues:

- MsgBoxDemo Project
  Copy statement does not always work if quotes around path are missing

- MsgBox
  Cannot set Owner property to itself
  Added code to ensure that owner of MsgBox dialog can never be the window itself
  (which causes an exception to be thrown and the message box not to be displayed)

- Notification
  Added SimpleNotification view to support scenarios with tool tip like view

# Credits

Implementations in this project are based on these resources:

## MsgBox Project
Source:
http://blogsprajeesh.blogspot.de/2009/12/wpf-messagebox-custom-control.html

Service Locator:
http://www.codeproject.com/Articles/70223/Using-a-Service-Locator-to-Work-with-MessageBoxes

## Notification Project

The project contains a user notification component:
https://github.com/Dirkster99/UserNotifications

that pops-up user messages similar to extended tool-tips.

This component is based on a Growl Notifications project at Code Project:
http://www.codeproject.com/Articles/499241/Growl-Alike-WPF-Notifications
