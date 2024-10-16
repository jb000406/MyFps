using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{

    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        private string playScene = "PlayScene";
        private string TitleUI = "Title";
        #endregion

        private void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            //페이드인 효과
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(playScene);
        }

        public void Menu()
        {
            SceneManager.LoadScene(TitleUI);
        }
    }
}