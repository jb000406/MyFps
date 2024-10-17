using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //�÷��̾� ����
    public enum PlayerState
    {
        P_Idle,
        P_Walk,
        P_Attack,
        P_Death
    }
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";

        Animator animator;

        //�÷��̾� ���� ����
        private PlayerState currentState;
        //�÷��̾� ���� ����
        private PlayerState beforeState;

        private bool isDeath = false;

        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        //������ ȿ��
        public GameObject damageFlash;      //������ �÷��� ȿ��
        public AudioSource hurt01;          //������ ����1
        public AudioSource hurt02;          //������ ����2
        public AudioSource hurt03;          //������ ����3

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            //����
            animator = GetComponent<Animator>();

            //�ʱ�ȭ
            isDeath = false;
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            if (isDeath) return;

            switch (currentState)
            {
                case PlayerState.P_Idle:
                    break;
                case PlayerState.P_Walk:
                    break;
                case PlayerState.P_Attack:
                    break;
                case PlayerState.P_Death:
                    break;
            }
        }

        public void SetState(PlayerState newState)
        {
            //���� ���� üũ
            if (currentState == newState)
                return;

            //���� ���� ����
            beforeState = currentState;
            //���� ����
            currentState = newState;

            //���� ���濡 ���� ���� ����
            //animator.SetInteger("PlayerState", (int)newState);
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Remaion Health : {currentHealth}");

            //������ ȿ��
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;
            fader.FadeTo(loadToScene);
            
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);
            if(randNumber == 1)
            {
                hurt01.Play();
            }
            else if(randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);

            damageFlash.SetActive(false);
        }
    }
}