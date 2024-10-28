using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class FExitTrigger : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                PlaySequence();
            }
        }

        void PlaySequence()
        {
            //씬 클리어 처리

            //배경음 종료
            AudioManager.Instance.StopBgm();

            //씬 클리어 보상, 데이터 처리
            //...

            //커서 초기화
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //메인 매뉴로 이동
            fader.FadeTo(loadToScene);
        }
    }
}