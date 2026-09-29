# Module 4 Tasks: Advanced OOP

In this module, you will master inheritance, polymorphism, abstract classes, and interfaces by designing a system based on business requirements!

## Task: The Arena Battle Simulator

You are the lead architect for a new fantasy RPG game. The game designers have provided you with a Game Design Document (GDD) for the core battle arena mechanics. 

Your goal is to model this system using **Advanced OOP principles**. You must decide which elements should be abstract classes, which should be interfaces, and where inheritance and polymorphism are required to satisfy the rules securely and elegantly.

### System Requirements (Game Design Document):

1. **Arena Combatants:**
   - Every participant in the arena has a Name and a pool of Health.
   - It must be impossible to spawn a generic "participant" on the arena – every fighter must be of a specific type (e.g., a Warrior or a Mage).

2. **Taking Damage:**
   - Any participant can be hit by an attack, which reduces their Health.
   - However, some fighter types have intrinsic defenses. For example, **Warriors** wear heavy armor that permanently reduces all incoming physical damage by 3 points.

3. **Basic Attacks:**
   - Every combatant is capable of performing a basic physical attack against another target.
   - The way a basic attack works and how much damage it deals is completely unique to the type of fighter. There is no "default" attack behavior that makes sense.
   - For example, a **Warrior's** basic attack deals 15 damage. A **Mage's** basic attack is weak, dealing only 5 damage.

4. **Magical Abilities:**
   - Certain participants have an affinity for magic. The system must have a clean, decoupled way to identify if any given combatant is capable of using magic.
   - If a combatant is magical (like a **Mage**), they have the ability to cast a spell on a target.
   - Spells are devastating (dealing 25 damage) and they **bypass all armor** (the target takes raw damage, ignoring their normal defensive traits).

5. **The Simulation Engine:**
   - The battle engine must be able to hold all fighters in a single, unified list, regardless of their specific type.
   - The engine will loop through this list to process turns.
   - On a fighter's turn, the engine must check if the fighter is capable of using magic. If they are, they will cast a spell at the opponent. If they are not magical, they will perform their basic attack.

### Your Objective:
Implement the system described above in `Program.cs`. Create a duel between one Warrior and one Mage. Use abstract classes, interfaces, virtual methods, and overriding to meet all the GDD constraints perfectly. Kto wygra ten pojedynek?
