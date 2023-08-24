using System;
using MedivalBuilder.Inventory;
using UnityEngine;

namespace MedivalBuilder.Characters.Interfaces
{
    public interface ICharacterController
    {
        void SetWalk(Transform targetTransform, Action onEnd);
        void SetIdle();
        void SetBuild(float time, Action onEnd);
        void SetPickup(Item item, Action onEnd);
    }
}