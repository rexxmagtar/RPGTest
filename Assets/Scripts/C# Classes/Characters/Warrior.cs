using System;
using WarriorSkills;

namespace Characters
{
    public class Warrior : Character
    {
        
        //Шкала ярости - аналог маны, ярость расходуется на особые способности воина, как и мана на заклинания
        private int _fury;
        public int Fury
        {
            get => _fury;
            set => _fury = value;
        }

        public static readonly int MaxFury = 100;
          
        public Warrior(string aName, Race aRace, Gender aGender, int aAge) : base(aName, aRace, aGender, aAge)
        {
            Power = 100;
            Agility = 30;
            Intellegency = 0;
            Armor = 100;
        }

        public void BeInFury()
        {
            var infury = new InFury();
            infury.SkillEffect(this, Power);
        }

        public void BeArmorFury()
        {
            var armorfury = new ArmorFury();
            armorfury.SkillEffect(this, Power);
        }

    }
}