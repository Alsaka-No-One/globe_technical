import React from 'react';

interface Familiar {
  name: string;
  hp: number;
  atk: number;
}

interface FamiliarSectionProps {
  familiar: Familiar;
}

export const FamiliarSection: React.FC<FamiliarSectionProps> = ({ familiar }) => {
  return (
    <section>
      <h2>Familiar</h2>
      <div>
        <label>Name: </label>
        <span>{familiar.name}</span>
      </div>
      <div>
        <label>HP: </label>
        <span>{familiar.hp}</span>
      </div>
      <div>
        <label>ATK: </label>
        <span>{familiar.atk}</span>
      </div>
    </section>
  );
}; 