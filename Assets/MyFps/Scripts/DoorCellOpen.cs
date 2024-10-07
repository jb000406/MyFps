using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        private float theDistance;

        //Action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string openAction = "Open The Door";
        [SerializeField] private string closeAction = "Close The Door";
        [SerializeField] private Collider collider;

        //action
        private Animator animator;
       // private Collider collider;
        public AudioSource audioSource;

        

        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
           // collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }


        // 마우스를 가져가면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 1.5f)
            {
                actionUI.SetActive(true);
                if(animator.GetBool("IsOpen") == false)
                {
                    actionText.text = openAction;
                    if (Input.GetButtonDown("Action"))
                    {
                        //문이 열린다
                        animator.SetBool("IsOpen", true);
                        //collider.enabled = false;
                        audioSource.Play();
                    }
                }
                else if(animator.GetBool("IsOpen") == true)
                {
                    actionText.text = closeAction;
                    if (Input.GetButtonDown("Action"))
                    {
                        //문이 열린다
                        animator.SetBool("IsOpen", false);
                        //collider.enabled = true;
                        audioSource.Play();
                    }
                } 
            }
            else
            {
                HideActionUI();
            }
        }

        // 마우스가 벗어나면 액션 UI를 감춘다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }

    }
}