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
            //���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            //���̵��� ȿ��
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