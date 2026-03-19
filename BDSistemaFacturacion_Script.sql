-- =============================================
-- BASE DE DATOS: BDSistemaFacturacion
-- =============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BDSistemaFacturacion')
    DROP DATABASE BDSistemaFacturacion;
GO

CREATE DATABASE BDSistemaFacturacion;
GO

USE BDSistemaFacturacion;
GO

------------------------------------------------
-- TABLAS
------------------------------------------------

CREATE TABLE Categorias (
    IdCategoria     INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Clientes (
    IdCliente  INT IDENTITY(1,1) PRIMARY KEY,
    Nombre     NVARCHAR(150) NOT NULL,
    Documento  NVARCHAR(20)  NOT NULL,
    Direccion  NVARCHAR(200),
    Correo     NVARCHAR(100)
);
GO

CREATE TABLE Roles (
    IdRol       INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol   NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Empleados (
    IdEmpleado    INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        NVARCHAR(150) NOT NULL,
    Documento     NVARCHAR(20),
    Direccion     NVARCHAR(200),
    Telefono      NVARCHAR(20),
    Email         NVARCHAR(100),
    IdRol         INT,
    FechaIngreso  DATE,
    FechaRetiro   DATE,
    Detalles      NVARCHAR(500),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);
GO

CREATE TABLE Usuarios (
    IdUsuario   INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado  INT          NOT NULL,
    Usuario     NVARCHAR(50) NOT NULL UNIQUE,
    Clave       NVARCHAR(100) NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);
GO

CREATE TABLE Productos (
    IdProducto     INT IDENTITY(1,1) PRIMARY KEY,
    Codigo         NVARCHAR(50)  NOT NULL,
    NombreProducto NVARCHAR(150) NOT NULL,
    PrecioCompra   DECIMAL(10,2) NOT NULL,
    PrecioVenta    DECIMAL(10,2) NOT NULL,
    Stock          INT           NOT NULL DEFAULT 0,
    RutaImagen     NVARCHAR(300),
    Detalles       NVARCHAR(500),
    IdCategoria    INT,
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);
GO

------------------------------------------------
-- DATOS INICIALES
------------------------------------------------

INSERT INTO Categorias (NombreCategoria) VALUES
    ('General'), ('Electronica'), ('Ropa'), ('Alimentos');

INSERT INTO Roles (NombreRol) VALUES
    ('Administrador'),
    ('Empleado'),
    ('Usuario'),
    ('Vendedor'),
    ('Supervisor'),
    ('Cliente');

INSERT INTO Empleados (Nombre, Documento, IdRol) VALUES
    ('Administrador', '000000001', 1);

INSERT INTO Usuarios (IdEmpleado, Usuario, Clave) VALUES
    (1, 'admin', 'admin123');

INSERT INTO Productos (Codigo, NombreProducto, PrecioCompra, PrecioVenta, Stock, RutaImagen, Detalles, IdCategoria) VALUES
    ('PROD-001', 'Producto Demo', 10.00, 15.00, 100, '', 'Producto de ejemplo por defecto', 1);
GO

------------------------------------------------
-- STORED PROCEDURES - LOGIN
------------------------------------------------

CREATE OR ALTER PROCEDURE sp_ValidarLogin
    @Usuario NVARCHAR(50),
    @Clave   NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.IdUsuario, u.Usuario, e.Nombre, r.NombreRol AS Rol
    FROM Usuarios u
    INNER JOIN Empleados e ON u.IdEmpleado = e.IdEmpleado
    LEFT  JOIN Roles     r ON e.IdRol      = r.IdRol
    WHERE u.Usuario = @Usuario AND u.Clave = @Clave;
END;
GO

------------------------------------------------
-- STORED PROCEDURES - CLIENTES
------------------------------------------------

CREATE OR ALTER PROCEDURE sp_ListarClientes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCliente, Nombre, Documento, Direccion, Correo
    FROM Clientes
    ORDER BY Nombre;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarClientes
    @Criterio NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCliente, Nombre, Documento, Direccion, Correo
    FROM Clientes
    WHERE Nombre    LIKE '%' + @Criterio + '%'
       OR Documento LIKE '%' + @Criterio + '%'
    ORDER BY Nombre;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerClientePorId
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCliente, Nombre, Documento, Direccion, Correo
    FROM Clientes
    WHERE IdCliente = @IdCliente;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarCliente
    @Nombre    NVARCHAR(150),
    @Documento NVARCHAR(20),
    @Direccion NVARCHAR(200),
    @Correo    NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes (Nombre, Documento, Direccion, Correo)
    VALUES (@Nombre, @Documento, @Direccion, @Correo);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarCliente
    @IdCliente INT,
    @Nombre    NVARCHAR(150),
    @Documento NVARCHAR(20),
    @Direccion NVARCHAR(200),
    @Correo    NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Nombre    = @Nombre,
        Documento = @Documento,
        Direccion = @Direccion,
        Correo    = @Correo
    WHERE IdCliente = @IdCliente;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarCliente
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Clientes WHERE IdCliente = @IdCliente;
END;
GO

------------------------------------------------
-- STORED PROCEDURES - PRODUCTOS
------------------------------------------------

CREATE OR ALTER PROCEDURE sp_ListarProductos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.IdProducto, p.Codigo, p.NombreProducto, p.PrecioCompra,
           p.PrecioVenta, p.Stock, p.RutaImagen, p.Detalles,
           p.IdCategoria, c.NombreCategoria
    FROM Productos p
    LEFT JOIN Categorias c ON p.IdCategoria = c.IdCategoria
    ORDER BY p.NombreProducto;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarProductos
    @Criterio NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.IdProducto, p.Codigo, p.NombreProducto, p.PrecioCompra,
           p.PrecioVenta, p.Stock, p.RutaImagen, p.Detalles,
           p.IdCategoria, c.NombreCategoria
    FROM Productos p
    LEFT JOIN Categorias c ON p.IdCategoria = c.IdCategoria
    WHERE p.NombreProducto LIKE '%' + @Criterio + '%'
       OR p.Codigo         LIKE '%' + @Criterio + '%'
    ORDER BY p.NombreProducto;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerProductoPorId
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdProducto, Codigo, NombreProducto, PrecioCompra,
           PrecioVenta, Stock, RutaImagen, Detalles, IdCategoria
    FROM Productos
    WHERE IdProducto = @IdProducto;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarProducto
    @Codigo         NVARCHAR(50),
    @NombreProducto NVARCHAR(150),
    @PrecioCompra   DECIMAL(10,2),
    @PrecioVenta    DECIMAL(10,2),
    @Stock          INT,
    @RutaImagen     NVARCHAR(300),
    @Detalles       NVARCHAR(500),
    @IdCategoria    INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Productos (Codigo, NombreProducto, PrecioCompra, PrecioVenta, Stock, RutaImagen, Detalles, IdCategoria)
    VALUES (@Codigo, @NombreProducto, @PrecioCompra, @PrecioVenta, @Stock, @RutaImagen, @Detalles, @IdCategoria);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarProducto
    @IdProducto     INT,
    @Codigo         NVARCHAR(50),
    @NombreProducto NVARCHAR(150),
    @PrecioCompra   DECIMAL(10,2),
    @PrecioVenta    DECIMAL(10,2),
    @Stock          INT,
    @RutaImagen     NVARCHAR(300),
    @Detalles       NVARCHAR(500),
    @IdCategoria    INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Productos
    SET Codigo         = @Codigo,
        NombreProducto = @NombreProducto,
        PrecioCompra   = @PrecioCompra,
        PrecioVenta    = @PrecioVenta,
        Stock          = @Stock,
        RutaImagen     = @RutaImagen,
        Detalles       = @Detalles,
        IdCategoria    = @IdCategoria
    WHERE IdProducto = @IdProducto;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarProducto
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Productos WHERE IdProducto = @IdProducto;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarCategorias
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCategoria, NombreCategoria FROM Categorias ORDER BY NombreCategoria;
END;
GO

------------------------------------------------
-- STORED PROCEDURES - SEGURIDAD
------------------------------------------------

CREATE OR ALTER PROCEDURE sp_ListarRoles
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdRol, NombreRol FROM Roles ORDER BY NombreRol;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarEmpleados
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.IdEmpleado, e.Nombre, e.Documento, e.Telefono, e.Email,
           r.NombreRol AS Rol, e.FechaIngreso
    FROM Empleados e
    LEFT JOIN Roles r ON e.IdRol = r.IdRol
    ORDER BY e.Nombre;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarEmpleados
    @Criterio NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.IdEmpleado, e.Nombre, e.Documento, e.Telefono, e.Email,
           r.NombreRol AS Rol, e.FechaIngreso
    FROM Empleados e
    LEFT JOIN Roles r ON e.IdRol = r.IdRol
    WHERE e.Nombre     LIKE '%' + @Criterio + '%'
       OR e.Documento  LIKE '%' + @Criterio + '%'
       OR e.Email      LIKE '%' + @Criterio + '%'
    ORDER BY e.Nombre;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerEmpleadoPorId
    @IdEmpleado INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdEmpleado, Nombre, Documento, Direccion, Telefono, Email,
           IdRol, FechaIngreso, FechaRetiro, Detalles
    FROM Empleados
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarEmpleado
    @Nombre       NVARCHAR(150),
    @Documento    NVARCHAR(20),
    @Direccion    NVARCHAR(200),
    @Telefono     NVARCHAR(20),
    @Email        NVARCHAR(100),
    @IdRol        INT,
    @FechaIngreso DATE,
    @FechaRetiro  DATE = NULL,
    @Detalles     NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Empleados (Nombre, Documento, Direccion, Telefono, Email,
                           IdRol, FechaIngreso, FechaRetiro, Detalles)
    VALUES (@Nombre, @Documento, @Direccion, @Telefono, @Email,
            @IdRol, @FechaIngreso, @FechaRetiro, @Detalles);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarEmpleado
    @IdEmpleado   INT,
    @Nombre       NVARCHAR(150),
    @Documento    NVARCHAR(20),
    @Direccion    NVARCHAR(200),
    @Telefono     NVARCHAR(20),
    @Email        NVARCHAR(100),
    @IdRol        INT,
    @FechaIngreso DATE,
    @FechaRetiro  DATE = NULL,
    @Detalles     NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Empleados
    SET Nombre       = @Nombre,
        Documento    = @Documento,
        Direccion    = @Direccion,
        Telefono     = @Telefono,
        Email        = @Email,
        IdRol        = @IdRol,
        FechaIngreso = @FechaIngreso,
        FechaRetiro  = @FechaRetiro,
        Detalles     = @Detalles
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarEmpleado
    @IdEmpleado INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Empleados WHERE IdEmpleado = @IdEmpleado;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarUsuariosSistema
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.IdUsuario, u.Usuario, e.Nombre AS NombreEmpleado
    FROM Usuarios u
    INNER JOIN Empleados e ON u.IdEmpleado = e.IdEmpleado
    ORDER BY u.Usuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarUsuario
    @IdUsuario INT,
    @Usuario   NVARCHAR(50),
    @Clave     NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuarios
    SET Usuario = @Usuario, Clave = @Clave
    WHERE IdUsuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUsuarioPorEmpleado
    @IdEmpleado INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, Usuario, Clave
    FROM Usuarios
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarSeguridad
    @IdEmpleado INT,
    @Usuario    NVARCHAR(50),
    @Clave      NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Usuarios WHERE IdEmpleado = @IdEmpleado)
    BEGIN
        UPDATE Usuarios
        SET Usuario = @Usuario, Clave = @Clave
        WHERE IdEmpleado = @IdEmpleado;
    END
    ELSE
    BEGIN
        INSERT INTO Usuarios (IdEmpleado, Usuario, Clave)
        VALUES (@IdEmpleado, @Usuario, @Clave);
    END
END;
GO
