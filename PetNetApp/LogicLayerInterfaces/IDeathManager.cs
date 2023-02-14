// Created by Asa Armstrong
// Created on 2023/02/02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IDeathManager
    {
        bool AddAnimalDeath(Death death);
        DeathVM RetrieveAnimalDeath(Animal animal);
        bool EditAnimalDeath(Death newDeath, Death oldDeath);
    }
}
