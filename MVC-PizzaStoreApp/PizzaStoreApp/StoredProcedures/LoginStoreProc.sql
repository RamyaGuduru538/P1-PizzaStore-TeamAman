//Add New User
create proc spAddNewUsers
  @Name varchar(50),
  @Zipcode int,
  @Email varchar(50),
  @Gender varchar(50),
  @Password varchar(50)
  as
  BEGIN
  set nocount on;
  declare @ID int;
  insert into Users(Name,Zipcode,Email,Gender,Password) values(@Name,@Zipcode,@Email,@Gender,@Password);
	set @ID =  scope_identity();
  insert into Login(CustomerId,Username,Password) values(@ID,@Name,@Password);
END


//Validate User
create proc spValidateUser
  @Email varchar(50),
  @Password varchar(50)
  as 
  BEGIN 
  set NOCOUNT on
  declare @userid int
  select @userid = u.id from Users as u inner join Login as l on l.user_id=u.id where u.email=@Email and l.Password=@Password

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


