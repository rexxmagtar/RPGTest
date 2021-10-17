using Characters;
using System;
using System.Threading;

namespace WarriorSkills
{
    public class ArmorFury : WarriorSkill
    {
        public static void Tick(object parameters)
        {

            while (((Parameters) parameters).duration != 0)
            {
                (parameters as Parameters).duration--;
                (parameters as Parameters).property = 100000;
                Thread.Sleep(300);
            }
            (parameters as Parameters).property = 100;
        }
        public class Parameters
        {
            public int duration { get; set; }
            public int property { get; set; }
            public Parameters(int duration, int property)
            {
                this.duration = duration;
                this.property = property;
            }
        }

        public int Duration { get; set; }
        public override int FuryCost => 50;

        public override void SkillEffect(object effectedCharacter, int skillPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Warrior))
            {
                var armoredCharacter = effectedCharacter as Warrior;
                if (armoredCharacter.Fury >= FuryCost)
                {
                    Duration = armoredCharacter.Level;
                    armoredCharacter.Fury -= FuryCost;
                    Thread thr = new Thread(Tick);
                    thr.Start(new Parameters(Duration, (armoredCharacter as Character).Armor));

                }
                else
                    throw new ArgumentException("Недостаточно ярости!");
            }
            else
                throw new ArgumentException("Этот персонаж не воин!");
        }
    }
}