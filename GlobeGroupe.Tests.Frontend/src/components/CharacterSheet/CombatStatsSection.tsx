import React from 'react';

interface CombatStatsSectionProps {
  atk: number;
  hp: number;
  characterClass: string;
  criticalStrikeChance: number;
}

export const CombatStatsSection: React.FC<CombatStatsSectionProps> = ({
  atk,
  hp,
  characterClass,
  criticalStrikeChance,
}) => {
  return (
    <section>
      <h2>Combat Stats</h2>
      <div>
        <label>ATK: </label>
        <span>{atk}</span>
      </div>
      <div>
        <label>HP: </label>
        <span>{hp}</span>
      </div>
      {characterClass === 'Archer' && criticalStrikeChance > 0 && (
        <div>
          <label>Critical Strike Chance: </label>
          <span>{criticalStrikeChance}%</span>
        </div>
      )}
    </section>
  );
}; 