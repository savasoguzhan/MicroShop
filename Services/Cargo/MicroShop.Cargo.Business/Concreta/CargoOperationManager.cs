using MicroShop.Cargo.Business.Abstract;
using MicroShop.Cargo.DAL.Abstract;
using MicroShop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.Business.Concreta
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }
        public void TDelete(int id)
        {
           _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
           return _cargoOperationDal.GetAll();  
        }

        public CargoOperation TGetById(int id)
        {
           return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
           _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
           _cargoOperationDal.Update(entity);
        }
    }
}
