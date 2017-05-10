# Create a “Dev Workstation” on “CorpNet”…

The first job is to create a *clean, virgin* Dev Workstation. Once this lab is complete, you don’t even need Visual Studio installed on your local workstation.

1.	Go to the Azure portal – http://portal.azure.com and log in using your Azure subscription credentials.
2.	Click More Services|Virtual machines then click Add.
3.	In the search filter type “Visual Studio 2015” and hit return.
4.	Select a machine that has Visual Studio Community 2015 Update 3 with Azure SDK 2.9 on Windows Server 2012 R2 then in the rightmost blade Ensure Resource Manager is selected in the text box near the bottom of the screen, then click Create. 
5.	Set the name to vmCorpDevWS. Type a username and password for your machine. Ensure your subscription is selected. Enter a Resource group name of “rgCorpNet” and in location select “West Europe”. Click OK.
6.	On the Choose a size blade, click View all.
7.	Select DS3 Standard.
8.	On the Settings blade set the Virtual network name to vnetCorpNet but leave everything at its default value and click OK.
9.	At the Summary page click OK
10.	It will now take about 7 minutes for your VM to provision. Go to More Services|Virtual machines
Handy Tip: If you ever see the Azure services icon column reduced and missing the descriptive names – you can restore the names using the “burger button” near the top-left of the screen:
 
11.	Click the Refresh icon every so often to check whether your machine has started provisioning yet. When it has, click the machine. The blue status bar probably says “Creating” or “Updating”. Near the top right corner of the screen is a bell icon. This shows the current status.
12.	When it shows “Deployment succeeded” …
13.	On the Virtual machine blade click Connect near the top of the page.
14.	Click Open in the IE Save dialog (if you are using a different browser, make the necessary adjustment to the instructions).
15.	Select Use Another Account and then enter your credentials (In the username box enter .\<your-account-name>) and click OK.
16.	At the certificate dialogue, click Yes
17.	Ensure you are connected to the VM and logged in.
18.	Use Server Manager to switch off IE enhanced Security for Administrators and Users.
19.	If there is no Visual Studio icon on the desktop – create one from C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe. 
20.	Open Visual Studio. At the sign-in box, click Sign In. At this point, you need a Microsoft Account. Use the one you used to create your free trial subscription.
21.	Fill in the Visual Studio registration information (no need to create a Visual Studio Online account) and click Continue.
22.	Click the gear wheel in Cloud Explorer (left hand side of the screen). If your Azure account is already shown ignore this. If not – click the down-arrow and click Add an account.
23.	Sign in using your Azure account. When your subscription shows, click Apply. You should have something that looks rather like a simplified mini-portal.
24.	Now you have a totally clean, virgin machine you can use for future lab work.
