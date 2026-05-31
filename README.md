# 🎰 Unity Slot Machine Game

A modular 2D Slot Machine game developed in Unity with a strong focus on scalable gameplay architecture, clean code practices, and reusable systems.

---

# 🚀 Features

* Reel spinning system
* RNG-based weighted symbol generation
* Payline evaluation system
* Wild symbol support
* Expanding Wild mechanic
* Event-driven architecture using Event Bus
* Finite State Machine (FSM) for game flow
* ScriptableObject-driven configuration
* Win animations and audio feedback

---

# 🧠 Architecture Highlights

This project focuses heavily on gameplay systems architecture and maintainable Unity development practices.

## ✅ Modular Reel System

Reel logic was refactored into separate systems:

* Reel Generator
* Reel Spinner
* Reel Stopper
* Reel Symbol Tracker

## ✅ Interface-Based Design

Used interfaces to decouple gameplay systems and improve scalability.

Examples:

* `IReel`
* `IReelSpinner`
* `IReelStopper`
* `IReelGenerator`
* `IReelSymbolTracker`
* `IPaylineService`
* `IGridModifier`

## ✅ Modifier-Based Gameplay System

Implemented an expanding wild modifier system that modifies grid data independently from UI rendering.

This architecture supports future mechanics such as:

* Sticky Wilds
* Cascading Symbols
* Multiplier Systems
* Free Spins

## ✅ Event-Driven Architecture

Custom Event Bus used to reduce tight coupling between gameplay systems.

## ✅ FSM-Based Game Flow

Game states handled using a Finite State Machine:

* Idle State
* Spin State
* Result State
* Win State

---

# 🛠️ Built With

* Unity
* C#
* ScriptableObjects
* FSM Architecture
* Event Bus Pattern

---

# 🎯 Focus Areas

* Gameplay Systems Programming
* Clean Architecture
* Scalable Unity Systems
* Modular Design
* SOLID Principles
