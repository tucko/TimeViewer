using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Orders
{
    public class OrdersService
    {
        IDataModule _dataModule;

        public OrdersService()
        {
            _dataModule = OrdersCommandFacade.ModuleHandler.DataModule;
        }

        public DataSet GetOrder(int id_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlDataAdapter _da = new SqlDataAdapter("Select * from tb_Order Where OrderID = " + id_.ToString(), _conn);
                DataSet _dsOrder = new DataSet();

                _dataModule.OpenSharedConnection();

                _da.Fill(_dsOrder, "tb_Order");
                if (_dsOrder.Tables.Count > 0 && _dsOrder.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter _daOrderDetail = new SqlDataAdapter("Select * from tb_OrderDetail Where OrderID = " + id_.ToString(), _conn);
                    _daOrderDetail.Fill(_dsOrder, "tb_OrderDetail");
                    return _dsOrder;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }


        public DataTable GetOrderDetails(int id_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlDataAdapter _daOrderDetail = new SqlDataAdapter("SELECT OD.OrderID, OD.DetailID, OD.Product, P.Name, OD.Quantity, (P.Price * OD.Quantity) TotalPrice FROM tb_OrderDetail OD INNER JOIN tb_Products P ON OD.Product = P.ID Where OD.OrderID = " + id_.ToString(), _conn);
                DataSet _dsOrderDetails = new DataSet();

                _dataModule.OpenSharedConnection();

                _daOrderDetail.Fill(_dsOrderDetails, "tb_OrderDetail");
                if (_dsOrderDetails.Tables.Count > 0 && _dsOrderDetails.Tables[0].Rows.Count > 0)
                {
                    return _dsOrderDetails.Tables[0];
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public DataTable GetOrdersDataSet()
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();

                string _sql = "";
                _sql += " SELECT O.OrderID, O.OrderDate, O.OrderClient, C.Name, ";
                _sql += "     (SELECT P.Price * OD.Quantity FROM tb_OrderDetail AS OD INNER JOIN tb_Products AS P ON OD.Product = P.ID WHERE OD.OrderID = O.OrderID) AS TOTAL";
                _sql += " FROM tb_Order O INNER JOIN tb_Clients C ON O.OrderClient = C.ID";
                _sql += " ORDER BY O.OrderDate desc";

                SqlDataAdapter _da = new SqlDataAdapter(_sql, _conn);
                DataSet _ds = new DataSet();

                _dataModule.OpenSharedConnection();

                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                    return _ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public int InsertOrder(DateTime orderDate_, int clientID_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "INSERT INTO tb_Order (OrderID, OrderDate, OrderClient) VALUES (@OrderID, @OrderDate, @OrderClient)";

                int newID = NewOrderID();

                SqlParameter _paramOrderID = new SqlParameter("@OrderID", newID);
                SqlParameter _paramOrderDate = new SqlParameter("@OrderDate", orderDate_);
                SqlParameter _paramClient = new SqlParameter("@OrderClient", clientID_);
                _cmd.Parameters.AddRange(new SqlParameter[] { _paramOrderID, _paramOrderDate, _paramClient });
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                _cmd.ExecuteNonQuery();

                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public int InsertOrderDetail(int orderID_, int productID_, int quantity_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "INSERT INTO tb_OrderDetail (OrderID, DetailID, Product, Quantity) VALUES (@OrderID, @DetailID, @Product, @Quantity)";

                int newID = NewDetailID(orderID_);

                SqlParameter _paramOrderID = new SqlParameter("@OrderID", orderID_);
                SqlParameter _paramDetailID = new SqlParameter("@DetailID", newID);
                SqlParameter _paramProduct = new SqlParameter("@Product", productID_);
                SqlParameter _paramQuantity = new SqlParameter("@Quantity", quantity_);
                _cmd.Parameters.AddRange(new SqlParameter[] { _paramOrderID, _paramDetailID, _paramProduct, _paramQuantity });
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                _cmd.ExecuteNonQuery();

                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        private int NewOrderID()
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "SELECT IsNull(MAX(OrderID), 0) + 1 FROM tb_Order";
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                return (int)_cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }

        }

        private int NewDetailID(int orderID_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "SELECT IsNull(MAX(DetailID), 0) + 1 FROM tb_OrderDetail Where OrderID = " + orderID_.ToString();
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                return (int)_cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }

        }

    }
}
