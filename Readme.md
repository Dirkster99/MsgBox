[![Build status](https://ci.appveyor.com/api/projects/status/0fsqyn7spal3ir2k?svg=true)](https://ci.appveyor.com/project/Dirkster99/msgbox)
[![Release](https://img.shields.io/github/release/Dirkster99/MsgBox.svg)](https://github.com/Dirkster99/MsgBox/releases/latest)
[![NuGet](https://img.shields.io/nuget/dt/Dirkster.MsgBox.svg)](http://nuget.org/packages/Dirkster.MsgBox)

![Net4](https://badgen.net/badge/Framework/.Net&nbsp;4/blue) ![NetCore3](https://badgen.net/badge/Framework/NetCore&nbsp;3/blue)

<h1><img src="https://github.com/Dirkster99/Docu/blob/master/MsgBox/ProjectIcon.png"/>Overview</h1>

This project shows implements a custom message box service that is driven by a
service locator interface. It inlcudes a notification component that can be used to implement
positioned pop-up messages in the vicinity of related controls. All implementation is in WPF
and follows MVVM without compromises.

See http://www.msgbox.codeplex.com for more details.

##Tip
Review App class in the Demo application to understand the service initialization:
https://github.com/Dirkster99/MsgBox/blob/master/source/MsgBoxDemo/App.xaml.cs

![Basic Terminilogy Screenshot](https://github.com/Dirkster99/Docu/blob/master/MsgBox/BasicTerminology.png?raw=true)

![Dark Sample Screenshot](https://github.com/Dirkster99/Docu/blob/master/MsgBox/DarkMessageBoxSample.png?raw=true)

## Theming

Load *Light* or *Dark* brush resources in you resource dictionary to take advantage of existing definitions.

```XAML
    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="/MsgBox;component/Themes/DarkBrushs.xaml" />
    </ResourceDictionary.MergedDictionaries>
```

```XAML
    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="/MsgBox;component/Themes/LightBrushs.xaml" />
    </ResourceDictionary.MergedDictionaries>
```

These definitions do not theme all controls used within this library. You should use a standard theming library, such as:
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro),
- [MLib](https://github.com/Dirkster99/MLib), or
- [MUI](https://github.com/firstfloorsoftware/mui)

to also theme standard elements, such as, button and textblock etc.

## Change History:

- 2017-07-28
  Removed UserNotification and replaced it with nuget Dependency:
  https://preview.nuget.org/packages/Dirkster.UserNotifications
  https://github.com/Dirkster99/UserNotifications

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
