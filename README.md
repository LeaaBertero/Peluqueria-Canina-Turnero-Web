# 🐾 Sistema de Gestión de Turnos y Clientes para Peluquería Canina

Aplicación web desarrollada en **.NET / C#** diseñada para digitalizar, centralizar y automatizar la gestión operativa de centros de estética canina y veterinarias.

---

## 📌 Problema de Negocio que Resuelve

En los servicios de estética canina tradicionales, la gestión manual de citas (vía WhatsApp o cuadernos de papel) genera problemas operativos recurrentes:
* **Superposición de horarios:** Falta de validación en tiempo real de turnos disponibles según la duración estimada de cada servicio.
* **Pérdida de trazabilidad del paciente/mascota:** Dificultad para registrar y consultar historial de atenciones, temperamento del animal, condiciones especiales o frecuencia de visita.
* **Ineficiencia en la atención al cliente:** Tiempos de espera innecesarios y cancelaciones por falta de un flujo de reservas claro y estructurado.

**Solución implementada:**  
Una plataforma centralizada donde el cliente puede registrar a sus mascotas y autogestionar reservas según disponibilidad horaria real, permitiendo a la administración visualizar la agenda diaria, reducir ausencias y mantener un registro estructurado de cada cliente y servicio.

---

## 🚀 Funcionalidades Principales

* **Gestión de Mascotas y Clientes:** Alta, edición y vinculación relacional de tutores con una o múltiples mascotas (raza, tamaño, notas de cuidado).
* **Motor de Turnos y Disponibilidad:** Asignación de citas evitando colisiones de horarios entre turnos activos.
* **Catálogo de Servicios:** Administración de prestaciones (baño, corte higiénico, deslanado, corte de raza) con asignación de precios y tiempos estimados.
* **Control de Estados:** Seguimiento del ciclo de vida del turno (*Pendiente*, *Confirmado*, *Completado*, *Cancelado*).

---

## 🛠️ Stack Tecnológico y Arquitectura

* **Lenguaje:** C# (.NET)
* **Persistencia de Datos:** SQL Server / SQLite con modelado relacional normalizado.
* **Acceso a Datos:** Entity Framework Core / ADO.NET (consultas parametrizadas, migraciones y mapeo objeto-relacional).
* **Control de Versiones:** Git & GitHub (flujo de trabajo con ramas temáticas).
* **Patrones aplicados:** Separación de responsabilidades en capas (Controladores/Lógica de Negocio/Acceso a Datos) y principios de código limpio.

---

## 🗄️ Modelo Relacional de Base de Datos

El esquema relacional fue diseñado para garantizar integridad referencial y escalabilidad:
* `Clientes` (1 : N) `Mascotas`
* `Mascotas` (1 : N) `Turnos`
* `Servicios` (1 : N) `Turnos`

---

## ⚙️ Instalación y Ejecución Local

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/LeaaBertero/Peluqueria-Canina-Turnero-Web.git](https://github.com/LeaaBertero/Peluqueria-Canina-Turnero-Web.git)
