using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        //�̵�
        [SerializeField] private float moveSpeed = 5f;

        //�Է°�
        private float moveX;
        private float moveY;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //�յ��¿� �Է� ó��
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            //�̵�: ����, �ӵ�
            Vector3 dir = new Vector3(moveX, 0f, moveY);
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            //
            //AnimatorStateTest();
            AnimationBlendTest();
        }

        void AnimationBlendTest()
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }

        void AnimatorStateTest()
        {
            if (moveX == 0f && moveY == 0f)
            {
                animator.SetInteger("MoveState", 0);    //���
            }
            if (moveY > 0f)
            {
                animator.SetInteger("MoveState", 1);    //��
            }
            if (moveY < 0f)
            {
                animator.SetInteger("MoveState", 2);    //��     
            }
            if (moveX < 0f)
            {
                animator.SetInteger("MoveState", 3);    //��
            }
            if (moveX > 0f)
            {
                animator.SetInteger("MoveState", 4);    //��
            }
        }
    }
}