using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> subs = new();
   public static void Subscribe<T>(Action<T> handler) where T: IEvent
    {
        Type t = typeof(T);

        if(!subs.TryGetValue(t, out List<Delegate> list))
        {
            list = new List<Delegate>();
            subs[t] = list;
        }
        list.Add(handler);
    }
    public static void UnSubscribe<T>(Action<T> handler) where T : IEvent
    {
        Type t = typeof(T);

        if (subs.TryGetValue(t, out List<Delegate> list))
        {
            list.Remove(handler);

            if (list.Count == 0) subs.Remove(t);
        }
        
    }

    public static void Publish<T>(T eventData) where T: IEvent
    {
        Type t = typeof(T);

        if (subs.TryGetValue(t, out List<Delegate> list))
        {
            Delegate[] copy = list.ToArray();

            foreach(var c in copy)
            {
                ((Action<T>)c)(eventData);
               
            }
        }
        
    }

   
}

