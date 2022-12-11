using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    public abstract class Ability
    {
        protected string abilityName;
        protected int abilityAnimationIndex;
        protected AbilityPhase abilityPhase;

    }
    public enum AbilityPhase
    {
        Ready,
        Started,
        Finished,
        Interrupted,
        Cancelled
    }
}