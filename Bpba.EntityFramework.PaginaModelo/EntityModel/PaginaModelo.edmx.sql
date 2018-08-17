
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2018 11:33:38
-- Generated from EDMX file: C:\Users\BABC10A\Desktop\webPractice1\Bpba.EntityFramework.PaginaModelo\EntityModel\PaginaModelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pagina];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_PersonaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioSesion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sesiones] DROP CONSTRAINT [FK_UsuarioSesion];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_UsuarioPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioInventario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventarios] DROP CONSTRAINT [FK_UsuarioInventario];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloInventario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventarios] DROP CONSTRAINT [FK_ArticuloInventario];
GO
IF OBJECT_ID(N'[dbo].[FK_InventarioVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_InventarioVenta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Sesiones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sesiones];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Inventarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventarios];
GO
IF OBJECT_ID(N'[dbo].[Ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ventas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellido] nvarchar(max)  NOT NULL,
    [correo] nvarchar(max)  NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [pais] tinyint  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [pass] nvarchar(max)  NOT NULL,
    [Persona_id] int  NOT NULL,
    [lastlogin] datetime  NOT NULL
);
GO

-- Creating table 'Sesiones'
CREATE TABLE [dbo].[Sesiones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [key] nvarchar(max)  NOT NULL,
    [value] nvarchar(max)  NOT NULL,
    [isonline] bit  NOT NULL,
    [Usuario_id] int  NOT NULL,
    [duracion] time  NOT NULL,
    [initTime] datetime  NOT NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [acceso] tinyint  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [Usuario_id] int  NOT NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Inventarios'
CREATE TABLE [dbo].[Inventarios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [disponible] bit  NOT NULL,
    [precio] decimal(18,0)  NOT NULL,
    [ciudad] int  NOT NULL,
    [Usuario_id] int  NOT NULL,
    [Articulo_id] int  NOT NULL,
    [pais] tinyint  NOT NULL
);
GO

-- Creating table 'Ventas'
CREATE TABLE [dbo].[Ventas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [Inventario_id] int  NOT NULL,
    [comprador_id] int  NOT NULL,
    [status] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sesiones'
ALTER TABLE [dbo].[Sesiones]
ADD CONSTRAINT [PK_Sesiones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Inventarios'
ALTER TABLE [dbo].[Inventarios]
ADD CONSTRAINT [PK_Inventarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [PK_Ventas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Persona_id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_PersonaUsuario]
    FOREIGN KEY ([Persona_id])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaUsuario'
CREATE INDEX [IX_FK_PersonaUsuario]
ON [dbo].[Usuarios]
    ([Persona_id]);
GO

-- Creating foreign key on [Usuario_id] in table 'Sesiones'
ALTER TABLE [dbo].[Sesiones]
ADD CONSTRAINT [FK_UsuarioSesion]
    FOREIGN KEY ([Usuario_id])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioSesion'
CREATE INDEX [IX_FK_UsuarioSesion]
ON [dbo].[Sesiones]
    ([Usuario_id]);
GO

-- Creating foreign key on [Usuario_id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_UsuarioPerfil]
    FOREIGN KEY ([Usuario_id])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPerfil'
CREATE INDEX [IX_FK_UsuarioPerfil]
ON [dbo].[Perfiles]
    ([Usuario_id]);
GO

-- Creating foreign key on [Usuario_id] in table 'Inventarios'
ALTER TABLE [dbo].[Inventarios]
ADD CONSTRAINT [FK_UsuarioInventario]
    FOREIGN KEY ([Usuario_id])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioInventario'
CREATE INDEX [IX_FK_UsuarioInventario]
ON [dbo].[Inventarios]
    ([Usuario_id]);
GO

-- Creating foreign key on [Articulo_id] in table 'Inventarios'
ALTER TABLE [dbo].[Inventarios]
ADD CONSTRAINT [FK_ArticuloInventario]
    FOREIGN KEY ([Articulo_id])
    REFERENCES [dbo].[Articulos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloInventario'
CREATE INDEX [IX_FK_ArticuloInventario]
ON [dbo].[Inventarios]
    ([Articulo_id]);
GO

-- Creating foreign key on [Inventario_id] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [FK_InventarioVenta]
    FOREIGN KEY ([Inventario_id])
    REFERENCES [dbo].[Inventarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InventarioVenta'
CREATE INDEX [IX_FK_InventarioVenta]
ON [dbo].[Ventas]
    ([Inventario_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------