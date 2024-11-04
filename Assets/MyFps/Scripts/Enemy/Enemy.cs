using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idle,     //���
        E_Walk,     //�ȱ�   - ���� ���������� ���� ���
        E_Attack,   //���Ž� ����
        E_Death,    //�ױ�
        E_Chase     //�߰�(�ȱ�)    - ���� �������� ���
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        //�� ���� ����
        private EnemyState currentState;
        //�� ���� ����
        private EnemyState beforeState;

        //ü��
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;

        //����
        [SerializeField] private float attackRange = 1.5f;      //���� ���� ����
        [SerializeField] private float attackDamage = 5f;       //���� ������

        //��Ʈ��
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startPosition;  //������ġ, Ÿ���� �Ҿ����� ���ƿ��� ����

        //�� ����
        private bool isAiming = false;
        public bool IsAiming
        {
            get { return isAiming; }
            private set
            {
                isAiming = value;
            }
        }

        [SerializeField] private float detectDistance = 20f;
        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            //����
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            //�ʱ�ȭ
            currentHealth = maxHealth;
            startPosition = transform.position;
            nowWayPoint = 0;

            if(wayPoints.Length > 0 )
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
            



        }

        private void Update()
        {
            if (isDeath)
                return;

            //Ÿ�� ����            
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (detectDistance > 0)
            {
                IsAiming = distance <= detectDistance;
            }

            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
                agent.SetDestination(this.transform.position);
            }
            else if (detectDistance > 0)
            {
                if (IsAiming)
                {
                    SetState(EnemyState.E_Chase);
                }
            }

            switch (currentState)
            {
                case EnemyState.E_Idle:
                    break;

                case EnemyState.E_Walk:
                    //���� ����
                    if(agent.remainingDistance < 0.2f)
                    {
                        GoNextPoint();
                    }
                    else
                    {
                        SetState(EnemyState.E_Idle);
                    }    
                    break;
                case EnemyState.E_Attack:
                    transform.LookAt(transform.position);
                    if (distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;
                case EnemyState.E_Chase:
                    if (detectDistance > 0 && !IsAiming)
                    {
                        GoStartPostion();
                        return;
                    }

                    //�÷��̾� ��ġ ������Ʈ
                    agent.SetDestination(thePlayer.position);
                    break;
            }
        }



        //���� ���� ����
        public void SetState(EnemyState newState)
        {
            if (isDeath)
                return;

            //���� ���� üũ
            if (currentState == newState)
                return;

            //���� ���� ����
            beforeState = currentState;
            //���� ����
            currentState = newState;

            //���� ���濡 ���� ���� ����
            if (currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);   //���ϸ��̼� �ȱ� ����
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }
            //Agent �ʱ�ȭ
            agent.ResetPath();
        }

        private void Attack()
        {
            Debug.Log("�÷��̾�");
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
           // Debug.Log($"Remaion Health : {currentHealth}");

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            SetState(EnemyState.E_Death);

            isDeath = true;

            //�浹ü ����
            transform.GetComponent<BoxCollider>().enabled = false;

            //ų
            Destroy(gameObject, 3f);
        }

        private void GoNextPoint()
        {
            nowWayPoint++;
            if(nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }

        //���ڸ��� ���ư���
        public void GoStartPostion()
        {
            if (isDeath)
                return;

            SetState(EnemyState.E_Walk);

            nowWayPoint = 0;
            agent.SetDestination(startPosition);
        }

        //�� ���� �ݰ�
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectDistance);
        }
    }
}