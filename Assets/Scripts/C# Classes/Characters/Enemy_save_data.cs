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
    public  class Enemy_save_data : Character_save_data
    {


        public int exp_given;

        public Enemy_save_data(Enemy save):base(save)
        {
            exp_given = save.expirience_given;
        }
    }

}

