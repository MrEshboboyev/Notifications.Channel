# 🔔 Notifications.Channel – Scalable Asynchronous Notifications in .NET 9 🚀  

![.NET 9](https://img.shields.io/badge/.NET%209-blue?style=for-the-badge)
![MediatR](https://img.shields.io/badge/MediatR-%E2%9C%85-green?style=for-the-badge)
![OpenTelemetry](https://img.shields.io/badge/OpenTelemetry-%F0%9F%94%A5-orange?style=for-the-badge)
![Asynchronous Messaging](https://img.shields.io/badge/Async%20Messaging-%F0%9F%9A%80-purple?style=for-the-badge)
![Docker](https://img.shields.io/badge/Docker-%F0%9F%90%A6-blue?style=for-the-badge)

## 🎯 Overview  

**Notifications.Channel** is a **high-performance, asynchronous notification system** built with **.NET 9**, **MediatR**, and **OpenTelemetry**. This solution provides **event-driven messaging** using a **custom channel-based publisher**, ensuring **scalability, reliability, and observability** for real-time notifications.  

> **Why Use Notifications.Channel?**  
> - 🚀 **Asynchronous & Non-Blocking** – Uses **channels for efficient notification handling**.  
> - 📡 **Event-Driven Design** – Implements **MediatR for pub/sub messaging**.  
> - 🔎 **Built-in Observability** – Integrated with **OpenTelemetry** for tracing.  
> - 🛠 **Docker-Ready & Scalable** – Deployable in **containerized environments**.  

---

## 🌟 Features  

✅ **.NET 9 Web API** – Built with the latest **ASP.NET Core framework**.  
✅ **MediatR Integration** – Implements **publish-subscribe (pub/sub) messaging**.  
✅ **Channel-Based Notifications** – Uses **custom channel publishers** for async handling.  
✅ **Multiple Notification Handlers** – Supports **parallel processing**.  
✅ **OpenTelemetry Tracing** – Provides **real-time observability**.  
✅ **Docker Support** – Easily deploy with **Docker containers**.  

---

## 🏗️ Architecture & Project Structure  

📌 **src/Notifications.Channel/Program.cs** – Configures **MediatR, OpenTelemetry**, and API setup.  
📌 **src/Notifications.Channel/ChannelPublisher.cs** – Implements the **custom channel-based publisher**.  
📌 **src/Notifications.Channel/OrderCreatedNotification.cs** – Defines the **notification event**.  
📌 **src/Notifications.Channel/NotificationHandlers/** – Contains **async notification handlers**.  

---

## 🚀 Getting Started  

### **📌 Prerequisites**  
✅ [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)  
✅ [Docker](https://www.docker.com/) (optional for containerization)  

### **Step 1: Clone the Repository**  
```bash
git clone https://github.com/yourusername/Notifications.Channel.git
cd Notifications.Channel
```

### **Step 2: Build & Run the Application**  
```bash
dotnet build
dotnet run --project src/Notifications.Channel
```

---

## 🐳 Running with Docker  

### **Step 1: Build Docker Image**  
```bash
docker build -t notifications-channel .
```

### **Step 2: Run Container**  
```bash
docker run -p 8080:80 notifications-channel
```

> 🔹 **Docker allows easy deployment** in **cloud environments** or **microservices architectures**.  

---

## 🌍 API Endpoints  

| Method | Endpoint   | Description |
|--------|-----------|-------------|
| **POST**  | `/orders`  | Creates a new order & triggers **OrderCreatedNotification** |

### **Example Request (cURL)**
```bash
curl -X POST http://localhost:8080/orders
```

> 📢 **When a new order is created**, the API **publishes an event** that triggers **multiple handlers** asynchronously.  

---

## 🔎 OpenTelemetry Integration  

This project is **pre-configured with OpenTelemetry** for **end-to-end tracing**, providing **real-time monitoring** of notifications.  

🔹 **Features**:  
✅ **ASP.NET Core Instrumentation** – Captures **request-response tracing**.  
✅ **OTLP Exporter** – Sends telemetry data to **external observability platforms**.  
✅ **Real-Time Monitoring** – View **end-to-end tracing** of notifications.  

---

## 📨 MediatR & Asynchronous Notifications  

### **How Notifications Work**  

1️⃣ **Client sends a POST request to `/orders`**.  
2️⃣ **MediatR publishes an `OrderCreatedNotification` event**.  
3️⃣ **ChannelPublisher asynchronously processes notifications**.  
4️⃣ **Multiple handlers consume the notification in parallel**.  

### **Notification Handlers**  

🔹 **OrderCreatedHandler** – Logs **order creation event**.  
🔹 **SlowOrderCreatedHandler** – Simulates a **delayed event handler**.  
🔹 **VerySlowOrderCreatedHandler** – Simulates a **long-running task**.  

> ⚡ **Handlers process events independently** without blocking the main request.  

---

## 🧪 Testing  

### **Unit Tests**  
Run tests to verify **notification handling and performance**:  
```bash
dotnet test
```

### **Manual API Testing**  
📌 **Use Postman or Swagger UI** to:  
✅ **Create an order** → `/orders`  
✅ **Check OpenTelemetry traces**  
✅ **Verify async notification handling**  

---

## 🎯 Why Use This Project?  

✅ **High-Performance Asynchronous Notifications** – Reduces **blocking operations**.  
✅ **Scalable & Fault-Tolerant** – Uses **channels & MediatR** for parallel execution.  
✅ **Full Observability with OpenTelemetry** – Provides **tracing & monitoring**.  
✅ **Production-Ready & Docker-Deployable** – Easily **scales in microservices**.  

---

## 📜 License  

This project is licensed under the **MIT License**. See [LICENSE](LICENSE) for details.  

---

## 📞 Contact  

For feedback, contributions, or questions:  
📧 **Email**: mreshboboyev@gmail.com  
💻 **GitHub**: [MrEshboboyev](https://github.com/MrEshboboyev)  

---

🚀 **Build scalable, event-driven APIs with Notifications.Channel!** Clone the repo & start now!  
