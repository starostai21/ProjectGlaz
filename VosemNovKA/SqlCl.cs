using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VosemNovKA
{
    class SqlCl
    {
        public string QueryMat = "SELECT * from materials_short_k_import";
        // "SELECT m.TitleMat As 'Наименование материала', m.TypeMat As 'Тип материала', m.CountInPack As 'Кол-во в упаковке', m.Unit As 'Единица измеренеия', m.CountInStock As 'Кол-во на складе', m.MinCost As 'Миним.цена', m.Cost As 'Цена' FROM import_mat_compl m";
        public string QueryProd = "SELECT * from products_k_import"; 
            //"SELECT p.Title As 'Наименование продукта', p.Article As 'Артикль', p.MinCost As 'Мин.Цена', p.Image As 'Изображение', p.TypeProduct As 'Тип продукта', p.CountMan As 'Кол-во персонала', p.NumberCeh As 'Номер Цеха' FROM import_products p";
        public string QueryProdMat = "SELECT * from productmaterial_k_import";
        //"SELECT pm.Product As 'Продукт', pm.Material As 'Материал', pm.CountMaterial As 'Кол-во материала' FROM import_productmaterial_k pm";
    }
}
