using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Idea.Common.Mappings
{
    public static class MapperFactory
    {
        //
        public static Mapper getMapper()
        {
            return Mapper;
        }
    }
}
