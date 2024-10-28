using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //���� ������ ȹ�� ����
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY             //���� ������ ����
    }

    //�÷��̾� �Ӽ����� �����ϴ�(�̱���, DontDestroy)Ŭ����.. ammoCount
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        //źȯ ����
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            private set { ammoCount = value; }
        }


        //���� ���� ������ Ű
        private bool[] puzzleKeys;

        #endregion

        private void Start()
        {
            //�Ӽ���/Data �ʱ�ȭ
            AmmoCount = 0;
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            //���� ���� üũ
            if (AmmoCount < amount)
            {
                Debug.Log("You need to reload!!!!");
                return false;   //��뷮���� �����ϴ�
            }

            AmmoCount -= amount;
            return true;
        }

        //���� ������ ȹ��
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }

        //���� �������� ���� ����
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }
    }
}