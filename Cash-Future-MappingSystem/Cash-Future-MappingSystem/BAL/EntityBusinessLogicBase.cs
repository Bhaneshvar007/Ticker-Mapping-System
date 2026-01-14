using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class EntityBusinessLogicBase<TModel> : BusinessLogicBase where TModel : new()
    {
        public EntityBusinessLogicBase()
        { }
        public virtual TModel GetModel(int id)
        {
            TModel item = new TModel();
            return item;
        }
    }
}