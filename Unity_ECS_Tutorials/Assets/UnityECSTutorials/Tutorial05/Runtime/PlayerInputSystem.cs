using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RafeTutorials.Tutorials5
{
    public struct PlayerInput : IComponentData
    {
        public float3 move;
    }

    public class PlayerInputSystem : ComponentSystem
    {
        public struct PlayerData
        {
            public int length;
            public ComponentDataArray<PlayerInput> inputs;

            public void Execute()
            {
                for (int i = 0; i < length; i++)
                {
                    inputs[i] = new PlayerInput()
                    {
                        // W A S D
                        move = new float3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)
                    };
                }
            }
        }

        private ComponentGroup players;

        protected override void OnUpdate()
        {
            players = GetComponentGroup(typeof(PlayerInput));
            new PlayerData()
            {
                length = players.CalculateLength(),
                inputs = players.GetComponentDataArray<PlayerInput>(),
            }.Execute();

        }
    }
}
