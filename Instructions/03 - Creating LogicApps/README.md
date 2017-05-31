# Persisting Orders & Sending customer notifications

This scenario demonstrates how you can easily persist the orders in the database and send customer notifications using Logic Apps in the browser.
### Pre Requisite - 
1) Create Send Grid Account from the Market Place.


## Adding new Logic App - Step 1

The steps here assume that you are logged into an account that has an Azure subscription.

1. *Select* the resource group StoreSimple and *click* ```Add```.
<img src="assets/Creating Logic App - Step 1 Click Add.PNG" width="500px"/>

2. *Enter* ```Logic Apps``` in the ```search marketplace``` text box and *hit*  ```Enter key```  to search.  
<img src="assets/Creating Logic Apps - Step 2 Search Logic App.PNG" width="500px"/>

3. *Select*  ```Logic Apps``` from the search results and *Click* ```Create``` button in the Logic App Blade.
<img src="assets/Creating Logic Apps - Step 3 Click Create Button.PNG" width="500px"/>

4. *Enter* Name ```StoreSimple_LA``` and selection Location as ```North Europe``` and *click* Create.
<img src="assets/Creating Logic Apps - Step 4 Enter Parameters and Click Create.PNG" width="500px" height ="500px"/>

## Adding Trigger - Step 2
 
1. Once the deployment is complete, *select* StoreSimple_LA logic app. This will open up Logic App Designer blade and will offer you range of templates. *Select* Blank Template.
 <img src="assets/Adding Trigger - Step 1 Select Blank Template.PNG" width="500px"/>
 
2. It will then prompt you select connector and trigger. *Search* for ```Azure Queues``` and *Select* Azure Queues.
 <img src="assets/Adding Trigger - Step 2 Select Azure Queues.PNG" width="500px"/>
 
3. *Select* the trigger ```Azure Queues - When there are messages in a queue```.
 <img src="assets/Adding Trigger - Step 3 Select AQ When There are messages in Queue.PNG" width="500px"/>	
 
4. This will open Connection dialog box. *Enter* Connection  Name as ```StoreSimpleMsgQ_Con``` and *Select* the stroage account that contains the queue. 
 <img src="assets/Adding Trigger - Step 4 Select the storage account.jpg" width="500px"/>
 
5. It will then ask you to provide the Queue details. *Select* Queue.
  <img src="assets/Adding Trigger - Step 5 Select Queue.JPG" width="500px"/>
6. *Update* the interval to ```1```. 
  <img src="assets/Adding Trigger - Step 6 Update the poll frequency.JPG" width="500px"/>
  
7. This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. 
*Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration. On save, the portal will validate the parameters and it will highlight, if there are any errors in the configuration.
    
## Parsing Queue Message - Step 3
   
1. *Click* Next Step and *Select* ```Add Action```.<br/>
   <img src="assets/Parsing Queue Message - Step 1 Next Action after Message Recd.JPG" width="500px"/>
   
2. *Search* for ```Parse``` and select This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. *Click* the ```Save``` button on the Logic Apps Designer tool bar. 
<img src="assets/Parsing Queue Message - Step 2 Search Parse and Select Parse JSON action.JPG" width="500px"/>
    
3. *Select* ```Message Text``` by clicking ```Add Dynamic content +``` and selecting the ```Message Text``` item from the list.
   <img src="assets/Parsing Queue Message - Step 3 Select Message Text for content property.JPG" width="500px"/>
   
4. The portal allows you to generate the JSON schema based on sample record. *Copy* following sample JSON message 
``` 
{     
     "IdOrder": 0, 
     "BookId":3, 
     "OrderPlacedAtUtc": "2017-05-10T13:42:31.2887004Z",
     "Quantity": 1, 
     "TotalPrice": 19.0200, 
     "FirstName":"John", 
     "LastName":"Smith",
     "Email":"John.Smith@gmail.com",
     "TelephoneNumber":"00447971449042",
     "HouseNumber":"1",
     "PostCode":"RG1 1WG",
     "CreditCardNumber":"d3ea4d6e-3d79-464c-956c-f72240bfb76b",
     "Book":null
}
``` 
*Click* ```Use sample payload to generate schema``` and paste the JSON record. *Click* ```Done``` to generate the schema.
<img src="assets/Parsing Queue Message - Step 4 Select generate schema from the data.JPG" width="500px"/>
  
