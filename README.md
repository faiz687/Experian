# Experian - Marketplaces

An ASP.net core web API to find appropriate card for customer. Scroll to bottom of the page to read improvements or to-do that can be made to the application.

## pre-requisites
1. SQL Server express

## Images 

###### 1. Making request without mandatory data.
![Annual income Missing](Images/Snip1.png)

![Date of Birth Missing](Images/Snip2.png)

![Annual income Missing](Images/Snip3.png)

###### 2. Making request with incorrect versioning number.
![Incorrect API version](Images/Snip11.png)

###### 3. Below 18 request.
![Below 18 request](Images/Snip4.png)

###### 3. Annual income below 30000.
![Incorrect API version](Images/Snip5.png)

###### 3. Annual income above 30000.
![Incorrect API version](Images/Snip6.png)

###### 3. Marketplaces Database.
![Incorrect API version](Images/Snip7.png)

###### 3. Applicant detail table saving applicant details.
![Incorrect API version](Images/Snip8.png)

###### 3. Applicant results that were shown with their card results.
![Incorrect API version](Images/Snip9.png)

###### 3. All cards available on the system.
![Incorrect API version](Images/Snip10.png)



## Improvements to the application
1. Unit testing for services, repository and helper classes.
2. Adding comments on top of functions or Documenting code.
3. Not using magic numbers like 30,000 find a way to store them or use them more appropriately.
4. Defaulting to an API version if not found.
5. Making all models inherit from a base model class.
