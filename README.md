# 🎰 Slot Machine Game

A polished 2D Slot Machine game developed in Unity with a strong focus on clean architecture, scalable systems, and maintainable gameplay programming.

---

# 📌 Project Goal

The goal of this project was not only to create a functional slot game, but also to practice industry-standard Unity architecture patterns, modular system design, and scalable gameplay systems.

---

# 🚀 Features

- 🎡 Reel spinning system
- 🎲 RNG-based symbol generation
- 🧠 Payline evaluation system
- ⚡ Event-driven architecture using Event Bus
- 🔄 Finite State Machine (FSM) for game flow
- 🧩 Interface-based decoupled systems
- 📦 ScriptableObject-driven game configuration
- 🔊 Audio feedback system
- ✨ UI animations and transitions
- 🛠️ Scalable and maintainable architecture

---

# 🧠 Architecture & Design Patterns

This project focuses heavily on clean architecture and scalable Unity development practices.

## ✅ Event Bus System
Implemented an event-driven communication system to reduce tight coupling between gameplay systems.

## ✅ Finite State Machine (FSM)
Game flow is controlled using FSM states such as:
- Idle State
- Spin State
- Result State
- Win State

## ✅ Interface-Based Design
Used interfaces to replace direct singleton dependencies and improve:
- Testability
- Flexibility
- Maintainability

## ✅ RNG System
Implemented Random Number Generation logic for:
- Reel symbol generation
- Fair spin outcomes

## ✅ Payline Evaluator
Custom payline evaluation system to:
- Detect winning combinations
- Calculate rewards
- Support scalable paylines

## ✅ Scriptable Objects
Used ScriptableObjects for:
- Symbol data configuration
- Payline definitions
- Easy designer-friendly balancing

---

# 🏗️ Programming Principles

- SOLID Principles
- Separation of Concerns
- Modular System Design
- Reusable Components
- Scalable Architecture

---

# 🛠️ Built With

- Unity
- C#
- DOTween
- ScriptableObjects
- FSM Architecture
- Event Bus Pattern

---

# 📂 Project Structure

```bash
Assets/
├── Scripts/
│   ├── Core
│   ├── Events
│   ├── FSM
│   ├── Interfaces
│   ├── Managers
│   ├── ReelSystem
│   ├── UI
│   └── PaylineSystem
├── ScriptableObjects
├── Audio
├── Prefabs
└── Art
