using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string objTag;
        public GameObject prefab;
        public int size;
        
    }

    private Dictionary<string, Queue<GameObject>> poolingDictionary = new Dictionary<string, Queue<GameObject>>();

    [SerializeField] private List<Pool> listaDePools = new List<Pool>();

    #region Singleton

    private static Pooling instance;
    public static Pooling Instance => instance;

    #endregion

    private void Awake()
    {
        if(instance != this)
            instance = this;
        
        foreach (Pool pool in listaDePools)
        {
            Queue<GameObject> filaDeObjetos = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                filaDeObjetos.Enqueue(obj);
                obj.SetActive(false);
            }
            poolingDictionary.Add(pool.objTag,filaDeObjetos);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        if (!poolingDictionary.ContainsKey(tag))
        {
            print($"Pool com a tag {tag} não encontrado");
            return null;
        }
        
        GameObject pooledObj = poolingDictionary[tag].Dequeue();

        pooledObj.transform.position = pos;
        pooledObj.transform.rotation = rot;
        pooledObj.SetActive(true);
        
        poolingDictionary[tag].Enqueue(pooledObj);
        
        return pooledObj;
    }
}
