# Ejecución del frontend

La estructura comprende:

- app/models
  - Clases que representan los esquemas de las clases del backend. No se utilizo la mayoría de estos, solo los que se iban a utilizar en la prueba.
- app/pages
  - Componentes visuales y de funcionamiento para obtener información del backend.
- app/services
  - Servicios utilizados para comunicarse con la API del backend.
- app/utils
  Funcionalidades que se pueden utilizar en todos los servicios, en este caso la de parametros.
- environments
  Valores a utilizar según el ambiente, en este caso se utilizará el de desarrollo.

## Ejecución Desarrollo

Para ejecutar el proyecto, abrir una consola en directorio del front/rick-y-morty y ejecutar.

### `npm install`

Con esto se instalaran las dependencias que utiliza el proyecto.

Posteriormente, ejecutar el comando:

### `ng serve -o`

Esto levantará una instancia local en el puerto 4200 y una ventana o pestaña del navegador.<br />
Si no se levanta una ventana o pestaña del navegador utilizar esta url [http://localhost:4200](http://localhost:4200) en el navegador.

Ahora podrá navegar por el sitio para poder ver el funcionamiento.
