using MicroShop.Cargo.DAL.Abstract;
using MicroShop.Cargo.DAL.Concrate;
using MicroShop.Cargo.DAL.Repositories;
using MicroShop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.DAL.EntityFramework
{
    public class EFCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EFCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
