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
('Teclado Mecánico RGB', 15),
('Mouse Inalámbrico Logitech', 30),
('Monitor LED 24"', 8),
('Monitor Curvo 27"', 5),
('Portátil Lenovo ThinkPad', 12),
('Portátil HP Pavilion', 10),
('Disco Duro Externo 1TB', 20),
('Disco Duro SSD 512GB', 18),
('Memoria RAM 8GB DDR4', 25),
('Memoria RAM 16GB DDR4', 14),
('Auriculares Gamer HyperX', 22),
('Auriculares Bluetooth Sony', 16),
('Silla Gamer Cougar', 7),
('Webcam Full HD Logitech', 11),
('Micrófono Condensador USB', 9),
('Tarjeta Gráfica RTX 3060', 4),
('Tarjeta Gráfica GTX 1660', 6),
('Impresora HP LaserJet', 13),
('Router WiFi TP-Link', 19),
('Tablet Samsung Galaxy Tab A8', 10);
