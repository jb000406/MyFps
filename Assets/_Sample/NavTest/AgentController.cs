using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MySample
{
    // ���콺�� �׶��带 Ŭ���ϸ� Ŭ���� �������� Agent�� �̵���Ų��
    public class AgentController : MonoBehaviour
    {
        #region Variables

        private NavMeshAgent agent;

        [SerializeField] private Vector3 worldPosition; //�̵� ��ǥ����
        #endregion

        private void Start()
        {
            //����
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                SetDestinationToMousePosition();
            }
        }

        private void SetDestinationToMousePosition()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

            }
        }
    }
}