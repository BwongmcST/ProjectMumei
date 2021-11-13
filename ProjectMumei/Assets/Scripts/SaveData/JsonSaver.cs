using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace SaveData
{
    public class JsonSaver
    {

        private static readonly string _filename = "saveData1.sav";

        public static string GetSaveFilename()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        public void Save (SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            string saveFileName = GetSaveFilename();

            FileStream filestream = new FileStream(saveFileName, FileMode.Create);

            using(StreamWriter writer = new StreamWriter(filestream))
            {
                writer.Write(json);
            }
            Debug.Log("File Saved to" + GetSaveFilename());
            
        }

        public bool Load(SaveData data)
        {
            string loadFilename = GetSaveFilename();
            if(File.Exists(loadFilename))
            {
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    string json = reader.ReadToEnd();
                    JsonUtility.FromJsonOverwrite(json, data);
                    Debug.Log("Load Successful");
                }           
                return true;
            }
            Debug.Log("NO Json File found");
            return false;
        }

        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

    }
}
