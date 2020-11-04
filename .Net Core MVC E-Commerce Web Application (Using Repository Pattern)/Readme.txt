Project Title: ACME

Welcome to ACME. This new e-commerce website has been developed for ACME Inc, a traditional brick and mortar store that wished to offer their products online, in order to attract new customers, and make it more efficient for the end user to purchase products in an online environment.
This web application allows its customers to view and purchase items, and have them delivered to their door using courier services. From their account, they can edit personal details, and view previous orders.
The website also allows administrators to update product listings, categories, user roles, and much more. It provides a simple yet effective interface for administrators to manage available products, view sales performance, and provide the support that its users require.

Getting Started
The following steps are required to get the ACME web application running on the development environment:
•	Open the application source code in Visual Studio
•	Set the start-up project to “ACME”
•	Run the application on IIS Express

Prerequisites
There are a few prerequisites required to run the application, including:
•	Install the *latest Visual Studio
•	Install prerequisites to run IIS .Net Core 2.1 MVC web applications
*latest Visual Studio as of when the application was developed is: Visual Studio 2019

More detailed specifications are included below
-----------------------------------------------------------------------------
Microsoft Visual Studio Enterprise 2019
Version 16.5.3
VisualStudio.16.Release/16.5.3+30002.166
Microsoft .NET Framework
Version 4.8.03752
-----------------------------------------------------------------------------

Installing
•	Open the application source code in Visual Studio
•	Set the start-up project to “ACME”
•	Run the application on IIS Express

The development test system has been detailed on the following page.

Test System
Development PC
---------------------------------------------------------------------------------------------------------------------------------------------------
OS Name				Microsoft Windows 10 Pro
Version				10.0.18363 Build 18363
Other OS Description 		Not Available
OS Manufacturer			Microsoft Corporation
System Name			KARL
System Manufacturer		System manufacturer
System Model			System Product Name
System Type			x64-based PC
System SKU			SKU
Processor			Intel(R) Core(TM) i7-8700K CPU @ 3.70GHz, 3696 Mhz, 6 Core(s), 12 Logical Processor(s)
BIOS Version/Date		American Megatrends Inc. 2301, 2020/02/25
SMBIOS Version			3.0
Embedded Controller Version	255.255
BIOS Mode			Legacy
BaseBoard Manufacturer		ASUSTeK COMPUTER INC.
BaseBoard Product		ROG MAXIMUS X HERO
BaseBoard Version		Rev 1.xx
Platform Role			Desktop
Secure Boot State		Unsupported
PCR7 Configuration		Binding Not Possible
Windows Directory		C:\WINDOWS
System Directory		C:\WINDOWS\system32
Boot Device			\Device\HarddiskVolume5
Locale				South Africa
Hardware Abstraction Layer	Version = "10.0.18362.752"
User Name			KARL\Karl
Time Zone			South Africa Standard Time
Installed Physical Memory (RAM)	48,0 GB
Total Physical Memory		47,9 GB
Available Physical Memory	32,7 GB
Total Virtual Memory		54,9 GB
Available Virtual Memory	35,4 GB
Page File Space			7,00 GB
Page File			C:\pagefile.sys
Kernel DMA Protection		Off
Virtualization-based security	Not enabled

Hyper-V - VM Monitor Mode Extensions			Yes
Hyper-V - Second Level Address Translation Extensions	Yes
Hyper-V - Virtualization Enabled in Firmware		Yes
Hyper-V - Data Execution Protection			Yes
---------------------------------------------------------------------------------------------------------------------------------------------------

Built With
Visual Studio – The IDE used to develop the web application
.NET Core 2.1 – Web Framework:  Used .NET Core 2.1 for backwards compatibility with Visual Studio 2017, and it also works with 2019. .NET Core 3.1 only works with Visual Studio 2019.
Model View Controller – Software design pattern used to develop the web application
Entity Framework – Object-relational mapping framework used for ADO.NET (database)

Versioning
-------------------------------------------
Version		23
-------------------------------------------

Authors
Karl Dicks – 17667327

Acknowledgments
Inspiration: 	Programming 3A POE Question Paper; Takealot; Woolworths

Deployment
Documentation will be included in the final POE, as marks have been allocated to this section for the POE, and not Task 2.

Demo
Video link: https://youtu.be/1uU-heZBGvg

***
Notes:
1.	Registering users requires an internet connection (Email Verification Enabled). The registration process uses an email account hosted by Afrihost, and is blocked by default at VC. Use mobile data or home internet to test.
2.	Admin account is "admin@admin.com", password is "P@ssword123!" This user account can create new products, or edit / delete existing products. Admin accounts are able to assign administrative access to other users who have signed up on the registration page.
3.	Two Factor Authentication is enabled, but not by default. The user can use Google Authenticator. This setting can be set up in the Profile -> Two-factor authentication page.
***