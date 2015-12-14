using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{

    //declaration of variables
    public GameObject poolObj;
    public int poolAmt;
    List<GameObject> poolObjs;

    void Start()
    {
        poolObjs = new List<GameObject>();

        for(int i = 0; i < poolAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObj);
            obj.SetActive (false);
            poolObjs.Add(obj);
        }//for
    }//start

    public GameObject GetPoolObj()
    {
        for(int i  = 0; i < poolObjs.Count; i++)
        {
            if (!poolObjs[i].activeInHierarchy)
            {
                return poolObjs[i];
            }//if
        }//for

        GameObject obj = (GameObject)Instantiate(poolObj);
        obj.SetActive(false);
        poolObjs.Add(obj);

        return obj;
    }//get pooled object
}//class