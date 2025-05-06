using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float Followspeed = 2f;
    public float yOffset = 1f;
    public Transform target;


    // Update is called once per frame
    void Update()
    {   // camera transfomrs location to follow player
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, Followspeed * Time.deltaTime);
    
    }
}
