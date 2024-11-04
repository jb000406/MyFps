using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        //�̵�
        public CinemachineDollyCart cart;

        private bool[] isArrive;
        [SerializeField] private int wayPointIndex = 0; //�̵� ��ǥ���� �ε���

        //����
        public Animator cameraAnim;
        public GameObject introUI;
        public GameObject theShedLight;
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            cart.m_Speed = 0f;
            wayPointIndex = 0;
            isArrive = new bool[5];

            //��Ʈ�� ����
            StartCoroutine(StartIntro());
        }

        private void Update()
        {
            //��������
            if (cart.m_Position >= wayPointIndex && isArrive[wayPointIndex] == false)
            {
                //����
                if (wayPointIndex == isArrive.Length - 1)
                {
                    //������ ����
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }

            //��Ʈ�� ��ŵ escŰ ������ ��Ʈ�� ���� �����ϰ� �� �̵�
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainScene();
            }
        }

        IEnumerator StartIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;

            fader.FromFade();
            AudioManager.Instance.PlayBgm("IntroBgm");

            yield return new WaitForSeconds(1f);

            //ī�޶� �ִϸ��̼�
            cameraAnim.SetTrigger("ArroundTrigger");

            yield return new WaitForSeconds(3f);
            //���
            cart.m_Speed = 0.08f;
        }

        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            cart.m_Speed = 0f;

            yield return new WaitForSeconds(1f);

            //ī�޶� �ִϸ��̼�
            cameraAnim.SetTrigger("ArroundTrigger");

            int nowIndex = wayPointIndex - 1;   //���� ��ġ�ϰ� �ִ� ��������Ʈ �ε���
            switch (nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    break;
                case 2:
                    introUI.SetActive(false);
                    break;
                case 3:
                    break;
            }

            yield return new WaitForSeconds(3f);

            if (nowIndex == 3)
            {
                theShedLight.SetActive(true);
                yield return new WaitForSeconds(1f);
            }

            //���
            cart.m_Speed = 0.08f;
        }

        //
        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            yield return new WaitForSeconds(2f);

            theShedLight.SetActive(false);
            yield return new WaitForSeconds(2f);

            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }

        private void GoToMainScene()
        {
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
    }
}
