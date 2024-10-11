using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;

        public GameObject thePlayer;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(OpenDoor());
        }

        IEnumerator OpenDoor()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ(�÷��� ����)
            thePlayer.SetActive(false);
            

            yield return new WaitForSeconds(1f);

            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            

            yield return new WaitForSeconds(1f);

            thePlayer.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}