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
            //�� Ŭ���� ó��

            //����� ����
            AudioManager.Instance.StopBgm();

            //�� Ŭ���� ����, ������ ó��
            //...

            //Ŀ�� �ʱ�ȭ
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //���� �Ŵ��� �̵�
            fader.FadeTo(loadToScene);
        }
    }
}