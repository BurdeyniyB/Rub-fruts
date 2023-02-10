﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts
{
    class Slicer
    {
        /// <summary>
        /// Slice the object by the plane 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="objectToCut"></param>
        /// <returns></returns>
        public static GameObject[] Slice(Plane plane, GameObject objectToCut)
        {
            Mesh mesh = objectToCut.GetComponent<MeshFilter>().mesh;
            var a = mesh.GetSubMesh(0);
            Sliceable sliceable = objectToCut.GetComponent<Sliceable>();

//            if(sliceable == null)
//            {
//                throw new NotSupportedException("Cannot slice non sliceable object, add the sliceable script to the object or inherit from sliceable to support slicing");
//            }
            
            //Create left and right slice of hollow object
            SlicesMetadata slicesMeta = new SlicesMetadata(plane, mesh, sliceable.IsSolid, sliceable.ReverseWireTriangles, sliceable.ShareVertices, sliceable.SmoothVertices);            

            GameObject positiveObject = CreateMeshGameObject(objectToCut);
            positiveObject.name = string.Format("{0}_positive", objectToCut.name);

//            GameObject negativeObject = CreateMeshGameObject(objectToCut);
//            negativeObject.name = string.Format("{0}_negative", objectToCut.name);
//            if(objectToCut.tag == "apple")
//            {
//              positiveObject = negativeObject;
//              Destroy(negativeObject);
//            }

//            if(positiveObject.transform.position.x > negativeObject.transform.position.x)
//            {
//               positiveObject = negativeObject;
//            }

            positiveObject.transform.SetParent(GameObject.Find("Fruit").transform);
//            negativeObject.transform.SetParent(GameObject.Find("Fruit").transform);
            FruitGeneration.instance.AddFruit(positiveObject);

            var positiveSideMeshData = slicesMeta.PositiveSideMesh;
//            var negativeSideMeshData = slicesMeta.NegativeSideMesh;

            positiveObject.GetComponent<MeshFilter>().mesh = positiveSideMeshData;
//            negativeObject.GetComponent<MeshFilter>().mesh = negativeSideMeshData;

            SetupCollidersAndRigidBodys(ref positiveObject, positiveSideMeshData, sliceable.UseGravity);
//            SetupCollidersAndRigidBodys(ref negativeObject, negativeSideMeshData, sliceable.UseGravity);
            
            Debug.Log("transform pos " + positiveObject.transform.position.x);
//            Debug.Log("transform neg " + negativeObject.transform.position.x);

            return new GameObject[] {positiveObject};
            //positiveObject, negativeObject
        }        

        /// <summary>
        /// Creates the default mesh game object.
        /// </summary>
        /// <param name="originalObject">The original object.</param>
        /// <returns></returns>
        private static GameObject CreateMeshGameObject(GameObject originalObject)
        {
            var originalMaterial = originalObject.GetComponent<MeshRenderer>().materials;

            GameObject meshGameObject = new GameObject();
            Sliceable originalSliceable = originalObject.GetComponent<Sliceable>();

            meshGameObject.AddComponent<MeshFilter>();
            meshGameObject.AddComponent<MeshRenderer>();
            Sliceable sliceable = meshGameObject.AddComponent<Sliceable>();

            sliceable.IsSolid = originalSliceable.IsSolid;
            sliceable.ReverseWireTriangles = originalSliceable.ReverseWireTriangles;
            sliceable.UseGravity = originalSliceable.UseGravity;

            meshGameObject.GetComponent<MeshRenderer>().materials = originalMaterial;

            meshGameObject.transform.localScale = originalObject.transform.localScale;
            meshGameObject.transform.rotation = originalObject.transform.rotation;
            meshGameObject.transform.position = originalObject.transform.position;

            meshGameObject.tag = originalObject.tag;

            return meshGameObject;
        }

        /// <summary>
        /// Add mesh collider and rigid body to game object
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="mesh"></param>
        private static void SetupCollidersAndRigidBodys(ref GameObject gameObject, Mesh mesh, bool useGravity)
        {                     
            MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
            meshCollider.sharedMesh = mesh;
            meshCollider.convex = true;

            var rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = useGravity;
        }
    }
}