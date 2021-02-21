using UnityEngine;
using TMPro;

namespace AnneCHPostma.RandomWalker
{
    [RequireComponent(typeof(GameObject))]
    public class UpdatePrefabsCounter : MonoBehaviour
    {
        [Tooltip("Add a GameObject that is spawning the Prefabs")]
        [SerializeField]
        private GameObject _prefabsSpawner = null;

        [Tooltip("Add a GameObject that is updating the Prefabs counter")]
        [SerializeField]
        private GameObject _prefabsCounter = null;

        private PrefabsSpawner prefabsSpawner = null;
        private TextMeshProUGUI prefabsCounter = null;

        private void Start()
        {
            prefabsSpawner = _prefabsSpawner.GetComponent<PrefabsSpawner>();
            prefabsCounter = _prefabsCounter.GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (prefabsSpawner == null)
            {
                Debug.LogError("There is no PrefabsSpawner component present in the 'Prefabs Spawner' GameObject.");

                return;
            }

            if (prefabsCounter == null)
            {
                Debug.LogError("There is no TextMeshProUGUI component present in the 'Prefabs Counter' GameObject.");

                return;
            }

            prefabsCounter.text = prefabsSpawner.prefabsCounter.ToString();
        }
    }
}
