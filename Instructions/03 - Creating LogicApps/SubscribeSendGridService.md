# Subscribe to SendGrid Email delivery service


1. *Select* the resource group StoreSimple and *click* ```Add```.
   <img src="assets/Subscribe SendGrid - Step 1 Add Send Grid.JPG" width="500px"/>

2. *Enter* ```SendGrid``` in the ```search marketplace``` text box and *hit*  ```Enter key```  to search. <br/>
    The tool tip will show ```SendGrid Email Delivery```, *Select* it and *Hit* Enter. <br/>
   *Select* ```SendGrid Email Delivery``` from the search results area and *Click* ```Create```. <br/>
  
   <img src="assets/Subscribe SendGrid - Step 2 Search SendGrid and Click Create.JPG" width="500px"/>
  
3. It will prompt for account parameters in the ```Create a New SendGrid Account``` Blade. Enter Name, Password, Confirm Password. *Select* ```Free Pricing Tier```.<br/>
   <img src="assets/Subscribe SendGrid - Step 3 Create Parameters.JPG" width="500px"/>
  
 
4. *Enter* Contact Information (First Name, Last Name, Email, Company and Website). Website field is optional. *Hit* OK on the  ```Contract Information``` Blade.<br/>
  <img src="assets/Subscribe SendGrid - Step 4 Contact Information.JPG" width="500px"/>

5. *Select*  the checkbox ```I give Microsoft permission to use and share my contact infomration...```. *Accept* Legal Terms by click Purchase in the  ```Offer Details``` Blade.<br/>
   <img src="assets/Subscribe SendGrid - Step 5 Accept Legal Terms.JPG" width="500px"/>

6. Once the deployment is completed, explore the SendGrid resource from the resource group. *Note* ```USERNAME``` by *clicking* the Keys icon on the overview blade.<br/> *Click* on Manage icon. <br/>
   It will connect you to SendGrid website and automatically log you in through SSO.
   <img src="assets/Subscribe SendGrid - Step 6 Find Login user id.JPG" width="500px"/>
 
7. On SendGrid website, it will prompt you to verify your email id by sending you a conirmation email. *Click*  ```Send Confirmation Email``` button. <br/>
   Once the confirmation email is received, click on the email link to confirm your email. It will transfer you back to SendGrid website. <br/>
   *Login* using the ```USERNAME``` obtained in the previous step. Use the same ```password``` that was specified in Step 3. <br/>
   <img src="assets/Subscribe SendGrid - Step 7 Email verification.JPG" width="500px"/>
   
8. *Click* on ```Settings``` side menue and then ```API Keys``` sub menu to configure a new API Key for the Logic App. *Click* ```Create API Key``` button.<br/>
   <img src="assets/Subscribe SendGrid - Step 8 Add API Keys.JPG" width="500px"/>
   
   
9. *Enter* ```API Key Name``` as ```StoreSimple_LA_ServiceAccount```. Slect Full Access option. You could go for restricted access to include send email permission.<br/> 
    For simplicity lets select Full access option for now. *Click* ```Create & New``` button to create new API Key.<br/>
   <img src="assets/Subscribe SendGrid - Step 9 Create API Key.JPG" width="500px"/>
   
 
10. This will generated one time API Key. Copy this key and keep it in safe location. This will be needed in the next section- (Notifying the customer).
  <img src="assets/Subscribe SendGrid - Step 10 API Key Generated.JPG" width="500px"/>
  
   
 Next Step [Notifying the Customer](NotifyingtheCustomer.md)


