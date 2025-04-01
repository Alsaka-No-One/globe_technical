import React from 'react';
import { useCharacterSheet } from '../../hooks/useCharacterSheet';
import { GeneralSection } from './GeneralSection';
import { StatsDistributionSection } from './StatsDistributionSection';
import { CombatStatsSection } from './CombatStatsSection';
import { FamiliarSection } from './FamiliarSection';
import { WarriorSpecializationSection } from './WarriorSpecializationSection';

interface CharacterSheetProps {
  startingLevel: number;
  startingStamina: number;
  startingStrength: number;
  availableExperience?: number;
}

const CharacterSheet: React.FC<CharacterSheetProps> = (props) => {
  const {
    state,
    combatStats,
    handleLevelUp,
    handleReset,
    handleNameChange,
    handleClassChange,
    handleWarriorSpecialization,
  } = useCharacterSheet(props);

  return (
    <div className="character-sheet">
      <h1>Character Sheet</h1>
      
      <GeneralSection
        name={state.name}
        characterClass={state.characterClass}
        level={state.level}
        experience={state.experience}
        availableExperience={props.availableExperience}
        onNameChange={handleNameChange}
        onClassChange={handleClassChange}
      />

      <StatsDistributionSection
        strength={state.strength}
        stamina={state.stamina}
        experience={state.experience}
        onLevelUp={handleLevelUp}
      />

      <CombatStatsSection
        atk={combatStats.atk}
        hp={combatStats.hp}
        characterClass={state.characterClass}
        criticalStrikeChance={state.criticalStrikeChance}
      />

      {state.characterClass === 'Mage' && state.familiar && (
        <FamiliarSection familiar={state.familiar} />
      )}

      {state.characterClass === 'Warrior' && (
        <WarriorSpecializationSection
          level={state.level}
          warriorSpecialization={state.warriorSpecialization}
          onSpecializationChange={handleWarriorSpecialization}
        />
      )}

      <button onClick={handleReset}>Reset Character</button>
    </div>
  );
};

export default CharacterSheet; 