using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;          //문

        public AudioSource doorBang;        //문 열기 사운드
        public AudioSource JumpscareTune;   //적 등장 사운드

        public GameObject thePlayer;        //플레이어
        public GameObject theRobot;         //로봇

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
            //플레이 캐릭터 비활성화(플레이 멈춤)
            thePlayer.SetActive(false);
            

            yield return new WaitForSeconds(1f);

            //적 소환
            theRobot.SetActive(true);

            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);

            //문 사운드
            doorBang.Play();
            
            //적 등장 사운드
            JumpscareTune.Play();
            

            yield return new WaitForSeconds(1f);

            thePlayer.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}