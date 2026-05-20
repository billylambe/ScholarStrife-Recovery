# Scholar Strife (Recovery) — Onboarding Guide

This document provides an overview of the rebuilt card game architecture, explains how the current gameplay loop functions, and outlines the key scripts responsible for each system. The original project structure has been heavily refactored into a more modular and maintainable architecture, separating gameplay systems into dedicated managers and runtime components. This should provide a much clearer foundation for extending the game with new mechanics, card effects, AI behaviour, and UI systems. Many of the granular code features are taken from the old code base, but they now correctly function together 

# Overview

The game is a turn-based card battler built around hero combat. Both the player and enemy control a Hero card with a health value. The objective of the game is to reduce the opposing hero’s health to zero before your own hero is defeated.

The gameplay loop currently works as follows:

1. The game starts and both decks are built and shuffled.
2. Both players draw opening hands.
3. Turns alternate between player and enemy.
4. Mana regenerates at the start of turns.
5. Cards can be drawn, played onto the board, and used in combat.
6. Cards can attack opposing units or directly target heroes depending on the board state.
7. Destroyed cards are moved to the discard pile.
8. The game ends when either hero reaches zero health.

The current implementation is designed as a proof-of-concept gameplay framework rather than a fully content-complete card game. The architecture is intentionally modular so additional mechanics can be layered onto the existing systems cleanly. Game-relevent events such as the win conditon are simply shown in the Debug.Log.

---

# Recommended Workflow For Extending The Game

If adding new features, the safest approach is:

1. Add new data fields to `CardData`
2. Update `CardView` to display the data
3. Extend `CardCombat` or `CombatManager` to process the behaviour
4. Add any new runtime tracking to the relevant manager

Examples:

| Feature            | Recommended Scripts      |
| ------------------ | ------------------------ |
| Card abilities     | CardData, CardCombat     |
| New mana rules     | ManaManager, TurnManager |
| Smarter AI         | EnemyManager             |
| New board rules    | BoardManager, BoardSlot  |
| Hero powers        | HeroCard, HeroManager    |
| New win conditions | GameManager              |

---

# Final Notes

The project has been intentionally rebuilt into smaller focused systems to make debugging and future development easier. Most gameplay features now have a dedicated manager or component responsible for only one area of logic, which should make extending the game significantly more manageable compared to the original architecture.

The current codebase should be treated as a gameplay framework and foundation layer. The expectation is that future development would primarily involve extending the existing systems rather than rewriting them.

See below for a full breakdown of the systems

---


# Core Architecture

The project is split into several major gameplay systems:

* Game Flow Managers
* Hero System
* Card Data System
* Hand and Deck Systems
* Board Placement System
* Combat System
* Turn and Mana Systems
* Enemy AI Systems

Each area has dedicated scripts responsible for very specific functionality.

---

# Manager Hierarchy

## GameManager

Controls the overall flow of the game.

Responsibilities:

* Starting the match
* Initialising gameplay systems
* Building and shuffling decks
* Drawing opening hands
* Checking win and loss conditions

This is effectively the “master controller” of the game loop.

Potential Extensions:

* Match restart system
* Main menu integration
* Round tracking
* Victory screens
* Match timers

---

## EnemyManager

Controls enemy-side gameplay behaviour and AI logic.

Responsibilities:

* Choosing enemy actions
* Playing enemy cards
* Deciding attacks
* Handling automated enemy turns

Potential Extensions:

* Difficulty levels
* Smarter targeting logic
* Aggressive/defensive AI behaviours
* Deck archetypes
* Behaviour trees or state machines

---

## TurnManager

Controls the overall turn cycle.

Responsibilities:

* Starting turns
* Ending turns
* Switching active players
* Regenerating mana
* Optional automatic card drawing

Important Inspector Variables:

* `startingMana`
* `manaIncreasePerTurn`
* `maxMana`

This is one of the most important scripts for balancing gameplay pacing.

Potential Extensions:

* Extra turn mechanics
* Timed turns
* Turn countdown UI
* Phase systems (Draw/Main/Combat/End)

---

## DeckManager

Controls deck creation and card drawing.

Responsibilities:

* Building decks
* Storing deck contents
* Shuffling
* Drawing cards

