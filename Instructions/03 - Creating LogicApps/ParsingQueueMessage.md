# Parsing Queue Message
   
1. *Click* Next Step and *Select* ```Add Action```.<br/>
   <img src="assets/Parsing Queue Message - Step 1 Next Action after Message Recd.JPG" width="500px"/>
   
2. *Search* for ```Parse``` and select This completes the trigger part of the Logic Apps. It will be good to save the configuraiton at this point. *Click* the ```Save``` button on the Logic Apps Designer tool bar. 
<img src="assets/Parsing Queue Message - Step 2 Search Parse and Select Parse JSON action.JPG" width="500px"/>
    
3. *Select* ```Message Text``` by clicking ```Add Dynamic content +``` and selecting the ```Message Text``` item from the list.
   <img src="assets/Parsing Queue Message - Step 3 Select Message Text for content property.JPG" width="500px"/>
   
4. The portal allows you to generate the JSON schema based on sample record. *Copy* following sample JSON message 
<pre><code> 
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
</pre></code>
*Click* ```Use sample payload to generate schema``` and paste the JSON record. *Click* ```Done``` to generate the schema.
<img src="assets/Parsing Queue Message - Step 4 Select generate schema from the data.JPG" width="500px"/>
  
5. Generated schema is populated in the ```Schema``` field.
  <img src="assets/Parsing Queue Message - Step 5 Parse Json Complete.JPG" width="500px"/>
  
6. *Click* the ```Save``` button on the Logic Apps Designer tool bar to save the configuration.
 <img src="assets/Parsing Queue Message - Step 6  Parse Json Save Logic Apps.JPG" width="500px"/>

