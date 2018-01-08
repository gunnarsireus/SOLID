using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    interface ITopicAreaService
    {
	    IEnumerable<TopicArea> GetAllTopicAreas();
	}
}
