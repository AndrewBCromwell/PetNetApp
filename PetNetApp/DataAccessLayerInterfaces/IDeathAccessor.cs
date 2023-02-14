// Created by Asa Armstrong
// Created on 2023/02/02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IDeathAccessor
    {
        int InsertAnimalDeath(Death death);
        DeathVM SelectAnimalDeath(Animal animal);
        int UpdateAnimalDeath(Death newDeath, Death oldDeath);
    }
}
