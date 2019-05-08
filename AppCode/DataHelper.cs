using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Bliss_POS.AppCode
{
    class DataHelper
    {
        private static SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.POSConnection);
            return con;
        }

        public static List<POSSection> GetSections()
        {
            List<POSSection> sections = new List<POSSection>();
            try
            {

                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSections", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSSection sec = new POSSection(
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["sname"]),
                                    Convert.ToString(dr["sdescription"]),
                                    Convert.ToBoolean(dr["visible"]),
                                    Convert.ToInt32(dr["sortOrder"]));
                                sections.Add(sec);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            return sections;
        }

        public static List<POSSection> GetSectionsVisible()
        {
            List<POSSection> sections = new List<POSSection>();
            try
            {

                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSectionsVisible", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSSection sec = new POSSection(
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["sname"]),
                                    Convert.ToString(dr["sdescription"]),
                                    Convert.ToBoolean(dr["visible"]),
                                    Convert.ToInt32(dr["sortOrder"]));
                                sections.Add(sec);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            return sections;
        }

        public static POSSection GetSection(int sid)
        {
            POSSection section = null;
            try
            {

                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSection", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@sid", sid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                section = new POSSection(
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["sname"]),
                                    Convert.ToString(dr["sdescription"]),
                                    Convert.ToBoolean(dr["visible"]),
                                    Convert.ToInt32(dr["sortOrder"]));
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            return section;
        }

        public static void SaveSections(List<POSSection> sections)
        {
            foreach (POSSection section in sections)
            {
                SaveSection(section);
            }
              
        }

        public static void SaveSection(POSSection section)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@sname", section.SectionName);
            pars.Add("@sdescription", section.Description);
            pars.Add("@visible", section.Visible);
            pars.Add("@sortOrder", section.SortOrder);

            if (section.SectionId == -1) //not yet in database
            {
                POSExecuteNonQuery("InsertSection", pars);
            }
            else
            {
                pars.Add("@sid", section.SectionId);
                POSExecuteNonQuery("UpdateSection", pars);
            }
        }

        public static void DeleteSection(int sectionId)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("DeleteSection", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@sid", sectionId));
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<POSCategory> GetCategories(int sid)
        {
            List<POSCategory> cats = new List<POSCategory>();
            try
            {

                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetCategories", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@sid", sid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSCategory cat = new POSCategory(
                                    Convert.ToInt32(dr["cid"]),
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["cname"]),
                                    Convert.ToString(dr["backcolour"]),
                                    Convert.ToString(dr["forecolour"]),
                                    Convert.ToInt32(dr["gid"]));
                                cats.Add(cat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }


            return cats;

        }

        public static List<POSCategory> GetCategoriesAll()
        {
            List<POSCategory> cats = new List<POSCategory>();
            try
            {

                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetCategoriesAll", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSCategory cat = new POSCategory(
                                    Convert.ToInt32(dr["cid"]),
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["cname"]),
                                    Convert.ToString(dr["backcolour"]),
                                    Convert.ToString(dr["forecolour"]),
                                    Convert.ToInt32(dr["gid"]));
                                cats.Add(cat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            return cats;
        }

        public static int GetFirstCategory(int sid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@sid", sid);
            return Convert.ToInt32(POSExecuteScalar("GetFirstCategory", pars));
        }

        public static int GetFirstSection()
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            return Convert.ToInt32(POSExecuteScalar("GetFirstSection", pars));
        }
        
        public static void DeleteCategory(int categoryId)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("DeleteCategory", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@cid", categoryId));
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void SaveCategories(List<POSCategory> categories)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSCategory cat in categories)
                    {
                        if (cat.CategoryId < 0) //not yet in database
                        {
                            using (SqlCommand com = new SqlCommand("InsertCategory", con))
                            {
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.Add(new SqlParameter("@sid", cat.SectionId));
                                com.Parameters.Add(new SqlParameter("@cname", cat.CategoryName));
                                com.Parameters.Add(new SqlParameter("@backcolour", cat.BackColour));
                                com.Parameters.Add(new SqlParameter("@forecolour", cat.ForeColour));
                                com.Parameters.Add(new SqlParameter("@gid", cat.GroupId));
                                com.ExecuteNonQuery();
                            }
                        }
                            else
                            {
                                using (SqlCommand com = new SqlCommand("UpdateCategory", con))
                                {
                                    com.CommandType = CommandType.StoredProcedure;
                                    com.Parameters.Add(new SqlParameter("@cid", cat.CategoryId));
                                    com.Parameters.Add(new SqlParameter("@sid", cat.SectionId));
                                    com.Parameters.Add(new SqlParameter("@cname", cat.CategoryName));
                                    com.Parameters.Add(new SqlParameter("@backcolour", cat.BackColour));
                                    com.Parameters.Add(new SqlParameter("@forecolour", cat.ForeColour));
                                    com.Parameters.Add(new SqlParameter("@gid", cat.GroupId));
                                    com.ExecuteNonQuery();
                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int SaveProduct(POSProduct product)
        {
            int newid = product.ProductId;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pname", product.Product);
            pars.Add("@buttonText", product.ButtonText);
            pars.Add("@description", product.Description);
            pars.Add("@cid", product.CategoryId);
            pars.Add("@pcode", product.Code);
            pars.Add("@suid", product.SupplierId);
            pars.Add("@x", product.X);
            pars.Add("@y", product.Y);
            pars.Add("@visible", product.Visible);
            if (product.ProductId < 0) //new product
            {
                newid = Convert.ToInt32(POSExecuteScalar("InsertProduct", pars));
            }
            else
            {
                pars.Add("@pid", product.ProductId);
                POSExecuteNonQuery("UpdateProduct", pars);
            }
            return newid;
        }

        public static int SaveItem(int pid, POSItemEdit item)
        {
            int itemid = item.ItemId;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pid", pid);
            parameters.Add("@variation", item.Variation);
            parameters.Add("@price", item.Price);
            parameters.Add("@barcode", item.Barcode);
            parameters.Add("@costPrice", item.CostPrice);
            parameters.Add("@stockLevel", item.StockLevel);
            parameters.Add("@PLU", item.PLU);
            parameters.Add("@suPLU", item.SupplierPLU);
            if (item.ItemId < 0) //new item
            {
                itemid = Convert.ToInt32(POSExecuteScalar("InsertItem", parameters));
            }
            else
            {
                parameters.Add("@itemid", item.ItemId);
                POSExecuteNonQuery("UpdateItem", parameters);
            }
            return itemid;
        } 

        public static void SaveProductVisible(POSProduct product)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", product.ProductId);
            pars.Add("@visible", product.Visible);
            POSExecuteNonQuery("UpdateProductVisible", pars);
        }
        
        public static void DeleteItem(int itemid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@itemid", itemid);
            POSExecuteNonQuery("DeleteItem", pars);
        }

        public static List<POSProduct> GetProducts(int catId)
        {
            List<POSProduct> prods = new List<POSProduct>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetProducts", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@cid", catId));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSProduct prod = new POSProduct(
                                  Convert.ToInt32(dr["pid"]),
                                  Convert.ToString(dr["pname"]),
                                  Convert.ToString(dr["buttonText"]),
                                  Convert.ToString(dr["description"]),
                                  Convert.ToInt32(dr["cid"]),
                                  Convert.ToString(dr["cname"]),
                                  Convert.ToInt32(dr["sid"]),
                                  Convert.ToString(dr["sname"]),
                                  Convert.ToString(dr["pcode"]),
                                  Convert.ToBoolean(dr["visible"]),
                                  Convert.ToInt32(dr["suid"]),
                                  Convert.ToString(dr["supplier"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]));
                                prods.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return prods;
        }

        public static POSProduct GetProduct(int pid)
        {
            POSProduct prod = null;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetProduct", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                prod = new POSProduct(
                                  Convert.ToInt32(dr["pid"]),
                                  Convert.ToString(dr["pname"]),
                                  Convert.ToString(dr["buttonText"]),
                                  Convert.ToString(dr["description"]),
                                  Convert.ToInt32(dr["cid"]),
                                  Convert.ToString(dr["cname"]),
                                  Convert.ToInt32(dr["sid"]),
                                  Convert.ToString(dr["sname"]),
                                  Convert.ToString(dr["pcode"]),
                                  Convert.ToBoolean(dr["visible"]),
                                  Convert.ToInt32(dr["suid"]),
                                  Convert.ToString(dr["supplier"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return prod;

        }

        public static BindingList<POSProductView> FilterProducts(string name, int suid,
            int sid, int cid)
        {
            BindingList<POSProductView> products = new BindingList<POSProductView>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("FilterProducts", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pname", name));
                        com.Parameters.Add(new SqlParameter("@suid", suid));
                        com.Parameters.Add(new SqlParameter("@sid", sid));
                        com.Parameters.Add(new SqlParameter("@cid", cid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSProductView prod = new POSProductView(
                                      Convert.ToInt32(dr["pid"]),
                                      Convert.ToString(dr["pname"]),
                                      Convert.ToString(dr["buttonText"]),
                                      Convert.ToString(dr["description"]),
                                      Convert.ToInt32(dr["cid"]),
                                      Convert.ToString(dr["cname"]),
                                      Convert.ToInt32(dr["sid"]),
                                      Convert.ToString(dr["sname"]),
                                      Convert.ToString(dr["pcode"]),
                                      Convert.ToBoolean(dr["visible"]),
                                      Convert.ToInt32(dr["suid"]),
                                      Convert.ToString(dr["supplier"]),
                                      Convert.ToInt32(dr["x"]),
                                      Convert.ToInt32(dr["y"]));
                                products.Add(prod);

                            }
                            
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return products;
        }

        public static BindingList<POSProductSearchResult> SearchProducts(string name)
        {
            BindingList<POSProductSearchResult> products = new BindingList<POSProductSearchResult>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("FilterProducts", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pname", name));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSProductSearchResult prod = new POSProductSearchResult(
                                      Convert.ToInt32(dr["pid"]),
                                      Convert.ToString(dr["pname"]),
                                      Convert.ToString(dr["buttonText"]),
                                      Convert.ToString(dr["description"]),
                                      Convert.ToInt32(dr["cid"]),
                                      Convert.ToString(dr["cname"]),
                                      Convert.ToInt32(dr["sid"]),
                                      Convert.ToString(dr["sname"]),
                                      Convert.ToString(dr["pcode"]),
                                      Convert.ToBoolean(dr["visible"]),
                                      Convert.ToInt32(dr["suid"]),
                                      Convert.ToString(dr["supplier"]),
                                      Convert.ToInt32(dr["x"]),
                                      Convert.ToInt32(dr["y"]));
                                products.Add(prod);

                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return products;
        }

        public static void DeleteProduct(int pid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            POSExecuteNonQuery("DeleteProduct", pars);
        }

        public static List<POSItemTill> GetItemsByProduct(int pid)
        {
            List<POSItemTill> items = new List<POSItemTill>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetItemsByProduct", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSItemTill item = new POSItemTill(
                                    Convert.ToInt32(dr["itemid"]),
                                    pid,
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                  Convert.ToDouble(dr["price"]),
                                  1,
                                  Convert.ToString(dr["barcode"]),
                                  Convert.ToDouble(dr["costPrice"]),
                                  Convert.ToInt32(dr["stockLevel"]),
                                  Convert.ToString(dr["PLU"]),
                                  Convert.ToString(dr["suPLU"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]),
                                  Convert.ToInt32(dr["sortOrder"]));
                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return items;
        }

        public static BindingList<POSItemEdit> GetItemsEditByProduct(int pid)
        {
            BindingList<POSItemEdit> items = new BindingList<POSItemEdit>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetItemsByProduct", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSItemEdit item = new POSItemEdit(
                                    Convert.ToInt32(dr["itemid"]),
                                    pid,
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                  Convert.ToDouble(dr["price"]),
                                  1,
                                  Convert.ToString(dr["barcode"]),
                                  Convert.ToDouble(dr["costPrice"]),
                                  Convert.ToInt32(dr["stockLevel"]),
                                  Convert.ToString(dr["PLU"]),
                                  Convert.ToString(dr["suPLU"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]));
                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return items;
        }

        public static void SaveOrder(int uid, POSOrder order, int guestCount, 
            int paymentType)
        {
            int orderId = -1;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("InsertOrder", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@uid", uid));
                        com.Parameters.Add(new SqlParameter("@guestCount", guestCount));
                        com.Parameters.Add(new SqlParameter("@ptid", paymentType));
                        orderId = Convert.ToInt32(com.ExecuteScalar());
                    }
                    if (order.Hid > 0) //remove from hold table
                    {
                        using (SqlCommand com = new SqlCommand("RemoveHoldDetails", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("@hid", order.Hid));
                            com.ExecuteNonQuery();
                        }
                        using (SqlCommand com = new SqlCommand("RemoveHold", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("hid", order.Hid));
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (orderId != -1)
            {
                SaveOrderDetails(orderId, order.OrderItems);
            }
           
        }

        public static void SaveOrderDetails(int orderId, BindingList<POSItemTill> order)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSItemTill item in order)
                    {
                        using (SqlCommand com = new SqlCommand("InsertOrderDetail", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("@oid", orderId));
                            com.Parameters.Add(new SqlParameter("@itemid", item.ItemId));
                            com.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
                            com.Parameters.Add(new SqlParameter("@salePrice", item.SalePrice));
                            int odid = Convert.ToInt32(com.ExecuteScalar());

                            List<POSInstruction> instructions = item.GetInstructions();
                            if (instructions.Count > 0)
                            {
                                foreach (POSInstruction i in instructions)
                                {
                                    using (SqlCommand com2 = new SqlCommand("InsertOrderDetailInstruction", con))
                                    {
                                        com2.CommandType = CommandType.StoredProcedure;
                                        com2.Parameters.Add(new SqlParameter("odid", odid));
                                        com2.Parameters.Add(new SqlParameter("iid", i.InstructionId));
                                        com2.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveHold(int hid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@hid", hid);
            POSExecuteNonQuery("RemoveHoldDetails", pars);
            POSExecuteNonQuery("RemoveHold", pars);
            
        }
        
        /**
         * For new holds
         * */
        public static void HoldOrder(int uid, int tid, POSOrder order)
        {
            //check if there is already a hold on this table
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@tid", tid);
            int hid = Convert.ToInt32(POSExecuteScalar("CheckTableHold", pars));
            if (hid == 0) //there is no hold so create one
            {
                pars.Add("@uid", uid);
                hid = Convert.ToInt32(POSExecuteScalar("InsertOrderHold", pars));
            }
            HoldOrderDetails(hid, order.OrderItems);
        }

        /**
         * For updating existing holds
         * */
        public static void UpdateHold(POSOrder order)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    //replace order hold details
                    using (SqlCommand com = new SqlCommand("RemoveHoldDetails", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@hid", order.Hid));
                        com.ExecuteNonQuery();
                    }
                }
                HoldOrderDetails(order.Hid, order.OrderItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void HoldOrderDetails(int hid, BindingList<POSItemTill> order)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSItemTill item in order)
                    {
                        using (SqlCommand com = new SqlCommand("InsertOrderHoldDetail", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("@hid", hid));
                            com.Parameters.Add(new SqlParameter("@itemid", item.ItemId));
                            com.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
                            com.Parameters.Add(new SqlParameter("@salePrice", item.SalePrice));
                            int hdid = Convert.ToInt32(com.ExecuteScalar());

                            List<POSInstruction> instructions = item.GetInstructions();
                            if (instructions.Count > 0)
                            {
                                foreach (POSInstruction i in instructions)
                                {
                                    using (SqlCommand com2 = new SqlCommand("InsertOrderHoldDetailInstruction", con))
                                    {
                                        com2.CommandType = CommandType.StoredProcedure;
                                        com2.Parameters.Add(new SqlParameter("hdid", hdid));
                                        com2.Parameters.Add(new SqlParameter("iid", i.InstructionId));
                                        com2.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<POSItemTill> GetOrder(int hid)
        {
            List<POSItemTill> order = new List<POSItemTill>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetOrderHold", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@hid", hid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSItemTill item = new POSItemTill(
                                    Convert.ToInt32(dr["itemid"]),
                                  Convert.ToInt32(dr["pid"]),
                                  Convert.ToString(dr["pname"]),
                                  Convert.ToString(dr["variation"]),
                                  Convert.ToDouble(dr["price"]),
                                  Convert.ToInt32(dr["quantity"]),
                                  Convert.ToString(dr["barcode"]),
                                  Convert.ToDouble(dr["costPrice"]),
                                  Convert.ToInt32(dr["stockLevel"]),
                                  Convert.ToString(dr["PLU"]),
                                  Convert.ToString(dr["suPLU"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]),
                                  Convert.ToInt32(dr["sortOrder"]));
                                item.SalePrice = Convert.ToDouble(dr["salePrice"]);
                                List<POSInstruction> instructions = GetOrderHoldDetailInstructions(Convert.ToInt32(dr["hdid"]));
                                foreach (POSInstruction i in instructions)
                                {
                                    item.AddInstruction(i);
                                }
                                order.Add(item);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return order;
        }

        public static BindingList<POSItemTill> GetOrder(int oid, string type)
        {
            BindingList<POSItemTill> order = new BindingList<POSItemTill>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetOrder", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@oid", oid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSItemTill item = new POSItemTill(
                                   Convert.ToInt32(dr["itemid"]),
                                 Convert.ToInt32(dr["pid"]),
                                 Convert.ToString(dr["pname"]),
                                 Convert.ToString(dr["variation"]),
                                 Convert.ToDouble(dr["price"]),
                                 Convert.ToInt32(dr["quantity"]),
                                 Convert.ToString(dr["barcode"]),
                                 Convert.ToDouble(dr["costPrice"]),
                                 Convert.ToInt32(dr["stockLevel"]),
                                 Convert.ToString(dr["PLU"]),
                                 Convert.ToString(dr["suPLU"]),
                                 Convert.ToInt32(dr["x"]),
                                 Convert.ToInt32(dr["y"]),
                                 Convert.ToInt32(dr["sortOrder"]));
                                item.SalePrice = Convert.ToDouble(dr["salePrice"]);
                               
                                order.Add(item);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return order;
        }

        public static List<POSRecentOrder> GetRecentOrders()
        {
            List<POSRecentOrder> orders = new List<POSRecentOrder>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetRecentOrders", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSRecentOrder order = new POSRecentOrder(
                                    Convert.ToInt32(dr["oid"]),
                                    Convert.ToDateTime(dr["odate"]),
                                    Convert.ToString(dr["username"]),
                                    Convert.ToInt32(dr["guestCount"]),
                                    Convert.ToDouble(dr["total"]));
                                orders.Add(order);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return orders;
        }

        public static List<POSInstruction> GetOrderHoldDetailInstructions(int hdid)
        {
            List<POSInstruction> instructions = new List<POSInstruction>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetOrderHoldDetailInstructions", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@hdid", hdid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSInstruction i = new POSInstruction(
                                    Convert.ToInt32(dr["iid"]),
                                    Convert.ToString(dr["iname"]));
                                instructions.Add(i);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return instructions;
        }
       
        public static List<POSUser> GetUsers()
        {
            List<POSUser> users = new List<POSUser>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetUsers", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSUser user = new POSUser(
                                    Convert.ToInt32(dr["uid"]), 
                                    Convert.ToString(dr["firstName"]),
                                    Convert.ToString(dr["lastName"]),
                                    Convert.ToString(dr["username"]),
                                    Convert.ToString(dr["password"]),
                                    Convert.ToInt32(dr["utid"]));
                                users.Add(user);
                                 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return users;
        }

        public static POSUser GetUser(string password)
        {
            POSUser user = null;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetUserByPassword", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@password", password));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if(dr.Read())
                            {
                                user = new POSUser(
                                    Convert.ToInt32(dr["uid"]),
                                    Convert.ToString(dr["firstName"]),
                                    Convert.ToString(dr["lastName"]),
                                    Convert.ToString(dr["username"]),
                                    Convert.ToString(dr["password"]),
                                    Convert.ToInt32(dr["utid"]));

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return user;
        }

        public static Dictionary<int, string> GetUserTypes()
        {
            Dictionary<int, string> userTypes = new Dictionary<int, string>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetUserTypes", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                userTypes.Add(Convert.ToInt32(dr["utid"]),
                                    Convert.ToString(dr["name"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return userTypes;
        }

        public static void SaveUsers(List<POSUser> users)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSUser user in users)
                    {
                        if (user.Uid == -1) //new user
                        {
                            int id;
                            using (SqlCommand com = new SqlCommand("InsertUser", con))
                            {
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.Add(new SqlParameter("@firstName", user.Firstname));
                                com.Parameters.Add(new SqlParameter("@lastName", user.Lastname));
                                com.Parameters.Add(new SqlParameter("@username", user.Username));
                                com.Parameters.Add(new SqlParameter("@password", user.Password));
                                com.Parameters.Add(new SqlParameter("@utid", user.UserTypeId));
                                id = Convert.ToInt32(com.ExecuteScalar());
                            }
                            SetDefaultPrivileges(id);

                        }
                        else  //existing user
                        {
                            using (SqlCommand com = new SqlCommand("UpdateUser", con))
                            {
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.Add(new SqlParameter("@uid", user.Uid));
                                com.Parameters.Add(new SqlParameter("@firstName", user.Firstname));
                                com.Parameters.Add(new SqlParameter("@lastName", user.Lastname));
                                com.Parameters.Add(new SqlParameter("@username", user.Username));
                                com.Parameters.Add(new SqlParameter("@password", user.Password));
                                com.Parameters.Add(new SqlParameter("@utid", user.UserTypeId));
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int InsertUser(POSUser user)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@firstName", user.Firstname);
            pars.Add("@lastName", user.Lastname);
            pars.Add("@username", user.Username);
            pars.Add("@password", user.Password);
            pars.Add("@utid", user.UserTypeId);
            int id = Convert.ToInt32(POSExecuteScalar("InsertUser", pars));
            SetDefaultPrivileges(id);
            return id;
        }

        public static List<POSPriceLevel> GetPriceLevels()
        {
            List<POSPriceLevel> priceLevels = new List<POSPriceLevel>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPriceLevels", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPriceLevel pl = new POSPriceLevel(
                                    Convert.ToInt32(dr["plid"]),
                                    Convert.ToString(dr["plname"]),
                                    Convert.ToString(dr["pldescription"]),
                                    Convert.ToDouble(dr["plrate"]));
                                priceLevels.Add(pl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return priceLevels;
        }

        public static int SavePriceLevel(POSPriceLevel priceLevel)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@plname", priceLevel.PriceLevelName);
            pars.Add("@pldescription", priceLevel.PriceLevelDescription);
            pars.Add("@plrate", priceLevel.PriceLevelRate);

            if (priceLevel.PriceLevelId > 0)
            {
                pars.Add("@plid", priceLevel.PriceLevelId);
                POSExecuteNonQuery("UpdatePriceLevel", pars);
                return priceLevel.PriceLevelId;
            }
            else
            {//not yet in database
                int id = Convert.ToInt32(POSExecuteScalar("InsertPriceLevel", pars));
                return id;
            }

        }

        public static double GetPriceLevel(int plid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@plid", plid);
            return Convert.ToDouble(POSExecuteScalar("GetPriceLevel", pars));
            
        }

        public static double GetPriceLevelRateForItem(int plid, int itemid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@plid", plid);
            pars.Add("@itemid", itemid);
            return Convert.ToDouble(POSExecuteScalar("GetPriceLevelRateForItem", pars));
        }
        
        public static List<POSRoom> GetRooms()
        {
            List<POSRoom> rooms = new List<POSRoom>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetRooms", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rooms.Add(new POSRoom(
                                    Convert.ToInt32(dr["rid"]),
                                    Convert.ToString(dr["rname"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rooms;
        }

        public static void SaveRooms(List<POSRoom> rooms)
        {
            foreach (POSRoom room in rooms)
            {
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars.Add("@rname", room.Rname);

                if (room.Rid < 0)
                {
                    POSExecuteNonQuery("InsertRoom", pars);
                }
                else
                {
                    pars.Add("@rid", room.Rid);
                    POSExecuteNonQuery("UpdateRoom", pars);
                }
            }

           
        }

        public static void DeleteRoom(int rid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@rid", rid);
            POSExecuteNonQuery("DeleteRoom", pars);
        }
        
        public static bool RoomHasHolds(int rid)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("RoomHasHolds", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@rid", rid));
                        bool result = Convert.ToBoolean(com.ExecuteScalar());
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool RoomHasTables(int rid)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("RoomHasTables", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@rid", rid));
                        bool result = Convert.ToBoolean(com.ExecuteScalar());
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        
        public static List<POSTable> GetTables(int rid)
        {
            List<POSTable> tables = new List<POSTable>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetTablesAndHolds", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@rid", rid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSTable table = new POSTable(
                                    Convert.ToInt32(dr["tid"]), 
                                    Convert.ToInt32(dr["hid"]),
                                    Convert.ToString(dr["tname"]),
                                    rid,
                                    Convert.ToInt32(dr["x"]),
                                    Convert.ToInt32(dr["y"]));
                                tables.Add(table);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tables;
        }

        public static int SaveTable(POSTable table)
        {
            int tid = 0;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("InsertTable", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@tname", table.Tname));
                        com.Parameters.Add(new SqlParameter("@rid", table.Rid));
                        com.Parameters.Add(new SqlParameter("@x", table.X));
                        com.Parameters.Add(new SqlParameter("@y", table.Y));
                        tid = Convert.ToInt32(com.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tid;
        }

        public static void DeleteTable(int tid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@tid", tid);
            POSExecuteNonQuery("DeleteTable", pars);

        }

        public static List<POSInstruction> GetInstructionsGeneral()
        {
            List<POSInstruction> instructions = new List<POSInstruction>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetInstructionsGeneral", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                instructions.Add(new POSInstruction(
                                    Convert.ToInt32(dr["iid"]),
                                    Convert.ToString(dr["iname"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return instructions;
        }

        public static void DeleteInstruction(int iid)
        {
            Dictionary<string, object> pars = new Dictionary<string,object>();
            pars.Add("@iid", iid);
            POSExecuteNonQuery("DeleteInstruction", pars);
        }

        public static void SaveInstructions(List<POSInstruction> instructions)
        {
            foreach (POSInstruction i in instructions)
            {
                SaveInstruction(i);
            }
        }

        public static int SaveInstruction(POSInstruction i)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            int id = i.InstructionId;
            pars.Add("@iname", i.Instruction);
            pars.Add("@pid", i.ProductId);
            pars.Add("@sid", i.SectionId);
            pars.Add("@x", i.X);
            pars.Add("@y", i.Y);
            if (i.InstructionId == -1)
            {//not yet in database
                id = Convert.ToInt32(POSExecuteScalar("InsertInstruction", pars));
            }
            else
            {
                pars.Add("@iid", i.InstructionId);
                POSExecuteNonQuery("UpdateInstruction", pars);
            }
            return id;
        }
        
        public static int GetSuid(string supplier)
        {
            int suid = 0;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSuid", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@supplier", supplier));
                        suid = Convert.ToInt32(com.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return suid;
        }

        public static List<POSSupplier> GetSuppliers()
        {
            List<POSSupplier> suppliers = new List<POSSupplier>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSuppliers", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSSupplier s = new POSSupplier(
                                    Convert.ToInt32(dr["suid"]),
                                    Convert.ToString(dr["name"]));
                                suppliers.Add(s);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return suppliers;
        }

        public static List<POSZeroIncomeType> GetZeroIncomeTypes()
        {
            List<POSZeroIncomeType> types = new List<POSZeroIncomeType>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetZeroIncomeTypes", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                types.Add(new POSZeroIncomeType(
                                    Convert.ToInt32(dr["ztid"]),
                                    Convert.ToString(dr["ztname"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return types;
        }

        public static void SaveZeroIncome(BindingList<POSItemTill> items, int ztid)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSItemTill item in items)
                    {
                        using (SqlCommand com = new SqlCommand("InsertZeroWastage", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("@itemid", item.ItemId));
                            com.Parameters.Add(new SqlParameter("@ztid", ztid));
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ClearProductLocations(int sid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@sid", sid); 
            POSExecuteNonQuery("ClearProductLocations", pars);
        }

        /// <summary>
        /// Attempts to update the location of a product button. 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="proposedLocation"></param>
        /// <returns>Returns true if the update is successful.</returns>
        public static bool SaveProductLocation(int pid, Point proposedLocation)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            pars.Add("@x", proposedLocation.X);
            pars.Add("@y", proposedLocation.Y);
            bool ok = Convert.ToBoolean(POSExecuteScalar("UpdateProductLocation", pars));
            return ok;
        }

        public static int GetNextLocationRow(int cid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@cid", cid);
            return Convert.ToInt32(POSExecuteScalar("GetNextLocationRow", pars));
        }
        
        public static int GetSid(int pid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            return Convert.ToInt32(POSExecuteScalar("GetSid", pars));
        }

        public static string GetSectionName(int sid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@sid", sid);
            return Convert.ToString(POSExecuteScalar("GetSectionName", pars));
        }

        public static string GetCategoryName(int cid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@cid", cid);
            return Convert.ToString(POSExecuteScalar("GetCategoryName", pars));
        }
       
        public static string GetButtonText(int pid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            return POSExecuteString("GetButtonText", pars);
        }

        public static Dictionary<int, POSUserPrivilege> GetUserPrivileges(int uid)
        {
            Dictionary<int, POSUserPrivilege> userPrivileges = new Dictionary<int, POSUserPrivilege>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetUserPrivileges", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@uid", uid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSUserPrivilege up = new POSUserPrivilege(
                                    Convert.ToInt32(dr["prid"]),
                                    Convert.ToString(dr["prname"]),
                                    Convert.ToBoolean(dr["allowed"]));
                                userPrivileges.Add(up.PrivilegeId, up);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return userPrivileges;
        }

        public static void SetDefaultPrivileges(int uid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@uid", uid);
            POSExecuteNonQuery("SetDefaultPrivileges", pars);
        }

        public static void DeleteUser(int uid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@uid", uid);
            POSExecuteNonQuery("DeleteUser", pars);
        }

        public static void SaveUserPrivileges(int uid, List<POSUserPrivilege> userPrivileges)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    foreach (POSUserPrivilege up in userPrivileges)
                    {
                        using (SqlCommand com = new SqlCommand("UpdateUserPrivilege", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add(new SqlParameter("@uid", uid));
                            com.Parameters.Add(new SqlParameter("@prid", up.PrivilegeId));
                            com.Parameters.Add(new SqlParameter("@allowed", up.Allowed));
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        public static string GetReceiptPrinterName()
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            return Convert.ToString(POSExecuteScalar("GetReceiptPrinterName", pars));
        }

        public static POSPrinter GetReceiptPrinter()
        {
            POSPrinter printer = null;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetReceiptPrinter", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                printer = new POSPrinter(
                                    Convert.ToInt32(dr["prid"]),
                                    Convert.ToString(dr["location"]),
                                    Convert.ToString(dr["prname"]), true);
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return printer;
        }
        
        public static List<POSPrinter> GetPrinters()
        {
            List<POSPrinter> printers = new List<POSPrinter>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPrinters", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPrinter printer = new POSPrinter(
                                    Convert.ToInt32(dr["prid"]),
                                    Convert.ToString(dr["location"]),
                                    Convert.ToString(dr["prname"]),
                                    Convert.ToBoolean(dr["isReceiptPrinter"]));
                                printers.Add(printer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return printers;
        }

        public static BindingList<POSPrinter> GetPrinters(int pid)
        {
            BindingList<POSPrinter> printers = new BindingList<POSPrinter>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPrintersForProduct", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPrinter printer = new POSPrinter(
                                    Convert.ToInt32(dr["prid"]),
                                    Convert.ToString(dr["location"]),
                                    Convert.ToString(dr["prname"]),
                                    Convert.ToBoolean(dr["isReceiptPrinter"]));
                                printers.Add(printer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return printers;
        }

        public static int InsertPrinter(POSPrinter printer)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@location", printer.Location);
            pars.Add("@prname", printer.PrinterName);
            pars.Add("@isReceiptPrinter", printer.IsReceiptPrinter);
            return Convert.ToInt32(POSExecuteScalar("InsertPrinter", pars));
        }

        public static void UpdatePrinter(POSPrinter printer)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@prid", printer.PrinterId);
            pars.Add("@location", printer.Location);
            pars.Add("@prname", printer.PrinterName);
            pars.Add("@isReceiptPrinter", printer.IsReceiptPrinter);
            POSExecuteNonQuery("UpdatePrinter", pars);
        }

        public static void InsertProductPrinter(int pid, int prid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            pars.Add("@prid", prid);
            POSExecuteNonQuery("InsertProductPrinter", pars);
        }

        public static void DeleteProductPrinter(int pid, int prid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@pid", pid);
            pars.Add("@prid", prid);
            POSExecuteNonQuery("DeleteProductPrinter", pars);
        }

        public static void DeletePrinter(int prid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@prid", prid);
            POSExecuteNonQuery("DeletePrinter", pars);
        }
        
        public static POSCategory GetProductCategory(int pid)
        {
            POSCategory cat = null;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetProductCategory", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                cat = new POSCategory(
                                    Convert.ToInt32(dr["cid"]),
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["cname"]),
                                    Convert.ToString(dr["backcolour"]),
                                    Convert.ToString(dr["forecolour"]),
                                    Convert.ToInt32(dr["gid"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cat;
        }

        public static int GetFirstGroupId()
        {
            return Convert.ToInt32(
                POSExecuteScalar("GetFirstGroupId", new Dictionary<string, object>()));
        }

        public static List<POSGroup> GetGroups()
        {
            List<POSGroup> groups = new List<POSGroup>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetGroups", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSGroup group = new POSGroup(
                                    Convert.ToInt32(dr["gid"]),
                                    Convert.ToString(dr["gname"]));
                                groups.Add(group);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return groups;
        }

        public static List<POSConfigItem> GetConfigItems()
        {
            List<POSConfigItem> items = new List<POSConfigItem>();

            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetConfig", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSConfigItem item = new POSConfigItem(
                                    Convert.ToInt32(dr["cid"]),
                                    Convert.ToString(dr["Item"]),
                                    Convert.ToString(dr["Value"]));
                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return items;
        }

        public static void SaveConfig(int cid, string item, string value)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@cid", cid);
            pars.Add("@item", item);
            pars.Add("@value", value);
            POSExecuteNonQuery("SaveConfig", pars);
        }

        public static string GetConfigValue(string name)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@item", name);
            return POSExecuteString("GetConfigValue", pars);
        }

        public static List<ItemTotal> GetDailyItemTotals(int cid, DateTime date)
        {
            List<ItemTotal> totals = new List<ItemTotal>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("DailyItemTotalsByCategory", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@cid", cid));
                        com.Parameters.Add(new SqlParameter("@day", date));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ItemTotal it = new ItemTotal(
                                    Convert.ToInt32(dr["pid"]),
                                    Convert.ToInt32(dr["itemid"]),
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                    Convert.ToInt32(dr["quantity"]),
                                    Convert.ToDouble(dr["Total Sales"]));
                                totals.Add(it);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return totals;
        }

        public static List<ItemTotal> GetItemTotals(int cid, DateTime start,
            DateTime end)
        {
            List<ItemTotal> totals = new List<ItemTotal>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("Report_ItemTotalsByCategory", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@cid", cid));
                        com.Parameters.Add(new SqlParameter("@startdate", start));
                        com.Parameters.Add(new SqlParameter("@enddate", end));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ItemTotal it = new ItemTotal(
                                    Convert.ToInt32(dr["pid"]),
                                    Convert.ToInt32(dr["itemid"]),
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                    Convert.ToInt32(dr["quantity"]),
                                    Convert.ToDouble(dr["Total Sales"]));
                                totals.Add(it);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return totals;
        }

        public static Dictionary<string, double> GetDailyPaymentTypeTotals()
        {
            Dictionary<string, double> totals = new Dictionary<string, double>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetDailyPaymentTypeTotals", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                totals.Add(Convert.ToString(dr["Payment Type"]),
                                    Convert.ToDouble(dr["Total"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return totals;
        }

        public static Dictionary<string, int> GetDailyCustomerTotal()
        {
            Dictionary<string, int> totals = new Dictionary<string, int>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetCustomerCount", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                totals.Add(Convert.ToString(dr["tname"]),
                                    Convert.ToInt32(dr["total"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return totals;
        }

        public static POSItemTill GetItemByBarcode(string barcode)
        {
            POSItemTill item = null;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetItemByBarcode", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@barcode", barcode));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                item = new POSItemTill(
                                    Convert.ToInt32(dr["itemid"]),
                                    Convert.ToInt32(dr["pid"]),
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                  Convert.ToDouble(dr["price"]),
                                  1,
                                  Convert.ToString(dr["barcode"]),
                                  Convert.ToDouble(dr["costPrice"]),
                                  Convert.ToInt32(dr["stockLevel"]),
                                  Convert.ToString(dr["PLU"]),
                                  Convert.ToString(dr["suPLU"]),
                                  Convert.ToInt32(dr["x"]),
                                  Convert.ToInt32(dr["y"]),
                                  Convert.ToInt32(dr["sortOrder"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return item;
        }
        
        public static int SaveSupplier(POSSupplier supplier)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@name", supplier.Supplier);
            pars.Add("@phone", supplier.Phone);
            pars.Add("@address", supplier.Address);
            int id = supplier.Suid;
            if (supplier.Suid < 0)
            {
                id = Convert.ToInt32(POSExecuteScalar("InsertSupplier", pars));
            }
            else
            {
                pars.Add("@suid", supplier.Suid);
                POSExecuteNonQuery("UpdateSupplier", pars);
            }
            return id;
        }

        public static BindingList<POSInstruction> GetProductInstructions(int pid)
        {
            BindingList<POSInstruction> instructions = 
                new BindingList<POSInstruction>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetProductInstructions", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pid", pid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSInstruction instruction = new POSInstruction(
                                    Convert.ToInt32(dr["iid"]),
                                    Convert.ToString(dr["iname"]),
                                    pid);
                                instructions.Add(instruction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return instructions;
        }

        public static void SaveZeroIncomeTypes(List<POSZeroIncomeType> zeroIncomeTypes)
        {
            foreach (POSZeroIncomeType zi in zeroIncomeTypes)
            {
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars.Add("@ztname", zi.Ztname);

                if (zi.Ztid > 0)
                {
                    pars.Add("@ztid", zi.Ztid);
                    POSExecuteNonQuery("UpdateZeroIncomeType", pars);
                }
                else
                {
                    POSExecuteNonQuery("InsertZeroIncomeType", pars);
                }
            }
        }

        public static void DeleteZeroIncomeType(int ztid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@ztid", ztid);
            POSExecuteNonQuery("DeleteZeroIncomeType", pars);
        }

        public static List<POSSupplierType> GetSupplierTypes()
        {
            List<POSSupplierType> types = new List<POSSupplierType>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSupplierTypes", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSSupplierType type = new POSSupplierType(
                                    Convert.ToInt32(dr["id"]),
                                    Convert.ToString(dr["type"]));
                                types.Add(type);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return types;
        }

        public static List<POSInstruction> GetSectionInstructions(int sid)
        {
            List<POSInstruction> sectionInstructions = new List<POSInstruction>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetSectionInstructions", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@sid", sid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSInstruction instruction = new POSInstruction(
                                    Convert.ToInt32(dr["iid"]),
                                    Convert.ToString(dr["iname"]),
                                    sid,
                                    Convert.ToInt32(dr["x"]),
                                    Convert.ToInt32(dr["y"]));
                                sectionInstructions.Add(instruction);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sectionInstructions;
        }

        public static void SaveInstructionLocation(int id, int x, int y)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@iid", id);
            pars.Add("@x", x);
            pars.Add("@y", y);
            POSExecuteNonQuery("UpdateInstructionLocation", pars);
        }

        public static bool CheckLocationAvailable(int x, int y, int sid)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@x", x);
            pars.Add("@y", y);
            pars.Add("@sid", sid);
            return Convert.ToBoolean(POSExecuteScalar("CheckLocationAvailable", pars));

        }
        
        public static BindingList<POSPrinter> GetCommonProductPrinters(List<POSProduct> products)
        {
            BindingList<POSPrinter> printers = new BindingList<POSPrinter>();
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach(POSProduct prod in products)
                {
                    sb.Append(prod.ProductId.ToString() + ",");
                }
                string idArray = sb.ToString();
                idArray = idArray.TrimEnd(',');
                if (idArray.Length > 500)
                {
                    idArray = idArray.Substring(0, 500);
                }
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetCommonProductPrinters", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@pidArray", idArray));
                        com.Parameters.Add(new SqlParameter("@count", products.Count));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPrinter printer = new POSPrinter(
                                    Convert.ToInt32(dr["prid"]),
                                    Convert.ToString(dr["location"]),
                                    Convert.ToString(dr["prname"]),
                                    Convert.ToBoolean(dr["isReceiptPrinter"]));
                                printers.Add(printer);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return printers;
        }

        public static Dictionary<int, string> GetPriceLevelsForItems(string idarray)
        {
            Dictionary<int, string> priceLevels = new Dictionary<int, string>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPriceLevelsForItems", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@idarray", idarray));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                priceLevels.Add(Convert.ToInt32(dr["plid"]),
                                    Convert.ToString(dr["plname"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return priceLevels;
        }

        public static List<POSPriceLevel_Item> GetPriceLevelsForItem(int itemid)
        {
            List<POSPriceLevel_Item> pricelevels = new List<POSPriceLevel_Item>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPriceLevelsForItem", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@itemid", itemid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPriceLevel_Item pl = new POSPriceLevel_Item(
                                    Convert.ToInt32(dr["id"]),
                                    Convert.ToInt32(dr["plid"]),
                                    Convert.ToString(dr["plname"]),
                                    itemid,
                                    Convert.ToInt32(dr["priceLevelException_id"]),
                                    Convert.ToDouble(dr["rate"]));
                                pricelevels.Add(pl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pricelevels;
        }

        public static void SavePriceLevelItem(int id, double rate)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@id", id);
            pars.Add("@rate", rate);
            POSExecuteNonQuery("UpdatePriceLevel_Item", pars);
        }

        public static BindingList<POSPriceLevelException> GetPriceLevelExceptions(int plid)
        {
            BindingList<POSPriceLevelException> priceLevelRules =
                new BindingList<POSPriceLevelException>();
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("GetPriceLevelExceptions", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@plid", plid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                POSPriceLevelException rule = new POSPriceLevelException(
                                    Convert.ToInt32(dr["id"]),
                                    Convert.ToInt32(dr["plid"]),
                                    Convert.ToInt32(dr["suid"]),
                                    Convert.ToString(dr["supplier"]),
                                    Convert.ToInt32(dr["sid"]),
                                    Convert.ToString(dr["section"]),
                                    Convert.ToInt32(dr["cid"]),
                                    Convert.ToString(dr["category"]),
                                    Convert.ToDouble(dr["rate"]));
                                priceLevelRules.Add(rule);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return priceLevelRules;
        }

        public static void InsertPriceLevelException(int plid, int suid, int sid, int cid,
            double rate)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@plid", plid);
            pars.Add("@suid", suid);
            pars.Add("@sid", sid);
            pars.Add("@cid", cid);
            pars.Add("@rate", rate);
            POSExecuteNonQuery("InsertPriceLevelException", pars);
        }

        public static void DeletePriceLevelException(POSPriceLevelException exception)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@id", exception.Id);
            pars.Add("@plid", exception.PriceLevelId);
            POSExecuteNonQuery("DeletePriceLevelException", pars);
        }
        
        public static BindingList<POSItemStock> FilterStock(int suid, int sid, int cid)
        {
            BindingList<POSItemStock> stock = new BindingList<POSItemStock>();
            string pname = string.Empty;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("FilterStock", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@suid", suid));
                        com.Parameters.Add(new SqlParameter("@sid", sid));
                        com.Parameters.Add(new SqlParameter("@cid", cid));
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                pname = Convert.ToString(dr["pname"]);
                                POSItemStock item = new POSItemStock(
                                    Convert.ToInt32(dr["itemid"]),
                                    Convert.ToInt32(dr["pid"]),
                                    Convert.ToString(dr["pname"]),
                                    Convert.ToString(dr["variation"]),
                                    Convert.ToString(dr["supplier"]),
                                    Convert.ToDouble(dr["price"]),
                                    Convert.ToString(dr["cname"]),
                                    Convert.ToString(dr["sname"]),
                                    Convert.ToString(dr["barcode"]),
                                    Convert.ToDouble(dr["costPrice"]),
                                    Convert.ToInt32(dr["stockLevel"]),
                                    Convert.ToString(dr["PLU"]),
                                    Convert.ToString(dr["suPLU"]));
                                stock.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + pname + " " + ex.StackTrace);
            }
            return stock;
        }

        public static void SaveItemStock(int itemid, int stockLevel, string PLU, string suPLU)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("@itemid", itemid);
            pars.Add("@stockLevel", stockLevel);
            pars.Add("@PLU", PLU);
            pars.Add("@suPLU", suPLU);
            POSExecuteNonQuery("UpdateStock", pars);
        }
        
        private static void POSExecuteNonQuery(string procedureName, 
            Dictionary<string, object> pars)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(procedureName, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        foreach(KeyValuePair<string, object> parameter in pars)
                        {
                            com.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        }
                        com.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static object POSExecuteScalar(string procedureName,
            Dictionary<string, object> pars)
        {
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(procedureName, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        foreach (KeyValuePair<string, object> parameter in pars)
                        {
                            com.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        }
                        return com.ExecuteScalar();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private static string POSExecuteString(string procedureName,
           Dictionary<string, object> pars)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection con = Connect())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(procedureName, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        foreach (KeyValuePair<string, object> parameter in pars)
                        {
                            com.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        }
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                result = Convert.ToString(dr[0]);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }




    }
}
