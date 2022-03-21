﻿//@CodeCopy
//MdStart

using QTCityCongestionCharge.Logic.Controllers;

namespace QTCityCongestionCharge.Logic.Facades
{
    public abstract class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
