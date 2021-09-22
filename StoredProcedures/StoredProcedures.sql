SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Add New User
CREATE PROCEDURE spAddNewUsers
  @Name varchar(80),
  @Zipcode int,
  @email varchar(50),
  @Gender char,
  @Password varchar(80)
  AS
  BEGIN
  SET NOCOUNT ON;
  declare @ID int;
  insert into Users(Name,Gender,email,Zipcode) values(@Name,@Gender,@email,@Zipcode);
	set @ID =  scope_identity();
  insert into Login(user_id,Password) values(@ID,@Password);
END
GO


--Validate User
create proc spValidateUser
  @email varchar(50),
  @Password varchar(50)
  as 
  BEGIN 
  set NOCOUNT on
  declare @userid int
  select @userid = u.id from Users as u inner join Login as l on l.user_id=u.id where u.email=@email and l.Password=@Password

   if @userid is not null
   begin
    select @userid
   end

   else
     begin
     select -1
   end 
END

select * from Users
select * from Login
