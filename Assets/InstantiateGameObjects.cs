using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameObjects : MonoBehaviour
{

    [Header("Instantiated Game Object 1 and 2")]
    public GameObject Object1;
    public Vector2 position1;
    public GameObject Object2;
    public Vector2 position2;

    // Start is called before the first frame update
    void Start()
    {
      GameObject Marker1 = Instantiate(Object1, new Vector3(position1.x, 0, position1.y), Quaternion.Euler(0, 0, 0));
      GameObject Marker2 = Instantiate(Object2, new Vector3(position2.x, 0, position2.y), Quaternion.Euler(0, 0, 0));

    }
}
