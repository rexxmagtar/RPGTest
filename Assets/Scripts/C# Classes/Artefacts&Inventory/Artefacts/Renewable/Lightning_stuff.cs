using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artefacts;
using Characters;

namespace Artefacts
{
    public class Lightning_stuff : Artefact
    {
        public GameObject lightning;
        public bool csasah;
        public int power = 100;
        public bool isRenewable = true;
        public override bool IsRenewable
        {
            get { return isRenewable; }
        }

        public Lightning_stuff(int power)
        {
            this.power = power;
            name_ = "Lightning";

        }

        public override void SkillEffect(object ch)

        {
            

            if (ArtefactPower <= 0)
            {
                Debug.LogError("Art power is " + ArtefactPower);
                return;
            }
            Debug.Log("Lightning is no in use");
            Transform caster_pos = (ch as Wizard).gameObject.GetComponent<Transform>();
            GameObject[] targets = GameObject.FindGameObjectsWithTag ( "enemy" );
            GameObject main_target=null;
            Transform trans_ataker = caster_pos;
            
            foreach (var item in targets)
            {
               
                Transform trans_target = item.transform;
                if (Mathf.Abs(trans_ataker.position.x - trans_target.position.x) + Mathf.Abs(trans_ataker.position.y - trans_target.position.y) <= 100 / 2)
                {
                    Debug.Log("Цель найдена!");
                    main_target = item;
                    break;

                }
            }



            if (main_target != null)
            {
                Vector2 direction_agro = (main_target.transform.position + trans_ataker.position)/2;
                Vector3 direction_rotate = (main_target.transform.position - trans_ataker.position);
                Debug.Log("Name " + lightning);

                Instantiate((ch as Wizard).lightning, direction_agro, new Quaternion(direction_rotate.x,direction_rotate.y,0,0));
                main_target.GetComponent<Characters.Enemy>().Hp -= power;
                Debug.Log("Попали в " + main_target);
                ArtefactPower -= power;
            }
         
            
           

        }

        public void cast_lightning(GameObject target,GameObject caster)
        {
          

        }

            // Start is called before the first frame update
            void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
