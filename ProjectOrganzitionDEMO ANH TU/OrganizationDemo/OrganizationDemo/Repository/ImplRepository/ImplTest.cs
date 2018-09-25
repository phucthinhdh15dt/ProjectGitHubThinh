using OrganizationDemo.ManageOrganData;
using OrganizationDemo.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.ImplRepository
{
    public class ImplTest : ITest
    {
        ApplicationContext ab=new ApplicationContext();

        public void test1()
        {
            ab.Database.EnsureCreated();
        }
    }
}
