/*Creamos la base de datos del proyecto*/
CREATE DATABASE db_tareas;
DROP DATABASE db_tareas;

/*Seleccionamos la base de datos a utilizar*/
USE db_tareas;

/*Instruccion para eliminar tabla si es necesario*/
DROP table items;

/*Creamos una tambla con los campos requeridos por la aplicacion*/
CREATE TABLE items(
	user_id int,
	item_id int primary key auto_increment,
    item_name varchar(50),
    item_done varchar(50),
    item_created varchar(50)
)

