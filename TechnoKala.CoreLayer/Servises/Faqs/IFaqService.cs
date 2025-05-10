using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.CoreLayer.Dtos.Faqs;
using X.PagedList;

namespace TechnoKala.CoreLayer.Servises.Faqs
{
   public interface IFaqService
    {
        OperationResult CreateFaq(CreateFaqDtos command);
        OperationResult EditFaq(EditFaqDtos command);

        IPagedList<FaqDtos> FaqDtos(int pageNumber, int pageSize);
        FaqDtos GetFaqBy(int id);
       
     
    }
}
