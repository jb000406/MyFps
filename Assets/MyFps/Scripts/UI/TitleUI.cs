using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{

    public class TitleUI : MonoBehaviour
    {
        #region Variables
        private string SceneString = "PlayScene";

        public SceneFader fader;

        #endregion

        void Start()
        {
            StartCoroutine(PlaySequence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            //1.페이드인 연출(1초 대기후 페인드인 효과)            
            fader.FromFade(1f); //2초동안 페이드 효과

            yield return new WaitForSeconds(3f);

        }


        public void GamePlay()
        {
            SceneManager.LoadScene(SceneString);
        }

        public void GameQuit()
        {
            Debug.Log("게임 종료");
        }
    }
}