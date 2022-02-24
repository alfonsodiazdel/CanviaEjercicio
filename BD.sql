DROP DATABASE CANVIA_EJERCICIO;
CREATE DATABASE CANVIA_EJERCICIO;
USE CANVIA_EJERCICIO;

CREATE TABLE Categoria
(
	idCategoria int not null identity(1,1),
	descripcion varchar(200) not null,
	fecha datetime default getdate(),
	estado bit default 1
)
GO

CREATE TABLE Libro
(
	idLibro int not null identity(1,1),
	idCategoria int not null,
	descripcion varchar(200) not null,
	paginas int not null,
	fecha datetime default getdate(),
	estado bit default 1
)
GO

ALTER TABLE Categoria
ADD CONSTRAINT PK_CATEGORIA PRIMARY KEY (idCategoria)
GO

ALTER TABLE Libro 
ADD CONSTRAINT PK_LIBRO PRIMARY KEY (idLibro)
GO

ALTER TABLE Libro
ADD CONSTRAINT FK_LIBRO_CATEGORIA FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
GO

CREATE NONCLUSTERED INDEX IDX_CATEGORIA
ON Categoria(descripcion)
GO

CREATE NONCLUSTERED INDEX IDX_LIBRO
ON Libro(descripcion)
GO

INSERT INTO Categoria(descripcion) values('Matemática'),('Física'),('Programación'),('Terror'),('Fantasía')
GO

INSERT INTO Libro(idCategoria,descripcion,paginas) values (3,'Clean Code',300),(3,'The Pragmatic Programmer', 240),(4,'El gato negro',123),(5,'Bestiario',200)
GO


--- STORED PROCEDURES CATEGORIA -----

CREATE PROCEDURE SP_CREAR_CATEGORIA
@descripcion VARCHAR(200)
AS
BEGIN
	INSERT INTO Categoria(descripcion)VALUES(@descripcion);
END
GO

CREATE PROCEDURE SP_ELIMINAR_CATEGORIA
@idCategoria INT
AS
BEGIN
	UPDATE Categoria SET estado = 0 WHERE idCategoria = @idCategoria;
END
GO

CREATE PROCEDURE SP_BUSCAR_CATEGORIA
@idCategoria int
AS
BEGIN
	SELECT * FROM Categoria WHERE idCategoria = @idCategoria;
END
GO

CREATE PROCEDURE SP_LISTAR_CATEGORIA
AS
BEGIN
	SELECT * FROM Categoria WHERE estado = 1;
END
GO

CREATE PROCEDURE SP_ACTUALIZAR_CATEGORIA
@idCategoria INT,
@descripcion VARCHAR(200)
AS
BEGIN
	UPDATE Categoria SET descripcion = @descripcion WHERE idCategoria = @idCategoria;
END
GO



--- STORED PROCEDURES LIBRO -----

CREATE PROCEDURE SP_CREAR_LIBRO
@idCategoria INT,
@descripcion VARCHAR(200),
@paginas INT
AS
BEGIN
	INSERT INTO Libro(idCategoria,descripcion,paginas) VALUES(@idCategoria,@descripcion,@paginas);
END
GO

CREATE PROCEDURE SP_ELIMINAR_LIBRO
@idLibro int
AS
BEGIN
	UPDATE Libro SET estado = 0 WHERE idLibro = @idLibro;
END
GO

CREATE PROCEDURE SP_BUSCAR_LIBRO
@idLibro int
AS
BEGIN
	SELECT *, C.descripcion AS [categoria]  FROM Libro L INNER JOIN Categoria C 
	ON L.idCategoria = C.idCategoria 
	WHERE idLibro = @idLibro;
END
GO

CREATE PROCEDURE SP_LISTAR_LIBRO
AS
BEGIN
	SELECT L.*, C.descripcion AS [categoria] FROM Libro L INNER JOIN Categoria C 
	ON L.idCategoria = C.idCategoria 
	WHERE L.estado = 1;
END
GO


CREATE PROCEDURE SP_ACTUALIZAR_LIBRO
@idLibro INT,
@idCategoria INT,
@descripcion VARCHAR(200),
@paginas INT
AS
BEGIN
	UPDATE Libro SET descripcion = @descripcion, paginas = @paginas, idCategoria = @idCategoria WHERE idLibro = @idLibro;
END
GO

CREATE PROCEDURE SP_FILTRAR_LIBRO_POR_CATEGORIA
@idCategoria int
AS
BEGIN
	SELECT L.*, C.descripcion AS [categoria] FROM Libro L INNER JOIN Categoria C 
	ON L.idCategoria = C.idCategoria 
	WHERE L.idCategoria = @idCategoria;
END
GO
