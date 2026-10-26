# Tony's Food | Sistema de Gestión para Rotisería

Tony's Food es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server, diseñada para facilitar la administración y las operaciones diarias de una rotisería.

El sistema permite gestionar usuarios, vendedores, productos, ventas y stock desde una misma aplicación. Cuenta con un inicio de sesión y distintas opciones de gestión para organizar las tareas del negocio y mantener la información centralizada.

## 📸 Funcionalidades del sistema

### 🔐 Inicio de sesión

El sistema cuenta con un formulario de login que permite a los usuarios ingresar utilizando sus credenciales. Este acceso sirve como punto de entrada a la aplicación y permite diferenciar las opciones disponibles según el perfil del usuario.

![Inicio de sesión](imagenes/login.png)

### 🏠 Menú principal del administrador

El menú del administrador funciona como el centro de navegación del sistema. Desde este formulario se puede acceder a las distintas herramientas de gestión, como vendedores, ventas, control diario y stock, facilitando el acceso a las tareas administrativas del negocio.

![Menú principal del administrador](imagenes/menu-administrador.png)

### 👥 Gestión de vendedores

Este formulario está destinado a la administración de los vendedores que utilizan el sistema. Permite registrar nuevos vendedores y gestionar la información de los usuarios asociados a esta función. Su objetivo es mantener organizados los datos del personal y facilitar la administración de los accesos al sistema.

![Formulario de vendedores](imagenes/vendedores.png)

### 📊 Control diario

El formulario de control diario permite consultar y supervisar la actividad del negocio durante la jornada. Su finalidad es facilitar el seguimiento de las operaciones realizadas y disponer de información útil para revisar el movimiento diario de la rotisería.

![Control diario](imagenes/control-diario.png)

### 🧾 Nueva venta

Este formulario se utiliza para registrar las ventas realizadas en la rotisería. Permite gestionar los productos que forman parte de una operación y registrar la venta correspondiente, ayudando a organizar las transacciones y mantener un seguimiento de las ventas del negocio.

![Formulario de nueva venta](imagenes/nueva-venta.png)

### 📦 Gestión de stock

El formulario de stock permite administrar y consultar la información de las existencias del negocio. Está orientado al seguimiento de los insumos y productos utilizados en la rotisería, ayudando a controlar las cantidades disponibles y a mantener actualizada la información relacionada con el inventario.

![Formulario de stock](imagenes/stock.png)

## 🛠️ Tecnologías utilizadas

- **C#** — Lenguaje de programación.
- **Windows Forms** — Desarrollo de la interfaz gráfica.
- **SQL Server** — Base de datos para almacenar la información del sistema.
- **ADO.NET** — Acceso e interacción con la base de datos.
- **Visual Studio** — Entorno de desarrollo.
- **Git y GitHub** — Control de versiones y gestión del repositorio.

## 🏗️ Arquitectura del proyecto

El proyecto está organizado en capas para separar las responsabilidades y facilitar el mantenimiento del código.

- **Vistas:** contienen los formularios y las interfaces con las que interactúa el usuario.
- **Negocio:** concentra la lógica y las reglas de funcionamiento del sistema.
- **Datos:** gestiona las operaciones de acceso a la base de datos.
- **Entidades:** contiene las clases que representan los datos utilizados por la aplicación.

## 🎯 Objetivo del proyecto

Desarrollar un sistema de gestión para una rotisería aplicando conocimientos de programación orientada a objetos, interfaces gráficas, bases de datos relacionales y separación de responsabilidades en capas.

El proyecto integra distintas funcionalidades en una aplicación de escritorio, buscando simplificar las tareas administrativas y mejorar la organización de la información del negocio.
