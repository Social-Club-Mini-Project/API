social club
Input / Output Interface Design :
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/2e423219-3c15-49be-afad-4a8135927a4e)
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/3dfffb48-6c66-4e14-aa1c-a7011e71342c)
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/5699129c-71c2-4d2f-b7cb-abc0df392caa)
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/a5d98e92-97b6-4600-ad20-460764b6c904)

Made By :
@darsh-7 
@reiyuchan

INTRODUCTION
In this project we considered a social club app for our University MTi. We want to give our community (MTI students) a way to communicate each other by a spatial app ,so we made a small version of an app call MTI social club.

Technologies/Techniques
We used deferent tools to complect this app in a web version, starting with the Database by using Microsoft SQL Server to save and modify the data of our users, for the front end we used React program base typescript and of course with HTML and CSS ,for delivering the data from our Database to the front end we used ASP API.

Features
The user can:
•	post his post easily.
•	give the post alike.
•	know the user level ,Name and maybe his image.
Functional Requirements: 
Admin 
•	Manage posts.
•	Manage users.
Normal User
•	Add, edit, delete posts. 
•	Change image. 

API Perform transactions:
•	Add, update, delete ,check user exists ,login user check(users).
•	Add, update, delete , get all posts ,search by user id(posts).
•	The API handles converting the data string ,numerical and image data to json so it can be handled and used in the front end.
Login Example:
In this example show how the API handle the login action the front sends the user id and his password then the API chick if the data are valid from the Database if it is not valid the API send empty object of user if else the API send this user data in object called user.
the code :
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/034301e5-abb5-431a-948c-a21a4afe5124)

Report
Search for posts by user ID:
in this example the API receive the user id from the front end and search for all posts from this user and send it back to the front 
The used quarry for the search :
“SELECT * FROM post where userID = {id}”
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/53e626da-cccf-4d48-95cc-9f06419402aa)
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/2f441989-7d3d-4d3f-befd-12b027308aa2)
 
Sitemap
A sitemap is a list of all the pages on a website, which helps search engines and website visitors understand the structure and content of the site. It can improve the visibility of the website in search engine results and make it easier for visitors to navigate the site.
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/3706c71d-52a8-49a7-a326-3d9da7ca52cc)

System Analysis
Context Diagram:
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/3ddeaa0d-afcd-4ae6-afb4-159991f24731)

![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/e546ae1b-d71c-4af9-945e-161e558c5a0f)

Level-1 DFD:
 ![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/e7ab2bb3-51d1-48d3-92d2-5721ad07c0e7)

use case 
A use case depicts a set of activities performed to produce some output result. Each use case describes how an external user triggers an event to which the system must respond.
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/3a2aaf89-0a52-4900-9b10-999e525b3b5d)
First Actor: User 
•	Can Login. 
•	Can add, edit and see posts. 
•	Can like other posts.
•	Can edit his image.
Second Actor: Admin 
•	Can do anything like a user. 
•	Can remove images and posts. 

Activity Diagram
The activity diagram gives a wide look at the system, the activity diagram is a tool that can be offered to non-technical people to understand the system well.
Main activity diagram of the User:
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/cae38b80-5a5b-4152-8c44-2819614f1567)
Main activity diagram of the admin changing Data
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/c7e7a008-eca8-44d4-b79b-5b6c675de17a)

Sequence Diagrams
The sequence diagram shows interactions in the system between objects put together respecting the sequence. It shows the message exchanged between the objects and what kind of interactions are done. In the MTI social club application, we look at the exchange between the actors and the system as well as the database and the API.

Login as User:
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/a2827130-70f2-42ed-b3ec-d8ea1b0f5aea)

<h3>note: the DB Analysis is based on the new DB not the one currently used in the program</h3>
 
EER Digram: 
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/4c7c7fdf-cd6f-4f54-a044-d8998ae594f7)
Mapping :
Department
(dep_id , dep_name)
Users
(userID , email ,password , name ,birth_date ,phone  ,address , Profile_photo, gender )
Student
(userID , enrolleddate  , Level , dep_id )
Academician
( userID , dep_id )
post
( Post_id , userID , post_date  , text , img )
Like
(userID, Post_id)

Skema:
![image](https://github.com/Social-Club-Mini-Project/API/assets/38864734/85e93802-d8ae-4e75-bf65-196b5bc67fc1)
 
