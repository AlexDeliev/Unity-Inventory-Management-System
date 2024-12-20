# Unity-Inventory-Management-System
![Derby DELI-ver - Inventory System - Windows, Mac, Linux - Unity 6 (6000 0 23f1)_ _DX11_ 20 12 2024 г  22_26_33](https://github.com/user-attachments/assets/541cdba6-2ad4-478b-9e45-35c90120488e)

<h2>Description</h2>
This inventory system was originally designed for managing soda-related items in a 2D game. However, thanks to its modular and scriptable architecture, it can be easily adapted for various use cases. Whether you need an inventory for tools, weapons, resources, or other in-game items, this system provides the flexibility to meet your needs.
<br></br>
<ul>
<li>Scriptable Items: Create custom item types by extending the ItemClass.</li> 
<li>Dynamic Inventory: Supports adding, removing, and moving items.</li>
<li>User Interface: Visually updates the inventory state in real time.</li>
<li>Audio Effects: Adds sounds for picking up and dropping items.</li>
<li>Slot System: Manages items and quantities through dedicated slot classes.</li>
<li>Interactivity: Supports drag-and-drop functionality with visual highlights.</li>
</ul>

<h3>Key Components</h3>

<ol>
<li><h5>InventoryManager.cs</h5>
The core script that manages the inventory. Responsible for:
<br></br>
<ul>
<li>Adding and removing items.</li>
<li>Visually updating UI components.</li>
<li>Handling mouse interactions for item movement.</li>
</ul>
</li>

<li><h5>ItemClass.cs</h5>
An abstract class for creating various item types. Features include:
<br></br>
<ul>
<li>Item name, icon, and prefab.</li>
<li>Stackability checks for items.</li>
</ul>
</li>

<li><h5>SlotClass.cs</h5>
A class for managing individual inventory slots. Features include:
<br></br>
<ul>
<li>Adding and removing items and quantities.</li>
<li>Copying and clearing slots.</li>
</ul>
</li>
</ol>

<h3>Features</h3>
<ul>
<li>Item Stacking: Supports stackable items that can be grouped together.</li>
<li>Dynamic Interactions: Move items between slots or outside the inventory.</li>
<li>Game Integration: Place items into the game world upon release.</li>
<li>Movement Effects: Animates items during drag operations.</li>
</ul>

<h3>Requirements</h3>
<ul>
<li>Unity 2021.3 or newer.</li>
<li>Suitable for 2D projects with inventory systems.</li>
</ul>

<h3>How to Use</h3>
<ol>
<li>Create ItemClass objects through the Unity menu.</li>
<li>Set up slots and UI components in the scene.</li>
<li>Attach the InventoryManager script to a GameObject and configure the required fields.</li>
</ol>

<h3>Future Improvements</h3>
<ul>
<li>Adding item categories.</li>
<li>Supporting additional interaction types.</li>
<li>Integrating with multiplayer features.</li>
</ul>