using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    //�÷��̾��� �����ϸ� �ڵ����� ���ӵ����� ����
    public class AutoSave : MonoBehaviour
    {
        private void Start()
        {
            //����ȣ ����
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            //���� �� ����
            int sceneNumber = PlayerStats.Instance.SceneNumber;
            int playScene = SceneManager.GetActiveScene().buildIndex;

            //���� �÷����ϴ� ���̳�?
            if (playScene > sceneNumber)
            {
                PlayerStats.Instance.SceneNumber = playScene;
                SaveLoad.SaveData();
            }
        }
    }
}