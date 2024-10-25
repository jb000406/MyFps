using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class BreakableObjects : MonoBehaviour , IDamageable
    {
        #region Variables
        public GameObject fakeObject;       //온전한 오브젝트
        public GameObject breakObject;      //깨진 오브젝트
        public GameObject effectObject;     //깨지는 움직임 효과 오브젝트

        public GameObject hiddenItem;       //숨겨진 아이템

        private bool isBreak = false;
        [SerializeField] private bool unBreakable = false;   //true:깨지지 않는다


        #endregion

        public void TakeDamage(float damage)
        {
            if(unBreakable == true) return;

            if(!isBreak)
            {
                StartCoroutine(BreakObject());
            }

        }

        IEnumerator BreakObject()
        {
            isBreak = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);

            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if (effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }

            if (hiddenItem != null )
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}