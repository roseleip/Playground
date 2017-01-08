using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSTest1
{
    public class Bus
    {
        private static readonly Dictionary<Type, Type> SagaStarters = new Dictionary<Type, Type>();
        private static readonly Dictionary<string, object> SagaInstances = new Dictionary<string, object>();

        public static void RegisterSage<TStartMessage, TSaga>()
        {
            SagaStarters.Add(typeof(TStartMessage), typeof(TSaga));
        }

        public static void Send<T>(T message) where T : Messsage
        {
            if (message is IDomainEvent)
            {
                foreach(var saga in SagaInstances)
                {
                    var handler = (IHandles<T>)saga;
                    if (handler != null)
                        handler.Handle(message);
                }

            }

            if (SagaStarters.ContainsKey(typeof (T)))
            {
                var typeOfSaga = SagaStarters[typeof(T)];
                var instance = (IHandles<T>)Activator.CreateInstance(typeOfSaga);
                instance.Handle(message);

                var saga = (SagaBase)instance;
                SagaInstances.Add(saga.Data.Id, instance);
                return;

            }

            if (SagaInstances.ContainsKey(message.Id))
            {
                var saga = (IHandles<T>)SagaInstances[message.Id];
                saga.Handle(message);

                if (saga.IsComplete())
                {
                    SagaInstances.Remove(message.Id);
                }
                else
                {
                    SagaInstances[message.Id] = saga;
                }
            }

        }
        

    }
}
