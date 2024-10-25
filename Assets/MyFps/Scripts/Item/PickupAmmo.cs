using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickupAmmo : PickupItem
    {
        #region Variables
        [SerializeField] private int giveAmount = 7;
        #endregion

        protected override bool OnPickup()
        {
            //ÅºÈ¯ 7°³ Áö±Þ
            PlayerStats.Instance.AddAmmo(giveAmount);

            return true;
        }
    }
}
