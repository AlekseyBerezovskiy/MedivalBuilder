using System;

namespace MedivalBuilder.Command
{
    public interface ICommand
    {
        event Action OnDone;
        void Do();
    }
}