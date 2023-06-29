using MedivalBuilder.Inventory;
using UnityEngine;

namespace MedivalBuilder.Characters.Interfaces
{
    public interface ICharacterController
    {
        void SetWalk(Vector3 targetPosition);
        void SetIdle();
        void SetBuild(float time);
        void SetPickup(Item item);
    }
}