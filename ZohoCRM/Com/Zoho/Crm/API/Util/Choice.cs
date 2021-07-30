using System;

using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Util
{
    public class Choice<T>
    {
        private T value;

        private Choice() 
	    {
	    }

        public Choice(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }
        
    }
    
}