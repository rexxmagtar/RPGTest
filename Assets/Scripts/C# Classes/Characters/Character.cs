using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artefacts;

namespace Characters

    

{
    

    public class inventory
    {
        public bool droped = true;
        public Artefact[] container = new Artefact[5] { null, null, null, null, null };
        public int count = 0;
        private void add_item(Artefact art)
        {
            
            for(int i = 0; i < 5; i++)
            {
                if (container[i] == null)
                {
                    container[i] = art;
                    count++;
                    return;
                }
            }
        }
        private void check_add(Artefact art)
        {
            if (count < 5)
            {
                add_item(art);
                Debug.Log(art.name_ + "Добавлен");
            }
            else
                throw new Exception("Инвентраь переполнен");

        }
        public void add_func(Artefact art)
        {
            if (art.IsRenewable)
            {
                check_add(art);
            }
            else
            {

                for(int i = 0; i < 5; i++)
                {

                    if (container[i]!=null && container[i].name_ == art.name_)
                    {

                        container[i].count_of_bottles++;
                        return;
                    }


                }
                check_add(art);
            }
           
        }

        public void throw_item(Artefact art)
        {
            Debug.Log("Наш артефакт " + art.name_ + " id= " + art.id_);
            for (int i = 0; i < 5; i++)
            {
                if (container[i] != null)
                  Debug.Log("Сравниваем с  " + container[i].name_+" id= "+container[i].id_);
                if (container[i]!=null && container[i].id_ == art.id_)
                {
                    Debug.Log("Выбросисли " + art.name_);
                    remove_item(i);
                    return;
                }
            }

        }
        private void remove_item(int i)
        {
            container[i] = null;
            count--;

        }




        public void UseArtefact(int id, Character target)
        {
            Debug.Log("Ищем в рюкзаке " + id);
            for (int i = 0; i < 5; i++)
            {
                if (container[i] != null)
                {
                    Debug.Log("Проверяем " + container[i].name_ + " id= " + container[i].id_);
                }
                   if (container[i]!=null &&  container[i].id_ == id)
                {
                    Debug.Log("нашли!");
                    container[i].SkillEffect(target);
                    if (!container[i].IsRenewable && container[i].count_of_bottles < 2)
                    {Debug.Log("Закончился! -выбрасываем");
                        throw_item(container[i]);
                        
                    }
                    else
                    {
                        container[i].count_of_bottles--;
                    }
                    return;
                }


            }
            Debug.Log(" не нашли...");


        }


    }
    [Serializable]
    public abstract class Character :MonoBehaviour, IComparable
    {
        public bool can_drop_items = true;   
        public Coroutine cor;
        public Canvas menu;
        public GameObject Poison_prefab;
        public enum Gender { Men, Woman };
        public enum Race { Human, Dwarf, Elf, Orc, Goblin };
        public enum Condition { Normal, Weak, Poisoned /*Sick, Paralyzed*/, Dead };
        public enum current_state { calm, got_damage, is_fighting };
       public  current_state state = current_state.calm;
        public float dead_time=3;
        public bool dead_count_time = false;
        public Characters.inventory inventory=new inventory();
        
        public Vector3 char_pos;
        public Canvas canvas_character;
        public Slider health_bar;
        public Slider mana_bar;
        public float speed;

        public Character()
        {

        }
        


        public void add_item_to_inventory(Artefact art)
        {


        }

        public void add_item_and_update(Artefact art)
        {

            inventory.add_func(art);
            menu.GetComponent<canvas_controller>().update_inventor_func();
            Debug.Log(" update comlited");

        }




        public void use_artefact_unity(int id)
        {
            Debug.Log("Использум " + id);
            
           this.inventory.UseArtefact(id, this);
            menu.GetComponent<canvas_controller>().update_inventor_func();

        }






        public void Start()
        {
           
            
            

        }

