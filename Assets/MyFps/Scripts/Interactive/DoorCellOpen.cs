using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        private float theDistance;

        //Action UI
        [SerializeField] private string openAction = "Open The Door";
        [SerializeField] private string closeAction = "Close The Door";
        [SerializeField] private Collider collider;


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


        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            GetComponent<Collider>().enabled = false;
            audioSource.Play();
        }

    }
}