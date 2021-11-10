CREATE PROC UserAddOrEdit
@User_id int,
@First_Name nvarchar(50),
@Last_Name nvarchar(50),
@User_Name nvarchar(50),
@Password nvarchar(50),
@Confirm_Password nvarchar(50),
@Gender nvarchar(50),
@Address nvarchar(50),
@Email_id nvarchar(50)
AS 
   IF @User_id = 0
   BEGIN
   INSERT INTO Register_Form (First_Name,Last_Name,User_Name,Password,Confirm_Password,Gender,Address,Email_id)
   VALUES(@First_Name,@Last_Name,@User_Name,@Password,@Confirm_Password,@Gender,@Address,@Email_id)
   END
   ELSE
   BEGIN
   UPDATE Register_Form
   SET
   First_Name = @First_Name ,
   Last_Name = @Last_Name,
   User_Name = @User_Name,
   Password = @Password,
   Confirm_Password = @Confirm_Password,
   Gender = @Gender,
   Address = @Address,
   Email_id = @Email_id
   WHERE User_id = @User_id
   END