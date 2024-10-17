using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //AmmoBox ������ ȹ��
    public class PickupAmmoBox : Interactive
    {
        #region Variables
        //AmmoBox ������ ȹ��� �����ϴ� ammo ����
        [SerializeField] private int giveAmmo = 7;

        #endregion


        protected override void DoAction()
        {
            //������ ����
            Debug.Log("źȯ 7���� ���� �߽��ϴ�");
            PlayerStats.Instance.AddAmmo(giveAmmo);



            //ų
            Destroy(gameObject);
        }
    }
}