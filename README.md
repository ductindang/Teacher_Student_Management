# Teacher_Student_Management
## Instruction
### Install environment
1. Watch how to install Visual Studio from url: [https://visualstudio.microsoft.com/downloads/](https://www.youtube.com/watch?v=tRbHlEVEVf0&t=172s) and install .NET 8
2. Download Sql Server, watch video for instruction: https://www.youtube.com/watch?v=LYR5o8TE7rM&t=81s
### Clone Project from github
1. Access into github repo
2. Take the link github follow the image
  <img width="962" height="476" alt="image" src="https://github.com/user-attachments/assets/c6fc3ac5-f29e-44c6-9ca4-0b4807c3a3b7" />
3. Open visual studio and clone the repo into your computer
### Open the Project
1. First, open ManagementAPI.sln in ManagementBackEnd folder
2. Connect database
   - Change the connection string to suitable with you SqlServer connection
   - <img width="1533" height="375" alt="image" src="https://github.com/user-attachments/assets/37e0a940-31ac-41b7-8172-b9cba9a274cd" />

   - Open Package Management Console follow the image
   - <img width="614" height="759" alt="image" src="https://github.com/user-attachments/assets/93d56077-fa63-4f2d-8ccf-a37634e1a845" />

   - Chose Default Project and enter "add-migration Initial" into the Package Manager Console
   - <img width="1539" height="275" alt="image" src="https://github.com/user-attachments/assets/fc755070-a25d-4688-b5a7-8e55d726d7a1" />
   - Enter "update-database" into the Package Manager Console to update data table into database
   - Run ManagementAPI.sln

4. Second, open ManagementFrontAdmin.sln in ManagementFrontAdmin folder
   - run ManagementFrontAdmin.sln
6. First, open ManagementFrontClient.sln in ManagementFrontClient folder
   - run ManagementFrontClient.sln

