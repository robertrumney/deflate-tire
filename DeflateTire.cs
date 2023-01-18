using UnityEngine;
using System.Collections;

public class DeflateTire : MonoBehaviour
{
    // the amount the tire will deflate
    private readonly float deflationAmount = 0.1f; 
    // the time it takes for the tire to deflate
    private readonly float deflationTime = 1f; 
    // the mesh of the tire
    private Mesh tireMesh;
    // flag for checking if the tire is currently deflating
    private bool deflating = false; 

    // assigns the tire mesh at runtime and calls the deflate function
    private void Start()
    {
        tireMesh = GetComponent<MeshFilter>().mesh; 
        Deflate();
    }

    // deflates the tire over time
    private void Deflate()
    {
        if (!deflating) // check if the tire is not already deflating
        {
            StartCoroutine(DeflateCoroutine()); // start the deflation coroutine
        }
    }

    // coroutine that gradually reduces the y-coordinate of each vertex in the tire mesh
    private IEnumerator DeflateCoroutine()
    {
        deflating = true; // set the deflating flag to true
        float elapsedTime = 0f;
        Vector3[] vertices = tireMesh.vertices;
        while (elapsedTime < deflationTime)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                // reduce the y-coordinate of each vertex based on the elapsed time and deflation amount
                vertices[i] = Vector3.Scale(vertices[i], new Vector3(1, 1 - (deflationAmount * (elapsedTime / deflationTime)), 1));
            }
            tireMesh.vertices = vertices;
            tireMesh.RecalculateBounds();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        deflating = false; // set the deflating flag to false
    }
}
