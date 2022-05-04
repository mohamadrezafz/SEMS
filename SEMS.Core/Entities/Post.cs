using KernelFramework.DataAccess.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Core.Entities
{
    public class Post : EntityBase
    {
        public string Caption { get; set; }
    }
}
