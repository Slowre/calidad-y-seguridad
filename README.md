# 🌦️ Weather App – usuario + clima (Fullstack .NET + React)

Aplicación full-stack que permite registrar usuarios, iniciar sesión y gestionar registros de clima (WeatherForecast).  
Cada usuario tiene acceso únicamente a sus propios registros gracias a la autenticación mediante JWT.

---
## 🛠️ Instalación y ejecución del proyecto

### 🔹 1. Clonar el repositorio

```bash
git clone https://github.com/TU-USUARIO/TU-REPO.git
cd TU-REPO
```
🟦 Backend (.NET API)

📁 Ruta del backend:
```bash
/backend/Inventario
```
✔️ 2. Restaurar dependencias
```bash
cd backend/Inventario
dotnet restore
```
✔️ 3. Crear base de datos mediante migraciones

Si es la primera vez:
```bash
dotnet ef database update
```
⚠️ Requiere tener SQL Server en ejecución.
✔️ 4. Ejecutar backend
```bash
dotnet run
```

La API estará disponible en:
```bash
http://localhost:7002
```
🟩 Frontend (React + TanStack Router)

📁 Ruta del frontend:
```bash
/frontend
```
✔️ 5. Instalar dependencias
```bash
cd frontend
npm install
```
✔️ 6. Ejecutar en modo desarrollo
```bash
npm run dev
```
La aplicación estará en:

```bash
http://localhost:5173
```
