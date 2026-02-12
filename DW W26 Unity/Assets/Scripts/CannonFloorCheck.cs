using UnityEngine;

public class CannonFloorCheck : MonoBehaviour
{
    LayerMask FloorLayers;
    public Rigidbody2D RigidBody; 

    private void Start()
    {
        FloorLayers = LayerMask.GetMask("ground");
    }
    void FixedUpdate()
    {
       if (RigidBody.IsTouchingLayers(FloorLayers))
        {
            RigidBody.transform.position += new Vector3(0,-0.1f,0);
        }
    }
}
