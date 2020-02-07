# Forum

### Description:

It's a web forum with two groups of users, admins and users. The forum it's organized in categories on different topics, each category has threads, and each thread has posts.The users can create/edit threads and posts, reply to posts, if the post has unappropriate content it can be reported, they can send private messages to each other as well. Only the administrators can create/edit/delete categories, they can aslo edit/delete posts, when someone is reported they can suspend/delete user's account.

### Instructions:

1) Open the solution "Forum.sln" in Visual Studio,
2) Right Click on "ForumWebApp" in the Solution Explorer, and choose "Set as StartUp Project",
3) Then open "Package Manager Console", you can find it under "Tools > NuGet Package Manager > Package Manager Console",
4) When the "Package Manager Console" window opens, in "Default Project" dropdown menu select "Forum.DataAccess"
5) In the "Package Manager Console" write "Add-Migration MigrationsName", you can choose any name you want instead of "MigrationsName".
6) When the migration fnishes building, in the "Package Manager Console" window write "Update-Database".
7) When it finishes, you can run the project, by clicking on "IIS Express" or by clicking on F5 function key.

That's it.
