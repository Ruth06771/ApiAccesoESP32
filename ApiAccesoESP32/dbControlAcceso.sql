CREATE TABLE Registros (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Uid NVARCHAR(50),
    Nombre NVARCHAR(100),
    Metodo NVARCHAR(20),     -- "PIN" o "RFID"
    Accion NVARCHAR(20),     -- "RETIRAR" o "DEVOLVER"
    FechaHora DATETIME DEFAULT GETDATE()
);
 