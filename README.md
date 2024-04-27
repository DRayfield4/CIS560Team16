# CIS560Team16

# Description
The goal of this project was to create a system that could store a database of books and allow users to filter by said books and purchase them. The main users of this system would be customers looking up potential books to buy. Books may be filtered by Title, Author, Date, Publisher, Price, and ISBN. A user may click the add button to add a book to a buy list. They can then remove it with a button or choose to hit the buy button, sending them to a separate window to enter their information. On the administrator side of commands, books may be added, removed, or edited from the database of books using a specific admin window. The admin window can filter the same as the user window. However, this window also has pre-programmed aggregating queries for more complicated requests. 

# Installation
1. Download the project as a ZIP file and extract its contents.
2. Open Azure Data Studio, SQL Server Management Studio, or any other SQL database manager.
3. Make a new server connection and set the following information:
    Server type: Database Engine
    Server Name: (localdb)\MSSQLLocalDb
    Authentication: Windows Authentication

    Then connect.
4. Once connected, right click on the databases folder and select "Import Data-tier Application..."
5. Select the "OnlineBookstore.bacpac" file and follow the prompts.
6. Once added successfully, the database is ready to go.
7. Now click the "OnlineBookstore.sln" file to open in Visual Studio or open the "OnlineBookstore" folder in your preferred IDE.
8. Once open, confirm that in the "App.config" file, the connection string is as follows:
    connectionString="Server=(localdb)\MSSQLLocalDb; Database=OnlineBookstore; Integrated Security=True;"
9. You can now run the program and access the database.

# Useage
There are two main aspects to the program: user access and admin access. Users can add books to their cart, remove books from their cart, checkout and purchase books, or filter the books in the database by Title, Author, ISBN, Genre, Price, and Publisher. Admins can add, update, or "remove" (soft delete) books from the database. The can also run queries that displays important information that would be interesting to admins.
