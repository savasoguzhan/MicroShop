﻿using MicroShop.Cargo.Business.Abstract;
using MicroShop.Cargo.DAL.Abstract;
using MicroShop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.Business.Concreta
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int id)
        {
           _cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
           return _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {

            _cargoCompanyDal.Update(entity);
        }
    }
}
