﻿// Responsible for calculating a pokemon's HP type based on IV
using PokeDojo.Poke;

namespace PokeDojo.Types
{
  static class HiddenPower
  {
    static public int HiddenPowerValue(Gen2Pokemon pokemon)
    {
      /* 
       * Type is determined by adding the two least significant bits
       * of the attack and defense ivs
       * */
      int attackIV = pokemon.GetStatValue().GetIndividualValue().GetAttackIV();
      int defenseIV = pokemon.GetStatValue().GetIndividualValue().GetDefenseIV();
      int hiddenPowerValue = 4 * (attackIV % 4) + (defenseIV % 4);
      return hiddenPowerValue;
    }

    static public void HiddenPowerType(Gen2Pokemon pokemon, List<PokemonType> types)
    {
      int HPValue = HiddenPowerValue(pokemon);
      if(HPValue >= 0 && HPValue <= 15)
      {
        pokemon.GetDescription().SetHiddenPower(types[HPValue]);
      }
    }
  }
}
