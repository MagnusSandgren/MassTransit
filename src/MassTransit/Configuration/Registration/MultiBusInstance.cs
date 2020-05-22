namespace MassTransit.Registration
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Attachments;
    using Configuration;


    public class MultiBusInstance<TBus> :
        IBusInstance<TBus>
        where TBus : IBus
    {
        readonly IBusInstance _instance;

        public MultiBusInstance(TBus bus, IBusInstance instance)
        {
            _instance = instance;
            BusInstance = bus;
        }

        public Type InstanceType => typeof(TBus);
        public IBus Bus => BusInstance;
        public IBusControl BusControl => _instance.BusControl;
        public IHostConfiguration HostConfiguration => _instance.HostConfiguration;
        public TBus BusInstance { get; }

        public void Connect(IBusAttachment attachment)
        {
            _instance.Connect(attachment);
        }

        public Task Start(CancellationToken cancellationToken)
        {
            return _instance.Start(cancellationToken);
        }

        public Task Stop(CancellationToken cancellationToken)
        {
            return _instance.Stop(cancellationToken);
        }
    }
}
