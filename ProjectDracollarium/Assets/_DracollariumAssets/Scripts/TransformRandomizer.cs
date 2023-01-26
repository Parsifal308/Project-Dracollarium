using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRandomizer : MonoBehaviour
{
    [SerializeField] private float xRotationRange;
    [SerializeField] private float yRotationRange;
    [SerializeField] private float zRotationRange;
    [SerializeField] private float scaleRange;
    void Start()
    {
        float randomNumberGenerated = Random.Range(1, scaleRange);
        this.transform.Rotate(Random.Range(-xRotationRange, xRotationRange), Random.Range(-yRotationRange, yRotationRange), Random.Range(-zRotationRange, zRotationRange));
        this.transform.localScale += new Vector3(randomNumberGenerated, randomNumberGenerated, randomNumberGenerated);
    }
}
