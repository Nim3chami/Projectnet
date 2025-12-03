# **Network Traffic Optimization System**
### *Real-Time Traffic Monitoring • Traffic Shaping • Content Filtering*

A unified, lightweight, Windows-based network optimization system integrating **packet-level monitoring**, **bandwidth shaping**, and **domain-level content filtering**.  
Developed using **C#** and **WinDivert**, this project demonstrates how real-time network control and security can be achieved in a single platform.

---

## 📘 **Research Paper**
📄 Full research paper (PDF):  
**[Research paper – Network Optimization](Research%20paper%20Network%20Optimization.pdf)**

---

## 🚀 **Project Overview**
Modern networks face congestion, bandwidth misuse, and increasing security risks. Most tools solve only one problem—either monitoring, shaping, or filtering.  

This project introduces a **unified system** that:

- Monitors live packet traffic  
- Controls bandwidth using shaping rules  
- Filters unwanted domains/content  
- Visualizes traffic patterns in real time  
- Uses packet-level interception for deeper control  

This makes it ideal for **SME networks**, **labs**, and **academic demonstrations**.

---

## 🛠 **Tech Stack**
- **C# (.NET Framework)** – Application logic & GUI  
- **WinDivert** – Packet capture, filtering, and injection  
- **Windows Forms / WPF** – Visualization & user interface  
- **Custom blocklists** – Domain & keyword filtering  
- **Real-time charts** – Traffic visualization  

---

## ✨ **Key Features**

### **📡 Real-Time Traffic Monitoring**
- Packet-level inspection  
- Bandwidth calculation (upload/download)  
- Protocol distribution stats  
- Live charts & visual updates  

### **🚦 Traffic Shaping (Bandwidth Control)**
- Rule-based throttling  
- Token-bucket–inspired flow algorithm  
- Application/Protocol-based limits  
- Smooth and predictable traffic behavior  

### **🔒 Content Filtering**
- Domain & keyword blocking  
- Uses DNS, HTTP headers, and TLS SNI  
- Blocks packets before application layer  
- Lightweight + high accuracy  

### **📊 Unified Comparison With Other Tools**

| Feature | Wireshark | NetLimiter | Proposed System |
|--------|-----------|-------------|------------------|
| Real-Time Monitoring | ✔ | Limited | ✔ |
| Traffic Shaping | ✖ | ✔ | ✔ |
| Content Filtering | ✖ | ✖ | ✔ |
| Packet-Level Control | ✔ | Partial | ✔ |
| Unified Platform | ✖ | ✖ | ✔ |

---

## 🖼 **Screenshots**

![Dashboard](/images/traffic monitoring.jpg)
![Traffic Shaping](/images/traffic shaping.jpg)
![Content Filtering](docs/images/content_filtering.png)
