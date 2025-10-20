Project: Azure API Management

This project showcases the integration of a deployed API hosted on Azure App Service with Azure API Management (APIM). It highlights how APIs can be securely published, managed, and accessed through APIM with configurations such as products, subscriptions, and policies. The repository includes screenshots demonstrating the complete setup and management process.

1) In Below Image we can see that APIManagementRG resource group has been created, inside which all the services has been Mapped.

<img width="1902" height="501" alt="image" src="https://github.com/user-attachments/assets/b13b24c3-4baf-4ca4-8e67-e2eb1ddc799b" />

2) Here, we have used APIManagementresource212 which is API Management service and AzureAPIManagement20251018211124 and AzureAPIManagement20251018211124Plan which is App service and APP Service Plan.
   
<img width="1907" height="732" alt="image" src="https://github.com/user-attachments/assets/d3f08514-56ac-44d3-b2c9-183952bb02f6" />

3) APIManagementresource212 has been created using developer Tier in canada central location.
   
<img width="1870" height="870" alt="image" src="https://github.com/user-attachments/assets/2304b71b-80b3-4422-aa41-1a8f15aed331" />

4) If will click on API's we will see we have uploaded our API inside APIM and all the API's has been listed one after another, and this has been done using swagger json.
   
<img width="1905" height="856" alt="image" src="https://github.com/user-attachments/assets/9cb682d7-32ca-45ef-becb-e7e0b9ebb3d3" />

5) If will see here in Below screenshot, products has been developed by name APIManagementProduct in which Administrators and developers has access too.
   
<img width="1906" height="685" alt="image" src="https://github.com/user-attachments/assets/dc95f3e8-aee3-44ef-a5eb-96338cd303bb" />

<img width="1895" height="661" alt="image" src="https://github.com/user-attachments/assets/a3bf5130-1feb-4f08-8c04-fa0aff784937" />

6) We have added our API's inside products API so that it can inherit the rules we define for product and its subscription.

<img width="1912" height="528" alt="image" src="https://github.com/user-attachments/assets/d56f71b8-f8c9-4f79-a479-5ffa434e6b89" />

7) We have created a subscription, we can now access this API only by using its primary or secondary key.
   
<img width="1912" height="520" alt="image" src="https://github.com/user-attachments/assets/114f9be3-3a8c-49d1-bd1f-2fa0a72fc523" />

In Below screenshot you can see API has been called using Key Ocp-Apim-Subscription-Key and it has access to its Data now.

<img width="1417" height="823" alt="image" src="https://github.com/user-attachments/assets/7381bc7f-8eb0-417b-9ae4-1890761198e8" />

8) Inside Portal Overview tab of APIManagementresource212, developer portal has been created by azure from where a developer can get access to its api and can also test the API with this portal and a Adminstrator can edit the portal according to the requirement recieved.
   
<img width="1893" height="921" alt="image" src="https://github.com/user-attachments/assets/2db5f8a2-7015-42d8-8d71-4be72dbbe086" />

Below is the screenshot of the portal, which a developer can access after the registration and can call the API's by providing sunscription key.

<img width="1897" height="996" alt="image" src="https://github.com/user-attachments/assets/f87fec6d-c4ff-4470-a5f3-59175db8a896" />



API Policy Configuration

The below screenshots demonstrate how various policies were applied to the APIs in Azure API Management (APIM). These include configurations at the inbound, backend, and outbound processing stages to control request validation, response handling, and access management.

1) Applying API Calling Quota's

In the Below Screenshot you can see we have added a policy inside Inbound with following attributes 
1) calls : Using which we have limited the calls a user can make to this API.
2) renewal-Period : Using which we can limit how much call a user can make in specific time period.
3) counter-key : This has used to Identify from which IP address a user is calling the API and the above settings should be validated according to the user IP.
4) increment-condition : This attribute helps to count request on specific condition, here we have mentioned it should count on the basis of status code "200 OK".
5) remaning-calls-variable-name : this we show message to user that after how long a user can access the API again.
   
<img width="1876" height="823" alt="image" src="https://github.com/user-attachments/assets/49bfb0c2-6ac1-4cfa-8450-c66ffb92b67c" />

Below screenshot shows a user has exceeded the limit of calling API and after 3 seconds user will get access to the API again.

<img width="1243" height="681" alt="image" src="https://github.com/user-attachments/assets/a5c65f70-5b3b-4daf-bba1-9c694bae41a9" />

2) Limiting API Caller IP

In Below screenshot we can see IP address configuration has been set for which we have used following attributes.
1) Address-Range : using this we can give access to IP address from certain range.
2) Address : Here, we can whitelist the single IP we want to give access to.
   
<img width="1873" height="796" alt="image" src="https://github.com/user-attachments/assets/80a9f5b5-58e5-4463-a371-910924bc440e" />

Before Whitelisting we are getting 403 forbidden error.

<img width="1375" height="617" alt="image" src="https://github.com/user-attachments/assets/71b34f11-031b-4d1c-89ad-b4fdcc81c24b" />

After WhiteListing API

<img width="1535" height="668" alt="image" src="https://github.com/user-attachments/assets/9c8f1771-7ca2-4f82-b235-89a86b6d5c7e" />

After WhiteListing we are getting proper response.

<img width="1397" height="852" alt="image" src="https://github.com/user-attachments/assets/f0d42f64-7cf5-4809-b683-67adc2a066bc" />

3) Converting Json to XML Response

In the below screenshot we have used policy which can convert Json response to XML and following are the attributes.

1) apply="always" : Defines when the policy should convert JSON to XML.
2) consider-accept-header="false" : Determines whether the conversion depends on the request’s Accept header.
3) parse-date="false" : Controls whether string values that look like dates should be automatically parsed as date types.
4) namespace-separator=":" Defines the character used to separate XML namespace prefix and element name.
5) namespace-prefix="xmlns" : Specifies the prefix used for XML namespaces.
6) attribute-block-name="#attrs" : Defines the JSON property name that will represent XML attributes.
   
<img width="1892" height="910" alt="image" src="https://github.com/user-attachments/assets/53745c7f-59fb-453a-a8ec-414024f2ec43" />

In Below screenshot you can see we are getting response in XML format now.

<img width="1432" height="826" alt="image" src="https://github.com/user-attachments/assets/f0b43bdf-b281-4197-8ccc-566283ff684b" />

4) Checking HTTP Header Request

In the Below API you can see that we have implemented a Http Header for API in which we have used following attributes.

1) name : Specifies which HTTP header to check in the incoming request. 
2) failed-check-httpcode="401" : Defines the HTTP status code returned if the header check fails.
3) failed-check-error-message="Not authorized" : Custom error message to include in the response if validation fails.
4) ignore-case="false" : Determines whether header value comparison is case-sensitive.
5) <value> : Defines the expected value of the header that must be present for the request to pass.
   
<img width="1857" height="820" alt="image" src="https://github.com/user-attachments/assets/3f8977e8-b17d-46e2-bca0-a4992ff626bb" />

Getting 401 not authorized response without header.

<img width="1397" height="716" alt="image" src="https://github.com/user-attachments/assets/92c523d2-e60e-48c5-a988-6b4c7936742d" />

After Implementing Header got successful response with data.

<img width="1368" height="842" alt="image" src="https://github.com/user-attachments/assets/c2889a6c-06d6-41cc-aaa4-de35cbd4b2f3" />


















