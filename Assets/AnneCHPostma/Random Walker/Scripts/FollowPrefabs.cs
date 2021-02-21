using UnityEngine;

namespace AnneCHPostma.RandomWalker
{
    public class FollowPrefabs : MonoBehaviour
    {
        [Tooltip("Add the GameObject that spawns the Prefabs")]
        [SerializeField]
        private GameObject spawnerObject = null;

        [Tooltip("Set a rotation speed")]
        [SerializeField]
        [Min(0.0f)]
        private float rotationSpeed = 5.0f;

        [Tooltip("Set a movement speed")]
        [SerializeField]
        [Min(0.0f)]
        private float movementSpeed = 5.0f;

        [Tooltip("Set the minimum distance to the last Prefab")]
        [SerializeField]
        [Min(1.0f)]
        private float distanceToLastPrefab = 75.0f;

        private void Awake()
        {
            if (spawnerObject == null)
            {
                Debug.LogError("There is no GameObject attached to the FollowPrefabs script.");

                return;
            }
        }

        private void Update()
        {
            UpdateCamera();
        }

        private Vector3 GetLastPrefabPosition()
        {
            var lastPrefabPosition = Vector3.zero;
            var renderers = spawnerObject.GetComponentsInChildren<Renderer>();

            if (renderers.Length > 0)
            {
                lastPrefabPosition = (renderers[renderers.Length - 1].transform.position);
            }

            return lastPrefabPosition;
        }

        private void UpdateCamera()
        {
            var positionOfLastPrefab = GetLastPrefabPosition();
            var directionToPrefab = positionOfLastPrefab - transform.position;
            var step = movementSpeed * Time.unscaledDeltaTime;

            if (Vector3.Distance(transform.position, positionOfLastPrefab) > distanceToLastPrefab)
            {
                transform.position = Vector3.MoveTowards(transform.position, positionOfLastPrefab, step);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(directionToPrefab), Time.deltaTime * rotationSpeed);
        }
    }
}
