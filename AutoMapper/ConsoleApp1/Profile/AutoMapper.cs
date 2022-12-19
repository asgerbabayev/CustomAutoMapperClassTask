using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Profile
{
    public class AutoMapper
    {
        public Tout Map<Tin, Tout>(Tin input)
            where Tin : class, new()
            where Tout : class, new()
        {
            Tout returnObj = new();
            foreach (var property in input.GetType().GetProperties())
                if(property.Name == returnObj.GetType().GetProperty(property.Name).Name)
                    returnObj.GetType().GetProperty(property.Name).SetValue(returnObj, property.GetValue(input));
            return returnObj;
        }
    }
}
