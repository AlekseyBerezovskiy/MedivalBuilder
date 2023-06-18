using System;

namespace MedivalBuilder.Command
{
    public abstract class BaseCommand : ICommand
    {
        public abstract event Action OnDone;
        public abstract void Do();
    }
}