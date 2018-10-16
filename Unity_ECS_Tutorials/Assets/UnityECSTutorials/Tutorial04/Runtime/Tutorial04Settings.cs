using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials4
{
    public class Tutorial04Settings : MonoBehaviour
    {
        public Mesh playerMesh;
        public Material playerMaterial;
        public float delayDestroyTime = 3f;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private void Start()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            EntitySpawnManager.CreatePlayerArchetype(entityManager);
            var player = EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });
            entityManager.SetComponentData(player, new Position() { Value = new float3(0, 0, 0) });
        }
    }
}
