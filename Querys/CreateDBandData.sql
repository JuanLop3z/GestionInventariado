-- Crear base de datos
CREATE DATABASE inventario;

-- Conectarse a la base
\c inventario;

-- Crear tabla productos
CREATE TABLE productos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    cantidad INT NOT NULL
);

-- Insertar datos iniciales
INSERT INTO productos (nombre, cantidad) VALUES
('Teclado Mecánico', 15),
('Mouse Inalámbrico', 30),
('Monitor 24"', 8);