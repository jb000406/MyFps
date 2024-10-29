using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject gunMan;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                //건맨 추격 시작
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase); 
                
            }
        }
    }
}