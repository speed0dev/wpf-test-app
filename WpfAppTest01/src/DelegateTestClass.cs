using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest01.src
{
    internal class DelegateTestClass
    {
        // type 정의
        public delegate void EventCallFun(object sender, EventArgs e);

        private EventCallFun _deleEvent;

        public EventCallFun DeleEvent { get { return _deleEvent; }  set { _deleEvent = value; } }

        public DelegateTestClass() { 
            
        }


        // 제거
        public void RemoveAll() {
            //
            foreach (var handler in _deleEvent.GetInvocationList()) {
                _deleEvent -= (EventCallFun)handler;
            }
        }


    }
}
