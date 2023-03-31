using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        //CRUD
        //type Name();

        List<T> List();

        void Insert(T p);   //T den p (parametre) al
        T Get(Expression<Func<T, bool>> filter);    //Get isimli bir method tanımladık, türü T. Dışarıdan bir şart alacak ama o belli değil şuan
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter); //Parametre Alabilen ŞARTLI LİSTELEME

    }
}
