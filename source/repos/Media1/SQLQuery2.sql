CREATE PROC UserViewByID
@User_id int
as
	SELECT *
	FROM Register_Form
	WHERE User_id = @User_id