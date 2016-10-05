# Publishing and Scaling the Website

This scenario demonstrates how you can easily publish the project we've built in scenario 1 into _Azure_. We will use the built in facilities of Visual Studio to do that. Additionally, we will demonstrate how you can easily scale an Azure Web App to multiple nodes and take advantage of the hyper-scale cloud platform. 

## Publishing the _StoreSample_ Web App

The steps here assume that you are logged into an account that has an Azure subscription.

1. Right-click the StoreSample.Web project and select the `Publish...` option.

   <img src="assets/vs_publish.png" width="500px"/>

2. In the dialog, select the `App Service` option, as that's where we will be publishing the web. For more information on this, you can consult with the [website](https://azure.microsoft.com/en-us/services/app-service/web/).

   <img alt="The publishing dialog" src="assets/vs_publish_dialog_01.png" width="600px"/>

3. If you already are signed into your Microsoft account that has an active subscription, you will see a list of subscriptions, if not, you should sign in. You can do this in the upper-right corner, by clicking `Add Account`. This will bring up a dialog where you are able to enter your credentials. As you do that, the lists should populate. 

   <img alt="The subscription & Resource Group selection process" src="assets/vs_publish_dialog_02.png" width="600px"/>

4. Next, press the `New...` button in the middle right of the dialog to start creating the new App Service instance that will host our _StoreSample_. 

   <img alt="The new App Service dialog" src="assets/vs_publish_dialog_03.png" width="600px"/>

5. In the resulting dialog, we need to fill out the relevant details:
    * Name: to avoid naming conflicts, we suggest using something like `StoreSample-<yourname>`. If you see a red cross next to the name, it means that there is a conflict. Try variations in the name, e.g. appending 2 or 3.
    * Resource Group: select `PaasHandsOnRG`
    * App Service Plan: click on the `New` button on it, to create a new app service plan.

   <img alt="" src="assets/vs_publish_dialog_04.png" width="600px"/>

   > The App Service Plan is basically a _container_ for the applications that you host. Each plan can host multiple applications. An App Service Plan is also the unit that is used for billing. You can find an in-depth overview of App Service Plans [here](https://azure.microsoft.com/en-us/documentation/articles/azure-web-sites-web-hosting-plans-in-depth-overview/) and more information on billing of App Service Plans [here](https://azure.microsoft.com/en-us/pricing/details/app-service/plans/).

6. Confirm the new app service plan, by clicking `Ok`.
7. Verify the information is correct, and select `Create` to make sure the App Service is created. 
8. You will then see the _familiar_ Web Deploy dialog, pre-populated with the credentials and URLs.

   <img alt="Web Deploy Dialog for publishing to an Azure Web App" src="assets/vs_publish_dialog_05.png" width="600px"/>

9. If you want, you can verify the changes by advancing (using the `Next >` button) to the _Preview_

   > Selecting the `Start Preview` button will take a look at what files need to be published/modified/deleted. You can do this _anytime_ you publish the application manually, if you want to verify the changes that are getting published to the server. 

10. When you're happy with the changes, you can kick-off the publishing process by clicking `Publish`.
11. Visual Studio will then launch a _Build_ process in the background. Once that is completed, it wil launch the publishing process, opening the _Azure App Service Activity_ pane.

   ![Azure App Service Activity](assets/vs_azure_app_service_01.png)

12. When complete, the pane will show `Publish Succeeded`. This also shows you the link where the site is publishing. If you click on that link, you should see the website, up and running.

   ![Azure App Service Publish Succeeded](assets/vs_azure_app_service_02.png)

## Scaling the application

In this section, we'll explore how to easily scale the application. As we attempt to scale, we will run into an _issue_. That issue is that the free plan (for obvious reasons), does not allow you to scale the application out. That means that we will also migrate the _App Service Plan_ to a higher plan that will enable us to scale properly.

1. Start by logging into the [Azure Portal](https://portal.azure.com).
2. You should see a list of types of services in the left hand menu. Select `App Services` from the menu, as shown in the image below. 
    
    <img src="assets/azure_portal_01.png" width="600px" />

    > If you cannot see the item in the menu, click the `More Services >` menu item and type `App Services` in the search box. 

3. Once you open the App Services Pane, select your deployment (we've named it `StoreSample-<yourname>`). You'll see the corresponding pane show up, along with a list of options for you. 

    <img src="assets/azure_portal_02.png" width="600px" />

4. Find and click on `Scale Up` as the first thing we need to do is increase the _App Service Plan_ we are using. Select the *Basic* plan, and `Save`.

    <img src="assets/azure_portal_03.png" width="600px" />

    You will see a notification pop-up when that operation is complete.

    <img src="assets/azure_portal_04.png"/>

5. Now, in the same list of operations in the pane corresponding to your app, find `Scale Out`. 

    <img src="assets/azure_portal_05.png" width="600px"/>

    > Multiple scale-out scenarios are supported for Web Apps, namely _manual_ and _automatic_. However, the automatic (called Auto Scale) scaling is only supported in higher pricing plans. 

6. Drag the counter to the right, and select 3 instances and click `Save` in the toolbar above. 

    <img src="assets/azure_portal_06.png" width="600px"/>

7. Once that is complete, you should again see a notification in the upper right corner. The operation usually doesn't take long, so it should be fairly quick. 

    <img src="assets/azure_portal_07.png"/>

8. Once done, open your application through the URL towards it was published. You _should_ be able to force the load balancer to switch between multiple nodes by holding down F5. You will see something like the following image.

    <img src="assets/hostnames.png"/>

> Note that the load-balancer in use here, is fairly smart - it will maintain a list of incoming connections and try to maintain a fairly sticky session. To get around this, you might want to work with your neighboor in the course, to open their URL, and compare the hostname you are getting towards what they are getting. 