using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorKeyOpen : Interactive
    {
        #region Variables
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "You need the Key";
        #endregion

        protected override void DoAction()
        {
            //������
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(LockedDoor());
            }
        }

        void OpenDoor()
        {
            this.GetComponent<BoxCollider>().enabled = false;

            this.GetComponent<Animator>().SetBool("IsOpen", true);
            AudioManager.Instance.Play("DoorOpen");
        }

        IEnumerator LockedDoor()
        {
            //�� ��� �Ҹ�
            unInteractive = true;   //���ͷ�Ƽ�� ��� ����
            AudioManager.Instance.Play("DoorLocked");

            yield return new WaitForSeconds(1f);

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;   //���ͷ�Ƽ�� ��� ����
        }
    }
}
