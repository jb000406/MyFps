using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject gunMan;
        public GameObject[] enemyZoneOut; // Out 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                if (gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Out 트리거 활성화
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                foreach (GameObject zone in enemyZoneOut)
                {
                    zone.SetActive(true);
                }
            }
        }
    }
}