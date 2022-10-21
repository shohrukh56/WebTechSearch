CREATE DATABASE items
GO
USE items
GO
CREATE TABLE stores
(
     id int primary key identity,
     descritpion varchar(50) not null 
)
GO
CREATE TABLE computers
(
     id int primary key identity,
     descritpion varchar(200) not null,
     update_at datetime not null,
         FOREIGN KEY (store_id) REFERENCES stores (id)
)
GO