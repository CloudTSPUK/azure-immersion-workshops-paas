# Persisting Orders & Sending customer notifications

This scenario demonstrates how you can easily persist the orders in the database and send customer notifications using Logic Apps in the browser.
 

## Adding new Logic App - Step 1

The steps here assume that you are logged into an account that has an Azure subscription.

1. *Select* the resource group StoreSimple and *click* ```Add```
<img src="assets/Creating Logic App - Step 1 Click Add.PNG" width="500px"/>

2. *Enter*  ```Logic Apps``` in the ``'search marketplace``` text box and *hit* ```Enter key``` to search.  
   <img src="Creating Logic Apps - Step 2 Search Logic App.PNG" width="500px"/>
3. *Select* ```Logic Apps``` from the search results and *Click* ```Create``` button in the Logic App Blade.
 <img src="assets/Creating Logic Apps - Step 3 Click Create Button.PNG" width="500px"/>
4. *Enter* Name ```StoreSimple_LA``` and selection Location as ```North Europe``` and *click* Create.
 <img src="assets/Creating Logic Apps - Step 4 Enter Parameters and Click Create.PNG" width="500px"/>
 
## Desiging Logic Apps - Adding Trigger - Step 2
 
1. Once the deployment is complete, *select* StoreSimple_LA logic app. This will open up Logic App Designer blade and will offer you range of templates. *Select* Blank Template.
 <img src="assets/Adding Trigger - Step 1 Select Blank Template.PNG" width="500px"/>
2. It will then prompt you select connector and trigger. *Search* for ```Azure Queues``` and *Select* Azure Queues.
 <img src="assets/Adding Trigger - Step 2 Select Azure Queues.PNG" width="500px"/>
3. *Select* the trigger ```Azure Queues - When there are messages in a queue```.
 <img src="assets/Adding Trigger - Step 3 Select AQ When There are messages in Queue.PNG" width="500px"/>	
4. This will open Connection dialog box. *Enter* Connection  Name as ```StoreSimpleMsgQ_Con``` and *Select* the stroage account that contains the queue. 
 <img src="assets/Adding Trigger - Step 4 Select the storage account.jpg" width="500px"/>
5. It will then ask you to provide the Queue details. *Select* Queue.
  <img src="assets/Adding Trigger - Step 5 Select Queue.jpg" width="500px"/>
6. *Update* the interval to ```1```. 
  <img src="assets/Adding Trigger - Step 6 Update the poll frequency.jpg" width="500px"/>
7. This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. 
*Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration. On save, the portal will validate the parameters and it will highlight if there are any errors in the configuration.
    
## Desiging Logic Apps - Parsing Queue Message - Step 3
   
1. *Click* Next Step and *Select* ```Add Action``` 
   <img src="assets/Parsing Queue Message - Step 1 Next Action after Message Recd.jpg" width="500px"/>
2. *Search* for ```Parse``` and select This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. *Click* the ```Save``` button on the Logic Apps Designer tool bar. 
    <img src="assets/Parsing Queue Message - Step 2 Search Parse and Select Parse JSON action.jpg" width="500px"/>
3. *Select* ```Message Text``` by clicking ```Add Dynamic content +``` and selecting the ```Message Text``` item from the list.
   <img src="assets/Parsing Queue Message - Step 3 Select Message Text for content property.JPG" width="500px"/>
4. The portal allows you to generate the JSON schema based on sample record. *Copy* one of the JSON message from the queue. *Click* ```Use sample payload to generate schema``` and paste the JSON record. *Click* ```Done``` to generate the schema.
  <img src="assets/Parsing Queue Message - Step 4 Select generate schema from the data.jpg" width="500px"/>
5. Generated schema is populated in the ```Schema``` field.
  <img src="assets/Parsing Queue Message - Step 5 Parse Json Complete.jpg" width="500px"/>
6. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.

## Desinging Logic Apps - Persisting the Message - Step 4

1. *Click* Next Step and *Select* ```Add Action``` 
   <img src="assets/Persisting the Message - Step 1 Next Action after Message Parsed.jpg" width="500px"/>
2. *Search" for '''SQL Server'''. *Select* '''SQL Server'''. 
   <img src="assets/Persisting the Message - Step 2 Select SQL Server.JPG" width="500px"/>
3. *Search" for '''SQL Server'''. *Select* '''SQL Server'''. 
   <img src="assets/Persisting the Message - Step 2 Select Insert Row Action.JPG" width="500px"/>
 6. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.

## Desinging Logic Apps - Notifing the Customer - Step 5
6. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.
### Pre Requisite - Create Send Grid Account from the Market Place.

 