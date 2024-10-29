using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class MoveWall : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float moveSpeed = 1f;

        [SerializeField] private float moveTime = 1f;
        private float countdown = 0f;

        //�̵� ���� ��/��
        [SerializeField] private float dir = 1f;
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            countdown = moveTime;
        }

        private void Update()
        {
            //�¿� �̵� Ÿ�̸�
            if(countdown <= 0f)
            {
                //Ÿ�̸� �׼� - ������ȯ
                dir *= -1;

                //�ʱ�ȭ
                countdown = moveTime;
            }
            countdown -= Time.deltaTime;

            transform.Translate(Vector3.right * dir * Time.deltaTime * moveSpeed, Space.Self);
        }
    }
}