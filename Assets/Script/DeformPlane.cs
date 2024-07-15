using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeformPlane : MonoBehaviour
{
    MeshFilter m_MeshFilter;
    Mesh m_Mesh;
    Vector3[] verts;

    [SerializeField]
    float radius;
    [SerializeField]
    float power;

    private void Start()
    {
        m_MeshFilter = GetComponent<MeshFilter>();
        m_Mesh = m_MeshFilter.mesh;
        verts = m_Mesh.vertices;
    }

    public void DeformThisPlane(Vector3 PositionToDeform)
    {
        PositionToDeform = transform.InverseTransformPoint(PositionToDeform);
        for(int i=0;i<verts.Length;i++)
        {
            float dist = (verts[i] - PositionToDeform).sqrMagnitude;
            if(dist < radius)
            {
                verts[i] -= Vector3.up * power;
            }
        }

        m_Mesh.vertices = verts;
    }

}
