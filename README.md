# Fortnite-Style Mobile Game 🎮

A fast-paced mobile game with Fortnite-like mechanics including sprinting, sliding, jumping, and crouching.

## 🎯 Features
- 🏃 Sprint & Crouch mechanics
- 🛝 Slide system with momentum
- 📱 Mobile-optimized touch controls
- 🎨 Fortnite-inspired visuals
- 🕹️ Joystick-based movement
- 📊 HUD with kill count and speed tracking

## Quick Start
1. Clone this repository
2. Open in Unity 2022 LTS or later
3. Follow [SETUP_GUIDE.md](SETUP_GUIDE.md) for scene configuration
4. Build for Android/iOS or WebGL

## 📱 Controls (Mobile)
- **Joystick** (bottom-left): Move character
- **Jump Button** (bottom-right): Jump
- **Crouch Button** (right side): Toggle crouch
- **Sprint + Crouch**: Automatic slide when moving

## 🚀 Deploy & Share
See [DEPLOYMENT.md](DEPLOYMENT.md) for building and getting a playable link!

## Project Structure
```
Assets/
├── Scripts/
│   ├── PlayerMovement.cs      # Core movement mechanics
│   ├── GameManager.cs         # Game state & logic
│   ├── UIManager.cs           # HUD & UI updates
│   ├── CameraController.cs    # Follow camera
│   └── Joystick.cs            # Mobile joystick input
└── .gitignore
```

## Movement Speeds
- Walk: 5 m/s
- Sprint: 8.5 m/s
- Crouch: 3.5 m/s
- Slide: 12 m/s
- Jump Height: 2.1 units
