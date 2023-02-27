using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T[] managers = Object.FindObjectsOfType<T>();

                if (managers.Length > 0)
                {
                    for (int i = 1; i < managers.Length; i++)
                    {
                        Destroy(managers[i]);
                    }

                    instance = managers[0];
                    instance.gameObject.name = typeof(T).Name;
                }
                else
                {
                    GameObject temp = new GameObject(typeof(T).Name, typeof(T));
                    instance = temp.AddComponent<T>();
                }
            }

            return instance;
        }
    }
}

