using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{

    public class FullExitEye : Interactive
    {
        #region Variables
        public GameObject emptyPicture;
        public GameObject fullPicture;
        public GameObject exitTrigger;

        public Animator exitWallAnimator;

        public TextMeshProUGUI textBox;
        [SerializeField] private string puzzleStr = "You need more Eye Pictures";

        #endregion
        protected override void DoAction()
        {
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                 && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                //�ⱸ ����
                StartCoroutine(OpenExitWall());
            }
            else
            {
                //�޼��� ���
                StartCoroutine(LockedExitWall());
            }
        }

        IEnumerator OpenExitWall()
        {
            //�ϼ��� �׸� ���̱�

            emptyPicture.SetActive(false);
            fullPicture.SetActive(true);

            exitTrigger.SetActive(true);

            exitWallAnimator.SetBool("IsOpen", true);
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator LockedExitWall()
        {
            unInteractive = true;

            textBox.gameObject.SetActive(true);
            textBox.text = puzzleStr;

            yield return new WaitForSeconds(2f);

            textBox.text = "";
            textBox.gameObject.SetActive(false);

            unInteractive = false;
        }
    }
}