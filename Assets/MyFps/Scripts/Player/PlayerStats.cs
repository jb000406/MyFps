using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
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
        #endregion

        private void Start()
        {
            //�Ӽ���/Data �ʱ�ȭ
            AmmoCount = 0;
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
    }
}