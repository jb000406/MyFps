using MyFps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;


        //Action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        //Action
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 1.5f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //Action
                    DoAction();


                }

            }
            else
            {
                HideActionUI();
            }
        }

        private void OnMouseExit()
        {
            HideActionUI();
        }


        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }


    }
}