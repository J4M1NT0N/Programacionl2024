CREATE TABLE Productos (
    Codigo VARCHAR(50) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioIngreso DECIMAL(18, 2) NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    FechaIngreso DATE NOT NULL
);

SELECT * FROM Productos