Potential Extensions:

* Multiple deck presets
* Deck building menus
* Card rarity systems
* Separate player/enemy deck rules

---

## HandManager

Controls runtime hand management.

Responsibilities:

* Drawing cards into hands
* Tracking hand contents
* Enforcing hand limits
* Spawning card visuals

Potential Extensions:

* Hand size modifiers
* Mulligan system
* Hover previews
* Hand sorting

---

## ManaManager

Controls all mana-related systems.

Responsibilities:

* Tracking mana values
* Spending mana
* Regenerating mana
* Enforcing mana caps

Potential Extensions:

* Alternative resources
* Temporary mana buffs
* Resource stealing mechanics

---

## CombatManager

Controls combat resolution.

Responsibilities:

* Resolving attacks
* Applying damage
* Triggering combat outcomes
* Processing card deaths

Potential Extensions:

* Damage modifiers
* Combat animations

---

## BoardManager

Controls cards currently in play.

Responsibilities:

* Tracking active cards
* Managing board state
* Storing board references

Potential Extensions:

* Board buffs/debuffs
* Position-based gameplay

---

## DiscardManager

Controls discarded cards.

Responsibilities:

* Moving destroyed cards into discard
* Tracking discard pile contents

Potential Extensions:

* Resurrection cards
* Deck recycling
* Discard-triggered abilities

---

# Hero System

The hero system forms the win/loss condition for the game. Each side has a Hero card with health that can be damaged during gameplay. If a hero reaches zero health, the game ends. 

## HeroCard

Stores hero runtime data.

Responsibilities:

* Health values
* Damage handling
* Death state

Potential Extensions:

* Hero animations
* Status effects

---

## HeroManager

Controls hero gameplay interactions.

Responsibilities:

* Tracking hero references
* Updating hero states
* Coordinating hero systems

Potential Extensions:

* Hero selection
* Multiple hero classes
* Hero progression

---

## HeroTargeting

Handles hero targeting interactions.

Responsibilities:

* Allowing heroes to be attacked
* Processing target selection

Potential Extensions:

* Target restrictions
* Protection mechanics

---

# Card System

The card system is the core of gameplay. Cards are represented through reusable data structures and runtime visual components. 

## CardData

Stores the base definition of a card.

Responsibilities:

* Name
* Artwork
* Mana cost
* Attack value
* Health value

This is effectively the “template” for each card.

Potential Extensions:

* Card abilities
* Keywords
* Rarity values
* Tribe/faction systems

---

## CardDatabase

Stores all available card definitions.

Responsibilities:

* Central card lookup
* Providing card references

Potential Extensions:

* Search/filter systems
* Runtime loading
* Expansion support

---

## CardView

Controls the visual runtime card object.

Responsibilities:

* Displaying stats
* Updating UI
* Showing ownership

Potential Extensions:

* Animations
* Visual effects
* Card highlighting
* Hover zoom

---

## CardOwner

Defines ownership types.

Responsibilities:

* Identifying player or enemy ownership

Potential Extensions:

* Neutral ownership
* Multiplayer ownership IDs

---

## CardDragHandler

Controls dragging and placement.

Responsibilities:

* Dragging cards
* Moving cards between parents
* Placement handling

Potential Extensions:

* Drag previews
* Invalid placement effects

---

## CardCombat

Controls runtime combat behaviour.

Responsibilities:

* Attacking
* Taking damage
* Tracking board combat state

Potential Extensions:

* Combat keywords
* Counterattacks
* Triggered effects

---

## CardTargeting

Controls attack targeting.

Responsibilities:

* Selecting attackers
* Validating targets

Potential Extensions:

* Spell targeting
* Multi-target attacks
* Priority systems

---

## DeckPile

Controls deck interaction visuals.

Responsibilities:

* Visual deck object
* Manual card drawing interaction

Potential Extensions:

* Deck counters
* Shuffle animation
* Preview top card effects

---

# Board Placement System

The board placement system controls how cards enter active play. 

## BoardSlot

Controls individual placement positions.

Responsibilities:

* Detecting valid placement
* Tracking occupancy
* Holding placed cards

Potential Extensions:

* Lane systems
* Position bonuses
* Frontline/backline mechanics

