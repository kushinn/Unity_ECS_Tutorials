using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials2
{
    public class Boostrap : MonoBehaviour
    {
        public Mesh playerMesh;
        public Material playerMaterial;
        private Entity player;
        private bool pingpong = false;
        private float yOfPlayer = 0.0f;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private void Start()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            EntitySpawnManager.CreatePlayerArchetype(entityManager);
            player = EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });
        }

        void Update()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();
            if (pingpong)
            {
                yOfPlayer += Time.deltaTime * 3;
                if (yOfPlayer >= 3.0f)
                {
                    pingpong = !pingpong;
                }
            }
            else
            {
                yOfPlayer -= Time.deltaTime * 3;
                if (yOfPlayer <= -3.0f)
                {
                    pingpong = !pingpong;
                }
            }

            entityManager.SetComponentData(player, new Position() { Value = new float3(0, yOfPlayer, 0) });
        }
    }
}
