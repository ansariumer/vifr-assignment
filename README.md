First-Person Object Interaction System

Project Overview

This project is a first-person interaction game developed using Unity and C#.

The player is placed inside an empty room containing three randomly coloured cubes. One cube is the correct choice, while the remaining cubes are incorrect.

The objective is to identify the correct cube by looking at the objects.

Part 1 – Implementation

The game implements the following functionality:

Correct Cube:

- When the player looks at the correct cube, its colour changes to white.
- A success sound effect plays.
- A "Correct" message appears at the centre of the screen.
- Further interactions are disabled after successfully identifying the correct cube.

Wrong Cube:

- When the player looks at an incorrect cube, it briefly flashes red.
- A "Try Again" message appears.
- The player can continue interacting with other objects.

The player uses a camera raycast from the centre of the screen to detect interactable objects.

---

Part 2 – Reusable Architecture

The interaction system is designed to support different types of interactable objects without modifying the main player interaction logic.

I implemented an abstract base class called `Interactable`, which defines an abstract `Interact()` method.

Individual objects inherit from this base class and implement their own interaction behaviour.

For example:

- CorrectCube: Changes its colour to white and returns true.
- WrongCube: Briefly flashes red and returns false.

The `Player` script detects objects through their `Interactable` component and calls the `Interact()` method without needing to know the specific object type.

This approach uses abstraction, inheritance, and polymorphism to separate object-specific behaviours from the main interaction logic.

**Scalability:**

If the designer introduces 25 different interactable objects, new classes can inherit from `Interactable` and implement their own `Interact()` behaviour.

For example, a door could open, a button could activate a mechanism, or an object could play an animation.

The existing player interaction logic would not need to be rewritten for each new object type.

This reduces code duplication and makes the system easier to extend and maintain.

---

## Part 3 – Design Decisions

1. How have you structured your project? What was your thought process behind your choices?

I structured the project by separating the player interaction system from individual object behaviours.

My main goal was to avoid putting all the functionality into a single script and to make the architecture reusable.

The project uses the following scripts:

- Player.cs: Responsible for detecting objects using camera raycasting, identifying interactable targets, handling interaction results, displaying UI messages, and playing audio feedback.
- Interactable.cs: An abstract base class that defines the common interaction method that all interactable objects must implement.
- CorrectCube.cs: Implements the behaviour of the correct cube by changing its colour to white and returning a successful interaction result.
- WrongCube.cs: Implements the behaviour of an incorrect cube by briefly flashing red using a coroutine and returning an unsuccessful interaction result.
- **CameraRotation.cs:** Handles rotating the camera based on mouse movement, allowing the player to look around the environment.

I chose an abstract base class because all interactable objects share a common interaction requirement, but their actual behaviours can be different.

This allows the player script to interact with different objects through the same method without depending on their individual implementations.

2. If another developer joined tomorrow, how would they understand your code?

I would make the project easy to understand by keeping responsibilities separated and using meaningful class and method names.

The abstract `Interactable` class provides a common structure for all interactable objects. A developer can understand the interaction system by first looking at this class and then examining its derived classes.

Although abstraction might take a little time to understand initially, I believe it has several advantages, especially when working on larger projects. It makes the code more organised, reusable, and easier to extend.

The Player script handles the detection and interaction flow, while individual object scripts contain their own behaviours.

I would also use comments where necessary to explain important or non-obvious logic and maintain a clear project hierarchy.

This structure allows another developer to understand existing functionality and introduce new interactable objects without needing to modify the entire system.


3. If you had another day, what would you improve?

If I had another day, I would focus on improving the flexibility, maintainability, and visual quality of the project.

Some improvements I would consider:

- Separate UI management and audio management from the `Player` script to improve separation of responsibilities.
- Add support for more complex interaction behaviours, such as opening doors, activating buttons, and triggering animations.
- Add particle effects to make interactions more visually engaging.
- Model and improve the room environment using Blender instead of keeping it as a simple empty room.
- Improve interaction feedback with animations and additional visual effects.
- Handle edge cases, such as missing references or objects without valid interactable components.
- Improve code documentation and test the architecture with additional object types.

I would also review the interaction detection system to make it more flexible for future gameplay requirements.