        public void Update()
        {
           

            CheckCondition();

            if (!GetComponent<Animation>().isPlaying && CurrentCondition != Condition.Dead)
                GetComponent<Animation>().Play("calming");

            if (CurrentCondition == Condition.Dead)
            {
                MovingAble = false;
                canDamage = false;

                gameObject.transform.localRotation = new Quaternion(0, 0, 1, -15/10);
                cor = StartCoroutine(dead_func(gameObject));
                if (this is Enemy && this.can_drop_items)
                {
                    can_drop_items = false;
                    (this as Enemy).drop_items();
                }
                //dead_count_time = true;
            }
            if(this is Wizard)
            menu.GetComponent<canvas_controller>().update_bars();
            //if (dead_count_time)
            //{

            //    Debug.Log(dead_time.ToString());
            //    Debug.Log("COUNTIBG");
            //    dead_time -= Time.deltaTime;
            //    Debug.Log(Time.deltaTime.ToString());
            //    Debug.Log(dead_time.ToString());
            //    if (dead_time < 0)
            //    {
            //        dead_count_time = false;
            //        Destroy(gameObject);
            //    }
            //}
        }

        public IEnumerator dead_func(GameObject obj)
        {
            Debug.Log("Hes dying");
            yield return new WaitForSeconds(3);
            if (obj.GetComponent<Characters.Enemy>() != null)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<Wizard>().Experience += obj.GetComponent<Characters.Enemy>().expirience_given;
            }
            if (obj.GetComponent<Characters.Wizard>() != null && obj.GetComponent<Characters.Wizard>().Hp > 0)
                obj.transform.rotation = new Quaternion();
            else
            Destroy(obj);
        }
        public void func_destroy(GameObject obj)
        {
            Destroy(obj);
        }
        public bool _isSick;

        public bool IsSick
        {
            set
            {
                if (value == true)
                {
                    _isSick = true;
                    MaxHp = Convert.ToInt32(MaxHp * 0.6);

                }
                else
                {
                    _isSick = false;
                    MaxHp = Convert.ToInt32(MaxHp / 0.6);
                }
            }
            get => _isSick;
        }
        
        
        public bool _isParalized;
        public bool IsParalized
        {
            set
            {
                if (value == true)
                {
                    _isParalized = true;
                    MovingAble = false;

                }
                else
                {
                    _isParalized = false;
                    MovingAble = true;
                }
            }
            get => _isParalized;
            
        }


        public int Id;
        public Race CurrentRace;

        public string _name;
        public string Name {
            get => _name;
            set
            {
                if(value == null)
                    throw new ArgumentException();                    
            }
        }
        
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
            set {
                if (value < Hp)
                    state = current_state.got_damage;
                if (value >= MaxHp)
                    _hp = MaxHp;
                else
                _hp = value;
                
                health_bar.value = _hp;
         
                
            }
        }

        public int _maxHp;

        public int MaxHp
        {
            get => _maxHp;
            set
            {
                _maxHp = value;
                health_bar.maxValue = value;
            }
        }

        public int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                menu.GetComponent<canvas_controller>().spell_points++;
                if(_level<6)
                menu.GetComponent<canvas_controller>().start_upping();
                MaxHp *= _level;
                Damage *= _level;
                //При создании персонажа начальный уровень характеристик разный, с ростом уровня
                //разница будет все больше
                Agility *= _level;
                Power *= _level;
                Intellegency *= _level;
                
            }
        }


        public Gender CurrentGender;
        
        public int _age;
        public int Age
        {
            get => _age;
            set
            {
              if(value < 0)
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
        public Condition CurrentCondition=Condition.Normal;
        
        
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

        public bool MovingAble=true;

        public bool _talking;

        public bool Talking
        {
            get => _talking;
            set => _talking = value;
        }

        public static int NextId = 0;
        
      
        
        public Character(string aName, Race aRace, Gender aGender, int aAge)
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


        public void get_save(Character_save_data save)
        {
            char_pos =new Vector3( save.char_pos_x, save.char_pos_y, save.char_pos_z);
            Id = save.Id;
            Name = save.Name;
            speed = save.speed;
            CurrentRace = (Race)save.CurrentRace;
            CurrentGender = (Gender)save.CurrentGender;
            Age = save.Age;
            CurrentCondition = (Condition)save.CurrentCondition;
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
            CurrentCondition = Condition.Normal;
        double tempHp = Hp * 1.0 / (MaxHp * 1.0);
           

            if ((tempHp >=3))
            {
                CurrentCondition = Condition.Normal;
            }

            if (Hp <= 0) CurrentCondition = Condition.Dead;
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
            Debug.Log("Попытался ударить");
            
            
                Debug.Log(this.name + "Нанес " + Damage + " урона " + (effectedCharacter as Wizard).name);
                var atackedCharacter = effectedCharacter as Wizard;
                atackedCharacter.Hp  -= Damage;
            
            
               
        }
    }
    
}

