# Persisting the Message

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