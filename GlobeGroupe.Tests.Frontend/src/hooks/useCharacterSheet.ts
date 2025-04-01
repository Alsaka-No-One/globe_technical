import { useState } from 'react';

type CharacterClass = 'Archer' | 'Mage' | 'Warrior' | 'None';
type WarriorSpecialization = 'Tank' | 'DPS' | null;

interface Familiar {
  name: string;
  hp: number;
  atk: number;
}

interface CharacterSheetProps {
  startingLevel: number;
  startingStamina: number;
  startingStrength: number;
  availableExperience?: number;
}

export const useCharacterSheet = ({
  startingLevel,
  startingStamina,
  startingStrength,
  availableExperience = 0,
}: CharacterSheetProps) => {
  const [state, setState] = useState({
    name: '',
    characterClass: 'None' as CharacterClass,
    level: startingLevel,
    strength: startingStrength,
    stamina: startingStamina,
    experience: availableExperience,
    familiar: null as Familiar | null,
    warriorSpecialization: null as WarriorSpecialization,
    criticalStrikeChance: 0,
  });

  const calculateCombatStats = () => {
    switch (state.characterClass) {
      case 'Archer':
        return {
          atk: state.strength * 2,
          hp: state.stamina * 2,
        };
      case 'Mage':
        return {
          atk: state.strength * 3,
          hp: state.stamina * 1,
        };
      case 'Warrior':
        return {
          atk: state.strength * 1,
          hp: state.stamina * 3,
        };
      default:
        return {
          atk: 1,
          hp: 1,
        };
    }
  };

  const handleLevelUp = (stat: 'strength' | 'stamina') => {
    if (state.experience >= 100) {
      setState(prev => {
        const newState = {
          ...prev,
          level: prev.level + 1,
          [stat]: prev[stat] + 1,
          experience: prev.experience - 100,
        };

        // Ajout du familier au niveau 5 pour le Mage
        if (prev.characterClass === 'Mage' && newState.level >= 5) {
          const combatStats = calculateCombatStats();
          newState.familiar = {
            name: `${prev.name}'s Familiar`,
            hp: Math.floor(combatStats.hp * 0.5),
            atk: Math.floor(combatStats.atk * 0.5),
          };
        }

        // Bonus de stats pour le Warrior selon sa spécialisation
        if (prev.characterClass === 'Warrior' && prev.warriorSpecialization) {
          if (newState.level % 2 === 0) {
            if (prev.warriorSpecialization === 'Tank') {
              newState.stamina += 1;
            } else {
              newState.strength += 1;
            }
          }
        }

        // Chance de coup critique pour l'Archer
        if (prev.characterClass === 'Archer' && newState.level % 2 === 0) {
          newState.criticalStrikeChance += 1;
        }

        return newState;
      });
    }
  };

  const handleReset = () => {
    setState({
      name: '',
      characterClass: 'None',
      level: startingLevel,
      strength: startingStrength,
      stamina: startingStamina,
      experience: availableExperience,
      familiar: null,
      warriorSpecialization: null,
      criticalStrikeChance: 0,
    });
  };

  return {
    state,
    combatStats: calculateCombatStats(),
    handleLevelUp,
    handleReset,
    handleNameChange: (name: string) => setState(prev => ({ ...prev, name })),
    handleClassChange: (characterClass: CharacterClass) => setState(prev => ({ ...prev, characterClass })),
    handleWarriorSpecialization: (specialization: WarriorSpecialization) => 
      setState(prev => ({ ...prev, warriorSpecialization: specialization })),
  };
}; 