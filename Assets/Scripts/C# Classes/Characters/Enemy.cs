using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine.Serialization;
using UnityEngine;
using Artefacts;

namespace Characters
{

    public class Enemy : Character
    {

    public      List<GameObject> enemy_inventory=new List<GameObject>();
        public new void Start()
        {
            health_bar.maxValue = MaxHp;
            health_bar.value = Hp;
            canDamage = false;
            MovingAble = true;
        }


        public int expirience_given;
        public void get_save_enemy(Enemy_save_data save)
        {
            get_save(save);
            expirience_given = save.exp_given;
            
        }

        public void drop_items()
        {
            foreach (var item in enemy_inventory)
            {
                Instantiate(item.GetComponent<artefact_controller>().art.prefab, gameObject.transform.position,new Quaternion());
            }
        }
    }
}