using Interfaces;

namespace WarriorSkills
{
    
    public abstract class WarriorSkill : ISkill
    {
        public abstract int FuryCost { get; }
        public abstract void SkillEffect(object effectedCharacter, int skillPower = 1);

    }
}