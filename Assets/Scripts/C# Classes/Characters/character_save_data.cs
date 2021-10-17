using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artefacts;

namespace Characters
{
    [Serializable]
    public abstract class Character_save_data : IComparable
    {
        public enum Gender { Men, Woman };
        public enum Race { Human, Dwarf, Elf, Orc, Goblin };
        public enum Condition { Normal, Weak /*Sick, Poisoned, Paralyzed*/, Dead };
        public float dead_time = 3;
        public bool dead_count_time = false;
        public float speed;
        public List<Artefact> inventory;
        public  float char_pos_x;
        public float char_pos_y;
        public float char_pos_z;
        public Character_save_data()
        {

        }
        
      


       

        

         

      
        public bool _isSick;

        


        public bool _isParalized;
       


        public int Id;
        public Race CurrentRace { get; }

        public string Name;
        

        //Значение урона без оружия
        public int Damage;
        public int Power;
        public int Agility;
        public int Intellegency;
        public int Armor;

        public int _hp;
        public int Hp
        {
            get => _hp;
            set { _hp = value; }
        }

        public int _maxHp;

        public int MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        public int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                MaxHp *= _level;
                Damage *= _level;
                //При создании персонажа начальный уровень характеристик разный, с ростом уровня
                //разница будет все больше
                Agility *= _level;
                Power *= _level;
                Intellegency *= _level;
            }
        }


        public Gender CurrentGender { get; set; }

        public int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Возраст не должен быть отрицательным!");
                _age = value;
            }
        }

        public int _experience;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                if (_experience >= Level * 1000)
                    Level++;
            }
        }

        public Condition _condition;
        public Condition CurrentCondition { get; set; }


        //Игровые характиристики персонажа: сила, ловкость, интеллект
        public bool _canDamage;
        public bool canDamage
        {
            get
            {
                return _canDamage;
            }
            set
            {
                _canDamage = value;
            }
        }

        public bool MovingAble;

        public bool _talking;

        public bool Talking
        {
            get => _talking;
            set => _talking = value;
        }

        public static int NextId = 0;



        public Character_save_data(string aName, Race aRace, Gender aGender, int aAge)
        {
            Id = ++NextId;
            Name = aName;
            CurrentRace = aRace;
            CurrentGender = aGender;
            if (aAge < 0)
                throw new ArgumentException();
            Age = aAge;
            CurrentCondition = Condition.Normal;
            Hp = MaxHp;
            Experience = 0;
            Level = 0;
            MovingAble = false;
            Talking = false;
        }


        public Character_save_data(Character save)
        {
            char_pos_x = save.char_pos.x;
            char_pos_y = save.char_pos.y;
            char_pos_z = save.char_pos.z;
            Id = save.Id;
            Name = save.Name;
            CurrentRace =(Race)save.CurrentRace;
            CurrentGender = (Gender)save.CurrentGender;
            Age = save.Age;
            CurrentCondition =(Condition)save.CurrentCondition;
            Hp = save.Hp;
            Experience = save.Experience;
            Level = save.Level;
            MovingAble = save.MovingAble;
            Talking = save.Talking;
            Power = save.Power;
            Agility = save.Agility;
            Intellegency = save.Intellegency;
            Armor = save.Armor;

        }

            public int CompareTo(object obj)
        {
            if (!(obj is Character))
                throw new ArgumentException(
                "object is not a Person");
            Character other = (Character)obj;
            if (this.Experience < other.Experience)
                return -1;
            if (this.Experience > other.Experience)
                return 1;
            return 0;
        }
        public void CheckCondition()
        {
            double tempHp = Hp * 1.0 / (MaxHp * 1.0);
            if ((tempHp < 10) && (CurrentCondition == 0))
            {
                CurrentCondition = Condition.Weak;
            }

            if ((tempHp >= 10) && (CurrentCondition == Condition.Weak))
            {
                CurrentCondition = Condition.Normal;
            }

            if (Hp == 0) CurrentCondition = Condition.Dead;
        }

        public void Go() { MovingAble = true; }
        public void Stop() { MovingAble = false; }
        public void Talk() { Talking = true; }
        public void ShutUp() { Talking = false; }

        public override string ToString()
        {
            return String.Format
                ("The name is " + Name + "." + "\n" +
                 Name + " is " + CurrentRace + ", " + CurrentGender + ", " + Age + "." + "\n" +
                "Current experience level is " + Experience + "." + "\n" +
                "Current HP " + Hp + "." + "\n" +
                "Condition is " + CurrentCondition + ".");
        }

        public void ToHit(object effectedCharacter)
        {

            if (effectedCharacter.GetType() == typeof(Characters.Warrior) && (effectedCharacter as Warrior).Id != this.Id)
            {
                var atackedCharacter = effectedCharacter as Warrior;
                atackedCharacter.Hp -= Damage;
            }


        }
    }

}

