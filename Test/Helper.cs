using BusinessLogicLayer;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Helper
    {/*
        public static void RegisterTypes(UnityContainer container)
        {
            //register the concrete implementation for interfaces
            container.RegisterType<IDALEmployees, DALEmployeesMock>();
            container.RegisterType<IBLEmployees, BLEmployees>();

            //register a singleton for DAL
            DALEmployeesMock dalEmployeesMock = new DALEmployeesMock();
            container.RegisterInstance(dalEmployeesMock);

            //register a singleton for BL
            BLEmployees blEmployees = new BLEmployees(container.Resolve<IDALEmployees>());
            container.RegisterInstance(blEmployees);
        }
        */
    }
}
