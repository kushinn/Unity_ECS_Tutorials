using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials1
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
            var player = EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });

        }
    }
}

