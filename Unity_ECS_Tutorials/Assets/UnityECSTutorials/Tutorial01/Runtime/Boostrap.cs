using Unity.Entities;
using Unity.Rendering;
using UnityEngine;

namespace RafeTutorials
{
    public class Boostrap : MonoBehaviour
    {
        public Mesh playerMesh;
        public Material playerMaterial;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private void Start()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            EntitySpawnManager.CreatePlayerArchetype(entityManager);
            EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });
        }
    }
}

