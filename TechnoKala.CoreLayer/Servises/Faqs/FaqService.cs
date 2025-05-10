using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.CoreLayer.Dtos.Faqs;
using TechnoKala.CoreLayer.Mapper;
using TechnoKala.DaytaLayer.Contex;
using TechnoKala.DaytaLayer.Entities;
using X.PagedList;
using X.PagedList.Extensions;

namespace TechnoKala.CoreLayer.Servises.Faqs
{
    public class FaqService : IFaqService
    {
        private readonly AppDbContex _contex;

        public FaqService(AppDbContex contex)
        {
            _contex = contex;
        }
        public OperationResult CreateFaq(CreateFaqDtos command)
        {
            var faqs = FaqMapper.Map(command);


            _contex.faqs.Add(faqs);
            _contex.SaveChanges();
            return OperationResult.Success();
        }
        public OperationResult EditFaq(EditFaqDtos command)
        {
            throw new NotImplementedException();
        }

        public IPagedList<FaqDtos> FaqDtos(int pageNumber, int pageSize)
        {
            var FaqQuery = _contex.faqs
                 .Select(Faqs => new FaqDtos
                 {
                     id = Faqs.id,
                     title = Faqs.title,
                     description = Faqs.description,
            
                 })
                 .OrderBy(b => b.id); // مرتب‌سازی بر اساس Id یا هر فیلد دیگر

            return FaqQuery.ToPagedList(pageNumber, pageSize);
        }

        public FaqDtos GetFaqBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
