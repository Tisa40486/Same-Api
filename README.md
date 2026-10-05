# 🗣️ SameApiUnitOfWork API

A RESTful Web API for a Same, built with **ASP.NET Core** and **Entity Framework Core**.  
This API allows clients to perform full CRUD operations on forum entities such as **Users**, **Threads**, **Posts**, and **Comments**.

---
## 🚀 Features

- Full CRUD for:
  - 🧑 Users
  - 📌 Threads
  - 💬 Posts
  - 🗨️ Comments
- Entity Framework Core with database migrations
- Swagger UI for interactive API documentation
- DTOs and AutoMapper for clean data handling
- CORS support for frontend integration
- Basic error handling and validation

---
## Database Model

You can find the detailed MLD diagram [here](./MLD.md).

## 🧱 Entities Overview

### User
- `id`, `isadmin`, `age`, `pseudo`, `email`, `password`, `number_follow`, `createAt`, `id_gender_fk`, `id_school_fk`, `id_post_fk` 

### Gender
- `id`, `gender`

### Tags
- `Id`, `createAt`, `tag_required`, `tag_optional`
### TAG_REQUIRED
- `Id`, `tag_required`
  
### TAG_OPTIONAL
- `Id`, `tag_optional`
  
### SCHOOL
- `Id`, `name`, `profession`

### PROFESSION
- `Id`, `name`


### Post
- `Id`, `ThreadId`, `id_user`, `Content`, `CreatedAt`

### Comment
- `Id`, `PostId`, `id_user`, `title`, `Content`, `CreatedAt`

---
## 🛠️ Technologies Used

- ASP.NET Core 6 / 7
- C#
- Entity Framework Core
- SQL Server / SQLite
- Swagger (Swashbuckle)
- AutoMapper

## 📁 Project Structure

SameApi:
  - 🗂️ SameApi.App:
    - Program.cs

  - 🗂️ SameApi.Business:
    - 📄 SameApiProfile.cs

  - 🗂️ SameApi.Data:
    - 📁 DbContexts:
      - 📄 BaseDbContext
      - 📄 IBaseDbContext
    - 📁 Model:
      - 📄 IModelDao.cs
    - 📁 Repository:
      - 📄 BaseRepository
      - 📄 IBaseRepository

  - 🗂️ SameApi.Db:
    - 📁 DbContexts:
      - 📄 SameApiDbContext.cs
      - 📄 ISameApiDbContext.cs
    - 📁 UnitOfWork:
      - 📄 SameApiUnitOfWork.cs
      - 📄 ISameApiUnitOfWork.cs

  - 🗂️ SameApi.Dto: 

  - 🗂️ SameApi.Model: 

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 9}(https://dotnet.microsoft.com/)
- DB Server
- Visual Studio or VS Code

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Tisa40486/Same.git
   
2. **API Endpoints**
   
| Method | Endpoint             | Description         |
| ------ | -------------------- | ------------------- |
| GET    | `/api/threads`       | Get all threads     |
| POST   | `/api/threads`       | Create a new thread |
| GET    | `/api/posts/{id}`    | Get a single post   |
| PUT    | `/api/posts/{id}`    | Update a post       |
| DELETE | `/api/comments/{id}` | Delete a comment    |


--

- 📬 Contact
  - 📧Same - same@sames.school
  - 🧑‍💻GitHub - https://github.com/Tisa40486

