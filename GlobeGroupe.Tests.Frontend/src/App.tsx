import CharacterSheet from './components/CharacterSheet/index';

const App = () => {
  return (
    <div className="app">
      <CharacterSheet
        startingLevel={1}
        startingStamina={10}
        startingStrength={10}
        availableExperience={1000}
      />
    </div>
  );
};

/*
  For this test, you can add any dependencies you need.
  You can also create as many components as you need.
  When creating types/interfaces, assume that more functionalities will be added in the future.  
  For the purpose of this test (all exercices), assume that all stats computation are expensive.
  You can keep the design and CSS simple.

  The goal of the exercice is to create a simple RPG character sheet.
  The layout is as follows:
  ---------------------------------------------------------
  | Character Sheet                                       |
  ---------------------------------------------------------
  | General                                               |
  |                                                       |
  | Name: _                                               |
  | Class: _                                              |
  | Level: _                                              |
  ---------------------------------------------------------
  | Stats Distribution                                    |
  |                                                       |
  | Strength: _                                           |
  | Stamina: _                                            |
  ---------------------------------------------------------
  | Combat Stats                                          |
  |                                                       |
  | ATK: _                                                |
  | HP: _                                                 |
  ---------------------------------------------------------

  Your CharacterSheet component should have the following props:
    - starting level
    - starting stamina
    - starting strength

  Ex 1:
    Create the CharacterSheet component that takes the props and displays the layout above.
    Name and Class should be editable.

    Combat Stats should be calculated as follows:
    Archer:
      ATK: strength * 2
      HP: stamina * 2
  
    Mage:
      ATK: strength * 3
      HP: stamina * 1
  
    Warrior:
      ATK: strength * 1
      HP: stamina * 3
  
    None:
      ATK: 1
      HP: 1

  Ex 2:
    Add available experience points to the CharacterSheet component props and display it in the General section. 
    Allow the user to level up the character by spending 100 experience points and adding either 1 to strength or stamina.

  Ex 3:
    Add a button to the CharacterSheet component that allows the user to reset the character to its initial state.

  Ex 4:
    Classes have specific bonus now that can be added when leveling up:
       - Every 2 levels, the Archer gains 1% Critical Strike Chance, a new Combat Stats
       - At level 5, the Mage have a familiar, it has a Name, 50% of the Mage's HP and 50% of the Mage's ATK
       - At level 3, the Warrior can choose a specialization between Tank and DPS.
         Tank gain 1 bonus stamina every 2 levels
         DPS gain 1 bonus strength every 2 levels

*/

export default App
