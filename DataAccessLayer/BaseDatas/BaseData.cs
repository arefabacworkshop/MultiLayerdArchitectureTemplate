using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseDatas
{
    public abstract class BaseData
    {
        public int id { get; set; }
        public Guid? uid { get; set; }
    }
}
