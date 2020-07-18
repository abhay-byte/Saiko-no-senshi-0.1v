using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class CloudSystem : MonoBehaviour
    {
        public Vector3 windDirection = Vector2.left;
        public float windSpeed = 1;
        public float minSpeed = 0.5f;
        public float resetRadius = 100;
        Transform[] clouds;
        float[] speeds;


        void Start()
        {
            clouds = new Transform[transform.childCount];
            speeds = new float[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                clouds[i] = transform.GetChild(i);
                speeds[i] = Random.value;
            }
        }

        void Update()
        {
            var r2 = resetRadius * resetRadius;
            for (var i = 0; i < speeds.Length; i++)
            {
                var cloud = clouds[i];
                var speed = Mathf.Lerp(minSpeed, windSpeed, speeds[i]);
                cloud.position += windDirection * speed;
                if (cloud.localPosition.sqrMagnitude > r2)
                {
                    cloud.position = -cloud.position;
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, resetRadius);
        }
    }