using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.Domain
{
    /// <summary>
    /// Message bus for the Application.
    /// Singleton.
    /// </summary>
    public interface IApplicationBus
    {
        Task Publish<TNotification>(TNotification notification)
            where TNotification : INotification;

        Task Subscribe<TNotification>(Action<TNotification> subscriber)
            where TNotification : INotification;
    }
}