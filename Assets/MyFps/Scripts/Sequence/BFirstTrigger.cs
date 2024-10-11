using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public GameObject theArrow;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table";
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        //Ʈ���� �۵��� �÷���
        IEnumerator PlaySequence()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ(�÷��� ����)
            thePlayer.SetActive(false);

            //��� ���: "Looks like a weapon on that table."
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //1�� ������
            yield return new WaitForSeconds(1f);

            //ȭ��ǥ Ȱ��ȭ
            theArrow.SetActive(true);

            //1�� ������
            yield return new WaitForSeconds(2f);

            //�ʱ�ȭ
            textBox.text = "";
            textBox.gameObject.SetActive(false);
            //�÷��� ĳ���� Ȱ��ȭ(�ٽ� �÷���)
            thePlayer.SetActive(true);
            //Ʈ���� �浹ü ��Ȱ��ȭ
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}