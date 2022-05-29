use PetShopProject
go

create table Categories(
CategoryId int IDENTITY (1,1) primary key,
[Name] nvarchar(200))

go

create table Animal(
AnimalId int identity(1,1) primary key,
[Name] nvarchar(200)not null, 
[Description] nvarchar(max) null,
[BirtheDate] date null,
[PhotoUrl] nvarchar(max),
[CategryId] int foreign key references Categories(CategoryId)
)
go

Create table Comment(
[CommentId] int identity(1,1) primary key,
[CommentContent] nvarchar (max) not null,
[AnimalId] int foreign key references Animal(AnimalId),
)
go




