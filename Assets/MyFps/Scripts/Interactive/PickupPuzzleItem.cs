using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        [SerializeField] private PuzzleKey puzzleKey;

        //����UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGp;

        public Sprite itemSprite;                                   //ȹ���� ������ ������
        [SerializeField] private string puzzleStr = "Puzzle Text";  //������ ȹ�� �ȳ� �ؽ�Ʈ
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            //puzzleKey ���� ������ ȹ��
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);

            //UI����
            if (puzzleUI != null)
            {
                //������ Ʈ���� ��Ȱ��
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }

            //������ Ʈ���� ų
            Destroy(gameObject);
        }
    }
}
