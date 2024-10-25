using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class BreakableObjects : MonoBehaviour , IDamageable
    {
        #region Variables
        public GameObject fakeObject;       //������ ������Ʈ
        public GameObject breakObject;      //���� ������Ʈ
        public GameObject effectObject;     //������ ������ ȿ�� ������Ʈ

        public GameObject hiddenItem;       //������ ������

        private bool isBreak = false;
        [SerializeField] private bool unBreakable = false;   //true:������ �ʴ´�


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