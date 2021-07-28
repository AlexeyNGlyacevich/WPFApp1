﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp1.Services
{

    public class EventSubscriber : IDisposable
    {
        private readonly Action<EventSubscriber> _action;

        public Type MessageType { get; }

        public EventSubscriber(Type messageType, Action<EventSubscriber> action)
        {
            MessageType = messageType;
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke(this);
        }
    }

    public class MessageSubscriber : IDisposable
    {
        private readonly Action<MessageSubscriber> _action;

        public Type ReceiverType { get; }
        public Type MessageType { get; }

        public MessageSubscriber(Type receiverType, Type messageType, Action<MessageSubscriber> action)
        {
            ReceiverType = receiverType;
            MessageType = messageType;
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke(this);
        }
    }

}
