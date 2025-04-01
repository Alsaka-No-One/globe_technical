import React from 'react';

interface WarriorSpecializationSectionProps {
  level: number;
  warriorSpecialization: 'Tank' | 'DPS' | null;
  onSpecializationChange: (specialization: 'Tank' | 'DPS') => void;
}

export const WarriorSpecializationSection: React.FC<WarriorSpecializationSectionProps> = ({
  level,
  warriorSpecialization,
  onSpecializationChange,
}) => {
  if (level < 3) return null;

  if (!warriorSpecialization) {
    return (
      <section>
        <h2>Choose Specialization</h2>
        <div>
          <button onClick={() => onSpecializationChange('Tank')}>Tank</button>
          <button onClick={() => onSpecializationChange('DPS')}>DPS</button>
        </div>
      </section>
    );
  }

  return (
    <section>
      <h2>Specialization</h2>
      <div>
        <label>Type: </label>
        <span>{warriorSpecialization}</span>
      </div>
      <div>
        <label>Bonus: </label>
        <span>
          {warriorSpecialization === 'Tank' 
            ? '+1 Stamina every 2 levels' 
            : '+1 Strength every 2 levels'}
        </span>
      </div>
    </section>
  );
}; 