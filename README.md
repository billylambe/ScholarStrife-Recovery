# Notes From Rob

Hi Billy,

Here’s the plan for getting your project back into a stable and working state.

After reviewing the current scripts, the biggest issue is not necessarily the game idea itself, but the overall project architecture. A lot of systems are currently overlapping responsibilities, which makes the project extremely difficult to debug and expand safely. The current project also contains a number of structural problems with how Lists, runtime card creation, and gameplay state are being handled.

Rather than trying to endlessly patch the current version, we are going to rebuild the core gameplay loop in a much cleaner and simpler way while preserving the general structure and feel of your existing project.

The important thing is that we are NOT starting from scratch creatively. Your artwork, ideas, card concepts, mechanics, and overall game design can still be used. We are simply rebuilding the technical foundation underneath it so the project becomes understandable, stable, and expandable again.

## The Plan

We are going to rebuild the project in stages using version control so that every step is stable before moving on to the next feature.

The rebuild will focus on:

* Smaller number of scripts
* Clear responsibilities per script
* Shared systems instead of duplicated systems
* Stable deck and hand management
* Runtime card spawning using prefabs
* Cleaner combat and turn flow
* Easier debugging

We are intentionally avoiding overcomplicated systems such as ScriptableObjects for now, because the goal is clarity and stability first.

Cards will remain prefab-based so the workflow stays familiar.

## Rebuild Stages

### Stage 1 — Core Card Flow

Goal:
Get cards spawning correctly from a deck into a hand.

Features:

* Deck creation
* Shuffle
* Draw card
* Spawn prefab into hand
* Hand tracking

---

### Stage 2 — Playing Cards

Goal:
Allow cards to be dragged and played onto the board.

Features:

* Drag/drop
* Mana checking
* Removing cards from hand
* Board placement

---

### Stage 3 — Combat

Goal:
Allow cards to attack and resolve damage properly.

Features:

* Card attacks
* Targeting
* HP reduction
* Card destruction
* Direct player damage

---

### Stage 4 — Turn System

Goal:
Create a stable gameplay loop.

Features:

* Player/enemy turns
* Mana refill
* Draw per turn
* Attack reset
* Turn swapping

---

### Stage 5 — Basic AI

Goal:
Get the opponent functioning reliably.

Features:

* Draw cards
* Play affordable cards
* Attack targets

---

### Stage 6 — Expansion

Only once the core loop is stable.

This is where:

* Special abilities
* Keywords
* Buffs/debuffs
* VFX
* Animations
* Advanced mechanics

can safely be added.

## Most Important Rule

No new mechanics are added until the current stage is stable and working.

This prevents the project from becoming impossible to debug again.

## Final Goal

The final goal is not to make the “perfect” architecture.

The goal is to make a project that:

* works reliably
* is understandable
* is expandable
* is easy to debug
* can safely support your own custom mechanics and content

Once the core systems are stable, we can gradually migrate your existing content and ideas back into the project one feature at a time.

Rob
