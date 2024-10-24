using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{

    public class MainMenu : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;

        [SerializeField] private string loadToScene = "PlayScene01";
            
        #endregion
        // Start is called before the first frame update
        private void Start()
        {
            fader.FromFade();
        }

        public void NewGame()
        {
            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {

        }

        public void Options()
        {
            Debug.Log("���� â ����");
        }

        public void Credits()
        {
            Debug.Log("ũ���� â ����");
        }

        public void QuitGame()
        {
            Debug.Log("���� ����");
            Application.Quit();
        }
    }
}