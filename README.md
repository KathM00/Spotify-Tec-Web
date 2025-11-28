#  Spotify API Clone - Proyecto Tecnologías Web 1

Este proyecto es una API RESTful desarrollada en **.NET 9** que simula las funcionalidades backend de una plataforma de streaming de música como Spotify. Permite la gestión de artistas, canciones, playlists y usuarios.

## ?? Descripción del Proyecto

El sistema está diseñado siguiendo una **Arquitectura en Capas** (Layered Architecture) para asegurar la escalabilidad y el mantenimiento del código. Gestiona las relaciones entre entidades musicales y perfiles de usuario.

### Funcionalidades Principales
- **Artistas:** Gestión de artistas y sus perfiles detallados (Biografía, Redes Sociales).
- **Canciones:** Catálogo de música asociado a artistas.
- **Playlists:** Creación de listas de reproducción públicas o privadas.
- **Usuarios:** Gestión de usuarios y roles.

---

## ?? Tecnologías Utilizadas

- **Framework:** .NET 8 (ASP.NET Core Web API)
- **Lenguaje:** C#
- **ORM:** Entity Framework Core
- **Base de Datos:** SQL Server
- **Documentación:** Swagger (OpenAPI)

---

## ?? Arquitectura del Proyecto

El proyecto sigue el patrón **Controller-Service-Repository**:

```
spotify/
Controllers/    # Puntos de entrada de la API (Reciben HTTP Requests)
Services/       # Lógica de negocio y validaciones
Repositories/   # Acceso directo a la base de datos (Entity Framework)
Models/         # Entidades del dominio (tablas de BD)
DTOs/       # Data Transfer Objects (Datos de entrada/salida)
Data/           # Configuración del DbContext
```

### Entidades del Dominio (Basado en UML)

1.  **Artist (Artista):** Entidad principal que compone canciones.
    * *Relación 1 a 1* con `ArtistProfile`.
    * *Relación 1 a N* con `Song`.
2.  **ArtistProfile (PerfilArtista):** Información extendida (Bio, Fecha Debut).
3.  **Song (Cancion):** Unidad básica de música.
4.  **Playlist:** Colección de canciones creada por un usuario.
5.  **User (Usuario):** Usuario de la plataforma con roles.

## ?? Endpoints Principales

### Artistas
- `GET /api/artist` - Obtener todos los artistas.
- `GET /api/artist/{id}` - Obtener un artista por ID.
- `POST /api/artist` - Crear un nuevo artista.
- `POST /api/artist/{id}/profile` - Agregar perfil a un artista existente.

---

## ?? Autores

- **Gadiel** - *Implementación de Artistas y Perfiles*
- **[Tu Equipo]** - *Implementación de Playlists y Canciones*