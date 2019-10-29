//
//2019-10-29
//plane에 이미지 원본크기 대응
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshImageScaler : MonoBehaviour
{
    public GameObject p_obj;
    public Mesh _savedMesh;
    public Texture tex;
    public Camera thisCamera;

    void Start()
    {
        _savedMesh = GetComponent<MeshFilter>().mesh;

        Vector3 vWorld1 = p_obj.transform.TransformPoint(_savedMesh.vertices[0]);
        Vector3 v1 = thisCamera.WorldToScreenPoint(vWorld1);
        Vector3 vWorld2 = p_obj.transform.TransformPoint(_savedMesh.vertices[_savedMesh.uv.Length - 1]);
        Vector3 v2 = thisCamera.WorldToScreenPoint(vWorld2);
        float rateX = tex.width / (v2.x - v1.x);
        float rateY = tex.height / (v2.y - v1.y);
        p_obj.transform.localScale = new Vector3(p_obj.transform.localScale.x * rateX + 0.001f, p_obj.transform.localScale.y * rateY, p_obj.transform.localScale.z);
    }

    void Update()
    {

    }
}
