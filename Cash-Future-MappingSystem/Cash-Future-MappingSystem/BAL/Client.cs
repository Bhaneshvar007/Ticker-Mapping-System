using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Cash_Future_MappingSystem.Models;
using ClientMoodel = Cylsys.Common.ClientMoodel;

namespace Cash_Future_MappingSystem.BAL
{
    public class Client
    {
        public ClientMoodel GetItem(int id)
        {
            ClientMoodel bll = new ClientMoodel();
            if (id == 0)
            {
                bll = new ClientMoodel();
            }
            else
            {
                SqlParameter[] Params = { new SqlParameter("@id", id) };

                DataTable DT = DataAccess.ExecuteProcedure("getallclients", Params);
                if (DT.Rows.Count > 0)
                {
                    List<ClientMoodel> userlist = QueryHandler.GetUserGridList(DT);
                    if (userlist.Count > 0)
                        bll = userlist[0];

                }
            }
            return bll;
        }
        public string Save(ClientMoodel model)
        {
            string Response = string.Empty;
            List<UserModel> bll = new List<UserModel>();
            DbCommonHelper dbcom = new DbCommonHelper();


            SqlParameter[] Params = {
                                            new SqlParameter("@Client_ID",model.Client_ID),
                                            new SqlParameter("@ClientName",model.ClientName),
                                            new SqlParameter("@AccountNo",model.AccountNo),
                                            new SqlParameter("@SecurityId",model.SecurityId),
                                            new SqlParameter("@Broker",model.Broker),
                                            new SqlParameter("@IsActive",model.isactive),
                                            new SqlParameter("@Side",model.Side),
                                            new SqlParameter("@Quantity", model.Quantity),
                                            new SqlParameter("@Broker_Id", model.Broker_Id),
                                            new SqlParameter("@Action", "UPDATE"),
                                            //new SqlParameter("@UserID",UserManager.User.Code),

                                         };


            Response = dbcom.Save("sp_Clientmaster_CRUD", Params);
            return Response;
        }

        public List<ClientMoodel> GetclientGrid()
        {
            ClientMoodel bll = new ClientMoodel();

            List<ClientMoodel> RM_LIST = new List<ClientMoodel>();
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALL") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_Clientmaster_CRUD", Params);

            if (DT.Rows.Count > 0)
            {
                RM_LIST = QueryHandler.GetUserGridList(DT);
            }
            return RM_LIST;
        }

        public List<ClientMoodel> GetclientOldGrid()
        {
            ClientMoodel bll = new ClientMoodel();

            List<ClientMoodel> RM_LIST = new List<ClientMoodel>();
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALLOLD") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_Clientmaster_CRUD", Params);

            if (DT.Rows.Count > 0)
            {
                RM_LIST = QueryHandler.GetUserGridList(DT);
            }
            return RM_LIST;
        }


    }
}