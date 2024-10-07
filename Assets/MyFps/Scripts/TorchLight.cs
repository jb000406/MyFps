using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace MyFps
{

    public class TorchLight : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;
        private Animator animator;


        //1초 타이머
        [SerializeField] private float flameTimer = 1f;
        private float countdown = 0f;

        private int lightMode;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            animator = torchLight.GetComponent<Animator>();
            lightMode = 0;

            InvokeRepeating("LightAnimation", 0f, 1f);
        }

        // Update is called once per frame
        void Update()
        {
            /*if (lightMode == 0)
            {
                StartCoroutine(FrameAnimation());
            }*/


        }

        IEnumerator FrameAnimation()
        {
            lightMode = Random.Range(1, 4);
            animator.SetInteger("LightMode", lightMode);
            

            yield return new WaitForSeconds(1.0f);

            lightMode = 0;
        }

        //반복 함수
        private void LightAnimation()
        {
            lightMode = Random.Range(1, 4);
            animator.SetInteger("LightMode", lightMode);
        }

    }
}