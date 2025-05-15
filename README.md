# 🔵 Unity Custom Circular Loading Button
This project implements a custom circular loading button using Unity’s UI Toolkit (UI Document system). It provides a visually interactive button with smooth animated progress, built from scratch with reusable, customizable components. A video demo is provided below

https://github.com/user-attachments/assets/acabccf7-298c-431a-919b-805d80c5ad7e

# 🚀 Project Overview
# Goal:
Create a visually appealing, circular loading button with press/release interactions and animated progress, using pure code (no pre-made assets).

# Tech Stack:

Unity (UI Toolkit, UI Document system)

C# (MonoBehaviour, VisualElement, Custom Drawing)

# Main Features:

Custom-drawn, scalable circular button visuals

Animated loader arc (shows progress)

Interactive scaling when pressed/released

Fully customizable via code/inspector

# 📦 Components & Architecture
1. LerpNumber
   
Type: Pure C# helper class

Purpose: Handles smooth interpolation between two values over time, using a customizable speed (lerpRate). Used to animate the loader progress (angle).

Highlights:Start/stop/reset logic for seamless interpolation.Safe restarts if values change mid-animation

2. CustomCircle
Type: UI Toolkit VisualElement

Purpose: Draws a filled (and optionally stroked) circle in the UI, with customizable color, radius, stroke, and angle.

Highlights: Supports custom CSS-style colors (--primary-Fill, --primary-Stroke). Dynamic sizing and redrawing on attribute change. Used for button visuals (primary/secondary circles)

3. CustomPath
Type: UI Toolkit VisualElement

Purpose: Draws a circular arc or path (like a progress bar) with customizable radius, width, segments, and end angle.

Highlights: Flexible arc drawing using segments. Used for animated loader/progress effect

4. CustomButtomInteractionManager
Type: MonoBehaviour (attached to GameObject with UIDocument)

Purpose: Handles user interaction and ties together the custom UI elements. Controls scaling and progress animation in response to press/release.

Highlights: On button press: Scales up circles, animates loader to 360°. On release: Scales back, rewinds loader to 0°. Utilizes LerpNumber for smooth angle transitions

# 🧩 How It Works
Setup:

Attach CustomButtomInteractionManager to a GameObject with a UIDocument.

Reference circles and loader by their names in the UI Document (PrimaryCircle, SecondaryCircle, CircularLoader).

User Interaction:

Press:

Button scales up.

Loader arc animates to full circle (360°).

Release:

Button scales back.

Loader rewinds to empty (0°).

All transitions are smoothly animated.

Customization:

Control appearance via public attributes (e.g., radius, colors, stroke).

Adjust animation speed with lerpRate.

Easily extend visuals/styles using UI Toolkit styles.

# 🛠️ Core Classes
LerpNumber


`public class LerpNumber`
`{`

    // Smoothly interpolates between two numbers at a given rate.
    // Use for animating loader progress.
    
`}`

CustomCircle

`[UxmlElement]`
`public partial class CustomCircle : VisualElement`

`{`

    `// Draws a filled/stroked circle, supports custom attributes (color, radius, stroke, endAngle).`
    
`}`
CustomPath

`[UxmlElement]`

`public partial class CustomPath : VisualElement`

`{`

    // Draws a circular arc/progress path, customizable segments/angles/radius.
`}`
CustomButtomInteractionManager

`public class CustomButtomInteractionManager : MonoBehaviour`
`{`

    `// Handles UI element references, user input, and animates loader/progress in response.`
`}`
📋 Example Usage
# Setup:

Add a UIDocument to your Canvas or UI GameObject.

In UXML, add elements named PrimaryCircle, SecondaryCircle, and CircularLoader using CustomCircle and CustomPath.

Attach CustomButtomInteractionManager to the same GameObject and assign lerpRate in the inspector.

#Interaction:

Click and hold the button (secondary circle) to animate loading.

Release to animate rewind.

# ✨ Customization
Colors/Styles:
Override custom style properties --primary-Fill, --primary-Stroke.

# Animation Speed:
Set lerpRate in the Inspector or via code.

# Arc/Radius/Segments:
Adjust radius, endAngle, segments attributes on the UI elements.

# 📑 File/Script Summary
Script Name	Responsibility
LerpNumber.cs	Smooth value interpolation
CustomCircle.cs	Drawing filled/stroked circles (UI)
CustomPath.cs	Drawing circular arcs (loader/progress)
CustomButtomInteractionManager.cs	UI input & animation management

# 🤝 Contribution
Feel free to fork, modify, and use this in your own Unity projects!
Attribution appreciated but not required.

# 📝 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

