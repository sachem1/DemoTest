using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Class
{
    public class CustomEvent
    {

    }


    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string msg)
        {
            Message = msg;
        }

        public string Message { get; set; }

    }

    class Publisher
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("did something "));
        }


        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            e.Message += $"at {DateTime.Now}";
            RaiseCustomEvent?.Invoke(this, e);
        }
    }

    class Subscriber
    {
        private string Id;

        public Subscriber(string id, Publisher pub)
        {
            Id = id;
            pub.RaiseCustomEvent += Pub_RaiseCustomEvent;
        }

        private void Pub_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(Id+" received this message:{0}",e.Message);
        }
    }
}
