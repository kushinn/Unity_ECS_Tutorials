using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RafeTutorials.Tutorials4
{
    public struct PlayerInput : IComponentData
    {
        public float3 move;
    }

    public class PlayerInputSystem : ComponentSystem
    {
        struct PlayerData
        {
            public readonly int Length;

            public ComponentDataArray<PlayerInput> inputs;
        }

        [Inject] private PlayerData players;

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

            for (int i = 0; i < players.Length; ++i)
            {
                players.inputs[i] = new PlayerInput()
                {
                    move = new float3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)
                };
            }
        }
    }
}
