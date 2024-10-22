using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene02";

        private Animator animator;
        private Collider m_Collider;
        public AudioSource creakyDoor; //������ �Ҹ�

        public AudioSource bgm01;         //�����
        #endregion

        private void Start()
        {
            //����
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            //1.������ �ִϸ��̼�
            //2.������ ����
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;

            creakyDoor.Play();

            ChangeScene();
        }

        void ChangeScene()
        {
            //��������, .... bmg stop
            bgm01.Stop();

            //���������� �̵�
            fader.FadeTo(loadToScene);
        }
    }
}
