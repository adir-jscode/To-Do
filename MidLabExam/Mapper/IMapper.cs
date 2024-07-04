using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidLabExam.Mapper
{
    public interface IMapper<S,D>
    {
        S Map(D entity);
        D Map(S entity);
        List<D> Map(List<S> entities);
    }
}
