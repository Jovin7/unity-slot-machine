# 🎰 Unity Slot Machine Game

A modular 2D Slot Machine game developed in Unity with a strong focus on scalable gameplay architecture, reusable systems, and clean code practices.

---

# 🎥 Gameplay Demo

<p align="center">
  <a href="https://www.youtube.com/embed/UrzQjT2ywyo">
    <img src="https://img.youtube.com/vi/UrzQjT2ywyo/maxresdefault.jpg" width="800" alt="Unity Slot Machine Gameplay"/>
  </a>
</p>

# 🚀 Features

* Reel spinning system
* RNG-based weighted symbol generation
* Payline evaluation system
* Wild symbol support
* Expanding Wild mechanic
* Event-driven architecture using Event Bus
* Finite State Machine (FSM) based game flow
* ScriptableObject-driven configuration
* Win animations and audio feedback

---

# 🧠 Architecture Overview

This project focuses heavily on gameplay systems architecture and maintainable Unity development practices.

## System Architecture

```mermaid
flowchart TD

    UI[UI Layer]
    GM[Game Manager]
    SM[State Machine]
    REEL[Reel System]
    MATCH[Symbol Matcher]
    MOD[Grid Modifiers]
    WALLET[Wallet Service]
    EVENT[Event Bus]

    UI --> GM
    GM --> SM
    GM --> REEL
    REEL --> MATCH
    MATCH --> MOD
    GM --> WALLET

    GM <--> EVENT
    UI <--> EVENT

    classDef ui fill:#4F46E5,color:#ffffff,stroke:#312E81,stroke-width:3px;
    classDef core fill:#059669,color:#ffffff,stroke:#064E3B,stroke-width:3px;
    classDef system fill:#EA580C,color:#ffffff,stroke:#9A3412,stroke-width:3px;
    classDef event fill:#DC2626,color:#ffffff,stroke:#7F1D1D,stroke-width:3px;

    class UI ui;
    class GM,SM core;
    class REEL,MATCH,MOD,WALLET system;
    class EVENT event;
```

---

## Spin Flow

```mermaid
sequenceDiagram

    participant Player
    participant UI
    participant GameManager
    participant ReelController
    participant WinSystem
    participant Wallet

    rect rgb(79,70,229)
        Player->>UI: Press Spin
        UI->>GameManager: RequestSpin()
    end

    rect rgb(5,150,105)
        GameManager->>Wallet: Deduct Bet
        GameManager->>ReelController: Spin Reels
        ReelController-->>GameManager: Spin Complete
    end

    rect rgb(234,88,12)
        GameManager->>WinSystem: Evaluate Grid
        WinSystem-->>GameManager: Return Payout
    end

    rect rgb(220,38,38)
        GameManager->>Wallet: Add Coins
        GameManager-->>UI: Update UI
    end
```

---

# 🧩 Architecture Highlights

## ✅ Modular Reel System

Reel logic was separated into dedicated systems:

* Reel Generator
* Reel Spinner
* Reel Stopper
* Reel Symbol Tracker

## ✅ Interface-Based Design

Interfaces were used extensively to decouple gameplay systems and improve scalability.

### Examples

* `IReel`
* `IReelSpinner`
* `IReelStopper`
* `IReelGenerator`
* `IReelSymbolTracker`
* `IPaylineService`
* `IGridModifier`

## ✅ Modifier-Based Gameplay System

Implemented a modifier-driven gameplay architecture where grid data can be modified independently from rendering logic.

This architecture supports future mechanics such as:

* Sticky Wilds
* Cascading Symbols
* Multipliers
* Free Spins

## ✅ Event-Driven Architecture

A custom Event Bus was implemented to reduce tight coupling between systems and improve maintainability.

## ✅ FSM-Based Game Flow

Game flow is managed using a Finite State Machine:

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
