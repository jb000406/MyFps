using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        public GameObject thePlayer;
        public TextMeshProUGUI textBox;

        public GameObject ceiling;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            ceiling.SetActive(true);
            
            //���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(SequencePlay());
        }

        IEnumerator SequencePlay()
        {
            //�÷��̾� ��Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            //����� ����
            AudioManager.Instance.PlayBgm("PlayBgm");
            //������ �ؽ�Ʈ �ʱ�ȭ
            textBox.text = "";

            //1���� ���̵��� ȿ�� ����
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            //�÷��̾� Ȱ��ȭ
            yield return new WaitForSeconds(1f);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
