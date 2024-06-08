CREATE TABLE MovimientosCaja (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoMovimiento VARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Monto DECIMAL(18, 2) NOT NULL,
    Fecha DATETIME NOT NULL
);

SELECT * FROM MovimientosCaja