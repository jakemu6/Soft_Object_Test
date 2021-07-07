using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GeneratePlaneMesh))]
public class DeformableMesh : MonoBehaviour
{

    public float maximumDepression;
    public List<Vector3> originalVertices;
    public List<Vector3> modifiedVertices;

    private GeneratePlaneMesh plane;


    //called by GeneratePlaneMesh
    //anytime the mesh needs to be regenerated this is called.
    public void MeshRegenerated()
    {
      plane = GetComponent<GeneratePlaneMesh>();
      plane.mesh.MarkDynamic();
      //references to the mesh, mark as dynamic so that they can change and affect all lists of vertices
      originalVertices = plane.mesh.vertices.ToList();
      modifiedVertices = plane.mesh.vertices.ToList();
      Debug.Log("Mesh Regenerated");


    }

    public void AddDepression(Vector3 depressionPoint, float radius)
    {
      //translate the depression relative to the worldspace
      //creating a vector3 out of vec4
      var worldPos4 = this.transform.worldToLocalMatrix * depressionPoint;
      var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);

      //
      for (int i = 0; i < modifiedVertices.Count; ++i)
      {
        var distance = (worldPos - (modifiedVertices[i] + Vector3.down * maximumDepression)).magnitude;
        if (distance < radius)
        {
          var newVert = originalVertices[i] + Vector3.down * maximumDepression;
          modifiedVertices.RemoveAt(i);
          modifiedVertices.Insert(i, newVert);
        }



      }

      plane.mesh.SetVertices(modifiedVertices);
      Debug.Log("Mesh Depressed");

    }

}
