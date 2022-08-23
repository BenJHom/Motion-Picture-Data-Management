using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotionPictureDataManager.Dao;
using MotionPictureDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataManager.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class MotionPictureController : ControllerBase
    {
        private readonly IMotionPictureDAO motionPictureDAO;
        public MotionPictureController(IMotionPictureDAO motionPictureDao)
        {
            this.motionPictureDAO = motionPictureDao;
        }

        [HttpGet]
        public List<MotionPicture> GetMotionPictures()
        {
            return motionPictureDAO.GetAllMotionPictures();

        }

        [HttpPost]
        public MotionPicture AddMotionPicture(MotionPicture motionPicture)
        {
            return motionPictureDAO.AddMotionPicture(motionPicture);
        }

        [HttpPut]
        public Boolean UpdateMotionPicture(MotionPicture motionPicture)
        {
            return motionPictureDAO.UpdateMotionPicture(motionPicture);
        }

        [HttpDelete("{id}")]
        public Boolean DeleteMotionPicture(int id)
        {
            return motionPictureDAO.DeleteMotionPicture(id);
        }

    }

}
