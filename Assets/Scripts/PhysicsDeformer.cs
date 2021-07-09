using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDeformer : MonoBehaviour
{

    //Radius of which the collision appears
    public float collisionRadius = 0.1f;
    public DeformableMesh deformableMesh;
    // Start is called before the first frame update

    void OnCollisionStay(Collision collision)
    {
      foreach(var contact in collision.contacts)
      {
        deformableMesh.AddDepression(contact.point, collisionRadius);
      }
    }
}
