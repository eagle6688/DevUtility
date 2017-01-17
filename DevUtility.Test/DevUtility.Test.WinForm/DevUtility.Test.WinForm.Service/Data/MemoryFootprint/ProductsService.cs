using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.MemoryFootprint
{
    public class ProductsService : BaseAppService
    {
        #region Variables

        int count = 0;

        #endregion

        #region Constructor

        public ProductsService(int count)
        {
            this.count = count;
        }

        #endregion

        #region Start

        public override void Start()
        {
            var list = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new Product()
                {
                    ID = Guid.NewGuid(),
                    ProductID = "Laptops-and-netbooks/ThinkPad-X-Series-laptops/ThinkPad-X1-Carbon-20BS-20BT",
                    ProductType = CommercialProductTypes.All,
                    SNID = Guid.NewGuid(),
                    SN = "R90FR5ZR",
                    MTMID = Guid.NewGuid(),
                    Model = "20BTS1R100",
                    MTID = Guid.NewGuid(),
                    MT = "20BT",
                    SubSeriesID = Guid.NewGuid(),
                    SubSeries = "ThinkPad-X1-Carbon-20BS-20BT",
                    SeriesID = Guid.NewGuid(),
                    Series = "ThinkPad-X-Series-laptops",
                    GroupID = Guid.NewGuid(),
                    Group = "Laptops-and-netbooks",
                    CountryName = "Australia",
                    LocationID = Guid.NewGuid(),
                    DepartmentID = Guid.NewGuid()
                });
            }

            DisplayMessage("Done");
        }
    }

    #endregion

    class Product
    {
        public Guid ID { set; get; }

        public string ProductID { set; get; }

        public CommercialProductTypes ProductType { set; get; }

        public Guid SNID { set; get; }

        public string SN { set; get; }

        public Guid MTMID { set; get; }

        public string Model { set; get; }

        public Guid MTID { set; get; }

        public string MT { set; get; }

        public Guid SubSeriesID { set; get; }

        public string SubSeries { set; get; }

        public Guid SeriesID { set; get; }

        public string Series { set; get; }

        public Guid GroupID { set; get; }

        public string Group { set; get; }

        public string CountryName { set; get; }

        public Guid LocationID { set; get; }

        public Guid DepartmentID { set; get; }
    }

    enum CommercialProductTypes
    {
        All = 0,
        PC,
        Mobile,
        Enterprise
    }
}