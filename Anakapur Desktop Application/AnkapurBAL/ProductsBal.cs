using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkapurDAL;
using System.Data;
using System.Data.SqlClient;
namespace AnkapurBAL
{
    public class ProductsBal
    {
        private CoreDAL _objdal = new CoreDAL();
        public DataSet GetProdData(string Ppr)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@Table_Name", Ppr));
                return _objdal.fngetData("Dynamic_SP", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EditProducts(ProductProperties Ppr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ProductID", Ppr.ProductID));
                param.Add(new SqlParameter("@Availabe", Ppr.Available));
                param.Add(new SqlParameter("@Remarks", Ppr.Remarks));
                //param.Add(new SqlParameter("@ProductName", Ppr.ProductName));
                //param.Add(new SqlParameter("@ShortDescription", Ppr.ShortDescription));
                //param.Add(new SqlParameter("@LongDescription", Ppr.LongDescription));
                //param.Add(new SqlParameter("@Price", Ppr.Price));
                //param.Add(new SqlParameter("@Quantity", Ppr.Quantity));
                //param.Add(new SqlParameter("@ImageUrl", Ppr.ImageUrl));
                //param.Add(new SqlParameter("@SIH", Ppr.SIH));
                //param.Add(new SqlParameter("@ReCode", Ppr.Restcode));
                //param.Add(new SqlParameter("@Discounts", Ppr.Discounts));

                return _objdal.fnAdddata("spUpdateProdAvailonlyforHN", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EditProductdetails(ProductProperties Ppr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ProductID", Ppr.ProductID));
                param.Add(new SqlParameter("@Available", Ppr.Available));
                param.Add(new SqlParameter("@Remarks", Ppr.Remarks));
                param.Add(new SqlParameter("@ProductName", Ppr.ProductName));
                param.Add(new SqlParameter("@ShortDescription", Ppr.ShortDescription));
                param.Add(new SqlParameter("@Price", Ppr.Price));
                param.Add(new SqlParameter("@kitchendesc", Ppr.Kitchen_Description));
                param.Add(new SqlParameter("@image", Ppr.Image));
                return _objdal.fnAdddata("spEditProducts1", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet GetCategoryType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spGetCategoryType1", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetdishType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spGetDishType", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemCode()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spgetitemcode1", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetProdBasedOnRestaurantGetProData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetdata("[spGetRestCode]", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetProdMasterDtls()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetdata("spGetTotalProducts1", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetProdBasedOnRestaurant()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetdata("spgetAvailbasedOnRest", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetMaxProdId(string itemcode)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ItemCode", itemcode));
                return _objdal.fngetMaxId(" SELECT   CAST( (SUBSTRING( MAX (ProductID),3,5)) as int   )  +1  FROM tblProductMaster where ProductID like '%' +@ItemCode+ '%'  ", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddDtlsToProdMaster(ProductProperties ppr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ProDuctID", ppr.ProductID));
                param.Add(new SqlParameter("@ProductName", ppr.ProductName));
                param.Add(new SqlParameter("@Shortdesc", ppr.ShortDescription));
                param.Add(new SqlParameter("@LongDesc", ppr.LongDescription));
                param.Add(new SqlParameter("@Price", ppr.Price));
                param.Add(new SqlParameter("@Available", ppr.Available));
                param.Add(new SqlParameter("@Remarks", ppr.Remarks));
                param.Add(new SqlParameter("@Quantity", ppr.Quantity));
                param.Add(new SqlParameter("@Image", ppr.Image));
                param.Add(new SqlParameter("@ItemCode", ppr.ItemCode));
                param.Add(new SqlParameter("@CategoryID", ppr.CategoryID));
                param.Add(new SqlParameter("@DishTypeId", ppr.DishTypeID));
                param.Add(new SqlParameter("@SIH", ppr.SIH));
                param.Add(new SqlParameter("@Kitchendesc", ppr.Kitchen_Description));
                //param.Add(new SqlParameter("@Tax", ppr.Tax));
                //param.Add(new SqlParameter("@Discounts", ppr.Discounts));
                return _objdal.fnAdddata("spAddProducts1", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

