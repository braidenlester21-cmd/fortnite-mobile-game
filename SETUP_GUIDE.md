# Scene Setup Guide (15 minutes)

## Step 1: Create Ground
1. Right-click in Hierarchy → 3D Object → Plane
2. Name: "Ground"
3. Scale: (50, 1, 50)
4. Create Material:
   - Assets → Create → Material
   - Color: Bright Green or Blue (Fortnite style)
5. Drag material onto Ground plane

## Step 2: Create Player
1. Create empty GameObject → Name: "Player"
2. Add Component → Physics → Character Controller
   - Height: 2
   - Radius: 0.4
   - Center: (0, 1, 0)
3. Add child → 3D Object → Capsule
   - Name: "PlayerModel"
   - Scale: (0.8, 1, 0.8)
4. Add PlayerMovement script to Player
5. Add GameManager script to Player

## Step 3: Setup Camera
1. Delete default Main Camera
2. Add child to Player → Camera
   - Name: "MainCamera"
   - Position: (0, 1.6, -3)
3. Add CameraController script
4. Assign Player transform in inspector

## Step 4: Create UI Canvas
1. Right-click Hierarchy → UI → Canvas
2. Canvas Settings:
   - Render Mode: Screen Space - Overlay
   - Scale Mode: Scale with Screen Size
   - Reference Resolution: 1080 x 1920

## Step 5: Add Joystick
1. Right-click Canvas → UI → Panel
   - Name: "Joystick"
   - Position: (80, 80)
   - Size: (150, 150)
   - Add Image component (gray)
2. Add child Panel for handle:
   - Name: "Handle"
   - Size: (100, 100)
   - Add Image (bright blue)
3. Add Joystick script to parent panel
   - Container: Self
   - Handle: Child handle panel

## Step 6: Add Action Buttons

**Jump Button:**
1. Right-click Canvas → UI → Button
2. Name: "JumpButton"
3. Position: (-100, 100)
4. Text: "JUMP"
5. Add OnClick listener:
   - Assign Player
   - Function: PlayerMovement → JumpButton()

**Crouch Button:**
1. Duplicate Jump Button
2. Name: "CrouchButton"
3. Position: (-100, 220)
4. Text: "CROUCH"
5. OnClick: PlayerMovement → ToggleCrouchButton()

## Step 7: Add HUD Text
1. Right-click Canvas → UI → Text - TextMeshPro
   - Name: "KillCountText"
   - Position: Top-Left
   - Text: "Kills: 0"
2. Duplicate for "SpeedText" and "TimeText"

## Step 8: Wire References

**PlayerMovement:**
- Controller: CharacterController
- Joystick: Joystick panel
- Camera Transform: MainCamera

**UIManager:**
- Kill Count Text: KillCountText
- Speed Text: SpeedText
- Game Time Text: TimeText
- Player Movement: Player component

**GameManager:**
- Player Movement: Player component
- UI Manager: Canvas UIManager

## Step 9: Test
1. Press Play
2. Drag joystick to move
3. Click Jump/Crouch buttons
4. Watch HUD update

## Done! 🎉
Your mobile game is ready. See DEPLOYMENT.md to build and share online!
