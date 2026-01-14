using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cylsys.Common
{
    public class GetQuery
    {

        /* Kapil Query  start */
        public static string LovCategory_GRID_DATA
        {
            get
            {
                return @"select * from RM_tbl_lov_category";
            }
        }

        public static string LovCategory_DATA_SEQID
        {
            get
            {
                return @"select * from RM_tbl_lov_category where ID=@ID";
            }
        }

        public static string Lov_GRID_DATA
        {
            get
            {
                return @"select * from RM_tbl_lov";
            }
        }

        public static string Lov_DATA_SEQID
        {
            get
            {
                return @"select * from RM_tbl_lov where ID=@ID";
            }
        }

        public static string DDL_QUERY_CATEGORY_TYPES
        {
            get
            {
                return @"select 0 as ID,'Select' as Name
                union select lovc.ID,lovc.Name from RM_tbl_lov_category lovc
                where lovc.Is_Active=1;";
            }
        }
        /* Kapil Query  End */
        //Query for user screen
        public static string USER_INSERT_QUERY
        {
            get
            {
                return @"insert into RM_tbl_user_master(code,name,email,roleid,isactive,created_date)
                                                    values(@Code, @Name, @Email, @RoleID, @IsActive, @created_date)";
            }
        }
        public static string MENU_ROLE_MAPPING_INSERT_QUERY
        {
            get
            {
                return @"insert into RM_tbl_menu_role_mapping(menuid,roleid,created_date,isactive)
                                                    values(@menu_id,@role_id,@created_date,@isactive)";
            }
        }
        public static string GET_ASSIGNED_MENU_TO_ROLE
        {
            get
            {
                return @"select * from RM_tbl_menu_role_mapping where  isactive=1 and roleid=@role_id ";
            }
        }
        public static string DELETE_OLD_MENU_ROLE_MAPPING_QUERY
        {
            get
            {
                return @"delete from RM_tbl_menu_role_mapping where roleid=@role_id";
            }
        }
        public static string USER_RECORD_CHECK_QUERY
        {
            get
            {
                return @"select * from RM_tbl_user_master where code=@Code";
            }
        }
        public static string MENU_LIST_DATA
        {
            get
            {
                return @"select * from RM_tbl_menu_master where isactive=1";
            }
        }
        public static string ROLE_DATA_SEQID
        {
            get
            {
                return @"select * from RM_tbl_role_master where ID=@ID";
            }
        }

        public static string SCHEME_DATA_ID
        {
            get
            {
                return @"select * from tbl_scheme_master where ID=@ID";
            }
        }
        public static string ORDER_MANAGEMENT_DATA_ID
        {
            get
            {
                return @"select * from oms_tbl_order_management_trans where ID=@ID";
            }
        }

        // Query for role screen
        public static string ROLE_INSERT_QUERY
        {
            get
            {
                return @"insert into RM_tbl_role_master(code,name,IsActive,created_date)
                                                    values(@Code, @Name, @IsActive, @created_date)";
            }
        }
        public static string ROLE_RECORD_CHECK_QUERY
        {
            get
            {
                return @"select * from RM_tbl_role_master where code=@Code";
            }
        }

        public static string DDL_EMAIL_EXCEL_FILES
        {
            get
            {
                return @"select ID,FileName as Name from oms_polling_email_info where CONVERT(date,Created_Date,106) between @from_date and @to_date";
            }
        }

        public static string DDL_QUERY_SECURITY_TYPES
        {
            get
            {
                return @"select 0 as ID,'Select' as Name
                                                        union
                                                          select lov.ID,lov.Name from RM_tbl_lov_category lovc
                        inner join RM_tbl_lov lov on lov.CategoryID=lovc.ID
                        where lovc.Code='SECURITY_TYPE' and lovc.IsActive=1 and lov.IsActive=1 ";
            }
        }
        public static string DDL_QUERY_TOGGLES
        {
            get
            {
                return @"select 0 as ID,'Select' as Name
                                                        union
                                                          select lov.ID,lov.Name from RM_tbl_lov_category lovc
                        inner join RM_tbl_lov lov on lov.CategoryID=lovc.ID
                        where lovc.Code='TOGGLE' and lovc.IsActive=1 and lov.IsActive=1 ";
            }
        }
        public static string DDL_QUERY_PRICE_YIELD
        {
            get
            {
                return @"select 0 as ID,'Select' as Name
                                                        union
                                                          select lov.ID,lov.Name from RM_tbl_lov_category lovc
                        inner join RM_tbl_lov lov on lov.CategoryID=lovc.ID
                        where lovc.Code='PRICE_YIELD' and lovc.IsActive=1 and lov.IsActive=1 ";
            }
        }

        
        public static string DDL_QUERY_SCHEMES
        {
            get
            {
                return @" select ID, (Name+'- ('+ISNULL(Code,0)+')') [Name] from oms_tbl_scheme_master where IsActive=1 ";
            }
        }

        public static string DDL_GET_MENUS
        {
            get
            {
                return @"select 
                                                      mm2.ID ,
                                                      mm2.link
                                                	  ,mm2.title
                                                	  ,mm2.css_class
                                                	  ,mm2.IsActive 
                                                from RM_tbl_user_master um
                                                inner join RM_tbl_role_master rm on um.RoleID = rm.ID
                                                inner join RM_tbl_menu_role_mapping mm on mm.RoleID =rm.ID
                                                inner join RM_tbl_menu_master mm2 on mm2.ID=mm.MenuID
                                                where um.Code=@userid";
            }
        }

        public static string GET_REPORT_ACCESS_BY_EMPLOYEE_CODE
        {
            get
            {
                return @"select 
							0 as ID,
            							'Select' as Name,
            							'false' as is_send_mail_allowed, 
            							'false' as is_download_excel_allowed
                  union
                    select 
                                                  lov.ID,
                                            	  lov.Name, 
                                            	  rac.is_send_mail_allowed,
                                            	  rac.is_download_excel_allowed
                                            from oms_tbl_report_access rac
                                            	inner join RM_tbl_lov lov on lov.ID=rac.report_lov_id
                                            	inner join RM_tbl_lov_category lovc on lovc.ID=lov.CategoryID
                                            where rac.employee_code=@employee_code
                                             and lov.IsActive=1 and lovc.IsActive=1
                                             and rac.is_active=1 ";
            }
        }

        public static string DDL_GET_ROLES
        {
            get
            {
                return @"select ID,Name from RM_tbl_role_master where isactive=1";
            }
        }
     
        public static string ROLE_GRID_DATA
        {
            get
            {
                return @"select * from RM_tbl_role_master";
            }
        }
        public static string SCHEME_GRID_DATA
        {
            get
            {
                return @"select * from oms_tbl_scheme_master";
            }
        }

        public static string MENU_ROLE_GRID_DATA
        {
            get
            {
                return @"select * from RM_tbl_menu_role_mapping where isactive=1";
            }
        }

        public static string USER_GRID_DATA
        {
            get
            {
                return @"select * from RM_tbl_user_master";
            }
        }

        public static string USER_DATA_BY_ID
        {
            get
            {
                return @"select * from RM_tbl_user_master where ID=@ID";
            }
        }

       public static string POLLING_DATA_SELECT_GRID_QUERY
        {
            get
            {
                return @"select
                              ID,Issuer_Name,ISIN,Maturity_Date,Put_Call,Rating,Structure,Reason_for_poll,Traded_Yeild,Quantum_CR,Other_info,Yesterday_Valuation
                              ,POLLING_Level,POLLING_Range,Comments_For_Poll_Provider,Comment_Type_ID,Clasification,modify_by,modify_date
                        from oms_tbl_bonds_trans
                        where CONVERT(date,Created_Date,106)=CONVERT(date,getdate(),106) ";
            }
        }

        public static string REPORT_DATA_SELECT_GRID_QUERY
        {
            get
            {
                return @"select
                              bt.ID,bt.Issuer_Name,bt.ISIN,bt.Maturity_Date,bt.Put_Call,bt.Rating,bt.Structure,bt.Reason_for_poll,bt.Traded_Yeild,bt.Quantum_CR,bt.Other_info,bt.Yesterday_Valuation
                              ,bt.POLLING_Level,bt.POLLING_Range,bt.Comments_For_Poll_Provider,bt.Comment_Type_ID,bt.Clasification,CONVERT(varchar(15),bt.modify_date,106) modify_date
                              ,ISNULL(um.Name,'') modify_by                     
					   from oms_tbl_bonds_trans bt
					       left join RM_user_master um on um.Code=bt.Modify_By
                        where  CONVERT(date,bt.Created_Date,106) between CONVERT(date,@from_date,106) AND CONVERT(date,@to_date,106) ";
            }
        }

        public static string POLLING_DATA_UPDATE_QUERY
        {
            get
            {
                return @"UPDATE oms_tbl_bonds_trans 
                              SET POLLING_Level=@POLLING_Level,POLLING_Range=@POLLING_Range,Comments_For_Pool_Provider=@Comments_For_Pool_Provider,Is_Updation_Done=1
                        WHERE ID=@ID";
            }
        }
        public static string POLLING_DATA_SELECT_QUERY
        {
            get
            {
                return @"SELECT * FROM oms_tbl_bonds_trans  WHERE  Is_Updation_Done=1 and ID=@ID";
            }
        }

        public static string POLLING_UPLOAD_STATUS_SELECT_QUERY
        {
            get
            {
                return @"select * from oms_tbl_file_audit where CONVERT(date,Created_Date,106)=@AsOnDate";
            }
        }
        public static string POLLING_ACTIVITY_REPORT_SELECT_QUERY
        {
            get
            {
                return @"select * from oms_tbl_activity_Report where CONVERT(date,Created_Date,106)=@AsOnDate";
            }
        }
    }
}
