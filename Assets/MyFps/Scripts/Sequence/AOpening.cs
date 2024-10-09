using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "I need get out of here";
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(PlaySequence());
        }

        //������ ������
        IEnumerator PlaySequence()
        {
            //0.�÷��� ĳ���� �� Ȱ��ȭ
            thePlayer.SetActive(false);

            //1.���̵��� ����(1�� ����� ���ε��� ȿ��)            
            fader.FromFade(1f); //2�ʵ��� ���̵� ȿ��

            //2.ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ȭ�� ���(3��)
            //(I need get out of here)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //3. 3���Ŀ� �ó����� �ؽ�Ʈ ��������
            yield return new WaitForSeconds(3f);
            //textBox.text = "";
            textBox.gameObject.SetActive(false);

            //4.�÷��� ĳ���� Ȱ��ȭ
            thePlayer.SetActive(true);
        }

    }
}