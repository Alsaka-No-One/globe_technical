import React from 'react';

interface StatsDistributionSectionProps {
  strength: number;
  stamina: number;
  experience: number;
  onLevelUp: (stat: 'strength' | 'stamina') => void;
}

export const StatsDistributionSection: React.FC<StatsDistributionSectionProps> = ({
  strength,
  stamina,
  experience,
  onLevelUp,
}) => {
  return (
    <section>
      <h2>Stats Distribution</h2>
      <div>
        <label>Strength: </label>
        <span>{strength}</span>
        {experience >= 100 && (
          <button onClick={() => onLevelUp('strength')}>+</button>
        )}
      </div>
      <div>
        <label>Stamina: </label>
        <span>{stamina}</span>
        {experience >= 100 && (
          <button onClick={() => onLevelUp('stamina')}>+</button>
        )}
      </div>
    </section>
  );
}; 