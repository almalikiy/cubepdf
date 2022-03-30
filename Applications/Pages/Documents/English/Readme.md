CubePDF Page Documents
====

Copyright © 2013 CubeSoft, Inc.  
GNU Affero General Public License version 3 (AGPLv3)  
support@cube-soft.jp  
https://www.cube-soft.jp/cubepdfpage/

## Overview

![CubePDF Page overview](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/overview.en.png)

CubPDF Page is a software for merging or splitting existing PDF and image files. You can also add various PDF metadata and encryption settings to the merged or split PDF file. To use CubPDF Page, first add PDF or image files you wish to merge or split to the file list on the main window. There are two ways to add PDF files:

1. Click the **Open** button and choose from the popup dialog.
2. Drag&Drop PDF and/or image files to be merged or split to the file list on the main window.

If the selected PDF file is protected by a password, a dialog box will appear asking you to enter the administrative password. Please enter the correct password.

![Password dialog](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/password.png)

Adding source files and completing the necessary operations, click either of the following buttons at the end to complete the process.

* **Merge**  
  Merge multiple PDF files into a single PDF file. In addition to PDF files, image files in PNG, JPEG, BMP, and TIFF formats can also be merged into a single PDF file.
* **Split**  
  Split a multi-page PDF file into single-page PDF files.

### About PDF password

There are two types of passwords for PDF files: **User password**, which allows only viewing and pre-authorized operations, and **Owner password**, which allows all operations.

CubePDF Utility always requires **Owner password** when opening PDF files due to the feature of editing PDF files. For this reason, you cannot open a PDF file with the **User password**.
Note that even if a PDF file can be opened without any password, **Owner password** may be set. If you want to edit the PDF file, please ask the creator of the PDF file for the **Owner password**.

### Edit a PDF file page by page

