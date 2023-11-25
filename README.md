# Galleria
C# project to imitate an image board via forms app. Stores user and post information in an SQL database.
Quite proud of this one, image storing is something that I've always wanted to tackle within SQL, so this project was a proper fit for what I wanted.
All data is stored properly within tables following normal form rules, and all data is included in the .BACPAC file.

# How to run
To run the project, install SQL Server Management Studio (SSMS) and import the database from the .BACPAC file located in the main folder.
The database should automatically configure for everything required, but if any issues arise, feel free to edit the connection class within the source files to adjust for any anomalies.
Afterwards, simply navigate to Galerija/Galerija/Bin and find the executable file. Run it, and it should load the form user interface with all the posts available.
