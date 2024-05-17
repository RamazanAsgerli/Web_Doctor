using Business.CustomException;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null) throw new NotFoundException("", "Doctor is null!!!");
           
            if (!doctor.PhotoFile.ContentType.Contains(@"image/"))
            {
                throw new PhotoFileException("PhotoFile", "PhotoFile format duz deyil");
            }
            string path = "C:\\Users\\ll novbe\\Desktop\\WEB_Doctor\\WEB_Doctor\\wwwroot\\Upload\\Doctor\\" + doctor.PhotoFile.FileName;
            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                doctor.PhotoFile.CopyTo(stream);
            }
            doctor.ImgUrl = doctor.PhotoFile.FileName;
            _doctorRepository.Add(doctor);
            _doctorRepository.Commit();
        }

        public void RemoveDoctor(int id)
        {
            Doctor doctor =_doctorRepository.Get(x => x.Id == id);
            if (doctor == null) throw new NotFoundException("", "Format tapilmadi");
            string path = "C:\\Users\\ll novbe\\Desktop\\WEB_Doctor\\WEB_Doctor\\wwwroot\\Upload\\Doctor\\" + doctor.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            _doctorRepository.Delete(doctor);
            _doctorRepository.Commit();
        }

        public void UpdateDoctor(int id, Doctor doctor)
        {
            Doctor oldDoctor = _doctorRepository.Get(x => x.Id == id);
            if (oldDoctor == null) { throw new NotFoundException("", "Explore is not nul!!!!"); }
            if (!oldDoctor.PhotoFile.ContentType.Contains(@"image/"))
            {
                throw new PhotoFileException("PhotoFile", "PhotoFile format duz deyil");
            }
            if (oldDoctor != null)
            {
                string path = "C:\\Users\\ll novbe\\Desktop\\WEB_Doctor\\WEB_Doctor\\wwwroot\\Upload\\Doctor\\" + doctor.PhotoFile.FileName;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    doctor.PhotoFile.CopyTo(stream);
                }
                string path1 = "C:\\Users\\ll novbe\\Desktop\\WEB_Doctor\\WEB_Doctor\\wwwroot\\Upload\\Doctor\\" + oldDoctor.ImgUrl;
                FileInfo fileInfo = new FileInfo(path1);
                fileInfo.Delete();
                oldDoctor.ImgUrl = doctor.PhotoFile.FileName;


            }

            oldDoctor.Name = doctor.Name;
            oldDoctor.Position = doctor.Position;
           
            _doctorRepository.Commit();

        }

        public Doctor GetDoctor(Func<Doctor, bool>? func = null)
        {
           return _doctorRepository.Get(func);
        }

        public List<Doctor> GetAllDoctors(Func<Doctor, bool>? func = null)
        {
            return _doctorRepository.GetAll(func);
        }

        
    }
}