5. Generated schema is populated in the ```Schema``` field.
  <img src="assets/Parsing Queue Message - Step 5 Parse Json Complete.JPG" width="500px"/>
  
6. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.
 <img src="assets/Parsing Queue Message - Step 6  Parse Json Save Logic Apps.JPG" width="500px"/>


## Persisting the Message - Step 4

1. *Click* Next Step and *Select* ```Add Action```. <br/>
   <img src="assets/Persisting the Message - Step 1 Next Action after Message Parsed.JPG" width="500px"/>
   
2. *Search* for ```SQL Server```. *Select* ```SQL Server``` <br/>
   <img src="assets/Persisting the Message - Step 2 Select SQL Server.JPG" width="500px"/>
   
3. It will prompt for the SQL Server Action. *Select* ```SQL Server - Insert Row```. <br/> 
   <img src="assets/Persisting the Message - Step 3 Select Insert Row Action.JPG" width="500px"/>
   
4. *Select* SQL Server Instance.<br/>
   <img src="assets/Persisting the Message - Step 4 SQL Server Connection - Select SQL Server Instance.JPG" width="500px"/>
   
5. *Select* SQL Server Database and *Set* ```User Name``` and ```Password```. *Click* ```Create``` button to create the connection. <br/>
   <img src="assets/Persisting the Message - Step 5 SQL Server Connection - Select SQL Server Database.JPG" width="500px"/>
   
6. *Select* Table ```Order``` from the drop down list.<br/>
 <img src="assets/Persisting the Message - Step 6 Insert Row - Select Table.JPG" width="500px"/>

7. *Map* the message fields to individual table columns. BookId and Quantity fields it does not allow to select the fields. You can temporarily map OrderPlacedAtUTC with OrderPlaceAtUtc, BookId and Quantity.<br/>
 <img src="assets/Persisting the Message - Step 7 Insert Row - Map Message fields to table columns.JPG" width="500px"/>

8. *Update* the BookId and Quantity fields using ```Code View```. Set BookId = ```@body('Parse_JSON')?['BookId']```, Quantity = ```@body('Parse_JSON')?['Quantity']```.<br/>
 <img src="assets/Persisting the Message - Step 8 Insert Row - Edit fields.JPG" width="500px"/>

9. Once all the fields are assigned completed mapping will look like following image.<br/>
 <img src="assets/Persisting the Message - Step 9 Insert Row - Edit Fields Complete.JPG" width="500px"/>

10. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.<br/>
 <img src="assets/Persisting the Message - Step 10 Insert Row - Save Logic Apps.JPG" width="500px"/>

## Notifying the Customer - Step 5
1. *Click* Next Step and *Select* ```Add Action```. <br/>
   <img src="assets/Notifying the customer - Step 1 - Next Action after Message persisted.JPG" width="500px"/>
   
2. *Search* for ```SendGrid```. *Select* ```SendGrid``` <br/>
   <img src="assets/Notifying the customer - Step 2 - Add Send Grid.JPG" width="500px"/>

3. *Select* ```SendGrid - Send Email``` action. <br/>
 <img src="assets/Notifying the customer - Step 3 - Send Email Action.JPG" width="500px"/>

4. *Enter* ```Connection Name``` "SendGridConnection". <br/>
 <img src="assets/Notifying the customer - Step 4 - Send Grid Connection.JPG" width="500px"/>
 
5. *Map* Email message fields with message fields as shown in the image below. <br/>
 <img src="assets/Notifying the customer - Step 5 - Enter fields.JPG" width="500px"/>

 <img src="assets/Notifying the customer - Step 4 - Send Grid Connection.JPG" width="500px"/>

1. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.


