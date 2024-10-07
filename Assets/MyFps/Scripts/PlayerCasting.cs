using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //���鿡 �ִ� �浹ü���� �Ÿ� ���ϱ�
    public class PlayerCasting : MonoBehaviour
    {
        #region Variables
        public static float distanceFromTarget;
        [SerializeField] private float toTarget;
        #endregion

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distanceFromTarget = hit.distance;
                toTarget = distanceFromTarget;
            }

        }


        // Gizmo �׸��� : ī�޶� ��ġ���� �տ� �浹ü���� ������ ��� �� �׸���
        private void OnDrawGizmos()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);
            Gizmos.color = Color.red;

            if (isHit)
            {
                
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }
        }
    }
}