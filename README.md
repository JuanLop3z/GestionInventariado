# 📦 MiniSistema de Gestión de Inventario - CCL

Este es un sistema básico de gestión de inventario desarrollado como **prueba técnica**. Que nos permite a usuarios autenticados registrar **entradas/salidas de productos** y consultar el inventario actual.

---

## 🚀 Tecnologías Usadas

- **Backend:** C# .NET Core 9 + Entity Framework Core + PostgreSQL
- **Frontend:** Angular 19 + TypeScript
- **Base de Datos:** PostgreSQL
- **Autenticación:** JWT (Bearer Token)

---

## 📂 Estructura del Proyecto

```

.
├── querys/ # Scripts SQL para crear y poblar la base de datos
│ └── CreateDBandData.sql
├── InventarioBackend/ # API en .NET Core
├── InventarioFront/ # Aplicación Angular
└── README.md # Este archivo

```

---

## ⚙️ Configuración Previa

1. Tener instalado:

   - [PostgreSQL](https://www.postgresql.org/download/)
   - [.NET SDK 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
   - [Node.js](https://nodejs.org/) (v20 o superior recomendado)
   - [Angular CLI](https://angular.dev/tools/cli) (`npm install -g @angular/cli`)

2. Clonar el repositorio:
   ```bash
   git clone https://github.com/JuanLop3z/GestionInventariado.git
   cd GestionInventariado
   ```

## 🛢️ Base de Datos

1. Crear una base de datos en PostgreSQL llamada `inventario_ccl`.

   ```sql
   CREATE DATABASE inventario;
   ```

2. Ejecutar el script SQL dentro de la carpeta `querys/`:

   Esto creará la tabla `productos` y cargará datos iniciales.

---

## 🔙 Backend (.NET Core)

1. Ir a la carpeta del backend:

   ```bash
   cd InventarioBackend
   ```

2. Configurar la conexión a la BD en `appsettings.json`:

   ```json
    "ConnectionStrings": {
   "ConexionInventarioDB": "Host=localhost;Port=5432;Database=inventario;Username=postgres;Password=123456789;"
   }
   ```

3. Restaurar dependencias y correr la API:

   ```bash
   dotnet restore
   dotnet run
   ```

4. La API estará disponible con swagger en:

   ```
   https://localhost:7050/swagger/index.html
   ```

   ### Endpoints principales

   - `POST /JWTAuthentication/login` → Obtener JWT (credenciales en memoria).
   - `POST /productos/movimiento` → Registrar entrada/salida.
   - `GET /productos/inventario` → Consultar inventario.

---

## 🖥️ Frontend (Angular)

1. Ir a la carpeta del frontend:

   ```bash
   cd InventarioFrontend
   ```

2. Instalar dependencias:

   ```bash
   npm install
   ```

3. Ejecutar la aplicación:

   ```bash
   ng serve -o
   ```

4. Acceder en:

   ```
    http://localhost:4200/login
   ```

   ### Funcionalidades:

   - **Login** con usuario y contraseña fijos.
   - **Registro de movimientos** (entrada/salida de productos).
   - **Consulta del inventario** (listado de productos con cantidades).

---

## ✅ Credenciales de prueba

- **Usuario:** admin
- **Contraseña:** admin123

_(Se validan en memoria, no en base de datos)_

---

## ✨ Autor

Desarrollado por **Juan López** para la prueba técnica de **CCL**.
