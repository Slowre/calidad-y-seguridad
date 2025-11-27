# 🌦️ Weather App — Pruebas y Funcionalidades

Este documento muestra las pruebas realizadas, incluyendo flujo de usuario, funcionamiento del sistema y validaciones contra ataques de inyección (OWASP A3).

Las imágenes utilizadas se encuentran en la carpeta `readme-images/`.

---

# 🔐 1. Registro de Usuario

## 📌 Vista del formulario de registro
<p align="center">
  <img src="../assets/register.png" width="400">
</p>

## 📌 Registro exitoso
<p align="center">
  <img src="../assets/register_user.png" width="450">
</p>

---

# 🔑 2. Inicio de Sesión (Login)

## 📌 Vista de login
<p align="center">
  <img src="../assets/login.png" width="400">
</p>

## 📌 Prueba login usuario 1
<p align="center">
  <img src="../assets/login_user_1.png" width="450">
</p>

## 📌 Prueba login usuario 2
<p align="center">
  <img src="../assets/login_user_2.png" width="450">
</p>

---

# 🌤️ 3. Consulta de Weather Forecast

## 📌 Vista del usuario consultando su propio Weather
<p align="center">
  <img src="../assets/weather1.png" width="500">
</p>

## 📌 Segundo usuario mostrando su información
<p align="center">
  <img src="../assets/weather2.png" width="500">
</p>

---

# 🔎 4. Consulta por ID — Weather por Usuario

## 📌 get_weather_user_1
<p align="center">
  <img src="../assets/get_weather_user_1.png" width="550">
</p>

## 📌 get_weather_user_2
<p align="center">
  <img src="../assets/get_weather_user_2.png" width="550">
</p>

---

# 🛡️ 5. OWASP A3 — SQL Injection Tests

A continuación se muestran las pruebas realizadas para validar que el sistema **no es vulnerable a SQL Injection**, tanto en login, registro y creación de Weather.

---

## 🧪 5.1 Inyección en Login

### 1️⃣ Intento de inyección
<p align="center">
  <img src="../assets/injection_login.png" width="450">
</p>

### 2️⃣ Resultado — No vulnerable
<p align="center">
  <img src="../assets/injection_login_2_result.png" width="450">
</p>

### 3️⃣ Otro intento
<p align="center">
  <img src="../assets/injection_login_3_result.png" width="450">
</p>

### 4️⃣ Último intento fallido
<p align="center">
  <img src="../assets/injection_login_4_result.png" width="450">
</p>

---

## 🧪 5.2 Inyección en Registro

### 1️⃣ Intento de inyección
<p align="center">
  <img src="../assets/injection_register_1.png" width="450">
</p>

### 2️⃣ Resultado — Backend sanitiza correctamente
<p align="center">
  <img src="../assets/injection_register_1_result.png" width="450">
</p>

---

## 🧪 5.3 Inyección al crear Weather (POST /weather)

### Intento de inyección en los campos del Weather
<p align="center">
  <img src="../assets/injection_create_weather.png" width="500">
</p>

---

# 🏁 Conclusión

El sistema implementa:

- 🔐 Sanitización en backend (anti-XSS)
- 🛡️ EF Core parametrizado → evita SQL Injection
- ✔ JWT con validación fuerte
- ✔ CORS configurado correctamente
- ✔ Acceso por usuario (Broken Access Control mitigado)
- ✔ Validación completa del lado backend

Todas las pruebas de inyección fueron bloqueadas exitosamente.

---