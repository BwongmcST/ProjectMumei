using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public abstract class Menu<T>:Menu
        where T: Menu<T>
    {
        private static T _instance;
        public static T instance
        {
            get { return _instance; }
        }

        protected virtual void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
    

    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {
     
        public virtual void OnBackPressed()
        {
            if(MenuManager.instance != null)
            {
                MenuManager.instance.CloseMenu();
            }
        }

    }
}