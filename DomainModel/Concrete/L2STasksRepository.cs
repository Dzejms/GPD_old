using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace DomainModel.Concrete
{
    public class L2STasksRepository
    {
        DataContext context;

        public L2STasksRepository()
        {
            context = new DataContext("");
        }
    }
}
