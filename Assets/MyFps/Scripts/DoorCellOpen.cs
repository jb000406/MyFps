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
        public GameObject extraCross;

        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;

        

        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            // collider = GetComponent<BoxCollider>();
            m_Collider = GetComponent<BoxCollider>();
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
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //문이 열리는 액션
                    animator.SetBool("IsOpen", true);
                    GetComponent<Collider>().enabled = false;
                    audioSource.Play();
                }

            }
            else
            {
                HideActionUI();
            }
            /*if (theDistance <= 1.5f)
            {
                actionUI.SetActive(true);
                if (animator.GetBool("IsOpen") == false)
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
                else if (animator.GetBool("IsOpen") == true)
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
            }*/ // 문 여닫이
        }

        // 마우스가 벗어나면 액션 UI를 감춘다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = openAction;
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