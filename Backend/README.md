# Ejecución del backend

La solución Backend.sln, contiene una aplicación ASP.NET Core Web API.

Se utilizo inyección de dependencias para las interfaces y sus implementaciones, así poder consumir la api https://rickandmortyapi.com/documentation/#rest

La estructura comprende:

- Controllers
  - Se encuentran los controladores que se podrían utilizar para obtener informacion necesaria, tales como: episodios, localizaciones y personajes.
- Implementaciones
  - Servicios para realizar las llamadas a la api de rickandmortiapi.com
- Interfaces
  - Interfaces que contiene métodos para realizar las llamadas a la api de rickandmortiapi.com
- Modelos
  Clases que representan los esquemas de rickandmortyapi.com, incluída las respuestas que estas entregan.

## Ejecución Desarrollo

Al abrir solución, se debe presionar al tecla "F5" para que comience la ejecución de la API.

Esta, abrirá una ventana del navegador con la información de los métodos disponibles para consumir. Esto gracias a swagger.

Se pueden realizar las pruebas del endpoint directamente con swagger o con postman. Áca se puede obtener la colección para probar los endpoints con postman https://www.getpostman.com/collections/cb4b39541f6518454a25
