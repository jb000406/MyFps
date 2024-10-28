using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class PickupRightEye : PickupPuzzleItem
    {
        #region Variables

        public GameObject fakeWall;
        public GameObject exitWall;
        public GameObject emptyEye;
        public GameObject fullEye;

        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

            ShowExitWall();
            
        }

        private void ShowExitWall()
        {
            //�ⱸ ���̱�
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                fakeWall.SetActive(false);
                exitWall.SetActive(true);
            }
        }
    }
}