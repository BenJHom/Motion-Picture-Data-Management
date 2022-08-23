using MotionPictureDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataManager.Dao
{
    public interface IMotionPictureDAO
    {
        public List<MotionPicture> GetAllMotionPictures();

        public MotionPicture AddMotionPicture(MotionPicture motionPicture);

        public Boolean UpdateMotionPicture(MotionPicture motionPicture);

        public Boolean DeleteMotionPicture(int id);

    }
}
