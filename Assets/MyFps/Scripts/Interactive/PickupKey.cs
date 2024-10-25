using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class PickupKey : Interactive
    {
        protected override void DoAction()
        {
            //key Item ¿˙¿Â
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.ROOM01_KEY);

            //≈≥
            Destroy(gameObject);
        }
    }
}