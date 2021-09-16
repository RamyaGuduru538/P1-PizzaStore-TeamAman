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