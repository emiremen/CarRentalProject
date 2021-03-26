using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<Color>> GetAllColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.GetById(p => p.Id == Id));
        }
        
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Güncellendi");
        }
    }
}
