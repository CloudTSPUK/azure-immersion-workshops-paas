# Selecting Template and Trigger
 
1. Once the deployment is complete, *select* StoreSimple_LA logic app. This will open up Logic App Designer blade and will offer you range of templates. <Br/>
   *Select* Blank Template.<br/>
   <img src="assets/Adding Trigger - Step 1 Select Blank Template.PNG" width="500px"/>
 
2. It will then prompt you select connector and trigger. *Search* for ```Azure Queues``` and *Select* Azure Queues. <br/>
   <img src="assets/Adding Trigger - Step 2 Select Azure Queues.PNG" width="500px"/>
 
3. *Select* the trigger ```Azure Queues - When there are messages in a queue```. <br/>
   <img src="assets/Adding Trigger - Step 3 Select AQ When There are messages in Queue.PNG" width="500px"/>	
 
4. This will open Connection dialog box. *Enter* Connection  Name as ```StoreSimpleMsgQ_Con``` and *Select* the stroage account that contains the queue. <br/>
   <img src="assets/Adding Trigger - Step 4 Select the storage account.jpg" width="500px"/>
 
5. It will then ask you to provide the Queue details. *Select* Queue. <br/>
  <img src="assets/Adding Trigger - Step 5 Select Queue.JPG" width="500px"/>
  
6. *Update* the interval to ```1```. <br/>
  <img src="assets/Adding Trigger - Step 6 Update the poll frequency.JPG" width="500px"/>
  
7. This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. 
   *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration. 
   On save, the portal will validate the parameters and it will highlight, if there are any errors in the configuration.
   
   Next Step  [Parsing Queue Message](ParsingQueueMessage.md)
  
