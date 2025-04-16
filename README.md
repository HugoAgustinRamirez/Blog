# Microblogging API

API simplificada tipo Twitter para publicar tweets, seguir usuarios y ver timelines.  

## 📌 Requerimientos Cumplidos

- **Tweets**: 
  - Publicar mensajes ≤ 280 caracteres.
- **Follows**: 
  - Seguir/dejar de seguir usuarios.
- **Timeline**: 
  - Ver tweets de usuarios seguidos (paginado).
- **Assumptions**:
  - No hay autenticación (`userId` se envía por header/body).
  - Optimizada para lecturas rápidas.

## 🚀 Tecnologías

| Capa           | Tecnologías                                                                 |
|----------------|----------------------------------------------------------------------------|
| **API**        | .NET 8, Minimal APIs, Swagger                                      |
| **Application**|  DTOs, Validaciones                                       |
| **Domain**     | Entidades, Interfaces de Repositorios                                      |
| **Infrastructure**| EF Core (InMemory), Repositorios       |

## 🏗️ Arquitectura

```plaintext
Onion Architecture + Vertical Slices
.
├── API/                 # Endpoints (Minimal APIs)
├── Application/         # Casos de uso, DTOs
├── Domain/              # Entidades, Contracts
└── Infrastructure/      # Implementaciones (EF Core, Repositorios)
```

## 🗃️ ¿Por qué PostgreSQL?
PostgreSQL es aconsejado para este proyecto por:

- **✅** Alto desempeño en lecturas (ideal para timelines frecuentes)
- **✅** Escalabilidad (soporta millones de registros)
- **✅** ACID (garantiza consistencia en operaciones críticas)
- **✅** JSON/Full-Text Search (útil para futuras features como búsqueda de tweets)

Se utiliza EF Core InMemory para simplificar las pruebas.
