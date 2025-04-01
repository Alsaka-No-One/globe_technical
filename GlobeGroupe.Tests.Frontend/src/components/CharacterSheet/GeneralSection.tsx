import React from 'react';

type CharacterClass = 'Archer' | 'Mage' | 'Warrior' | 'None';

interface GeneralSectionProps {
  name: string;
  characterClass: CharacterClass;
  level: number;
  experience: number;
  availableExperience?: number;
  onNameChange: (name: string) => void;
  onClassChange: (characterClass: CharacterClass) => void;
}

export const GeneralSection: React.FC<GeneralSectionProps> = ({
  name,
  characterClass,
  level,
  experience,
  availableExperience,
  onNameChange,
  onClassChange,
}) => {
  return (
    <section>
      <h2>General</h2>
      <div>
        <label>Name: </label>
        <input
          type="text"
          value={name}
          onChange={(e) => onNameChange(e.target.value)}
        />
      </div>
      <div>
        <label>Class: </label>
        <select
          value={characterClass}
          onChange={(e) => onClassChange(e.target.value as CharacterClass)}
        >
          <option value="None">None</option>
          <option value="Archer">Archer</option>
          <option value="Mage">Mage</option>
          <option value="Warrior">Warrior</option>
        </select>
      </div>
      <div>
        <label>Level: </label>
        <span>{level}</span>
      </div>
      {availableExperience !== undefined && availableExperience > 0 && (
        <div>
          <label>Experience: </label>
          <span>{experience}</span>
        </div>
      )}
    </section>
  );
}; 