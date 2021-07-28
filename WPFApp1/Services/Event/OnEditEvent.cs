﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Services.Event
{
    public class OnEditEvent<T> : IEvent
    {
        public T Entity { get; set; }

        public OnEditEvent(T entity)
        {
            Entity = entity;
        }
    }
}
