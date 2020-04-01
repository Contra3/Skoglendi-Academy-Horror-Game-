using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NaiveMeshFix.cs - a script that naively creates collision bounds based on its mesh
public class NaiveMeshColliderFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // create an empty mesh
        Mesh mesh = null;

        // grab the mesh of the mesh filter
        var meshFilter = GetComponent<MeshFilter>();
        // and its skinned mesh renderer
        var skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        // making sure things are not null
        if (meshFilter == null)
            throw new System.ArgumentException("Mesh Filter cannot be null");
        // get the shared mesh of the mesh filter and apply it to the new mesh
        mesh = meshFilter.sharedMesh;

        if (skinnedMeshRenderer == null)
            throw new System.ArgumentException("Skinned Mesh Renderer cannot be null");
        // same thing as above but with the skinned mesh renderer instead
        mesh = skinnedMeshRenderer.sharedMesh;

        // if the mesh is null at this point, there's probably a problem
        if (mesh != null)
        {
            // create a mesh collider that will wrap around the object
            var collider = GetComponent<MeshCollider>();

            // pretty sure this shouldn't be null
            if (collider != null)
                throw new System.ArgumentException("Collider is not null when should be null");

            // make the collider = mesh bounds
            collider = gameObject.AddComponent<MeshCollider>();
            collider.sharedMesh = mesh;

            // and recalculate the normals
            mesh.RecalculateNormals();
        }
        else
            throw new System.ArgumentException("Empty mesh");

    }
}
