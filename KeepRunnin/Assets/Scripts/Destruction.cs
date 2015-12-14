using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject desPoint;

    void Start()
    {
        desPoint = GameObject.Find("Destroy");
    }//start

    void Update()
    {
        if (transform.position.x < desPoint.transform.position.x)
        {
            Destroy(gameObject);
        }//
    }//update

}//class