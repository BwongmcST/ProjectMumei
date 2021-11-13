using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;
        public float PlayerHP
        {
            get { return _saveData.playerHP; }
            set { _saveData.playerHP = value; }
        }

        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
        }

       public void Save()
        {
            _jsonSaver.Save(_saveData);
        }

        public void Load()
        {
            _jsonSaver.Load(_saveData);
        }
    }
}