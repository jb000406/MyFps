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

        //������ ������
        IEnumerator PlaySequence()
        {
            //1.���̵��� ����(1�� ����� ���ε��� ȿ��)            
            fader.FromFade(1f); //2�ʵ��� ���̵� ȿ��

            yield return new WaitForSeconds(3f);

        }


        public void GamePlay()
        {
            SceneManager.LoadScene(SceneString);
        }

        public void GameQuit()
        {
            Debug.Log("���� ����");
        }
    }
}