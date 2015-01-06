using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotkaNetApi
{
    interface IProfileBuldier
    {
        Profile Build(Profile profile);
    }
}
