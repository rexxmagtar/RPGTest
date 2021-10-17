using System;

namespace Characters
{
    public class Archer : Character
    {
        
        public Archer(string aName, Race aRace, Gender aGender, int aAge) : base(aName, aRace, aGender, aAge)
        {
            Agility = 100;
            Intellegency = 15;
            Power = 15;
            Armor = 20;

        }

    }
}