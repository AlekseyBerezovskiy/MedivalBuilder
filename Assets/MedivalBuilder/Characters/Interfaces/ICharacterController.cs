using System;
using MedivalBuilder.Inventory;
using UnityEngine;

namespace MedivalBuilder.Characters.Interfaces
{
    public interface ICharacterController
    {
        void SetWalk(Vector3 targetPosition, Action onEnd);
        void SetIdle();
        void SetBuild(float time, Action onEnd);
        void SetPickup(Item item, Action onEnd);
    }
}