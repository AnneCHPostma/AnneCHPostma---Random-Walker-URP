#region Referenced Namespaces

using UnityEngine;

#endregion

namespace AnneCHPostma.RandomWalker
{
    public class PrefabsSpawner : MonoBehaviour
    {
        [Tooltip("Add a Prefab that is going to be spawned")]
        [SerializeField]
        private GameObject _prefab = null;

        public bool maxPrefabsReached = false;

        public int prefabsCounter = 0;

        private GameObject currentPrefab = null;

        private void Start()
        {
            if (PrefabIsMissing()) return;

            // Add an initial prefab
            AddPrefab();
        }

        private void Update()
        {
            if (PrefabIsMissing()) return;

            AddPrefab();

            if (maxPrefabsReached) RemoveOldestPrefab();
        }

        private void RemoveOldestPrefab()
        {
            Destroy(transform.GetChild(0).gameObject);

            prefabsCounter--;
        }

        private void AddPrefab()
        {
            var newPrefabPosition = new Vector3(Random.value > 0.5 ? -1 : 1, Random.value > 0.5 ? -1 : 1, Random.value > 0.5 ? -1 : 1);

            if (currentPrefab == null)
            {
                currentPrefab = _prefab;

                newPrefabPosition = Vector3.zero;
            }

            var newPrefab = Instantiate(_prefab, currentPrefab.transform.position, Quaternion.identity);
            var newPrefabMaterial = Instantiate(Resources.Load("Materials/Default", typeof(Material)) as Material);
            var newPrefabRenderer = newPrefab.GetComponent<Renderer>();

            // TODO: Give the user a choice to generate random colors on each Prefab
            //var newPrefabColor = new Color(Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f), 0.5f);

            //newPrefabMaterial.SetColor("_BaseColor", newPrefabColor);
            //newPrefabMaterial.SetColor("_EmissionColor", newPrefabColor);

            newPrefabRenderer.material = newPrefabMaterial;
            newPrefab.transform.Translate(newPrefabPosition, Space.Self);
            newPrefab.transform.parent = transform;

            currentPrefab = newPrefab;

            prefabsCounter++;
        }

        private bool PrefabIsMissing()
        {
            var prefabIsMissing = _prefab == null;

            if (prefabIsMissing) Debug.LogError("No prefab is attached to the PrefabsSpawner script.");

            return prefabIsMissing;
        }
    }
}
