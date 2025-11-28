# Documentación de Endpoints - API `spotify`

Este proyecto es una API RESTful que simula funcionalidades clave de una plataforma de música, desarrollado en **ASP.NET Core** bajo una arquitectura de **capas** (Controller ➜ Service ➜ Repository) y utilizando **Entity Framework Core** para la gestión de datos.

## Arquitectura y Tecnologías

| Componente | Descripción |
| :--- | :--- |
| **Framework** | ASP.NET Core API |
| **Lenguaje** | C# |
| **Persistencia** | Entity Framework Core |
| **Autenticación** | JWT (JSON Web Tokens) Bearer |
| **Patrón** | Arquitectura por Capas (Controller ➜ Service ➜ Repository) |
| **Base URL** | `http://localhost:[PUERTO_DEL_PROYECTO]/api/` |

---

## Endpoints de Autenticación (`AuthController`)

Ruta base: `/api/auth`

| Método | Endpoint | Descripción | Requiere Auth | Body (DTO) | Respuesta Exitosa |
| :---: | :--- | :--- | :---: | :---: | :---: |
| `POST` | `/register` | Registra un nuevo usuario en el sistema. | No | `RegisterDto` | `201 Created` |
| `POST` | `/login` | Inicia sesión, valida credenciales y genera el par **Access Token** y **Refresh Token**. | No | `LoginDto` | `200 OK` (Tokens) |
| `POST` | `/logout` | Invalida el **Refresh Token** para cerrar la sesión activa. | No | `LogoutDto` | `200 OK` |
| `POST` | `/refresh` | Genera un nuevo **Access Token** utilizando un **Refresh Token** válido (para mantener la sesión). | No | `RefreshRequestDto` | `200 OK` (Nuevos Tokens) |

---

## Endpoints de Artistas (`ArtistController`)

Ruta base: `/api/artist`

| Método | Endpoint | Descripción | Requiere Auth | Body (DTO) | Respuesta Exitosa |
| :---: | :--- | :--- | :---: | :---: | :---: |
| `GET` | `/` | Obtiene la lista completa de todos los artistas. | No | N/A | `200 OK` (Lista de artistas) |
| `GET` | `/{id}` | Obtiene un artista específico por su **Guid ID**. | No | N/A | `200 OK` (Artist DTO) |
| `POST` | `/` | Crea un nuevo registro de artista. | No | `CreateArtistDto` | `201 Created` (Artist DTO) |
| `POST` | `/{id}/profile` | Crea o asocia un perfil detallado al artista especificado. | No | `CreateArtistProfileDto` | `200 OK` (Profile DTO) |

---

## Endpoints de Canciones (`SongController`)

Ruta base: `/api/song`

| Método | Endpoint | Descripción | Requiere Auth | Policy (Rol) | Body (DTO) | Respuesta Exitosa |
| :---: | :--- | :--- | :---: | :---: | :---: | :---: |
| `GET` | `/` | Obtiene una lista de todas las canciones en el catálogo. | No | N/A | N/A | `200 OK` (Lista de Songs) |
| `GET` | `/{id}` | Obtiene una canción por su **Guid ID**. | Sí | N/A | N/A | `200 OK` (Song DTO) |
| `POST` | `/` | Agrega una nueva canción al catálogo. | Sí | **AdminOnly** | `CreateSongDto` | `201 Created` (Song DTO) |
| `PUT` | `/{id}` | Actualiza la información de una canción existente. | Sí | **AdminOnly** | `UpdateSongDto` | `200 OK` (Song DTO actualizado) |
| `DELETE` | `/{id}` | Elimina una canción del catálogo. | Sí | **AdminOnly** | N/A | `204 No Content` |

---

## Endpoints de Playlists (`PlaylistController`)

Ruta base: `/api/playlist`

| Método | Endpoint | Descripción | Requiere Auth | Body (DTO) | Respuesta Exitosa |
| :---: | :--- | :--- | :---: | :---: | :---: |
| `GET` | `/` | Obtiene todas las *playlists* del sistema. | Sí | N/A | `200 OK` (Lista de Playlists) |
| `GET` | `/{id:guid}` | Obtiene una *playlist* específica por su **Guid ID**. | Sí | N/A | `200 OK` (Playlist DTO) |
| `POST` | `/` | Crea una nueva *playlist*. | Sí | `CreatePlaylistDto` | `201 Created` (Playlist DTO) |
| `PUT` | `/{id:guid}` | Actualiza los datos de una *playlist*. | Sí | `UpdatePlaylistDto` | `200 OK` (Playlist DTO actualizado) |
| `DELETE` | `/{id:guid}` | Elimina una *playlist*. | Sí | N/A | `204 No Content` |
| `POST` | `/{id:guid}/songs` | Agrega una canción a una *playlist* existente. | Sí | `AddSongToPlaylist` | `200 OK` |
| `DELETE` | `/{playlistId:guid}/songs/{songId:guid}` | Elimina una canción de la *playlist* especificada. | Sí | N/A | `2