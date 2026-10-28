# 🌿 EcoSal Sense: Smart Soil Salinity Monitoring and Remediation System

> An advanced IoT and software engineering solution designed to monitor soil salinity in real-time and provide precise biochar application recommendations for sustainable agriculture and land restoration. Developed for ISEF.

---

## 🚀 About the Project
Soil salinity is a major agricultural challenge that severely degrades crop yields and soil health. **EcoSal Sense** integrates Internet of Things (IoT) hardware with a robust .NET 8 backend built using **Clean Architecture** principles to automatically analyze soil conditions (Moisture & TDS levels) and calculate exact biochar remediation dosages to neutralize salt stress.

---

## 🏛️ System Architecture (Clean Architecture)
The backend is structured into four decoupled, highly maintainable layers:
1. **Core:** Contains domain entities, business models, DTOs, and repository interfaces.
2. **Data:** Implements Entity Framework Core, database contexts, and concrete data repositories with **SQLite**.
3. **Services:** Houses the core business logic, including the `SoilAnalysisService` algorithm for salt stress evaluation and biochar dosing.
4. **Presentation (API):** ASP.NET Core Web API controllers exposing endpoints for IoT devices and clients.

---

## 🛠️ Tech Stack & Technologies
* **Backend:** C#, .NET 8, ASP.NET Core Web API, Entity Framework Core, LINQ
* **Database:** SQLite (`ecosal.db`)
* **Testing:** xUnit (Unit Testing for core business services)
* **Hardware & Firmware:** ESP32 Microcontroller, Soil Moisture Sensor, TDS Sensor, Arduino IDE (C++)
* **Version Control:** Git & GitHub

---

## 🔌 IoT Firmware Workflow
1. The **ESP32** microcontroller reads analog sensor data (Soil Moisture and Total Dissolved Solids - TDS).
2. Packages the telemetry data into a JSON payload.
3. Automatically transmits data via **HTTP POST** requests to the ASP.NET Core backend API endpoint every designated interval.
4. The backend evaluates the data and returns optimal soil remediation recommendations.

---

## 🧪 Testing
The project includes robust unit tests written with **xUnit** inside the `EcoSal-Sense.Tests` project to ensure algorithmic accuracy for soil condition evaluation and biochar dosing under varying environmental parameters.

---

## 👨‍💻 Author
* **Ahmed Ghalaab** - Software Development & Computer Science Student (Fathalla International Applied Technology School)