using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    Camera cam;

    [SerializeField]
    Transform ringPrefab;

    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }

    void DeformMesh()
    {
        if((lastPos - Input.mousePosition).sqrMagnitude > 2)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                DeformPlane deformPlane = hit.transform.GetComponent<DeformPlane>();
                if (deformPlane == null) return;
                deformPlane.DeformThisPlane(hit.point);

                //Instantiate(ringPrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z + 0.12f), Quaternion.Euler(-90, 0, 0));
            }
        }
        
        lastPos = Input.mousePosition;
    }
}
