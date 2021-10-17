using Characters;
using System;
namespace WarriorSkills
{
    public class InFury : WarriorSkill
    {
        public override int FuryCost => 30;

        public override void SkillEffect(object effectedCharacter, int skillPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Warrior))
            {
                var furyCharacter = effectedCharacter as Warrior;
                if (furyCharacter.Fury >= FuryCost)
                {
                    //Реализация повышения урона на 30 единиц на 30 секунд

                }
                else
                    throw new ArgumentException("Недостаточно ярости!");
            }
            else
                throw new ArgumentException("Этот персонаж не воин!");
        }
    }
}