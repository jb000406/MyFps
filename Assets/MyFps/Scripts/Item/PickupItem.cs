using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float verticalBobFrequency = 1f;   //�̵� �ӵ�
        [SerializeField] private float bobingAmount = 1f;           //�̵� �Ÿ�
        [SerializeField] private float rotateSpeed = 360f;          //ȸ�� �ӵ�

        private Vector3 startPosition;                              //���� ��ġ
        #endregion

        private void Start()
        {
            //ó�� ��ġ ����
            startPosition = transform.position;
        }

        private void Update()
        {
            //�� �Ʒ� ��鸲
            float bobingAnimationPhase = Mathf.Sin(Time.time * verticalBobFrequency) * bobingAmount;
            transform.position = startPosition + Vector3.up * bobingAnimationPhase;

            //ȸ��
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }

        //�浹 üũ
        private void OnTriggerEnter(Collider other)
        {
            //�÷��̾� üũ
            if (other.tag == "Player")
            {
                //������ ȹ��
                if (OnPickup() == true)
                {
                    //ȹ�漺��ȿ�� ����/����Ʈ

                    //ų
                    Destroy(gameObject);
                }
            }
        }

        //������ ȹ�� ����,���� ��ȯ
        protected virtual bool OnPickup()
        {
            //źȯ 7�� ����
            //Hp, Mp ������
            //...
            return true;
        }
    }
}
