using UnityEngine;

public class camCtrl : MonoBehaviour {

    public GameObject target;
    private Vector3 targetPos;
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(target.transform.position.x , transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, velocity * Time.deltaTime);
    }// This will allow our camera to dynamically follow different objects in the game such as a player / event
}

