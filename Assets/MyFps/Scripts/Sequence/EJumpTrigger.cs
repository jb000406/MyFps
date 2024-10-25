using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject Player;

        public GameObject activityObject;

        [SerializeField] private float force = 20f;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(PlaySequence());
            }
        }

        IEnumerator PlaySequence()
        {
            
            Rigidbody rb = activityObject.GetComponent<Rigidbody>();
            AudioManager.Instance.Play("PotterySmash");
            if (rb != null)
            {
                rb.AddForce(Vector3.back * force, ForceMode.Impulse);
            }

            
            //트리거 충돌체 비활성화 - 킬
            Destroy(gameObject);

            yield return null;
        }

    }
}