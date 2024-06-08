CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Usuario NVARCHAR(50) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL
);

INSERT INTO Usuarios (Usuario, Nombre) VALUES
('user1', 'Usuario Uno'),
('user2', 'Usuario Dos'),
('user3', 'Usuario Tres');
