using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MyFps
{
    //���� ������ ���� ����/�������� ���� - ����ȭ ����
    public static class SaveLoad
    {
        #region Variables
        private static string fileName = "/playData.arr";
        #endregion

        public static void SaveData()
        {
            //�����̸�, ��� ����
            string path = Application.persistentDataPath + fileName;

            //������ �����͸� ����ȭ �غ�
            BinaryFormatter formatter = new BinaryFormatter();

            //�������� - �����ϸ� ���� ��������, �������� ������ ���� ���� ����
            FileStream fs = new FileStream(path, FileMode.Create);

            //������ ������ ����
            PlayData playData = new PlayData();

            //�غ��� �����͸� ����ȭ ����
            formatter.Serialize(fs, playData);

            //���� Ŭ����
            fs.Close();
        }

        public static PlayData LoadData()
        {
            PlayData playData;

            //�����̸�, ��� ����
            string path = Application.persistentDataPath + "/playData.arr";

            //������ ��ο� ����� ������ �ִ��� ������ üũ
            if (File.Exists(path) == true)
            {
                //������ ����
                //������ �����͸� ����ȭ �غ�
                BinaryFormatter formatter = new BinaryFormatter();

                //�������� - �����ϸ� ���� ��������, �������� ������ ���� ���� ����
                FileStream fs = new FileStream(path, FileMode.Open);

                //���Ͽ� ����ȭ�� ����� �����͸� ������ȭȭ�ؼ� �����´�
                playData = formatter.Deserialize(fs) as PlayData;

                //���� Ŭ����
                fs.Close();
            }
            else
            {
                //������ ����
                Debug.Log("Not Found Load File");
                playData = null;
            }

            return playData;
        }

        public static void DeleteFile()
        {
            string path = Application.persistentDataPath + fileName;
            File.Delete(path);

        }
    }
}
