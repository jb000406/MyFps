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


        // ���콺�� �������� �׼� UI�� �����ش�
        private void OnMouseOver()
        {
            //�Ÿ��� 2���� �϶�
            if (theDistance <= 1.5f)
            {
                actionUI.SetActive(true);
                if(animator.GetBool("IsOpen") == false)
                {
                    actionText.text = openAction;
                    if (Input.GetButtonDown("Action"))
                    {
                        //���� ������
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
                        //���� ������
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

        // ���콺�� ����� �׼� UI�� �����
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