using UnityEngine;
using System.Collections;

public class DeflateTire : MonoBehaviour
{
    // the amount the tire will deflate
    [SerializeField] private float deflationAmount = 0.1f; 
    // the time it takes for the tire to deflate
    [SerializeField] private float deflationTime = 1f; 
    // the mesh of the tire
    [SerializeField] private Mesh tireMesh;
    // the wheel collider for the tire
    [SerializeField] private WheelCollider wheelCollider;
    // flag for checking if the tire is currently deflating
    private bool deflating = false; 

    private Vector3[] originalVertices;

    private void Start()
    {
        originalVertices = tireMesh.vertices;
    }
    public void Deflate()
    {
        if (!deflating) // check if the tire is not already deflating
        {
            StartCoroutine(DeflateCoroutine()); // start the deflation coroutine
        }
    }
    private IEnumerator DeflateCoroutine()
    {
        deflating = true; // set the deflating flag to true
        float elapsedTime = 0f;
        Vector3[] vertices = tireMesh.vertices;
        float colliderRadius = wheelCollider.radius;
        while (elapsedTime < deflationTime)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                // reduce the y-coordinate of each vertex based on the elapsed time and deflation amount
                vertices[i] = Vector3.Scale(originalVertices[i], new Vector3(1, 1 - (deflationAmount * (elapsedTime / deflationTime)), 1));
            }
            tireMesh.vertices = vertices;
            tireMesh.RecalculateBounds();
            wheelCollider.radius = colliderRadius * (1 - (deflationAmount * (elapsedTime / deflationTime)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        deflating = false; // set the deflating flag to false
    }
}