Although CubePDF Page does not provide a way to reorder pages, extract or delete specific pages, this can be achieved indirectly by using the merge and split functions together. If you want to edit existing PDF files in detail, please consider using [CubePDF Utility](https://www.cube-soft.jp/cubepdfutility/).

## List of editing operations

### Main window

![CubePDF Page main window](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/main.png)

The buttons and other features displayed on the CubePDF Page main window are as follows:

* **File list**  
  On the left side of the main window, a list of files to be merged or split is displayed. PDF files or image files (BMP, PNG, JPEG, GIF, TIFF) can be registered in this file list. Double-clicking on a registered file will open it in its associated application for preview.
* **Add**  
  Display a dialog for adding new PDF or image files to the file list.
* **Up**, **Down**  
  Move the order of the currently selected item in the file list up or down by one. Note that CubePDF Page merges PDF or image files in the order they appear in the file list.
* **Remove**  
  Remove the selected items in the file list from the merge or split target.
* **Clear**  
  Remove all items in the file list from the merge or split target.
* **Metadata**  
  Configure various PDF metadata and encryption settings for the merged or split PDF file.
* **Merge**  
  Merge files registered in the file list as a single PDF file.
* **Split**  
  Split all files in the file list into single-page PDF files.
* **Exit**  
  Exit CubePDF Page.

### Metadata

![Metadata dialog](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/metadata.png)

In the **Metadata** dialog, you can register information such as the title and creator. The information registered here can be viewed in the properties dialog of PDF viewer such as Adobe Acrobat Reader DC. In addition, the **Layout** item allows you to change the way the document will be displayed when opened in PDF viewer.

### Encryption (Security)

![Encryption dialog](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/encryption.png)

The **Metadata** dialog displays the **Encryption** tab in addition to the **Summary (Metadata)** tab. In the **Encryption** tab, you can protect the PDF file with a password. To set a password, first enable the **Encrypt the PDF with password** option, and then enter the same password twice in the **Password** and **Confirm** fields.

In the **Operations** item, specify the operations to be allowed or restricted to users. The following items can be set.

* Open with password
* Allow printing
* Allow copying text and images
* Allow inserting and removing pages
* Allow using contents for accessibility
* Allow filling in form fields
* Allow creating and editing annotations

Note that if you enable the item **Open with password** and also enable the item **Use owner password**, CubePDF Utility will set the same password as the owner password for user password.

However, **if you share both passwords, the restrictions on printing and copying operations may not work properly depending on the PDF viwer**. This is probably because the PDF viewer recognizes that the PDF file was opened with the owner password. For this reason, CubePDF Page is designed not to accept permission settings when it is shared with the owner password.

Moreover, if a PDF file is recognized as having been opened with the owner password, all PDF editing, including removal of the user password, will be possible. Please make sure you fully understand these behaviors when you share the user password with the owner password.

## Other settings and version information

![Settings dialog](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/settings.png)

Click **CubePDF Page** in the header section of the main window to show the CubePDF Page version information and related settings dialog.

### Application settings

The **Settings** tab allows you to change several settings related to the behavior of CubePDF Page.

If the **Shrink duplicated resources** item is enabled, CubePDF Page will attempt to reduce file size by removing duplicated portions of font information and other resources as much as possible when merging multiple PDF files. Currently, there are reports that some annotations look different when this feature is enabled than they did before being combined. If you encounter such a phenomenon, please consider disabling this item.

If the **Keep bookmarks of source PDF files** item is enabled, the resulting merged PDF file will include the bookmark information of each of the merging sources. Currently, there are several reports of PDF file merging failures in CubePDF Utility and CubePDF Page, most of which seem to be caused by the bookmark information. If you encounter such a phenomenon, please consider disabling this item.

The **Temp** section is the folder where temporary files are created when CubePDF Page performs the merging or splitting process. If the device is located on a different terminal, processing speed may be significantly reduced. In such a case, you can avoid this problem by selecting a working folder in advance. If you do not have any problem with the default settings, leave this field blank.

The **Language** section allows you to set the display language of the CubePDF Page main window. There are two supported languages: **English** and **Japanese**. When **Auto** is selected as the display language, one of the languages will be automatically selected according to the Windows language setting.

If you enable the **Check for updates on startup** item, you will be notified in the lower right corner of your computer when the new CubePDF Page version has been released. Checking for updates will be performed when your computer starts up. The information sent to confirm the update is the version number of CubePDF Page, Windows, and .NET.

### Version

![Version information](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/version.png)

The **Version** tab displays version information for CubePDF Page.

## List of keyboard shortcuts

The keyboard shortcuts available in CubePDF Page are as follows.

* Ctrl + M ... Merge PDF files
* Ctrl + S ... Split PDF files
* Ctrl + E ... Display PDF metadata and encryption settings window
* Ctrl + H ... Display CubePDF Page settings window
* Ctrl + Q ... Exit the application
* Ctrl + O ... Display dialog to add PDF, PNG, JPEG, BMP files
* Ctrl + A ... Select all items in the file list
* Ctrl + R ... Open the selected file in the associated application
* Ctrl + K or Ctrl + Up ... Move selected files down up level
* Ctrl + J or Ctrl + Down ... Move selected files down one level
* Ctrl + D or Delete ... Delete selected files from the list
* Ctrl + Shift + D ... Delete all files from the list

## How to uninstall CubePDF Page

To uninstall CubePDF Page, first select **Uninstall a program** in **Control Panel** or **Apps** in **Settings** (Windows 8 or later). Then select the CubePDF Page icon on the window that appears and run the **Uninstall** item.

![Uninstall for Windows 8 and later](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/uninstall-01.png)
![Uninstall in the control pannel](https://raw.githubusercontent.com/cube-soft/Cube.Assets/master/cubepdfpage/doc/v2/en/uninstall-02.png)

## Having problems with CubePDF Utility?

CubePDF Page outputs logs in the ```C:\Users\%UserName%\AppData\Local\CubeSoft\CubePdfPage\Log``` folder. If you encounter any problems, please contact us at support@cube-soft.jp with these logs attached (Replace %UserName% with the name of the user currently logged on).