using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Caliburn.Micro;

namespace ScriptCsPad
{
    public class AutosubscriberModule : Module
    {


        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
        {
            //base.AttachToComponentRegistration(componentRegistry, registration);
            registration.Activated += OnComponentActivated;
        }

        private static void OnComponentActivated(object sender, ActivatedEventArgs<object> args)
        {
            var handler = args.Instance as IHandle;
            if (handler == null) return;

            var eventAggregator = args.Context.Resolve<IEventAggregator>();
            eventAggregator.Subscribe(handler);
        }
    }
}