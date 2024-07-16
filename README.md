# Prueba_tecnica_felipe_Buitrago

En esta prueba técnica se requiere desarrollar un REST API utilizando .NET y C# que permita realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en las entidades Cliente, Facturas y Productos, de acuerdo con un diagrama de entidad-relación proporcionado. A continuación, se detallan los pasos y consideraciones para llevar a cabo esta tarea.

Diagrama de Entidad-Relación
El diseño del API se basará en el siguiente diagrama de entidad-relación:

[Cliente]
- Id (int, clave primaria)
- Nombre (string)
- Email (string)
- Teléfono (string)

[Factura]
- Id (int, clave primaria)
- ClienteId (int, clave foránea hacia Cliente)
- Fecha (DateTime)
- Total (decimal)

[Producto]
- Id (int, clave primaria)
- Nombre (string)
- PrecioUnitario (decimal)

Requisitos y Criterios de Evaluación
La evaluación se centrará en las siguientes áreas:

Habilidades de algorítmica.
Buenas prácticas de desarrollo.
Buenas prácticas de arquitectura de software y diseño de bases de datos.
Conocimiento de lenguaje SQL.
Dominio de .NET y elementos del lenguaje C#.
Pasos para Desarrollar el REST API
A continuación se presentan los pasos básicos para implementar el REST API:

Configuración del Proyecto

Crear un proyecto ASP.NET Core Web API.
Configurar la conexión a la base de datos (SQL Server, por ejemplo) en appsettings.json.
